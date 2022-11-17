using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface IItemRepository
    {
        decimal GetCostPriceByLocAndItmKy(Company company, CodeBaseResponse location, DateTime effectiveDate, long ItemKey, int ProjectKey = 1);
        BaseServerResponse<IList<ItemSimple>> GetItemsForTransaction(Company company, User user, ComboRequestDTO dTO);
        ItemRateResponse GetItemRate(RateRetrivalModel rateRetrivalModel, Company company, User user);
        StockAsAtResponse GetStockAsAtByLocation(Company company, User user, StockAsAtRequest request);
        BaseServerResponse<IList<ItemSerialNumber>> GetItemsSerialNoForTransaction(Company company, User user, ComboRequestDTO dTO);
        BaseServerResponse<StockAsAtResponse> GetAvailableStock(Company company, User user, StockAsAtRequest request);
    }
}
