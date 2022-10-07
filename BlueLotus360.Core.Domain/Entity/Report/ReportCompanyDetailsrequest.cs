using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Report
{
    public class ReportCompanyDetailsRequest
    {
        public CodeBaseResponse BussinessUnit { get; set; }=new CodeBaseResponse();
        public CodeBaseResponse Location { get; set; }=new CodeBaseResponse();
        public long TransactionKey { get; set; } = 1;

        public long OrderKey { get; set; } = 1;
        public long EmployeeKey { get; set; } = 1;


    }
}
