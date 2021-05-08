#define OFFLINE_SYNC_ENABLED

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBoyApp.Helper
{
    public class AzureAppServiceHelper
    {
        public static async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> Syncerror = null;

            try
            {
                await App.MobileService.SyncContext.PushAsync();

                await App.postsTable.PullAsync("userPost", "");
            }
            catch(MobileServicePushFailedException mspfe)
            {
                if(mspfe.PushResult != null)
                {
                    Syncerror = mspfe.PushResult.Errors;
                }
            }
            catch(Exception)
            {

            }
            if(Syncerror != null)
            {
                foreach (var error in Syncerror)
                {
                    if(error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }
                }
            }
        }
    }
}
