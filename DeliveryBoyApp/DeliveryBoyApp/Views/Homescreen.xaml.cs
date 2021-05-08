using DeliveryBoyApp.ViewModel;
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
    public partial class Homescreen : TabbedPage
    {
        HomeVM viewmodel;
        public Homescreen()
        {
            InitializeComponent();
            viewmodel = new HomeVM();
            BindingContext = viewmodel;
        }
    }
}