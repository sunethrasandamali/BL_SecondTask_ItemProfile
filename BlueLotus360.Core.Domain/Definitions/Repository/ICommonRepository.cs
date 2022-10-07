using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface ICommonRepository
    {
        ReportCompanyDetailsResponse GetCompanyDetailsResponse(Company company, User user, ReportCompanyDetailsRequest request);
    }
}
