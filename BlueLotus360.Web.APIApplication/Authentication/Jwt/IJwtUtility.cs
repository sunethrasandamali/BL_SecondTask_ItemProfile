using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.APIApplication.Authentication;

namespace BlueLotus360.Web.API.Authentication.Jwt
{
    public interface IAuthenticationProvider
    {
        public string GenerateUserToken(User user);
        public BLAuthResponse ValidateRequestToken(string token);
        public RefreshToken GenerateRefreshToken(string ipAddress);
        public string GenerateUserToken(User user,Company company);

    }


}
