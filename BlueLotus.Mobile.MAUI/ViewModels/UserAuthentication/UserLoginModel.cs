using BlueLotus.Mobile.MAUI.Validators.UserAuthentication;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication
{
    public partial class UserLoginModel :BaseViewModel
    {
        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;


        [RelayCommand]      
        private  void OnLoginClick()
        {
            UserAuthenticationValidator validator = new UserAuthenticationValidator();
            ValidationResult result = validator.Validate(this);
            if (result.IsValid)
            {

            }
            else
            {
             
            }
           
        }

    }
}
