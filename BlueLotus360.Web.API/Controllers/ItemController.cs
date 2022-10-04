using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        ILogger<ItemController> _logger;
        IItemService _itemService;
        public ItemController(ILogger<ItemController> logger,
                                IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService; 
        }

        [HttpPost("getItemsForTransactionJson")]
        public IActionResult GetItemsForTransactionJson(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var list = _itemService.GetItems(company, user, comboRequest);
            IList<ItemSimple> Items = list.Value;
            Items = Items.Take(300).ToList();

            return Ok(Items);
        }
    }
}
