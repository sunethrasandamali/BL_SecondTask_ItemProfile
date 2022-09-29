using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class AddressResponse : BaseComboResponse
    {
        public long AddressKey { get; set; } = 1;

        public string AddressName { get; set; } = "";
        public string AddressId { get; set; } = "";

        public AddressResponse()
        {

        }
        public AddressResponse(long Key)
        {
            this.AddressKey = Key;

        }
        public AddressResponse(long Key, string id, string name)
        {
            this.AddressKey = Key;
            this.AddressName = name;
            this.AddressId = id;

        }
    }
}
