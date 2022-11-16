using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class UserMessage
    {
        
    }

    public class UserRequestValidation
    {
        public bool IsError { get; set; }
        public string? Message { get; set; }
    }
}
