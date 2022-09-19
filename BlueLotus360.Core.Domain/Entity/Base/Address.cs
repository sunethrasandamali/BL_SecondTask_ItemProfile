using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class Address:BaseEntity
    {
        public long AddressKey { get; set; }

        public Address(long addressKey=1)
        {
            AddressKey = addressKey;
        }
    }

}
