using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface IAccountRepository
    {
        BaseServerResponse<AddressResponse> GetAddressByAccount(Company company, User user, long AccountKey = 1);
        BaseServerResponse<AccountResponse> GetAccountByAddress(AddressResponse address, Company company, User user);
        BaseServerResponse<IList<AccountResponse>> GetAccounts(Company company, User user, ComboRequestDTO requestDTO);
    }
}
