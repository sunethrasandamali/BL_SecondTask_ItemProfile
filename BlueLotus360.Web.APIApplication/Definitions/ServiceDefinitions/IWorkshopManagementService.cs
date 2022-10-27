using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Core.Domain.Responses;
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
        BaseServerResponse<WorkOrder> OpenWorkOrder(Company company, User user, OrderOpenRequest request);
    }
}
