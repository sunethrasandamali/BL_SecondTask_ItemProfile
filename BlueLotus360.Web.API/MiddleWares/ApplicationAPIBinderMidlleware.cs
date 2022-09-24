


using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Web.API.Authentication.Jwt;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using BlueLotus360.Web.APIApplication.Services;
using Microsoft.Extensions.Options;
using System.Net;

namespace BlueLotus360.Web.API.MiddleWares
{
    public class ApplicationAPIBinderMidlleware
    {
        private readonly RequestDelegate _next;
        private IAPIService _apiService;



        public ApplicationAPIBinderMidlleware(RequestDelegate next)
        {
            _next = next;

        }


        public async Task Invoke(HttpContext context, IAPIService aPIService)
        {
            _apiService = aPIService;
            var appId = context.Request.Headers["IntegrationID"].FirstOrDefault();
            if (appId == null)
            {
                // context.Items["IntegrationID"] = token;


                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync("Bad Request: IntegrationID Not Defined, " +
                    "IntegrationID Sould be defined in the Header section of the request");

                return;
            }
            var information = _apiService.GetAPIInformationByAppId(appId);
            if (information == null || information.APIIntegrationKey < 11)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync($"Bad Request: Invalid IntegrationID  '{appId}', " +
                    "specified IntegrationID might be deactivated");
                return;
            }

            if ((information.ISIPFilterd && !context.Request.IsRequestMatchIP(information.RestrictToIP)))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsJsonAsync($"IP Validation failed {context.Request.GetRequestIP()}");
                return;
            }


            await _next(context);
        }

        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync("Bad Request: Integration Not Defined, " +
                "Request ID Sould be defined in the Header section of the request");


        }
    }
}
