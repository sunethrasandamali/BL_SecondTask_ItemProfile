using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.WorkOrder
{
    public class WorkOrder : Order
    {
        public CodeBaseResponse WorkOrderCategory { get; set; }
        public Vehicle VehicleDetails { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string WorkOrderStaus { get; set; }
        public decimal PrincipalPercentage { get; set; }
        public decimal PrincipalValue { get; set; }
        public decimal CarmartlPercentage { get; set; }
        public decimal CarmartValue { get; set; }
        public CodeBaseResponse Department { get; set; }
        public IList<string> CustomerComplaints { get; set; }
        public IList<Material> Materials { get; set; }
        public IList<Service> Services { get; set; }
        public IList<WorkOrder> JobHistory { get; set; }

        public WorkOrder()
        {
            WorkOrderCategory  = new CodeBaseResponse();    
            VehicleDetails = new Vehicle();
            Department = new CodeBaseResponse();
            CustomerComplaints = new List<string>();
            Materials = new List<Material>();
            Services = new List<Service>();
            JobHistory = new List<WorkOrder>();
        }
    }

    public class Vehicle
    {
        public AddressResponse VehicleRegistration { get; set; }
        public AddressMaster RegisteredCustomer { get; set; }
        public string VehicleID { get; set; } = "";
        public string ChasisNumber { get; set; } = "";
        public string EngineNumber { get; set; } = "";
        public string Category { get; set; } = "";
        public string SubCategory { get; set; } = "";
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public Warranty VehicleWarrannty { get; set; }
        public string MaintenancePackage { get; set; }
        public decimal CurrentMilage { get; set; }
        public decimal PreviousMilage { get; set; }
        public string Fuel { get; set; } = "";
        public Vehicle()
        {
            VehicleWarrannty = new Warranty();
            VehicleRegistration = new AddressResponse();
            RegisteredCustomer = new AddressMaster();
        }
    }

    public class Warranty
    {
        public string WarranrtyStatus { get; set; } = "";
        public DateTime WarrantyStartDate { get; set; } = DateTime.Now;
        public DateTime WarrantyEndDate { get; set; } = DateTime.Now;
    }

    public class Material
    {
        public UnitResponse Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrinciplePrecentage { get; set; }
        public decimal PrincipleAmount { get; set; }
        public decimal CarmartPrecentage { get; set; }
        public decimal CarmartAmount { get; set; }
        public decimal CustomerAmount { get; set; }
        public int IsActive { get; set; }
        public Material()
        {
            Unit = new UnitResponse();
        }
    }

    public class Service
    {
        public decimal Time { get; set; }
        public UnitResponse Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrinciplePrecentage { get; set; }
        public decimal PrincipleAmount { get; set; }
        public decimal CarmartPrecentage { get; set; }
        public decimal CarmartAmount { get; set; }
        public decimal CustomerAmount { get; set; }
        public int IsActive { get; set; }
        public Service()
        {
            Unit = new UnitResponse();
        }
    }
}
