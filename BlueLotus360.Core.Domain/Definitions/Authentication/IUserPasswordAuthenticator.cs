using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Authentication
{
    public interface IUserPasswordAuthenticator
    {
        public bool Authenticate(User user,string rawPassword);
    }
}
