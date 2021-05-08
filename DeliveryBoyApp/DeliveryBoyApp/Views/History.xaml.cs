using DeliveryBoyApp.Helper;
using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel;
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
    public partial class History : ContentPage
    {
        HistoryVM viewModel;
        public History()
        {
            InitializeComponent();
            viewModel = new HistoryVM();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            /*SQLiteConnection conn = new SQLiteConnection(App.Databaselocation);
            conn.CreateTable<info>();
            var show = conn.Table<info>().ToList();
            Listview.ItemsSource = show;
            conn.Close();*/

            viewModel.Updateinfo();
            await AzureAppServiceHelper.SyncAsync();
        }


        private async void listview_refresh(object sender, EventArgs e)
        {
            await viewModel.Updateinfo();
            await AzureAppServiceHelper.SyncAsync();
            Listview.IsRefreshing = false;
        }

        private async void menu_itemClicked(object sender, EventArgs e)
        {
            var post = (info)((MenuItem)sender).CommandParameter;
            viewModel.Deleteinfo(post);

            await viewModel.Updateinfo();
        }
    }
}