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
        public   string CodeExtraCharacter2 { get; set; }=String.Empty;
        public   int CodeInt1 { get; set; }
        public   int CodeInt2 { get; set; }
        public   int CodeInt3 { get; set; }
        public   DateTime CodeDate1 { get; set; }
        public   DateTime CodeDate2 { get; set; }
        public   DateTime CodeDate3 { get; set; }
        public   DateTime CodeDate4 { get; set; }



        public CodeBase(long CodeKey=1):base(CodeKey)
        {

        }
    }
}
