using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.ResponseDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Implementation
{
    public class AppUserService :BaseService, IAppUserService
    {
        public AppUserService(BLUIAppContext _context):base(_context)
        {

        }

        public async Task<BaseServerResponse<UserAuthenticationResponse>> AuthenticateUserAsync(UserAuthenticationRequest request)
        {
            BaseServerResponse<UserAuthenticationResponse> response = 
                                    await _restAPIConsumer.AuthenticationConsumer.AuthenticateUserAsync(request);
            if(response.Value != null && response.Value.IsSuccess)
            {
                _appContext.ApplicationUser = new BlueLotus360.Core.Domain.Entity.Base.User();
                _appContext.ApplicationUser.UserKey = response.Value.Id;
                _appContext.ApplicationUser.UserID = response.Value.Username;
                _appContext.IsUserLoggedIn = true;
                _appContext.ApplicationToken = response.Value.Token;
                _restAPIConsumer.AddUserToken(_appContext.ApplicationToken);
            }
            return response;
        }

        public async Task<BaseServerResponse<IList<Company>>> GetUserCompanies()
        {
            BaseAPIRequest req = new();
            BaseServerResponse<IList<Company>> serverResponse = await _restAPIConsumer.AuthenticationConsumer.GetUserCompanies(req);
            return serverResponse;

        }

        public async Task<BaseServerResponse<UserAuthenticationResponse>> UpdateSelectedCompany(CompanyResponse companyResponse)
        {
            BaseServerResponse<UserAuthenticationResponse> response = await _restAPIConsumer.AuthenticationConsumer.UpdateUserCompany(companyResponse);
            if(response.Value!=null && response.Value.IsSuccess)
            {
                _appContext.IsUserLoggedIn = true;
                _appContext.IsCompanyPicked = true;
                _appContext.ApllicationCompany = new Company() { CompanyName = companyResponse.CompanyName, CompanyKey = companyResponse.CompanyKey };
                _appContext.ApplicationToken = response.Value.Token;
                _restAPIConsumer.AddUserToken(_appContext.ApplicationToken);
            }
            return response;
        }

        public async Task LogOutAsync()
        {
            _appContext.ApplicationUser = null;
            _appContext.ApllicationCompany = null;          
            _appContext.IsCompanyPicked=false;
            _appContext.IsUserLoggedIn = false;
        }
    }


    public abstract class BaseService
    {
        protected readonly RestsharpAPIConsumer _restAPIConsumer;
        protected readonly BLUIAppContext _appContext;
        public BaseService(BLUIAppContext _context)
        {
            _restAPIConsumer = RestsharpAPIConsumer.GetDefaultAPIConsumner();
            _appContext = _context;
        }
    }
}
