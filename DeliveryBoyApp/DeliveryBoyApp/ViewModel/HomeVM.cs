using DeliveryBoyApp.ViewModel.Commands;
using DeliveryBoyApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryBoyApp.ViewModel
{
    public class HomeVM
    {
        public NavigationCommand NavCommand { get; set; }

        public HomeVM()
        {
            NavCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
           await App.Current.MainPage.Navigation.PushAsync(new NewTravelEntry());
        }
    }
}
