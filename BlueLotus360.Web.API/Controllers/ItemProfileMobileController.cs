using BlueLotus360.Core.Domain.Entity.Auth;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.ItemProfileMobile;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.UnitOfWork;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemProfileMobileController : ControllerBase
    {

        ILogger<ItemProfileMobileController> _logger;
        IItemProfileMobileService _itemProfileMobileService;
        IObjectService _objectService;
        ICodeBaseService _codeBaseService;

        //constructor
        public ItemProfileMobileController(ILogger<ItemProfileMobileController> logger,
                                IItemProfileMobileService itemProfileMobileService,
                                IObjectService objectService, ICodeBaseService codeBaseService)
        {
            _logger = logger;
            _itemProfileMobileService = itemProfileMobileService;
            _objectService = objectService;
            _codeBaseService = codeBaseService;
        }

        [HttpPost("GetItemList")]
        public IActionResult GetItemList(ItemSelectListRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            BaseServerResponse<IList<ItemSelectList>> list = _itemProfileMobileService.GetItemProfileList(company, user, request);
            return Ok(list.Value);
        }

        [HttpPost("InsertItemList")]
        public IActionResult InsertItemList(ItemSelectList request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            bool insertItem = _itemProfileMobileService.InsertItem(company , user , request);
            return Ok(insertItem);
        }

        [HttpPost("UpdateItemList")]
        public IActionResult UpdateItemList(ItemSelectList request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            bool updateItem = _itemProfileMobileService.UpdateItem(company, user, request);
            return Ok(updateItem);
        }

       

    }
}
