using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class ProjectService:IProjectService
    {
        public readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public ProjectResponse InsertProject(Company company, User user, Project project)
        {
            return _unitOfWork.ProjectRepository.CreateProjectHeader(company, user, project); 
        }
    }
}
