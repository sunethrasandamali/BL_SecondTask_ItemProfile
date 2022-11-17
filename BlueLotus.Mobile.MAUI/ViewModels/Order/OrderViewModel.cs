using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.Order
{
    public partial class OrderViewModel:BaseViewModel
    {
        [ObservableProperty]
        private DateTime transactionDate;

        [ObservableProperty]
        private string trancsactionNumber;


    }
}
