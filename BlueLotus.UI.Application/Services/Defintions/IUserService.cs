using BlueLotus360.Core.Domain.DTOs.ResponseDTO;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Defintions
{
    public interface  IUserService
    {
        Task<BaseServerResponse<UserAuthenticationResponse>> AuthenticateUserAsync(UserAuthenticationRequest request);
        Task<BaseServerResponse<UserAuthenticationResponse>> GetUserCompanies();
        Task<BaseServerResponse<UserAuthenticationResponse>> UpdateSelectedCompany(CompanyResponse companyResponse);

    }
}
