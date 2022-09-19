using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         ILogger<UserController> _logger;
        IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger=logger;
            _userService=userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserAuthenticationRequest model)
        {
            var response = _userService.AuthenticateUser(model, Request.GetRequestIP());
            return Ok(response);
        }

        [BLAuthorize(false)]
        [HttpPost("getUserCompanies")]

        public IActionResult GetUserCompanies()
        {            
            var companies = _userService.GetUserCompanies(Request.GetAuthenticatedUser());
            return Ok(companies);
        }

        [BLAuthorize(false)]
        [HttpPost("updateUserCompany")]
        public IActionResult UpdateUserCompany(UserCompanyUpdateRequest updateRequest)
        {
            
            var companies = _userService.GetUserCompanies(Request.GetAuthenticatedUser());
            var selectedCompany=companies.Where(x=>x.CompanyKey==updateRequest.CompanyKey).FirstOrDefault();
            if (Request.GetAuthenticatedUser()==null || selectedCompany == null)
            {
                return BadRequest();
            }
            var resp = _userService.UpdateCompanySelection(Request.GetAuthenticatedUser(), selectedCompany, Request.GetRequestIP());
            return Ok(resp);
        }
    }
}
