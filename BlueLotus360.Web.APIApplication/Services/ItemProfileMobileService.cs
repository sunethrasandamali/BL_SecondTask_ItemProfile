using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.ItemProfileMobile;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class ItemProfileMobileService : IItemProfileMobileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ItemProfileMobileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BaseServerResponse<IList<ItemSelectList>> GetItemProfileList(Company company, User user, ItemSelectListRequest request)
        {
            return _unitOfWork.ItemProfileMobileRepository.GetItemProfileList(company, user, request);
        }

        public bool InsertItem(Company company, User user, ItemSelectList request)
        {
            return _unitOfWork.ItemProfileMobileRepository.InsertItem(company, user, request);
        }

        public bool UpdateItem(Company company, User user, ItemSelectList request)
        {
            return _unitOfWork.ItemProfileMobileRepository.UpdateItem(company, user, request);
        }

        
    }
}
