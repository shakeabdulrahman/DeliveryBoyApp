using DeliveryBoyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DeliveryBoyApp.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public MainVM Viewmodel { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoginCommand(MainVM viewmodel)
        {
            Viewmodel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            var usr = (Users)parameter;
            if (usr == null)
                return false;

            if (string.IsNullOrEmpty(usr.Email) || string.IsNullOrEmpty(usr.Password))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            Viewmodel.Login();
        }
    }
}
