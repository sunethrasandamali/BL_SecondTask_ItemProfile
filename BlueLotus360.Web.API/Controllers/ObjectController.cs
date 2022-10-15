using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using BlueLotus360.Core.Domain.Utility;
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
    public class ObjectController : ControllerBase
    {
        ILogger<ObjectController> _logger;
        IObjectService _objectService;
        IMenuService _menuService;

        public ObjectController(ILogger<ObjectController> logger, 
                                IObjectService objectService,
                                IMenuService menuService)
        {
            _logger = logger;
            _objectService = objectService;
            _menuService = menuService;
        }

        
        [HttpGet("fetchSideMenu")]
        public IActionResult FetchSideMenu()
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            UIMenu Menus = _menuService.GetMenusByUserAndCompanyService(user, company).BuildTree();
            return Ok(Menus);
        }

        [HttpPost("fetchObjects")]
        public IActionResult FetchObjects(ObjectFromRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            BLUIElement element = _objectService.GetUIElementsService(request.MenuKey, company, user);

            return Ok(element);
        }

        [HttpGet("filterPinnedUnpinnedMenu")]
        public IActionResult FilterPinnedUnpinnedMenu()
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            UIMenu Menus = _menuService.GetPinnedMenuService(user,company).BuildTree();

            return Ok(Menus);
        }

        [HttpPost("updatePinnedUnpinnedMenu")]
        public IActionResult UpdatePinnedUnpinnedMenu(UIMenu request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            _menuService.UpdatePinnedMenuService(user, company, request);

            return Ok();
        }

    }
}
