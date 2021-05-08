using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DeliveryBoyApp.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {
        public HomeVM homeviewmodel { get; set; }

        public event EventHandler CanExecuteChanged;

        public NavigationCommand(HomeVM homevm)
        {
            homeviewmodel = homevm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            homeviewmodel.Navigate();
        }
    }
}
