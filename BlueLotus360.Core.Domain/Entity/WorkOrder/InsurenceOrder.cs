using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.WorkOrder
{
    public class InsurenceOrder : WorkOrder
    {
        public IList<IRNDetails> IRNDetail { get; set; } = new List<IRNDetails>();

    }
    public class IRNDetails
    {
        public bool ShowDetails { get; set; }
        public string ServiceAdvisor { get; set; } = "";
        public string IRNNumber { get; set; } = "";
        public string VehicleNumber { get; set; } = "";
        public string Branch { get; set; } = "";
        public string IRNType { get; set; } = "";
        public DateTime CreationDateAndTime { get; set; } = DateTime.Now;
        public string Insurence { get; set; } = "";
        public IList<Particulars> Particulars { get; set; } = new List<Particulars>();
    }
    public class Particulars
    {
        public string ServiceOrMaterial { get; set; } = "";
        public decimal Amount { get; set; }

    }
}
