using BlueLotus360.Core.Domain.DTOs.ResponseDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.Definitions
{
    public interface IAuthenticationConsumer
    {
        Task<BaseServerResponse<UserAuthenticationResponse>> AuthenticateUserAsync(UserAuthenticationRequest request);
        Task<BaseServerResponse<IList<Company>>> GetUserCompanies(BaseAPIRequest request);
        Task<BaseServerResponse<UserAuthenticationResponse>> UpdateUserCompany(CompanyResponse request);

    }
}
