using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.API
{
    public class APIInformation:BaseEntity
    {
        public int APIIntegrationKey { get; set; } =1;
        public string APIIntegrationNmae { get; set; }
        public string Description { get; set; }
        public string ApplicationID { get; set; }
        public string SecretKey { get; set; }
        public string RestrictToIP { get; set; }
        public int MappedCompanyKey { get; set; } = 1;
        public int MappedUserKey { get; set; } = 1;
        public bool IsLocalOnly { get; set; } 
        public bool ISIPFilterd { get; set; }
        public bool ValidateTokenOnly { get; set; }
        public string Scheme { get; set; }
        public int Direction { get; set; }
        public int MappedLocation { get; set; }
        public string BaseURL { get; set; }
        public bool IsNonAutoMapped { get; set; }
        public string AuthenticationType  { get; set; }
    }
}
