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

        ILogger<UserController> _logger;
        ITransactionService _transactionService;
        IObjectService _objectService;


        public TransactionController(ILogger<UserController> logger, ITransactionService transactionService,IObjectService objectService)
        {
            _logger = logger;
            _transactionService = transactionService;
            _objectService = objectService;
        }


        [HttpPost("saveTransaction")]
        public IActionResult SaveTransaction(BLTransaction transaction)
        {
            var user =  Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            var uobject = _objectService.GetObjectByObjectKey(transaction.ElementKey);
            var trn=_transactionService.SaveTransaction(transaction, company, user, uobject.Value);

            return Ok(trn.Value);
        }
    }
}
