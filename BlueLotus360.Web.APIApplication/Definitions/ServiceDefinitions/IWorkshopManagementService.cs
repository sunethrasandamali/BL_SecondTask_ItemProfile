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
        public IList<Vehicle> GetVehicleDetails(int regId=1);
    }
}
