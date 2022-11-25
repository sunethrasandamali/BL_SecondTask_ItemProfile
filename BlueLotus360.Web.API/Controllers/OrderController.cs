using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity;
using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Order;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Entity.UberEats;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Core.Domain.Utility;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.API.Integrations.Uber;
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
            if (request.APIIntegrationName == "Ubereats")
            {
                company.CompanyKey=1;
            }
            var user = Request.GetAuthenticatedUser();
            APIInformation APIInfo = _orderService.GetAPIDetails(company, user, request).Value;

            return Ok(APIInfo);
        }

        [HttpPost("GetOrderStatus")]
        public IActionResult GetOrderStatus(ComboRequestDTO comboRequest)
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

        [HttpPost("InsertLastOrderSync")]
        public IActionResult InsertLastOrderSync(RequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            bool success = _orderService.InsertLastOrderSync(request,company);

            return Ok(success);
        }

        [HttpPost("GenerateProvisionURL")]
        public IActionResult GenerateProvisionURL(APIRequestParameters request)
        {
            var company = Request.GetAssignedCompany();
            string Redirect_uri = request.BaseURL + "Order/GenerateProvisionToken?CompanyCode=" + CryptoService.ToEncryptedData(company.CompanyKey.ToString());
            string link = "https://login.uber.com/oauth/v2/authorize?response_type=code&client_id=" +request.IntegrationID +"&scope=eats.pos_provisioning&redirect_uri=" +Redirect_uri;
            return Ok(link);
        }

        [HttpGet("GenerateProvisionToken")]
        public ContentResult GenerateProvisionToken(string ComapayCode, string code)
        {
            var user = Request.GetAuthenticatedUser();
            string decryptedCompanyKeyAsString = CryptoService.ToDecryptedData(ComapayCode);
            int decryptedCompanyKey = Convert.ToInt32(decryptedCompanyKeyAsString);
            UberProvisionHandler uberProvisionHandler = new UberProvisionHandler(_orderService);
            UberTokenHandler uberTokenHandler = new UberTokenHandler(_orderService);
            APIInformation APIInfo= uberProvisionHandler.GetCommonUberDetails(user== null ? new Core.Domain.Entity.Base.User():user);
            if (APIInfo != null)
            {
                APIInformation endpointInfo = uberProvisionHandler.GetEndPoint(APIInfo.APIIntegrationKey, UberEndpointURLS.AuthCode.ToString());
                uberProvisionHandler.InsertAuthEndpoint(code, APIInfo.APIIntegrationKey, endpointInfo.EndPointURL, decryptedCompanyKey);
                var RedirectURL = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path;
                APIInformation ScopeendpointInfo = uberProvisionHandler.GetEndPoint(APIInfo.APIIntegrationKey, UberTokenEndpoints.Eats_Provisioning_Scope.GetDescription());
                APIInformation GetProvisionToken = uberTokenHandler.GetUberEatsTokensByEndPointName(APIInfo, ScopeendpointInfo, UberTokenEndpoints.Eats_Provisioning_Scope.GetDescription(), RedirectURL, code, decryptedCompanyKey);
                if(GetProvisionToken.EndPointToken != string.Empty && GetProvisionToken.EndPointToken != null)
                {
                    return new ContentResult
                    {
                        ContentType = "text/html",
                        Content = "<div>Successfully Provisioned with Uber !</div>"
                    };
                }
                else
                {
                    return new ContentResult
                    {
                        ContentType = "text/html",
                        Content = "<div>Something went wrong!</div>"
                    };
                }
            }
            else
            {
                return new ContentResult
                {
                    ContentType = "text/html",
                    Content = "<div>Something went wrong!</div>"
                };
            }
        }

        [HttpPost("GenerateUberToken")]
        public IActionResult GenerateUberToken(APIRequestParameters request)
        {
            UberProvisionHandler uberProvisionHandler = new UberProvisionHandler(_orderService);
            UberTokenHandler uberTokenHandler = new UberTokenHandler(_orderService);
            APIInformation GetUberToken = new APIInformation();
            User user = Request.GetAuthenticatedUser();
            Company company = Request.GetAssignedCompany();
            APIInformation APIInfo = uberProvisionHandler.GetCommonUberDetails(user == null ? new Core.Domain.Entity.Base.User() : user);
            if (APIInfo != null)
            {
                APIInformation ScopeendpointInfo = uberProvisionHandler.GetEndPoint(APIInfo.APIIntegrationKey, request.EndPointName);
                GetUberToken = uberTokenHandler.GetUberEatsTokensByEndPointName(APIInfo, ScopeendpointInfo, request.EndPointName, "", "", company.CompanyKey);
            }
                return Ok(GetUberToken);
        }

        [HttpPost("GetUberEndPoints")]
        public IActionResult GetUberEndPoints(APIRequestParameters request)
        {
            UberProvisionHandler uberProvisionHandler = new UberProvisionHandler(_orderService);
            APIInformation GetUberEndPoint = new APIInformation();
            User user = Request.GetAuthenticatedUser();
            APIInformation APIInfo = uberProvisionHandler.GetCommonUberDetails(user == null ? new Core.Domain.Entity.Base.User() : user);
            if (APIInfo != null)
            {
                GetUberEndPoint = uberProvisionHandler.GetEndPoint(APIInfo.APIIntegrationKey, request.EndPointName);
            }
            return Ok(GetUberEndPoint);
        }

        [HttpPost("GetAPIDetailsByMerchantID")]
        public IActionResult GetAPIDetailsByMerchantID(APIRequestParameters request)
        {
            APIInformation apiinfo = _orderService.GetAPIDetailsByMerchantID(request).Value;
            return Ok(apiinfo);
        }


    }
}
