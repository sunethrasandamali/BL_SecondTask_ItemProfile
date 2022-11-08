using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        [ObservableProperty]
        private string shellAvatarText;

        [ObservableProperty]
        private string shellTitle;

        [RelayCommand]
        private async Task OnLogOutClick()
        {
            await _userService.LogOutAsync();          
            await Shell.Current.GoToAsync($"LoginPage");

        }


        private readonly IAppUserService _userService;
        private readonly BLUIAppContext _appContext;

        public AppShellModel(IAppUserService service, BLUIAppContext appContext)
        {
            _userService = service;
            _appContext = appContext;
        }
    }
}
