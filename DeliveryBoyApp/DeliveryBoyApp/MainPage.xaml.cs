using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel;
using DeliveryBoyApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliveryBoyApp
{
    public partial class MainPage : ContentPage
    {
        MainVM viewmodel;
        public MainPage()
        {
            InitializeComponent();
            viewmodel = new MainVM();
            BindingContext = viewmodel;
        }

        private void gotoforget(object sender, EventArgs e)
        {

        }

        private void gotocreate(object sender, EventArgs e)
        {
            
        }
    }
}
