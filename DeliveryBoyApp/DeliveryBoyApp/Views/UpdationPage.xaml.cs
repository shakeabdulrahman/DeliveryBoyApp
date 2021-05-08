using DeliveryBoyApp.Model;
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
    public partial class UpdationPage : ContentPage
    {
        info SelectedItem;
        public UpdationPage(info selecteditem1)
        {
            InitializeComponent();
            this.SelectedItem = selecteditem1;
            updationentry.Text = selecteditem1.Experience;
            venuelabel.Text = selecteditem1.VenueName;
            categorylabel.Text = selecteditem1.CategoryName;
            addresslabel.Text = selecteditem1.Address;
            coordinatelabel.Text = $"{selecteditem1.Latitude},{selecteditem1.Longitude}";
            distancelabel.Text = $"{selecteditem1.Distance} m";
        }

        private async void Updatebutton_Clicked(object sender, EventArgs e)
        {
            SelectedItem.Experience = updationentry.Text;
            /* SQLiteConnection conn = new SQLiteConnection(App.Databaselocation);
             conn.CreateTable<info>();
             int row = conn.Update(SelectedItem);
             if(row > 0)
             { DisplayAlert("Success", "Successfully updated", "okay"); }
             else
             { DisplayAlert("Failure", "Updation failed", "Okay"); }
             conn.Close(); */
            info.Update(SelectedItem);
            await DisplayAlert("Success", "Successfully Updated", "Okay");

        }

        private async void Deletebutton_Clicked(object sender, EventArgs e)
        {

            /*SQLiteConnection conn = new SQLiteConnection(App.Databaselocation);
            conn.CreateTable<info>();
            int row = conn.Delete(SelectedItem);
            if (row > 0)
            { DisplayAlert("Success", "Entry deleted successfully", "okay"); }
            else
            { DisplayAlert("Failure", "Deletion failed", "Okay"); }
            conn.Close();*/

            info.Delete(SelectedItem);
            await DisplayAlert("Success", "Successfully Deleted", "Okay");
        }
    }
}