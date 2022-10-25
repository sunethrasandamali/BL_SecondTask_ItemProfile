using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface IWorkshopManagementService
    {
        public IList<Vehicle> GetVehicleDetails(VehicleSearch request, Company company, User user);
        IList<WorkOrder> GetJobHistoryDetails(Vehicle request, Company company, User user);
        IList<ProjectResponse> GetProgressingProjectDetails(Vehicle request, Company company, User user);
    }
}
