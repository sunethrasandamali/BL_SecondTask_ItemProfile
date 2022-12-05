using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class TransactionPermission
    {
        public int IsAllowInsert { get; set; }
        public int IsAllowUpdate { get; set; }
        public int IsAllowDelete { get; set; }
        public int IsAllowSourceDocumentPrint { get; set; }
        public int IsAlwAcs { get; set; }
        public int IsAllowAprrove { get; set; }
        public string? Message { get; set; }

    }
}
