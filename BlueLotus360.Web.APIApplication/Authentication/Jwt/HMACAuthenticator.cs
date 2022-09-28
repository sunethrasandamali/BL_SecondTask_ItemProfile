using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.API.Authentication.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Authentication.Jwt
{
    public class HMACAuthenticator : IAuthenticationProvider
    {
        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            throw new NotImplementedException();
        }

        public string GenerateUserToken(User user)
        {
            throw new NotImplementedException();
        }

        public string GenerateUserToken(User user, Company company)
        {
            throw new NotImplementedException();
        }

        public BLAuthResponse ValidateRequestToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
