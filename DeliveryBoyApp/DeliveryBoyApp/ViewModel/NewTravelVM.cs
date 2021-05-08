using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliveryBoyApp.ViewModel
{
    public class NewTravelVM : INotifyPropertyChanged
    {
        public PostCommand PostCommand { get; set; }

        private info info;
        public info Info
        {
            get { return info; }
            set 
            { 
                info = value;
                OnPropertyChanged("Info");
            }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set 
            { 
                experience = value;
                Info = new info()
                {
                    Experience = this.Experience,
                    Venuee = this.Venuee
                };
                OnPropertyChanged("Experience");

            }
        }

        private Venue venue;

        public Venue Venuee
        {
            get { return venue; }
            set
            { 
                venue = value;
                Info = new info()
                {
                    Experience = this.Experience,
                    Venuee = this.Venuee
                };
                OnPropertyChanged("Venuee");
            }
        }

        public NewTravelVM()
        {
            Info = new info(); 
            PostCommand = new PostCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void PublishPost(info inf)
        {
            try
            {
                info.Insert(inf);
                await App.Current.MainPage.DisplayAlert("Success", "Successfully Added", "Okay");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (NullReferenceException nre)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Insertion failed", "Okay");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Failed", "Insertion failed", "Okay");
            }
        }
    }
}
