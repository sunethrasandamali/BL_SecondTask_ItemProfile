using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Definitions.Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.UnitOfWork
{
    public class APIUnitOfWork:IUnitOfWork
    {
        #region Privates
        private IUserRepository _userRepository;
        private ICompanyRepository _companyRepository;
        private IAPIRepository _apiRepository;
        private IObjectRepository _objectRepository;
        private ICodeBaseRepository _codeBaseRepository;
        private IAccountRepository _accountRepository;
        private ITransactionRepository _transactionRepository;
        private IOrderRepository _orderRepository;
        private IItemRepository _itemRepository;
        private IMenuRepository _menuRepository;
        #endregion

        private readonly RestClient restClient;

        public IUserRepository UserRepository => throw new NotImplementedException();

        public IMenuRepository MenuRepository => throw new NotImplementedException();

        public ICompanyRepository CompanyRepository => throw new NotImplementedException();

        public IAPIRepository APIRepository => throw new NotImplementedException();

        public IObjectRepository ObjectRepository => throw new NotImplementedException();

        public ICodeBaseRepository CodeBaseRepository => throw new NotImplementedException();

        public IAccountRepository AccountRepository => throw new NotImplementedException();

        public ITransactionRepository TransactionRepository => throw new NotImplementedException();

        public IOrderRepository OrderRepository => throw new NotImplementedException();

        public IItemRepository ItemRepository => throw new NotImplementedException();

        public IUnitRepository UnitMasRepository => throw new NotImplementedException();

        public IAddressRepository AddressRepository => throw new NotImplementedException();

        public ICommonRepository CommonRepository => throw new NotImplementedException();

        public APIUnitOfWork()
        {
            restClient = new RestClient();
           
        }
    }
}
