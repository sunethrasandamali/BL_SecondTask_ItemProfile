using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
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
    public class UnitController : ControllerBase
    {
        ILogger<UnitController> _logger;
        IUnitService _unitService;

        public UnitController(ILogger<UnitController> logger,
                                       IUnitService unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        [HttpPost("readUnits")]
        public IActionResult ReadUnits(UnitComboRequestDTO comboRequest)
        {
            
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            IList<UnitResponse> unitResponses = _unitService.GetItemMultiUnit(comboRequest, company, user);

            return Ok(unitResponses);
         
        }




    }
}
