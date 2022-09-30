using System;
using System.Collections.Generic;
using System.Data;
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

            if (response is CodeBaseResponse)
            {
                return (response as CodeBaseResponse).CodeKey;
            }
            if (response is AddressResponse)
            {
                return (response as AddressResponse).AddressKey;
            }
            if (response is AccountResponse)
            {
                return (response as AccountResponse).AccountKey;
            }
            if (response is UnitResponse)
            {
                return (response as UnitResponse).UnitKey;
            }
            if (response is ItemResponse)
            {
                return (response as ItemResponse).ItemKey;
            }

            if (response is ProjectResponse)
            {
                return (response as ProjectResponse).ProjectKey;
            }

            return 1;
        }

        public static long GetKeyValue2(BaseComboResponse response)
        {
            if (response == null)
            {
                return 1;  
            }
            if (response is ItemResponse)
            {
                return (response as ItemResponse).ItemKey;
            }
            if (response is CodeBaseResponse)
            {
                return (response as CodeBaseResponse).CodeKey;
            }
            if (response is AddressResponse)
            {
                return (response as AddressResponse).AddressKey;
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
