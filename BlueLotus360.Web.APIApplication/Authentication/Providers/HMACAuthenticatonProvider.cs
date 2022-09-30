using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.API.Authentication.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Authentication.Providers
{
    public class HMACAuthenticatonProvider : IAuthenticationProvider
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HMACParameter _parameter;
        
        public HMACAuthenticatonProvider(IUnitOfWork unitOfWork,HMACParameter parameter)
        {
            _unitOfWork = unitOfWork;
            _parameter = parameter;
        }
        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            throw new InvalidOperationException();
        }

        public string GenerateUserToken(User user)
        {
            throw new InvalidOperationException();
        }

        public string GenerateUserToken(User user, Company company)
        {
            throw new InvalidOperationException();
        }

        public BLAuthResponse ValidateRequestToken(string token)
        {
           
            return null;
        }
    }
}
