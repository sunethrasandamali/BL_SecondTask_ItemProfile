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
        public DateTime FrmDt { get; set; }
        public DateTime ToDt { get; set; }
        public int Id { get; set; }
        public int PrcsDetKy { get; set; }
        public int PrjKy { get; set; }
        public int TaskID { get; set; }
        public string TaskNm { get; set; }
        public DateTime ReqDt { get; set; }
        public AddressResponse Registration { get; set; } = new AddressResponse();
        public int CusAdrKy { get; set; }
        public string CusNm { get; set; }
        public CodeBaseResponse ServiceType { get; set; } = new CodeBaseResponse();
        public decimal Milage { get; set; }
        public string Rem { get; set; }
        public string Mobile { get; set; }
        public BookingVehicleDetails VehicleDetails { get; set; } = new BookingVehicleDetails();
        public BookingTabDetails TabDetails { get; set; } = new BookingTabDetails();
        public IList<CusDetailsByVeh> CusDetails { get; set; } = new List<CusDetailsByVeh>();
        public AddressResponse SelectedCus { get; set; } = new AddressResponse();
    }

    public class BookingVehicleDetails
    {
        public long ElementKey { get; set; }
        public AddressResponse Registration { get; set; } = new AddressResponse();
        public int ModelKy { get; set; }
        public string MakeModelNm { get; set; }
        public string OwnerNm { get; set; }
        public string Code { get; set; }
        public string ContactNo { get; set; }
    }

    public class BookingInsertUpdate
    {
        public long ElementKey { get; set; }
        public int PrcsDetKy { get; set; }
        public int PrjKy { get; set; }
        public AddressResponse Registration { get; set; } = new AddressResponse();
        public CodeBaseResponse ServiceType { get; set; } = new CodeBaseResponse();
        public DateTime? BookingTime { get; set; }
        public decimal Milage { get; set; }
        public string Rem { get; set; }
    }
    public class BookingTabDetails
    {
        public int PrcsDetKy { get; set; }
        public int TaskID { get; set; }
        public string TaskNm { get; set; }
        public string VehID { get; set; }
        public decimal Milage { get; set; }
        public string Make { get; set; }
        public int Model { get; set; }
        public string ChassiNO { get; set; }
        public string EngineNo { get; set; }
        public string Fuel { get; set; }
        public string Cat { get; set; }
        public string SubCat { get; set; }
        public DateTime DelDt { get; set; }
        public decimal PreMilage { get; set; }
        public string CusNm { get; set; }
        public string NIC { get; set; }
        public string MobileBusiness { get; set; }
        public string EmailBusiness { get; set; }
        public string Address { get; set; }
    }
    //public class NewCustomer 
    //{
    //    public long ElementKey { get; set; }
    //    public DateTime RegDate { get; set; } = new DateTime();
    //    public CodeBaseResponse Province { get; set; } = new CodeBaseResponse();
    //    public string RegNo { get; set; }
    //    public string ChassiNo { get; set; }
    //    public CodeBaseResponse Make { get; set; } = new CodeBaseResponse();
    //    public CodeBaseResponse Model { get; set; } = new CodeBaseResponse();
    //    public CodeBaseResponse MakeYr { get; set; } = new CodeBaseResponse();//ItmDt2
    //    public CodeBaseResponse Category { get; set; } = new CodeBaseResponse(); //AdrCat1Ky
    //    public CodeBaseResponse SubCategory { get; set; } = new CodeBaseResponse(); //AdrCat2Ky
    //    public CodeBaseResponse MaintPckg { get; set; } = new CodeBaseResponse();//AdrCat6
    //    public string CusAdrNm { get; set; }
    //    public string NIC { get; set; }
    //    public string Email { get; set; }
    //    public string Message { get; set; }
    //    public bool HasError { get; set; }

    //}
    public class CusDetailsByVeh
    {
        public string Code { get; set; }
        public AddressResponse Customer { get; set; } = new AddressResponse();
        public string Mobile { get; set; }
    }
}
