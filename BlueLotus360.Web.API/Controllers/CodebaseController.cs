using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Extended;
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
    public class CodebaseController : ControllerBase
    {
        ILogger<CodebaseController> _logger;
        ICodeBaseService _codebaseService;

        public CodebaseController(ILogger<CodebaseController> logger,
                                        ICodeBaseService codebaseService)
        {
            _logger = logger;
            _codebaseService = codebaseService;
        }

        [HttpPost("readCodes")]
        public IActionResult ReadCodes(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var response = _codebaseService.ReadCodes(company, user, comboRequest);
            IList<CodeBaseResponse> codeBases= response.Value;

            return Ok(codeBases);
        }

        [HttpPost("readCategories")]
        public IActionResult ReadCategories(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var response = _codebaseService.ReadCategories(company, user, comboRequest);
            IList<CodeBase> codeBases = response.Value;

            return Ok(codeBases);
        }


    }
}
