using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Auth
{
    public class UserAuthenticateModel : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponseModal
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; } = "";
        public string UserImageURL { get; set; } = "";
        public DateTime RefreshTokenExpiryTime { get; set; } = DateTime.Now.AddDays(5);
        public bool IsSuccess { get; set; }

        public string Messages { get; set; }


    }

    public class CompletedUserAuth
    {
        public User AuthenticatedUser { get; set; }
        public Company AuthenticatedCompany { get; set; }

        public CompletedUserAuth()
        {
            this.AuthenticatedCompany = new Company();
            this.AuthenticatedCompany.CompanyKey = 1;
            this.AuthenticatedUser = new User();
            this.AuthenticatedUser.UserKey = 1;
        }
    }
}
