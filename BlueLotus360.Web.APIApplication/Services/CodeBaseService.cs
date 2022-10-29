using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class CodeBaseService : ICodeBaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CodeBaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseServerResponse<CodeBaseResponse> GetCodeByOurCodeAndConditionCode(Company company, User user, string OurCode, string Condition)
        {
           return _unitOfWork.CodeBaseRepository.GetCodeByOurCodeAndConditionCode(company, user, OurCode, Condition);
        }
        public BaseServerResponse<CodeBaseResponse> GetControlConditionCode(Company company, User user, int ObjKy, string TableName)
        {
            return _unitOfWork.CodeBaseRepository.GetControlConditionCode(company, user, ObjKy, TableName);
        }
        public BaseServerResponse<IList<CodeBaseResponse>> ReadCodes(Company company, User user, ComboRequestDTO requestDTO)
        {
            return _unitOfWork.CodeBaseRepository.GetCodeBaseByObject(company, user, requestDTO);
        }

    }
}
