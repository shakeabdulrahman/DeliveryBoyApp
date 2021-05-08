using DeliveryBoyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DeliveryBoyApp.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        NewTravelVM viewModel;

        public event EventHandler CanExecuteChanged;

        public PostCommand(NewTravelVM viewmodel)
        {
            viewModel = viewmodel;
        }

        public bool CanExecute(object parameter)
        {
            var inf = (info)parameter;
            if(inf != null)
            {
                if (string.IsNullOrEmpty(inf.Experience))
                    return false;

                if (inf.Venuee != null)
                    return true;

                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var inf = (info)parameter;
            viewModel.PublishPost(inf);
        }
    }
}
