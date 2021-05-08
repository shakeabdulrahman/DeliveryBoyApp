using DeliveryBoyApp.Model;
using DeliveryBoyApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBoyApp.ViewModel
{
    public class HistoryVM
    {
        public ObservableCollection<info> infos { get; set; }


        public HistoryVM()
        {
            infos = new ObservableCollection<info>();
        }

        public async Task<bool> Updateinfo()
        {
            try
            {
                var posts = await info.Read();
                if (posts != null)
                {
                    infos.Clear();
                    foreach (var post in posts)
                        infos.Add(post);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public async void Deleteinfo(info tobedeleted)
        {
            await info.Delete(tobedeleted);
        }

    }
}
