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

    public class AddressMaster : AddressResponse
    {
        public string Email { get; set; } = "";
        public string City { get; set; } = "";
        public string Address { get; set; } = "";
        public string NIC { get; set; } = "";
        public CodeBaseResponse AddressPrefix { get; set; }=new CodeBaseResponse();
        public decimal VAT { get; set; } 
        public decimal SVAT { get; set; }


    }

    public class AddAdvAnl
    {
        public CodeBaseResponse AdvAnlTyp { get; set; }=new CodeBaseResponse();
        public string Email { get; set; } = "";
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public string VATNo { get; set; } = "";
        public string SVATNo { get; set; } = "";
        public AddAdvAnl()
        {
            AdvAnlTyp = new CodeBaseResponse();
        }
    }

}
