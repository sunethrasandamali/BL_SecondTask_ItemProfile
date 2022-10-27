using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Core.Domain.Responses;
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
    public class WorkShopManagementController : ControllerBase
    {
        ILogger<WorkShopManagementController> _logger;
        IWorkshopManagementService _workshopManagementService;
        public WorkShopManagementController(ILogger<WorkShopManagementController> logger,IWorkshopManagementService workshopManagementService)
        {
            _logger = logger;
            _workshopManagementService = workshopManagementService;
        }

        [HttpPost("searchVehicle")]
        public IActionResult SearchVehicle(VehicleSearch request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            IList<Vehicle> vehicles = _workshopManagementService.GetVehicleDetails(request, company, user);
            return Ok(vehicles);
        }

        [HttpPost("getJobHistories")]
        public IActionResult GetJobHistories(Vehicle request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            IList<WorkOrder> WorkOrders = _workshopManagementService.GetJobHistoryDetails(request, company, user);
            return Ok(WorkOrders);
        }

        [HttpPost("getCarProgessingProjectDetails")]
        public IActionResult GetCarProgessingProjectDetails(Vehicle request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            IList<ProjectResponse> list = _workshopManagementService.GetProgressingProjectDetails(request, company, user);
            return Ok(list);
        }

        [HttpPost("openWorkOrder")]
        public IActionResult OpenWorkOrder(OrderOpenRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            BaseServerResponse<WorkOrder> order = _workshopManagementService.OpenWorkOrder(company, user, request);
            return Ok(order.Value);
        }

    }
}
