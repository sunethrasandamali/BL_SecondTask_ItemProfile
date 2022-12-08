using BlueLotus360.Core.Domain.Entity.BookingModule;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingModuleController : ControllerBase
    {
        ILogger<BookingModuleController> _logger;
        IBookingModuleService _bookingModuleService;
        IObjectService _objectService;
        ICodeBaseService _codeBaseService;
        public BookingModuleController(ILogger<BookingModuleController> logger,
                                            IBookingModuleService bookingModuleService,
                                            IObjectService objectService, ICodeBaseService codeBase)
        {
            _logger = logger;
            _bookingModuleService = bookingModuleService;
            _objectService = objectService;
            _codeBaseService = codeBase;
        }

        [HttpPost("getBookedCustomerDetails")]
        public IActionResult GetBookedCustomerDetails(BookingVehicleDetails request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            BaseServerResponse<IList<CustomerDetailsByVehicle>> customers = _bookingModuleService.GetBookingCustomerDetails(company, user, request);
            return Ok(customers.Value);
        }

        [HttpPost("getBookingList")]
        public IActionResult GetBookingList(BookingDetails request)
        {
			var user = Request.GetAuthenticatedUser();
			var company = Request.GetAssignedCompany();
            BaseServerResponse<IList<BookingDetails>> list = _bookingModuleService.GetBookingDetailsOnCalender(company, user, request);
			return Ok(list.Value);
		}
	}
}
