using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface ICommonService
    {
        ReportCompanyDetailsResponse GetCompanyDetailsResponse(Company company, User user, ReportCompanyDetailsRequest request);
    }
}
