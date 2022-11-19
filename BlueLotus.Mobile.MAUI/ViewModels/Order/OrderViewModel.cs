using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Order
{
    public partial class OrderViewModel: ObservableObject
    {
        [ObservableProperty]
        private DateTime transactionDate;

        [ObservableProperty]
        private string trancsactionNumber;

        [ObservableProperty]
        private bool isCustomerSelected;

        [ObservableProperty]
        private AddressResponse selectedCustomer;

        [ObservableProperty]
        private CodeBaseResponse location;

       public IList<OrderItemViewModel> Items { get; set; }


        public OrderViewModel()
        {
            Items= new List<OrderItemViewModel>();
        }


    }


    public  partial class OrderItemViewModel: ObservableObject
    {
        [ObservableProperty]
        private decimal transactionQuantity;

        [ObservableProperty]
        private decimal transactionRate;

        [ObservableProperty]
        private decimal rate;

        [ObservableProperty]
        private decimal discountPercentage;

        [ObservableProperty]
        private ProductViewModel transactionItem;
    }
}
