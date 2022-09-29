using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class ProjectResponse : BaseComboResponse
    {
        public long ProjectKey { get; set; } = 1;

        public string ProjectName { get; set; } = "";
        public string ProjectId { get; set; } = "";

        public DateTime ExpiryDate { get; set; }

    }
}
