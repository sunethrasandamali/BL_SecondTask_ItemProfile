using BlueLotus360.Core.Domain.Definitions.DataLayer;
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

        public IList<Vehicle> GetVehicleDetails(int regId = 1)
        {
            throw new NotImplementedException();
        }
    }
}
