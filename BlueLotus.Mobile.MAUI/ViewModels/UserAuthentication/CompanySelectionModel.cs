using BlueLotus.Mobile.MAUI.Pages;
using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.ResponseDTO;
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
    public partial class CompanySelectionModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Company> companies;

        [ObservableProperty]
        private Company selectedCompany;

        private readonly IAppUserService _userService;
        private readonly BLUIAppContext _appContext;

        public CompanySelectionModel(IAppUserService service, BLUIAppContext appContext)
        {
            _userService = service;
            _appContext = appContext;
            companies = new ObservableCollection<Company>();



        }


        [RelayCommand]
        public async Task OnContuneClick()
        {
            if(selectedCompany!=null && selectedCompany.CompanyKey > 11)
            {
                string cnm = selectedCompany.CompanyName;
                CompanyResponse companyResponse = new CompanyResponse();
                companyResponse.CompanyName=selectedCompany.CompanyName;
                companyResponse.CompanyCode = string.Empty;
                companyResponse.CompanyKey = selectedCompany.CompanyKey;
                var response = await _userService.UpdateSelectedCompany(companyResponse);
                if(response.Value !=null && response.Value.IsSuccess)
                {
                    Application.Current.MainPage = MauiProgram.Services.GetService<AppShell>();

                }
            }
        }

        public async void ReadCompanies()
        {
            var comp = await _userService.GetUserCompanies();
            foreach (var item in comp.Value)
            {
                companies.Add(item);
            }
            if (companies.Count > 0)
            {
                SelectedCompany=Companies.First();
            }

        }
    }
}
