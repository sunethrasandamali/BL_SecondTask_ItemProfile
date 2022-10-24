using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.ViewModels
{
    public partial class CustomerPageModel : BaseViewModel
    {
        [ObservableProperty]
        private DateTime customerDate;

        [RelayCommand]
        private async Task OnSaveButtonClick()
        {
            

            await Task.CompletedTask;

        }

    }
}
