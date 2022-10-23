using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Web.API.Authentication;
using BlueLotus360.Web.API.Extension;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using Microsoft.AspNetCore.Mvc;

namespace BlueLotus360.Web.API.Controllers
{
    [BLAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ILogger<ProjectController> _logger;
        IProjectService _projectService;
        public ProjectController(ILogger<ProjectController> logger,IProjectService projectService) 
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpPost("projectHeaderInsert")]
        public IActionResult ProjectHeaderInsert(Project request)
        {
            var user = Request.GetAuthenticatedUser();
            var company = Request.GetAssignedCompany();
            ProjectResponse response= _projectService.InsertProject(company,user,request);
            return Ok(response);
        }
    }
}
