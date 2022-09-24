using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.APIApplication.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlueLotus360.Web.API.Authentication.Jwt
{
    public class BasicJwtHelper : IJwtUtility
    {

        private IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public BasicJwtHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appSettings = new AppSettings();
        }

        public string GenerateUserToken(User user)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("ID", user.UserID.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateUserToken(User user, Company company)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("ID", user.UserID.ToString()),
                    new Claim("CCD", company.CompanyCode.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public BLAuthResponse ValidateRequestToken(string token)
        {
            if (token == null)
            {
                return null;
            }
               

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,                    
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "ID").Value;
                string CCD = null;
                if (jwtToken.Claims.FirstOrDefault(x => x.Type == "CCD") != null)
                {
                    CCD = jwtToken.Claims.FirstOrDefault(x => x.Type == "CCD").Value;
                }
                BLAuthResponse response = new BLAuthResponse();
                response.UserName = userId;
                response.CompanyCode = CCD;
                return response;
            }
            catch (Exception ex)
            {
                // return null if validation fails
                return null;
            }
        }

        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            var refreshToken = new RefreshToken
            {
                Token = getUniqueToken(),
                // token is valid for 7 days
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };

            return refreshToken;

            string getUniqueToken()
            {
                // token is a cryptographically strong random sequence of values
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                // ensure token is unique by checking against db
                var tokenIsUnique = 1 == 1;// !_context.Users.Any(u => u.RefreshTokens.Any(t => t.Token == token));

                if (!tokenIsUnique)
                    return getUniqueToken();

                return token;
            }
        }


    }
}
