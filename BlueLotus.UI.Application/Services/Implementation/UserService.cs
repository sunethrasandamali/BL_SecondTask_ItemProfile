using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.ResponseDTO;
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
    public class UserService :BaseService, IUserService
    {
       

        public async Task<BaseServerResponse<UserAuthenticationResponse>> AuthenticateUserAsync(UserAuthenticationRequest request)
        {
            BaseServerResponse<UserAuthenticationResponse> response = 
                                    await _restAPIConsumer.AuthenticationConsumer.AuthenticateUserAsync(request);
            return response;
        }

        public Task<BaseServerResponse<UserAuthenticationResponse>> GetUserCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<BaseServerResponse<UserAuthenticationResponse>> UpdateSelectedCompany(CompanyResponse companyResponse)
        {
            throw new NotImplementedException();
        }
    }


    public class BaseService
    {
        protected readonly RestsharpAPIConsumer _restAPIConsumer;
        public BaseService()
        {
            _restAPIConsumer = RestsharpAPIConsumer.GetDefaultAPIConsumner();
        }
    }
}
