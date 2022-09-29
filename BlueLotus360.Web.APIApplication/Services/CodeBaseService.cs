using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class CodeBaseService : ICodeBaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CodeBaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseServerResponse<CodeBaseSimple> GetCodeBaseByObject(Company company, User user, string Condition, string OurCode)
        {
           return _unitOfWork.CodeBaseRepository.GetCodeBaseByObject(company, user, Condition, OurCode);
        }
    }
}
