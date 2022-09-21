using BlueLotus360.Web.API.Authentication.Jwt;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.Extensions.Options;
using System.Net;

namespace BlueLotus360.Web.API.MiddleWares
{
    public class ApplicationAPIBinderMidlleware
    {
        private readonly RequestDelegate _next;


        public ApplicationAPIBinderMidlleware(RequestDelegate next)
        {
            _next = next;
           
        }


        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["IntegrationID"].FirstOrDefault();
            if(token != null)
            {
                context.Items["IntegrationID"] = token;

            }
            await _next(context);
        }

        private async Task ReturnErrorResponse(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync("Bad Request");
            

        }
    }
}
