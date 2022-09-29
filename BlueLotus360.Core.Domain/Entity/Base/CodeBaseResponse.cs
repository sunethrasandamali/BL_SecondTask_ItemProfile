using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class CodeBaseResponse:BaseComboResponse
    {
        public long CodeKey { get; set; } = 1;
        public string Code { get; set; } = "";
        public string ConditionCode { get; set; } = "";
        public string OurCode { get ; set ; }
        public string CodeName { get; set; } = "";

        public string CodeNameOnly { get; set; }


        public CodeBaseResponse()
        {

        }

        public CodeBaseResponse(long Key)
        {
            this.CodeKey = Key;
        }

        public CodeBaseResponse(long Key, string codeName)
        {
            this.CodeKey = Key;
            this.Code = codeName;
        }
    }

    
}
