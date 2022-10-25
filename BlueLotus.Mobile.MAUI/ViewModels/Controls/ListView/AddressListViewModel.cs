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
    public partial class AddressListViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string searchQuery;

        [ObservableProperty]
        private ObservableCollection<AddressMaster> addresses;

    
        private IList<AddressMaster> __addressList;

        public BLUIElement   BLUIElement { get; set; }



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
        }

        public void Finalze()
        {
            IEnumerable<AddressMaster> addressMasters;
            if (string.IsNullOrWhiteSpace(searchQuery) || SearchQuery.Length<4)
            {
                addressMasters = new ObservableCollection<AddressMaster>(__addressList);
            }
            else
            {
                addressMasters = __addressList.Where(x=>x.AddressName.Contains(SearchQuery));
            }

           Addresses=addressMasters.ToObservableCollection();

        }


        [RelayCommand]
        private async Task OnTextBoxChanged()
        {
           

          

        }

     


    }

    public partial class AddressViewModel: BaseViewModel
    {
        [ObservableProperty]

        private string addressName;

        [ObservableProperty]

        private string addressId;
    
    }
}
