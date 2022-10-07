using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface IUserRepository
    {
        public BaseServerResponse<User>  GetUserByUserId(string userId);
        public BaseServerResponse<User> AuthenticateUser(UserAuthenticationRequest model);

    }
}
