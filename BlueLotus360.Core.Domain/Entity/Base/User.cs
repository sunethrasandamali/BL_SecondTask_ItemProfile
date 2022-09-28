using BlueLotus360.Core.Domain.Definitions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class User:BaseEntity
    {
        public int UserKey { get; set; } = 1;
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string LoginUserID { get; set; }
        public Address  UserAddress { get; set; }

        public string HashedPassword {get; set; }

        public IUserPasswordAuthenticator PasswordAuthenticator { get; set; }



        public bool AuthenticateUser(string rawPassword)
        {
            if (UserKey < 11)
            {
                return false;
            }
            if(rawPassword == null)
            {
                return false;
            }
            if (PasswordAuthenticator == null)
            {
                throw new InvalidOperationException("No Passwod Authenticators Defined");
            }

            return PasswordAuthenticator.Authenticate(this, rawPassword);
        }
    }
}
