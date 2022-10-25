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

        [ObservableProperty]
        private decimal numberValue;
        [ObservableProperty]
        private bool isMultiplyMode;

        [RelayCommand]
        private async Task OnSaveButtonClick()
        {
            if (IsMultiplyMode)
            {
                NumberValue = numberValue * 2;

            }
            else
            {
                NumberValue = numberValue + 2;

            }

            await Task.CompletedTask;

        }

    }
}
