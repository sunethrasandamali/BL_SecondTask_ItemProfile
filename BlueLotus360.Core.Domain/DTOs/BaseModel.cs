using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.DTOs
{
    public class BaseModel
    {
        public string RequestId { get; set; } = "";

        public string IntegrationId { get; set; } = "";

        public string authToken { get; set; } = "";

        public int RequestingCompanyKey { get; set; } 
        public int RequestingUserKey { get; set; } = 1;
        public int RequestingObjectKey { get; set; } = 1;

        public string Scheme { get; set; } = "";

        public IList<string> ValidationMessages { get; set; }

        public BaseModel()
        {
            ValidationMessages = new List<string>();

        }

        public int IsApprovedStatus { get; set; }
        public int IsActive { get; set; }
    }
}
