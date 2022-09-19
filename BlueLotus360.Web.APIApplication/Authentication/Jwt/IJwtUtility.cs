using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.APIApplication.Authentication;

namespace BlueLotus360.Web.API.Authentication.Jwt
{
    public interface IJwtUtility
    {
        public string GenerateJwtToken(User user);
        public BLAuthResponse ValidateJwtToken(string token);
        public RefreshToken GenerateRefreshToken(string ipAddress);
        public string GenerateJwtToken(User user,Company company);

    }


}
