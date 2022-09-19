using BlueLotus360.Core.Domain.Entity.Base;
using System.Runtime.CompilerServices;

namespace BlueLotus360.Web.API.Extension
{
    public static class RequestExtension
    {
        public static string GetRequestIP(this HttpRequest httpRequest)
        {
            // get source ip address for the current request
            if (httpRequest.Headers.ContainsKey("X-Forwarded-For"))
                return httpRequest.Headers["X-Forwarded-For"];
            else
            {
              return  httpRequest.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
                
        }


        public static User  GetAuthenticatedUser(this HttpRequest httpRequest)
        {
            try
            {
                return (User)httpRequest.HttpContext.Items["User"];
            }
            catch
            {
                return null;
            }
        }

        public static Company GetAssignedCompany(this HttpRequest httpRequest)
        {
            try
            {
                return (Company)httpRequest.HttpContext.Items["Company"];
            }
            catch
            {
                return null;
            }
        }
    }
}
