using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class ItemResponse : BaseComboResponse
    {
        public long ItemKey { get; set; } = 1;

        public string ItemName { get; set; } = "";
        public string ItemCode { get; set; } = "";

        public CodeBaseResponse ItemCategory1;
        public CodeBaseResponse ItemCategory2;

        public CodeBaseResponse ItemType { get; set; }
        public int LineNumber { get; set; }
        public ItemResponse()
        {
            ItemCategory1=new CodeBaseResponse();
            ItemCategory2=new CodeBaseResponse();
            ItemType=new CodeBaseResponse();
        }

    }
}
