using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.API.Authentication.Jwt;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;

namespace BlueLotus360.Web.API.Authentication
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, ICompanyService companyService, IUnitOfWork unitOfWork)
        {

            IAuthenticationProvider authProvider=null;
            var apiInformation = context.Items["APIInformation"] as APIInformation;
            if (apiInformation == null || apiInformation.APIIntegrationKey < 11)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync("Bad Request: , " +
                    "cannot fetch Information Contact Support with this message");

                return;
            }
            if (apiInformation.AuthenticationType == null)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync("Bad Request: , " +
                    "cannot fetch Information Scheme Contact Support with this message");

                return;
            }
            if (apiInformation.AuthenticationType.Equals("JwtProvider"))
            {
                authProvider = new BasicJwtHelper(unitOfWork);
            }


            if (authProvider == null)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync("Bad Request: , " +
                    "Invalid Authentication Scheme");

                return;
            }


            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
             
            var authResp = authProvider.ValidateRequestToken(token);
            if (authResp != null)
            {
                if (authResp.UserName != null)
                {
                    context.Items["User"] = userService.GetUserByUserName(authResp.UserName);

                }
                if (authResp.CompanyCode != null)
                {
                    context.Items["Company"] = companyService.GetCompanyByCode(authResp.CompanyCode);
                }
            }


            await _next(context);
        }
    }
}
