using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Extended
{
    public class CodeBase:CodeBaseResponse
    {
        public   string CodeExtraCharacter1 { get; set; }=String.Empty;

        public CodeBase(long CodeKey=1):base(CodeKey)
        {

        }
    }
}
