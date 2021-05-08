using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel;
using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryBoyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelEntry : ContentPage
    {
        NewTravelVM viewModel;
        public NewTravelEntry()
        {
            InitializeComponent();
            viewModel = new NewTravelVM();
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var pos = await locator.GetPositionAsync();

            var venue_here = await Venue.GetVenues(pos.Latitude, pos.Longitude);

            listviewplaces.ItemsSource = venue_here;
        }
    }
}