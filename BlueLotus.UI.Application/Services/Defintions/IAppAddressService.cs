using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Defintions
{
    public interface IAppAddressService
    {
        Task<BaseServerResponse<IList<AddressResponse>>> GetAddressMAUI(ComboRequestDTO requestDTO);
    }
}
