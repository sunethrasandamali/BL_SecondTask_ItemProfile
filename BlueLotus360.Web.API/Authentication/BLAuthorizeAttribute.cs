using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BlueLotus360.Web.API.Model;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus360.Web.API.Authentication
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BLAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly bool RequiresFullValidation;

        public BLAuthorizeAttribute(bool requiresFullValidation=true)
        {
            RequiresFullValidation = requiresFullValidation;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<BLAllowAnonymousAttribute>().Any();
            if (context.HttpContext.Items["APIInformation"]==null)
            {
                context.Result = new JsonResult(new { message = "No Integration ID found in request header" }) { StatusCode = StatusCodes.Status400BadRequest };
                return;
            }
            if (allowAnonymous)
            {
                return;
            }
            // Middle ware will be responsible for user auth;
            var user = (User)context.HttpContext.Items["User"];
           

            if(RequiresFullValidation)
            {

            }

            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
