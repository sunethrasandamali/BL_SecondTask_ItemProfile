﻿using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.WorkOrder
{
    public class VehicleSearch
    {
        public long ObjectKey { get; set; }
        public AddressResponse VehicleRegistration { get; set; }
        public ItemSerialNumber VehicleSerialNumber { get; set; }
        public AddressResponse RegisteredCustomer { get; set; }
        public AddressResponse RegisterNIC { get; set; }
        public VehicleSearch()
        {
            VehicleRegistration = new AddressResponse();
            RegisteredCustomer = new AddressResponse();
            RegisterNIC = new AddressResponse();
            VehicleSerialNumber = new ItemSerialNumber();
        }
    }
    public class WorkOrder : GenericOrder
    {
        public CodeBaseResponse WorkOrderCategory { get; set; }
        public Vehicle SelectedVehicle { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string WorkOrderStaus { get; set; }
        public decimal PrincipalPercentage { get; set; }
        public decimal PrincipalValue { get; set; }
        public decimal CarmartlPercentage { get; set; }
        public decimal CarmartValue { get; set; }
        public CodeBaseResponse Department { get; set; }
        public Estimation WorkOrderSimpleEstimation { get; set; }
        public IList<CustomerComplain> CustomerComplains { get; set; }
        public IList<Material> Materials { get; set; }
        public IList<Service> Services { get; set; }
        public IList<WorkOrder> JobHistory { get; set; }

        public WorkOrder()
        {
            WorkOrderCategory = new CodeBaseResponse();
            SelectedVehicle = new Vehicle();
            Department = new CodeBaseResponse();
            WorkOrderSimpleEstimation = new Estimation();
            CustomerComplains = new List<CustomerComplain>();
            Materials = new List<Material>();
            Services = new List<Service>();
            JobHistory = new List<WorkOrder>();
        }
    }

    public class Vehicle
    {
        public long ObjectKey { get; set; }
        public ItemResponse VehicleRegistration { get; set; }
        public AddressResponse VehicleAddress { get; set; }
        public AddressMaster RegisteredCustomer { get; set; }
        public ItemSerialNumber SerialNumber { get; set; }
        public CodeBaseResponse Category { get; set; }
        public CodeBaseResponse SubCategory { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public Warranty VehicleWarrannty { get; set; }
        public string MaintenancePackage { get; set; } = "";
        public decimal CurrentMilage { get; set; }
        public decimal PreviousMilage { get; set; }
        public string Fuel { get; set; } = "";
        public int IsActive { get; set; }
        public Vehicle()
        {
            VehicleWarrannty = new Warranty();
            VehicleRegistration = new ItemResponse();
            RegisteredCustomer = new AddressMaster();
            SerialNumber = new ItemSerialNumber();
            Category = new CodeBaseResponse();
            SubCategory = new CodeBaseResponse();
            VehicleAddress=new AddressResponse();
        }
    }

    public class Warranty
    {
        public string WarranrtyStatus { get; set; } = "";
        public DateTime WarrantyStartDate { get; set; } = DateTime.Now;
        public DateTime WarrantyEndDate { get; set; } = DateTime.Now;
    }

    public class Material : OrderItem
    {
        public UnitResponse Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrinciplePrecentage { get; set; }
        public decimal PrincipleAmount { get; set; }
        public decimal CarmartPrecentage { get; set; }
        public decimal CarmartAmount { get; set; }
        public decimal CustomerAmount { get; set; }
        public int IsSelected { get; set; }
        public Material()
        {
            Unit = new UnitResponse();
        }
    }

    public class Service : OrderItem
    {
        public int ServiceID { get; set; }
        public decimal Time { get; set; }
        public UnitResponse Unit { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrinciplePrecentage { get; set; }
        public decimal PrincipleAmount { get; set; }
        public decimal CarmartPrecentage { get; set; }
        public decimal CarmartAmount { get; set; }
        public decimal CustomerAmount { get; set; }
        public int IsSelected { get; set; }
        public Service()
        {
            Unit = new UnitResponse();
        }
    }

    public class CustomerComplain
    {
        public int ComplainID { get; set; }
        public string? ComplainName { get; set; }
        public int IsActive { get; set; }
    }

    public class Estimation
    {
        public IList<Material> EstimatedMaterials { get; set; }
        public IList<Service> EstimatedServices { get; set; }
        public decimal TotalValue { get; set; }
        public Estimation()
        {
            EstimatedMaterials = new List<Material>();
            EstimatedServices = new List<Service>();
        }

    }
}