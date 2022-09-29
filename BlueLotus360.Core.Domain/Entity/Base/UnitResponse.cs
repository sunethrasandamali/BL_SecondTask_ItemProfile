using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class UnitResponse : BaseComboResponse
    {
        public long UnitKey { get; set; } = 1;

        public string UnitName { get; set; } = "";

        public UnitResponse()
        {

        }
        public UnitResponse(long key, string unitName)
        {
            this.UnitKey = key;
            this.UnitName = unitName;
        }

    }
}
