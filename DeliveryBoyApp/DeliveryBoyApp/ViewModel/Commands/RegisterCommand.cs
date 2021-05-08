using DeliveryBoyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DeliveryBoyApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        RegisterVM viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterCommand(RegisterVM viewmodel)
        {
            viewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            var user = (Users)parameter;
            if (user != null)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                    return false;

                    return true;
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Users user = (Users)parameter;
            viewModel.Register(user);
        }
    }
}
