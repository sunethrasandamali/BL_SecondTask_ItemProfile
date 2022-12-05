using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Extended;
using BlueLotus360.Core.Domain.Entity.Transaction;
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
    public class CodebaseController : ControllerBase
    {
        ILogger<CodebaseController> _logger;
        ICodeBaseService _codebaseService;

        public CodebaseController(ILogger<CodebaseController> logger,
                                        ICodeBaseService codebaseService)
        {
            _logger = logger;
            _codebaseService = codebaseService;
        }

        [HttpPost("readCodes")]
        public IActionResult ReadCodes(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var response = _codebaseService.ReadCodes(company, user, comboRequest);
            IList<CodeBaseResponse> codeBases= response.Value;

            return Ok(codeBases);
        }

        [HttpPost("readCategories")]
        public IActionResult ReadCategories(ComboRequestDTO comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var response = _codebaseService.ReadCategories(company, user, comboRequest);
            IList<CodeBase> codeBases = response.Value;

            return Ok(codeBases);
        }

        [HttpPost("ReadCodeByConditionCode")]
        public IActionResult ReadCodeByConditionCode(CodeBaseResponse comboRequest)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();

            var response = _codebaseService.GetCodesByConditionCode(company, comboRequest);
            IList<CodeBaseResponse> codeBases = response.Value;

            return Ok(codeBases);
        }

        [HttpPost("getApproveStatusComboDetail")]
        public IActionResult GetApproveStatusComboDetail(ComboRequestDTO request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            object CurAprStatusKey;
            object TransactionKey;
            object ElementKey;
            int trnky = 1;
            int curaprstsky = 1;
            int objky = 1;

            if (request.AddtionalData.TryGetValue("TransactionKey", out TransactionKey))
            {
                trnky = Convert.ToInt32(TransactionKey.ToString());
            }
            if (request.AddtionalData.TryGetValue("ApproveStatusKey", out CurAprStatusKey))
            {
                curaprstsky = Convert.ToInt32(CurAprStatusKey.ToString());
            }
            if (request.AddtionalData.TryGetValue("ObjectKey", out ElementKey))
            {
                objky = Convert.ToInt32(ElementKey.ToString());
            }

            var apprv = _codebaseService.GetAllApproveStatus(trnky, curaprstsky, objky, company, user);
            IList<CodeBaseResponse> codeBases = apprv.Value;
            return Ok(codeBases);
        }
    }
}
