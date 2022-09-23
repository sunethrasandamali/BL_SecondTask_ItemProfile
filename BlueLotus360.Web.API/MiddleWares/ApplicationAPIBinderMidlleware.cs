using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Web.API.Authentication.Jwt;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.Extensions.Options;
using System.Net;

namespace BlueLotus360.Web.API.MiddleWares
{
    public class ApplicationAPIBinderMidlleware
    {
        private readonly RequestDelegate _next;
        private readonly IAPIService _apiService;
       

        public ApplicationAPIBinderMidlleware(RequestDelegate next,IAPIService service)
        {
            _next = next;
            _apiService=service;
        }


        public async Task Invoke(HttpContext context)
        {
            var appId = context.Request.Headers["IntegrationID"].FirstOrDefault();
            if(appId == null)
            {
                // context.Items["IntegrationID"] = token;


                await ReturnErrorResponse(context);

                return;
            }

            // information = _apiService.GetAPIInformationByAppId(appId);


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
