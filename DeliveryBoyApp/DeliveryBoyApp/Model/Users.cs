using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBoyApp.Model
{
    public class Users : INotifyPropertyChanged
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

        private string email;

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            { 
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string confirmpassword;

        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Register(Users user)
        {
            await App.MobileService.GetTable<Users>().InsertAsync(user);
        }

        public static async Task<bool> Login(string email,string password)
        {
            bool isemailempty = string.IsNullOrEmpty(email);
            bool ispasswordempty = string.IsNullOrEmpty(password);

            if (isemailempty || ispasswordempty)
            {
                return false;
            }
            else
            {
                var use = (await App.MobileService.GetTable<Users>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (use != null)
                {
                    App.user = use;
                    if (use.Password == password)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
