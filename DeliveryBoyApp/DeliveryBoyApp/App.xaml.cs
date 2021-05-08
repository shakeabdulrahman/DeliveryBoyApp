using DeliveryBoyApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryBoyApp
{
    public partial class App : Application
    {
        public static string Databaselocation = string.Empty;

        public static Users user = new Users(); 

        public static MobileServiceClient MobileService = new MobileServiceClient("https://deliveryboyappxam.azurewebsites.net");

        public static IMobileServiceSyncTable<info> postsTable;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string database)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Databaselocation = database;

            var store = new MobileServiceSQLiteStore(database);
            store.DefineTable<info>();

            MobileService.SyncContext.InitializeAsync(store);

            postsTable = MobileService.GetSyncTable<info>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
