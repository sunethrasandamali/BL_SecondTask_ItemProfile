using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.DTOs.RequestDTO
{
    public class UnitComboRequestDTO : ComboRequestDTO
    {
        public long ItemKey { get; set; } = 1;
    }
}
