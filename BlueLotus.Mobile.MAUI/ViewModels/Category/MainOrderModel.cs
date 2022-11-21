using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.Mobile.MAUI.ViewModels.Order;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Category
{
    public partial class MainOrderModel:BaseViewModel
    {
       

        [ObservableProperty]    
        private AddressResponse selectedCustomer;

        [ObservableProperty]
        private OrderViewModel currentOrder;

        [ObservableProperty]
        private decimal totalQuantity;

        [ObservableProperty]
        private bool isCustomerSelected;
        public IList<AddressResponse> CustomerList { get; set; }

        public MainOrderModel()
        {
            currentOrder = new OrderViewModel();
            var service = MauiProgram.Services.GetService<IAppAddressService>();
            LoadDataFormServer(service);
        }

        private async void LoadDataFormServer(IAppAddressService service)
        {
            CustomerList = (await service.GetAddressMAUI(new BlueLotus360.Core.Domain.DTOs.RequestDTO.ComboRequestDTO())).Value;
        }

        public void TryAddProduct(ProductViewModel view,decimal TransactionRate,decimal TransactionQuantity = 1)
        {
            if(currentOrder== null)
            {
                currentOrder = new OrderViewModel();
                
            }

            var lineItem = currentOrder.Items.Where(x=>x.TransactionItem.ItemKey==view.ItemKey).FirstOrDefault();

            if(lineItem!=null)
            {
                lineItem.TransactionQuantity += TransactionQuantity;
            }
            else
            {
                OrderItemViewModel newLineItem = new OrderItemViewModel();
                newLineItem.TransactionQuantity = TransactionQuantity;
                newLineItem.TransactionItem= view;
                newLineItem.TransactionRate = TransactionRate;
                currentOrder.Items.Add(newLineItem);

            }
            currentOrder.UpdateVars();
            TotalQuantity= currentOrder.TotalProducts;
        }

        public void TryDecreasProduct(ProductViewModel view, decimal TransactionRate, decimal TransactionQuantity = 1)
        {
            var lineItem = currentOrder.Items.Where(x => x.TransactionItem.ItemKey == view.ItemKey).FirstOrDefault();

            if (lineItem != null)
            {
                if (lineItem.TransactionQuantity == 1)
                {
                   CurrentOrder.Items.Remove(lineItem);
                  
                }
                else
                {
                    lineItem.TransactionQuantity-= TransactionQuantity;
                }
            }
           
            currentOrder.UpdateVars();
            TotalQuantity = currentOrder.TotalProducts;
        }

        public decimal RetriveCurrentProductQty(ProductViewModel view)
        {
            var lineItem = currentOrder.Items.Where(x => x.TransactionItem.ItemKey == view.ItemKey).FirstOrDefault();

            if (lineItem != null)
            {
                return lineItem.TransactionQuantity;
            }
            return 0;
        }



        [RelayCommand]
        public async void OnCartIcon()
        {
            if(currentOrder!=null && currentOrder.TotalProducts > 0)
            {
              await  Shell.Current.GoToAsync(nameof(OrderSummaryPage));
            }
        }


        [RelayCommand]

        public async Task OnCustomerSelction(AddressResponse address)
        {
            SelectedCustomer = address;
            IsCustomerSelected = SelectedCustomer!=null;
            await Task.CompletedTask;
        }

        [RelayCommand]
        public async Task RemoveCustomerSelection()
        {
            await OnCustomerSelction(null);
        }

    }
}
