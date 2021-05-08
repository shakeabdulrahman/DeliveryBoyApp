using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel.Commands;
using DeliveryBoyApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DeliveryBoyApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public Users user;

        public Users User
        {
            get { return user; }
            set 
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        public string email;

        public string Email
        {
            get { return email; }
            set
            { 
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
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
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }


        public RegisterNavigationCommand RegisterNavigationCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainVM()
        {
            User = new Users();
            LoginCommand = new LoginCommand(this);
            RegisterNavigationCommand = new RegisterNavigationCommand(this);
        }

        public async void Login()
        {
            bool canlogin = await Users.Login(User.Email, User.Password);
            if (canlogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Homescreen());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "There was an error logging you in", "Okay");
            }
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
