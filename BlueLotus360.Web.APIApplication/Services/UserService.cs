using BlueLotus360.Core.Domain.Authentication;
using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Auth;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.API.Authentication.Providers;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitofWork { get; set; }
        IAuthenticationProvider _jwtUtils;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
            _jwtUtils = new JwtAuthenticatonProvider(_unitofWork);
        }
        public UserAuthenticationResponse AuthenticateUser(UserAuthenticationRequest model, string ipAddress)
        {
            var user = _unitofWork.UserRepository.GetUserByUserId(model.UserName).Value;
            user.PasswordAuthenticator = new ERPUserPasswordAuthenticator();
            // validate
            if (user != null && user.AuthenticateUser(model.Password))
            {
                var jwtToken = _jwtUtils.GenerateUserToken(user);
                var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
                return new UserAuthenticationResponse(user, jwtToken, refreshToken.Token,true);
                removeOldRefreshTokens(user);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public UserAuthenticationResponse RefreshToken(string token, string ipAddress)
        {

            return null;
            //var user = getUserByRefreshToken(token);
            //var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            //if (refreshToken.IsRevoked)
            //{
            //    // revoke all descendant tokens in case this token has been compromised
            //    revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
            //    _context.Update(user);
            //    _context.SaveChanges();
            //}

            //if (!refreshToken.IsActive)
            //    throw new AppException("Invalid token");

            //// replace old refresh token with a new one (rotate token)
            //var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            //user.RefreshTokens.Add(newRefreshToken);

            //// remove old refresh tokens from user
            //removeOldRefreshTokens(user);

            //// save changes to db
            //_context.Update(user);
            //_context.SaveChanges();

            //// generate new jwt
            //var jwtToken = _jwtUtils.GenerateJwtToken(user);

            //return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            //var user = getUserByRefreshToken(token);
            //var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            //if (!refreshToken.IsActive)
            //    throw new AppException("Invalid token");

            //// revoke token and save
            //revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            //_context.Update(user);
            //_context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return null;
        }

        public User GetById(int id)
        {
            //var user = _context.Users.Find(id);
            //if (user == null) throw new KeyNotFoundException("User not found");
            //return user;
            return null;
        }

        // helper methods

        private User getUserByRefreshToken(string token)
        {
            //var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            //if (user == null)
            //    throw new AppException("Invalid token");

            //return user;
            return null;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void removeOldRefreshTokens(User user)
        {
            //// remove old inactive refresh tokens from user based on TTL in app settings
            //user.RefreshTokens.RemoveAll(x =>
            //    !x.IsActive &&
            //    x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ipAddress, string reason)
        {
            //// recursively traverse the refresh token chain and ensure all descendants are revoked
            //if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            //{
            //    var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
            //    if (childToken.IsActive)
            //        revokeRefreshToken(childToken, ipAddress, reason);
            //    else
            //        revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            //}
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

        public User GetUserByUserName(string UserId)
        {
            var user = _unitofWork.UserRepository.GetUserByUserId(UserId).Value;
            return user;

        }

        public IList<Company> GetUserCompanies(User user)
        {
           var companies = _unitofWork.CompanyRepository.GetUserAssociatedCompanies(user);           
           return companies.Value;
        }

        public UserAuthenticationResponse UpdateCompanySelection(User user,Company company, string ipAddress)
        {

            // validate
            var jwtToken = "";
            if (user != null && company!=null)
            {
                if (company != null && company.CompanyKey > 11)
                {
                    jwtToken = _jwtUtils.GenerateCompanyAddedToken(user, company);
                }
                else
                {
                    jwtToken = _jwtUtils.GenerateUserToken(user, company);
                }
                var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
                return new UserAuthenticationResponse(user, jwtToken, refreshToken.Token,true);
                removeOldRefreshTokens(user);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
