using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.API.Authentication.Jwt;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

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

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtility jwtUtils,ICompanyService companyService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var authResp = jwtUtils.ValidateJwtToken(token);
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
