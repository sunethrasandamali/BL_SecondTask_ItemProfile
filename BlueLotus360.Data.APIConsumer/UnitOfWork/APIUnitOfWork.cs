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
        public APIUnitOfWork()
        {
            restClient = new RestClient();
           
        }
    }
}
