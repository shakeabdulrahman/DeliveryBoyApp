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
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using(SQLiteConnection con = new SQLiteConnection(App.Databaselocation))
            {
                var postTable = await info.Read();

                var categoriescount = info.PostCategories(postTable);
                categorylistview.ItemsSource = categoriescount;

                posttablecount.Text = postTable.Count.ToString();
            }
        }

    }
}