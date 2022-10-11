using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication
{
    public partial class CompanySelectionModel:BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Company> companies;
        public CompanySelectionModel()
        {
            companies=new ObservableCollection<Company>();
        }

       
    }
}
