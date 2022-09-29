using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class Address : BaseComboResponse
    {
        public long AddressKey { get; set; }

        public string AddressId { get; set; }
        public string AddressName { get; set; }

        public Address (long addressKey=1)
        {
            AddressKey = addressKey;
        }
    }

}
