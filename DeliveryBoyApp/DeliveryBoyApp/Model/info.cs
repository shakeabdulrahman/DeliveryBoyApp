using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryBoyApp.Model
{
    public class info : INotifyPropertyChanged
    {
        private string id;

        public string ID
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged("ID");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set 
            { 
                experience = value; 
                OnPropertyChanged("Experience"); 
            }
        }

        private string venuename;

        public string VenueName
        {
            get { return venuename; }
            set 
            { venuename = value; 
                OnPropertyChanged("VenueName");
            }
        }

        private string categoryid;

        public string CategoryId
        {
            get { return categoryid; }
            set 
            { 
                categoryid = value; 
                OnPropertyChanged("CategoryId"); 
            }
        }

        private string categoryname;

        public string CategoryName
        {
            get { return categoryname; }
            set 
            {
                categoryname = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            { 
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set
            { 
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set
            { 
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set
            { 
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string userid;

        public string UserId
        {
            get { return userid; }
            set 
            { 
                userid = value;
                OnPropertyChanged("UserId");
            }
        }

        private Venue venue;

        [JsonIgnore]
        public Venue Venuee
        {
            get { return venue; }
            set 
            { 
                venue = value;
                if (venue.categories != null)
                {
                    var firstcategory = venue.categories.FirstOrDefault();

                    if (firstcategory != null)
                    {
                        CategoryId = firstcategory.id;
                        CategoryName = firstcategory.name;
                    }
                }
                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                VenueName = venue.name;
                UserId = App.user.ID;
                OnPropertyChanged("Venuee");
            }
        }

        private DateTimeOffset createdat;

        public DateTimeOffset createdAt
        {
            get { return createdat; }
            set
            { 
                createdat = value;
                OnPropertyChanged("createdAt");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public async static void Insert(info inf)
        {
            await App.postsTable.InsertAsync(inf);
            await App.MobileService.SyncContext.PushAsync();
        }

        public async static Task<bool> Delete(info inf)
        {
            try
            {
                await App.postsTable.DeleteAsync(inf);
                await App.MobileService.SyncContext.PushAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static async Task<List<info>> Read()
        {
            var posts = await App.postsTable.Where(p => p.UserId == App.user.ID).ToListAsync();
            return posts;
        }

        public static Dictionary<string,int> PostCategories(List<info> inf)
        {
            var categories = (from p in inf
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriescount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = (from post in inf
                             where post.CategoryName == category
                             select post).ToList().Count;

                categoriescount.Add(category, count);
            }
            return categoriescount;
        }

        public static async void Update(info selecteditem)
        {
            await App.MobileService.GetTable<info>().UpdateAsync(selecteditem);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
