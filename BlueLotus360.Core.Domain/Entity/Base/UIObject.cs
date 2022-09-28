using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class UIObject:BaseEntity
    {
        public int ObjectKey { get; set; } = 1;
        public string ObjectName { get; set; }
        public string ObjectCaption { get; set; }
        public string OurCode1 { get; set; }
        public string OurCode2 { get; set; }

      
    }
}
