using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class AccountResponse : BaseComboResponse
    {
        public long AccountKey { get; set; } = 1;
        public string AccountName { get; set; }
        public string AccountCode { get; set; }

    }
}
