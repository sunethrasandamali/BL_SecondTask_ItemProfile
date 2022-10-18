using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.HomePage
{
    public partial class AppShellModel:BaseViewModel
    {
        [ObservableProperty]
        private string shellUser="";

        [ObservableProperty]
        private string shellCompany;


    }
}
