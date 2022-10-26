using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Order;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using BlueLotus360.Web.APIApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        ILogger<OrderController> _logger;
        IOrderService _orderService;
        IObjectService _objectService;
        ICodeBaseService _codeBaseService;
        public OrderController(ILogger<OrderController> logger,
                                IOrderService orderService,
                                IObjectService objectService, ICodeBaseService codeBaseService)
        {
            _logger = logger;
            _orderService = orderService;
            _objectService = objectService;
            _codeBaseService= codeBaseService;
        }

        [HttpPost("createGenericOrder")]
        public IActionResult CreateGenericOrder(GenericOrder orderDetails)
        {
            //
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey(orderDetails.FormObjectKey);
            var ordTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "OrdTyp");
            var ord = _orderService.SaveOrder(company, user, orderDetails, ordTyp.Value);
            OrderSaveResponse orderServerResponse = ord.Value;
            return Ok(orderServerResponse);

        }

        [HttpPost("updateGenericOrder")]
        public IActionResult UpdateGenericOrder(GenericOrder orderDetails)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey(orderDetails.FormObjectKey);
            var ordTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "OrdTyp");
            OrderSaveResponse orderServerResponse= _orderService.UpdateOrder(company, user, orderDetails, ordTyp.Value);
            
            return Ok(orderServerResponse);
        }

        [HttpPost("findOrders")]
        public IActionResult FindOrder(OrderFindDto request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey((int)request.ObjectKey);
            var ordTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "OrdTyp");

            BaseServerResponse<IList<OrderFindResults>> orders = _orderService.FindOrders(request,company, user, ordTyp.Value);
            return Ok(orders.Value);
        }

        [HttpPost("openOrder")]
        public IActionResult OpenOrder(OrderOpenRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            BaseServerResponse<GenericOrder> order = _orderService.OpenOrder(company,user,request);
            return Ok(order.Value);
        }

        [HttpPost("getFromQuotation")]
        public IActionResult GetFromQuotation(GetFromQuoatationDTO request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey((int)request.ObjKy);

            var ordTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "OrdTyp");
            var preOrdTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode2, "OrdTyp");

            IList<GetFromQuotResults> QuotationList = _orderService.RetrieveQuotation(request, company, user,ordTyp.Value, preOrdTyp.Value).Value;

            return Ok(QuotationList);
        }

        [HttpPost("openQuotation")]
        public IActionResult OpenQuotation(OrderOpenRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey((int)request.ObjKy);

            var ordTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "OrdTyp");
            

            GenericOrder ord = _orderService.OpenQuotation( company, user, request, ordTyp.Value).Value;

            return Ok(ord);
        }
    }
}
