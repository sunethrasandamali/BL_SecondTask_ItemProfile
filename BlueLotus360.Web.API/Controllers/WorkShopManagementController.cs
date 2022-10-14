using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Web.API.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopManagementController : ControllerBase
    {
        ILogger<OrderController> _logger;

        public WorkShopManagementController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getVehicleByRegNo/{id}")]
        public IActionResult getVehicleByRegNo(long id)
        {
            Vehicle veh=new Vehicle() { VehicleID="KH9915"};
            IList<Vehicle> vehicles=new List<Vehicle>() { veh};
            return Ok(vehicles);
        }

    }
}
