using BlueLotus.Mobile.MAUI.ViewModels.Order;
using CommunityToolkit.Mvvm.ComponentModel;
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
        private string customerName;

        [ObservableProperty]
        private OrderViewModel currentOrder;

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
           
        }
    }
}
