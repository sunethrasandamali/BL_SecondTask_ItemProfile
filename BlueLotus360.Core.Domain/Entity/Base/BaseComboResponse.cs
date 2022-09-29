using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{
    public class BaseComboResponse
    {
        public bool IsDefault { get; set; }

        public static long GetKeyValue(BaseComboResponse response)
        {
            if (response == null)
            {
                return 1;
            }

            if (response is CodeBaseSimple)
            {
                return (response as CodeBaseSimple).CodeKey;
            }
            if (response is Address)
            {
                return (response as Address).AddressKey;
            }
            if (response is Account)
            {
                return (response as Account).AccountKey;
            }
            if (response is UnitSimple)
            {
                return (response as UnitSimple).UnitKey;
            }
            if (response is Item)
            {
                return (response as Item).ItemKey;
            }

            if (response is Project)
            {
                return (response as Project).ProjectKey;
            }

            return 1;
        }

        public static long GetKeyValue2(BaseComboResponse response)
        {
            if (response == null)
            {
                return 1;
            }
            if (response is Item)
            {
                return (response as Item).ItemKey;
            }
            if (response is CodeBaseSimple)
            {
                return (response as CodeBaseSimple).CodeKey;
            }
            if (response is Address)
            {
                return (response as Address).AddressKey;
            }
            return 1;
        }
        public int IsActive { get; set; }
        public int IsApproved { get; set; }

        public static bool IsEntityWithDefaultValue(BaseComboResponse response)
        {
            return GetKeyValue(response) < 11;
        }


    }
}
