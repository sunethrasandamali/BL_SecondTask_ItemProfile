using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Controls.ListView
{
    public partial class AddressListViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string searchQuery;

        [ObservableProperty]
        private string timeToSearch;

        [ObservableProperty]
        private string timeToDisplay;

        [ObservableProperty]
        private ObservableCollection<AddressMaster> addresses;


        private IList<AddressMaster> __addressList;

        public BLUIElement BLUIElement { get; set; }

        private CancellationTokenSource _throttleCts = new CancellationTokenSource();

        public AddressListViewModel()
        {
            addresses = new ObservableCollection<AddressMaster>();

        }


        public void Add(AddressMaster master)
        {
            if (__addressList == null)
            {
                __addressList = new List<AddressMaster>();
            }
            __addressList.Add(master);
            addresses.Add(master);
        }

        public async Task Finalze()
        {
             await DebouncedSearch().ConfigureAwait(false);

        }

        private async Task Search()
        {
            DateTime rootTime1 = DateTime.Now;
            IEnumerable<AddressMaster> addressMasters;
            if (string.IsNullOrWhiteSpace(searchQuery) || SearchQuery.Length < 4)
            {
                addressMasters = new ObservableCollection<AddressMaster>(__addressList);
            }
            else
            {
                DateTime t1 = DateTime.Now;

                addressMasters = __addressList.Where(x => x.AddressName.Contains(SearchQuery));
                DateTime t2 = DateTime.Now;

                TimeSpan ts1 = t2 - t1;
                TimeToSearch = ts1.TotalMilliseconds.ToString();
            }

            addresses = addressMasters.ToObservableCollection();
            DateTime rootTime2 = DateTime.Now;
            TimeToDisplay = (rootTime2 - rootTime1).TotalMilliseconds.ToString();
            await Task.CompletedTask;

        }


        private async Task DebouncedSearch()
        {
            try
            {
                Interlocked.Exchange(ref _throttleCts, new CancellationTokenSource()).Cancel();

                //NOTE THE 500 HERE - WHICH IS THE TIME TO WAIT
                await Task.Delay(TimeSpan.FromMilliseconds(500), _throttleCts.Token)

                    //NOTICE THE "ACTUAL" SEARCH METHOD HERE
                    .ContinueWith(async task => await Search(),
                        CancellationToken.None,
                        TaskContinuationOptions.OnlyOnRanToCompletion,
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch
            {
                //Ignore any Threading errors
            }
        }
    



        private async Task OnTextBoxChanged()
        {




        }




    }

    public partial class AddressViewModel : BaseViewModel
    {
        [ObservableProperty]

        private string addressName;

        [ObservableProperty]

        private string addressId;

    }
}
