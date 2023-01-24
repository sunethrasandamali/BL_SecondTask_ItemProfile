using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.ItemProfileMobile
{
        public class ItemSelectListRequest
        {
            public long ElementKey { get; set; }

            public int ItmTypKy { get; set; } = 1;

            //public int Dept { get; set; } = 1;

            //public int Cat { get; set; } = 1;

            //public int FrmRow { get; set; } = 0;

            //public int ToRow { get; set; } = 999999;

            //public byte OnlyisAct { get; set; } = 1;

            //public string ItmCd { get; set; } = string.Empty;

            //public string ItmNm { get; set; } = string.Empty;
        }

        public class ItemSelectList
        {
            public int ItmKy { get; set; }
            public string ItemName { get; set; }
            public string ItemCode { get; set; }
            public CodeBaseResponse ItemType { get; set; } = new CodeBaseResponse();
            public UnitResponse ItemUnit { get; set; } = new UnitResponse();
            public ItemResponse ParentItem { get; set; } = new ItemResponse();
            public bool IsAct { get; set; }
            public bool IsApprove { get; set; }
        }
    
}
