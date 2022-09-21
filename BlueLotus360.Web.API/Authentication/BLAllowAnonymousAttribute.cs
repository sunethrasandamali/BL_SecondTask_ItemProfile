using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BlueLotus360.Web.API.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BLAllowAnonymousAttribute : Attribute
    {

    }
}
