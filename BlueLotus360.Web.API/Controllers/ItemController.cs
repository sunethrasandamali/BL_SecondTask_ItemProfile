using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using BlueLotus360.Web.APIApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Transactions;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        ILogger<ItemController> _logger;
        IItemService _itemService;
        IObjectService _objectService;
        ICodeBaseService _codeBaseService;
        public ItemController(ILogger<ItemController> logger,
                                IItemService itemService,
                                IObjectService objectService, ICodeBaseService codeBaseService)
        {
            _logger = logger;
            _itemService = itemService;
            _objectService = objectService;
            _codeBaseService = codeBaseService;
        }

        [HttpPost("getItemsForTransactionJson")]
        public IActionResult GetItemsForTransactionJson(ComboRequestDTO comboRequest)
        {
            //ComboRequestDTO comboRequest
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var list = _itemService.GetItems(company, user, comboRequest);
            IList<ItemSimple> Items = list.Value;
            Items = Items.Take(300).ToList();

            return Ok(Items);
        }

        [HttpPost("getItemRateEx")]
        public IActionResult GetItemRate(RateRetrivalModel model)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var uiObject = _objectService.GetObjectByObjectKey((int)model.ObjectKey);
            var typ = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, model.ConditionCode);

            ItemRateResponse response = _itemService.GetItemRateEx(model, company, user,typ.Value);

            return Ok(response);
        }

        [HttpPost("readSerialNumbers")]
        public IActionResult GetSerialNumbers(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var list = _itemService.GetItems(company, user, comboRequest);

            IList<ItemSerialNumber> serialNumbers = _itemService.GetSerialNumbers(company, user, comboRequest);

            return Ok(serialNumbers);
        }

        [HttpPost("readProducts")]
        public IActionResult ReadProducts(ComboRequestDTO comboRequest)
        {
            return Ok();
        }

        [HttpPost("getAvailableStock")]

        public IActionResult GetAvailableStock(StockAsAtRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            
            StockAsAtResponse response = _itemService.GetAvailableStock(company, user, request);
            return Ok(response);
        }

    }
}
