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
    public class AddressController : ControllerBase
    {
        ILogger<AddressController> _logger;
        IAddressService _addressService;

        public AddressController(ILogger<AddressController> logger,
                                IAddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }

        [HttpPost("readAddress")]
        public IActionResult ReadAddress(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var result = _addressService.GetComboAddresses(company, user, comboRequest);
            IList<AddressResponse> addresses = result.Value;

            return Ok(addresses);
        }
    }
}
