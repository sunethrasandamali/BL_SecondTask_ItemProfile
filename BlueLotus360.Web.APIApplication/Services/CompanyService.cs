using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Web.API.Authentication.Providers;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class CompanyService:ICompanyService
    {
        IUnitOfWork _unitofWork { get; set; }
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        public Company GetCompanyByCode(string code)
        {
            var resp = _unitofWork.CompanyRepository.GetCompanyByCode(code);
            return resp.Value;
        }
    }
}
