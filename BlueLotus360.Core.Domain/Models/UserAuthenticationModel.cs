using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Models
{
    public class BaseAPIRequest
    {
        [JsonIgnore]
        public string RequestToken { get; set; } = "";

        public string RequestId { get; set; } =string.Empty;
        

    }

    public class UserAuthenticationRequest: BaseAPIRequest
    {
        public string UserName  { get; set; } = "";
        public string Password  { get; set; } = "";
    }

    public class UserCompanyUpdateRequest: BaseAPIRequest
    {
        public int CompanyKey { get; set; }
        public string CompanyCode { get; set; } = "";
        public string CompanyName { get; set; } = "";

    }
}
