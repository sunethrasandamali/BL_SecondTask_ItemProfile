using BlueLotus.Mobile.MAUI.ViewModels.Category;
using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Order
{
    public partial class OrderViewModel : ObservableObject
    {

        [ObservableProperty]
        private string orderReference;
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


        [ObservableProperty]
        private decimal totalProducts;

        
        public ObservableCollection<OrderItemViewModel> Items { get; set; }


        public OrderViewModel()
        {
            Items = new ObservableCollection<OrderItemViewModel>();
            OrderReference = Guid.NewGuid().ToString().Substring(0, 6);
            TransactionDate = DateTime.Now;
        }


        public void UpdateVars()
        {
            TotalProducts = Items.Sum(x => x.TransactionQuantity);
        }

        public void UpdateCustomer(AddressResponse addressResponse)
        {
            selectedCustomer = addressResponse;

        }

    }



    public partial class OrderItemViewModel : ObservableObject
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
        private decimal discountAmount;

        [ObservableProperty]
        private ProductViewModel transactionItem;

        [ObservableProperty]
        private decimal lineTotal;


        public void CalculateOtherValues()
        {
            DiscountAmount = Math.Max(0, (transactionItem.SalesPrice - transactionRate));
            DiscountPercentage = (DiscountAmount / transactionItem.SalesPrice) * 100;
            LineTotal = TransactionQuantity * TransactionRate;


        }



        [RelayCommand]
        private void OnAddButton()
        {
            var mainorderModel = MauiProgram.Services.GetService<MainOrderModel>();
            if (mainorderModel != null)
            {
                mainorderModel.TryAddProduct(this.TransactionItem, 0.0M, 1);
            }
            CalculateOtherValues();


        }


        [RelayCommand]
        private void OnDecreaseButton()
        {
            var mainorderModel = MauiProgram.Services.GetService<MainOrderModel>();
            if (mainorderModel != null)
            {
                mainorderModel.TryDecreasProduct(this.TransactionItem, 0.0M, 1);
            }
            CalculateOtherValues()
        }

    }
}
