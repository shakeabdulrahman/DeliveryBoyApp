using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DeliveryBoyApp.ViewModel.Commands
{
    public class RegisterNavigationCommand : ICommand
    {
        MainVM viewModel;
        public event EventHandler CanExecuteChanged;

        public RegisterNavigationCommand(MainVM viewmodel)
        {
            viewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }
}
