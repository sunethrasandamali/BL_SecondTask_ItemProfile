using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.BookingModule
{
    public class BookingDetails
    {
        public long ElementKey { get; set; }
        public DateTime FromDate { get; set; } = new DateTime();
        public DateTime ToDate { get; set; } = new DateTime();
        public int Id { get; set; }
        public int ProcessDetailsKey { get; set; }
        public int ProjectKey { get; set; }
        public int TaskID { get; set; }
        public string TaskName { get; set; } = "";
        public DateTime RequestedDate { get; set; } = new DateTime();
        public AddressResponse Registration { get; set; } = new AddressResponse();
        public int CustomerAddressKey { get; set; }
        public string CustomerName { get; set; } = "";
        public CodeBaseResponse ServiceType { get; set; } = new CodeBaseResponse();
        public decimal Milage { get; set; }
        public string Remark { get; set; } = "";
        public string Mobile { get; set; } = "";
        public BookingVehicleDetails VehicleDetails { get; set; } = new BookingVehicleDetails();
        public BookingTabDetails TabDetails { get; set; } = new BookingTabDetails();
        public IList<CustomerDetailsByVehicle> CustomersDetails { get; set; } = new List<CustomerDetailsByVehicle>();
        public AddressResponse SelectedCustomer { get; set; } = new AddressResponse();
        public BookingInsertUpdate BookingInsertUpdateDetails { get; set; } = new BookingInsertUpdate();
    }

    public class BookingVehicleDetails
    {
        public long ElementKey { get; set; }
        public AddressResponse Registration { get; set; } = new AddressResponse();
        public int ModelKey { get; set; }
        public string MakeModelName { get; set; } = "";
        public string OwnerName { get; set; } = "";
        public string Code { get; set; } = "";
        public string ContactNumber { get; set; } = "";
    } 

    public class BookingInsertUpdate
    {
        public long ElementKey { get; set; }
        public int ProcessDetailsKey { get; set; }
        public int ProjectKey { get; set; }
        public AddressResponse Registration { get; set; } = new AddressResponse();
        public CodeBaseResponse ServiceType { get; set; } = new CodeBaseResponse();
        public DateTime BookingTime { get; set; } = new DateTime();
        public decimal Milage { get; set; }
        public string Remark { get; set; } = "";
    }
    public class BookingTabDetails
    {
        public int ProcessDetailsKey { get; set; }
        public int TaskID { get; set; }
        public string TaskName { get; set; } = "";
        public string VehicleID { get; set; } = "";
        public decimal Milage { get; set; }
        public string Make { get; set; } = "";
        public int Model { get; set; }
        public string ChassiNumber { get; set; } = "";
        public string EngineNumber { get; set; } = "";
        public string Fuel { get; set; } = "";
        public string Category { get; set; } = "";
        public string SubCategory { get; set; } = ""; 
        public DateTime DeliveryDate { get; set; } = new DateTime();
        public decimal PreMilage { get; set; }
        public string CustomerName { get; set; } = "";
        public string NIC { get; set; } = "";
        public string MobileBusiness { get; set; } = "";
        public string EmailBusiness { get; set; } = "";
        public string? Address { get; set; }
    }
    public class CustomerDetailsByVehicle
    {
        public string Code { get; set; } = "";
        public AddressResponse Customer { get; set; } = new AddressResponse();
        public string Mobile { get; set; } = "";
    }
}
