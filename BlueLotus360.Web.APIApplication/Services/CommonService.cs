using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Report;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class CommonService:ICommonService
    {
        public readonly IUnitOfWork _unitOfWork;
        public CommonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ReportCompanyDetailsResponse GetCompanyDetailsResponse(Company company, User user, ReportCompanyDetailsRequest request)
        {
            return _unitOfWork.CommonRepository.GetCompanyDetailsResponse(company, user, request);
        }
    }
}
