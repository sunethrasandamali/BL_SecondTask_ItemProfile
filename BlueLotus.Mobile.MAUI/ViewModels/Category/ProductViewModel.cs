using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Category
{
    public partial class ProductViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string productName;

        [ObservableProperty]
        private string imagePathName;

        [ObservableProperty]
        private long itemKey;

        [ObservableProperty]
        private decimal salesPrice;

        [ObservableProperty]
        private decimal defaultDiscount;

        [ObservableProperty]
        private string description;
        public CategoryViewModel Category { get; set; }

        [ObservableProperty]
        private MainOrderModel mainOrderModel;

        public ProductViewModel()
        {
            mainOrderModel=MauiProgram.Services.GetService<MainOrderModel>();   
        }
    }
}
