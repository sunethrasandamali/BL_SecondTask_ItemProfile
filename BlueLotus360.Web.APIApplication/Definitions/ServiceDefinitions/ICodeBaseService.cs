using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Extended;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface ICodeBaseService
    {
        BaseServerResponse<CodeBaseResponse> GetCodeByOurCodeAndConditionCode(Company company, User user, string OurCode, string Condition);
        BaseServerResponse<CodeBaseResponse> GetControlConditionCode(Company company, User user, int ObjKy, string TableName);
        BaseServerResponse<IList<CodeBaseResponse>> ReadCodes(Company company, User user, ComboRequestDTO requestDTO);
        BaseServerResponse<IList<CodeBase>> ReadCategories(Company company, User user, ComboRequestDTO requestDTO);
        BaseServerResponse<IList<CodeBaseResponse>> GetCodesByConditionCode(Company company, CodeBaseResponse request);
    }
}
