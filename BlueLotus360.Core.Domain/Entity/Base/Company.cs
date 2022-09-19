using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class Company
    {
        public int CompanyKey { get; set; } = 1;
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
    }
}
