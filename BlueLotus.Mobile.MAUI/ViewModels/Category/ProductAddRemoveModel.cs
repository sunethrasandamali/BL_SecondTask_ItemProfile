using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Category
{
    public partial class ProductAddRemoveModel:BaseViewModel
    {
        public long ItemKey { get; set; }

        public ProductViewModel LinkedProductViewModel { get; set; }

        [ObservableProperty]
        private decimal transactionQuantity;


        [RelayCommand]
        private void OnAddButton()
        {
            var mainorderModel =MauiProgram.Services.GetService<MainOrderModel>();
            if(mainorderModel != null)
            {
                mainorderModel.TryAddProduct(LinkedProductViewModel, 1);
            }
        }
    }
}
