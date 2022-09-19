using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface IUserService
    {
        UserAuthenticationResponse AuthenticateUser(UserAuthenticationRequest model, string ipAddress);
        UserAuthenticationResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetUserByUserName(string UserId);
        IList<Company> GetUserCompanies(User user);
        UserAuthenticationResponse UpdateCompanySelection(User user, Company company, string ipAddress);

    }

}
