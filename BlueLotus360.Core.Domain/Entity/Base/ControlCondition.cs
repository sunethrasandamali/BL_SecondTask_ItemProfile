using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class ControlCondition
    {
        public long CokditionKey { get; set; }  
        public string? ConditionName { get; set; }
        public string? ConditionCode1 { get; set; }
        public string? ConditionCode2 { get; set; }
        public string? ConditionOurCode { get; set; }
        public string? ConditionGroupCode { get; set; }
        public ControlCondition() 
        {

        }
    }
}
