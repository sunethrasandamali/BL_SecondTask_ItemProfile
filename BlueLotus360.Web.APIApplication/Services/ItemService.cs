using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Extension;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class ItemService:IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BaseServerResponse<IList<ItemSimple>> GetItems(Company company,User user,ComboRequestDTO comboRequest)
        {
            BaseServerResponse<IList<ItemSimple>> Items = _unitOfWork.ItemRepository.GetItemsForTransaction(company, user, comboRequest);
            return Items;
        }

        public ItemRateResponse GetItemRateEx(RateRetrivalModel rateRetrivalModel, Company company, User user, CodeBaseResponse type)
        {
            rateRetrivalModel.TransactionTypeKey = type.CodeKey;
            return _unitOfWork.ItemRepository.GetItemRate(rateRetrivalModel, company, user);
        }

        public StockAsAtResponse GetStockAsAtByLocation(Company company, User user, StockAsAtRequest request)
        {
            return _unitOfWork.ItemRepository.GetStockAsAtByLocation(company, user, request);   
        }

        public IList<ItemSerialNumber> GetSerialNumbers(Company company, User user, ComboRequestDTO comboRequest)
        {
            BaseServerResponse<IList<ItemSerialNumber>> serialNumbers = _unitOfWork.ItemRepository.GetItemsSerialNoForTransaction(company, user, comboRequest);
            return serialNumbers.Value;
        }

        public StockAsAtResponse GetAvailableStock(Company company, User user, StockAsAtRequest request)
        {
            var stock=_unitOfWork.ItemRepository.GetAvailableStock(company, user, request);
            return stock.Value;
        }
    }
}
