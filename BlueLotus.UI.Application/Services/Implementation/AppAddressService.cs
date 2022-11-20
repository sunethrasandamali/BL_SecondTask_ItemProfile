using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Implementation
{
    public class AppAddressService : BaseService, IAppAddressService
    {
        public AppAddressService(BLUIAppContext _context) : base(_context)
        {
        }

        public async Task<BaseServerResponse<IList<AddressResponse>>> GetAddressMAUI(ComboRequestDTO requestDTO)
        {
            return await _restAPIConsumer.AddressConsumer.GetMAUIAddress(requestDTO);
        }
    }
}
