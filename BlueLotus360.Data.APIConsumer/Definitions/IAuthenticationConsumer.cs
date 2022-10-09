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
      BaseServerResponse<UserAuthenticationResponse> AuthenticateUser(UserAuthenticationRequest request);
    }
}
