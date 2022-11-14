using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.DTOs.RequestDTO
{
    public class ComboRequestDTO : BaseModel
    {
        public int EntityKey { get; set; } = 1;


        public int RequestingElementKey { get; set; } = 1;


        public long PreviousKey { get; set; } = 1;

        public long TransactionTypeKey { get; set; } = 1;
        public IDictionary<string, object> AddtionalData { get; set; }=new Dictionary<string,object>();


        public string SearchQuery { get; set; } = "";

        public long Code1Key { get; set; } = 1;
        public long Code2Key { get; set; } = 1;

    }
}
