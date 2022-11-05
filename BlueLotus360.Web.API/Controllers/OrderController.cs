using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity;
using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Order;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
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

        [HttpPost("GetPartnerCountByStatus")]
        public IActionResult GetPartnerCountByStatus(RequestParameters request)
        {
            var company = Request.GetAssignedCompany();

            int OrderCount = _orderService.PartnerOrders_Count(company, request);

            return Ok(OrderCount);
        }

        [HttpPost("GetAllPartnerOrders")]
        public IActionResult GetAllPartnerOrders(RequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            var user = Request.GetAuthenticatedUser();
            IList<PartnerOrder> Orders = _orderService.GetAllPartnerOrder(company, user, request).Value;

            return Ok(Orders);
        }

        [HttpPost("GetAPIDetails")]
        public IActionResult GetAPIDetails(APIRequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            var user = Request.GetAuthenticatedUser();
            APIInformation APIInfo = _orderService.GetAPIDetails(company, user, request).Value;

            return Ok(APIInfo);
        }

        [HttpPost("GetOrderStatus")]
        public IActionResult GetOrderStatus()
        {
            var company = Request.GetAssignedCompany();
            var user = Request.GetAuthenticatedUser();
            IList<CodeBaseResponse> codes = _orderService.GetOrderStatus(company).Value;

            return Ok(codes);
        }

        [HttpPost("GetOrderEndPoints")]
        public IActionResult GetOrderEndPoints(APIRequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            APIInformation codes = _orderService.GetAPIEndPoints(company, request).Value;

            return Ok(codes);
        }

        [HttpPost("GetLastOrderSyncTime")]
        public IActionResult GetLastOrderSyncTime(APIRequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            PartnerOrder codes = _orderService.GetLastOrderSyncTime(company, request).Value;

            return Ok(codes);
        }

        [HttpPost("GetOrdersFromOrderPlatforms")]
        public IActionResult GetOrdersFromOrderPlatforms(PartnerOrder request)
        {
            var company = Request.GetAssignedCompany();
            var user = Request.GetAuthenticatedUser();
            PartnerOrder codes = _orderService.GetOrdersFromOrderPlatforms(company,user, request).Value;

            return Ok(codes);
        }

        [HttpPost("GetOrderStatusByPartnerStatus")]
        public IActionResult GetOrderStatusByPartnerStatus(CodeBaseResponse request)
        {
            var company = Request.GetAssignedCompany();
            CodeBaseResponse codes = _orderService.GetOrderStatusByPartnerStatus(company,request).Value;

            return Ok(codes);
        }

        [HttpPost("GetItemsByItemCode")]
        public IActionResult GetItemsByItemCode(ItemResponse request)
        {
            var company = Request.GetAssignedCompany();
            ItemResponse codes = _orderService.GetItemsByItemCode(company, request).Value;

            return Ok(codes);
        }

        [HttpPost("GetPartnerOrdersByOrderKy")] 
        public IActionResult GetPartnerOrdersByOrderKy(RequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            PartnerOrder codes = _orderService.GetPartnerOrdersByOrderKy(company, request).Value;

            return Ok(codes);
        }

    }
}
