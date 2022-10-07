using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace BlueLotus360.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BLAuthorize]
    public class TransactionController : ControllerBase
    {

        ILogger<TransactionController> _logger;
        ITransactionService _transactionService;
        IObjectService _objectService;
        ICodeBaseService _codeBaseService;
        IItemService _itemService;
        public TransactionController(ILogger<TransactionController> logger, 
                                    ITransactionService transactionService,
                                    IObjectService objectService, ICodeBaseService codeBaseService, IItemService itemService)
        {
            _logger = logger;
            _transactionService = transactionService;
            _objectService = objectService;
            _codeBaseService = codeBaseService;
            _itemService = itemService;
        }


        [HttpPost("saveTransaction")]
        public IActionResult SaveTransaction(BLTransaction transaction)
        {
            var user =  Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey(transaction.ElementKey);
            var trnTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "TrnTyp");
            var trn=_transactionService.SaveTransaction(transaction, company, user, uiObject.Value, trnTyp.Value);

            return Ok(trn.Value);
        }

        [HttpPost("findTransaction")]
        public IActionResult FindTransaction(TransactionFindRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uiObject = _objectService.GetObjectByObjectKey(request.ElementKey);
            var trnTyp = _codeBaseService.GetCodeByOurCodeAndConditionCode(company, user, uiObject.Value.OurCode, "TrnTyp");
            request.TransactionType=trnTyp.Value;   
            var trn = _transactionService.FindTransaction(company, user, request);
            IList<GenericTransactionFindResponse> responses = trn.Value;
            return Ok(responses);
        }

        [HttpPost("openTransaction")]
        public IActionResult OpenTransaction(TransactionOpenRequest request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var trn = _transactionService.OpenTransaction(company, user, request);
            BLTransaction transaction=trn.Value;
            request.TrasctionTypeKey = transaction.TransactionType.CodeKey;
            var linItm= _transactionService.GetTransactionLineItems(company, user, request);
            transaction.InvoiceLineItems=linItm.Value;

            return Ok(transaction);

        }

        //[HttpPost("getStockAsAtByLocation")]
        //public IActionResult GetStockAsAtByLocation(StockAsAtRequest request)
        //{
        //    var user = Request.GetAuthenticatedUser();
        //    var company = Request.GetAssignedCompany();
        //    StockAsAtResponse response = _itemService.GetStockAsAtByLocation(company, user, request);
        //    return Ok(response);
        //}
    }
}
