using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class ItemSerialNumber:BaseEntity
    {
        public long SerialNumberKey { get; set; } = 1;
        public long TransactionKey { get; set; } = 1;
        public long ItemTransactionKey { get; set; } = 1;
        public int LineNumber { get; set; }
        public string? SerialNumber { get; set; }
        public string? CustomerSerialNumber { get; set; }
        public string? SupplierWarrantyReading { get; set; }
        public string? CustomerWarrantyReading { get; set; }
        public long ItemKey { get; set; } = 1;
        public DateTime? SupplierExpiryDate { get; set; }
        public DateTime? CustomerExpiryDate { get; set; }
        public string? EngineNumber { get; set; }
        public string? VehicleNumber { get; set; }
        public string? BatchNumber { get; set; }
        public long PersistingElementKey { get; set; } = 1;
        public long ElementKey { get; set; } = 1;

    }
}
