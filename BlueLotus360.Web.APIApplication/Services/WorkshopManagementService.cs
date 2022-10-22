using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class WorkshopManagementService:IWorkshopManagementService
    {
        public readonly IUnitOfWork _unitOfWork;

        public WorkshopManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Vehicle> GetVehicleDetails(VehicleSearch request,Company company,User user)
        {
            var response =_unitOfWork.WorkShopManagementRepository.SelectVehicle(request, company, user);
            return response.Value;
        }

        public IList<WorkOrder> GetJobHistoryDetails(Vehicle request, Company company, User user)
        {
            var response = _unitOfWork.WorkShopManagementRepository.SelectJobhistory(request, company, user);
            return response.Value;
        }
    }
}
