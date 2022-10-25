using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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


        public AddressListViewModel()
        {
            addresses = new ObservableCollection<AddressMaster>();
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
