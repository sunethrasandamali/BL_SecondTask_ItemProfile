using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Report;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using BlueLotus360.Web.APIApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ILogger<CompanyController> _logger;
        ICommonService _commonService;
        public CompanyController(ILogger<CompanyController> logger, ICommonService commonService)
        {
            _logger = logger;
            _commonService = commonService;
        }

        [HttpPost("getCompanyInformation")]
        public IActionResult GetCompanyInformation(ReportCompanyDetailsRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            ReportCompanyDetailsResponse response = _commonService.GetCompanyDetailsResponse(company,user, request);

            return Ok(response);

        }
    }
}
