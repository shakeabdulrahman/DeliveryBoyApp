using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliveryBoyApp.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        public RegisterCommand RegisterCommand { get; set; }

        private Users users;

        public Users User
        {
            get { return users; }
            set 
            { 
                users = value;
                OnPropertyChanged("User");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            { 
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
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
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                    
                };
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
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                    
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }



        public RegisterVM()
        {
            User = new Users();
            RegisterCommand = new RegisterCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Register(Users users)
        {
            Users.Register(users);
        }
    }
}
