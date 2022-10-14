using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Data.SQL92.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class WorkShopManagementRepository : BaseRepository, IWorkShopManagementRepository
    {
        public WorkShopManagementRepository(ISQLDataLayer dataLayer):base(dataLayer) { }

    }
}
