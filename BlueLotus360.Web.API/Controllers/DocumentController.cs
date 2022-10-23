using BlueLotus360.Core.Domain.Entity.Document;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        ILogger<DocumentController> _logger;
        IDocumentService _documentService;
        public DocumentController(ILogger<DocumentController> logger,IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }


        [HttpPost("uploadFile")]
        public IActionResult UploadFile(FileUpload document)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            _documentService.UploadImages(company,user,document);
            return Ok();
        }

        [HttpPost("getBase64Doc")]
        public IActionResult GetBase64Doc(DocumentRetrivaltDTO document)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            IList<Base64Document> base64Documents = _documentService.GetBase64Documents(company,user,document);
            return Ok(base64Documents);
        }
    }
}
