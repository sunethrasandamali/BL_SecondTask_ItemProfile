using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class MenuService:IMenuService
    {
        public readonly IUnitOfWork _unitOfWork;
        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UIMenu GetMenuByObjectKeyService(User user, Company company, int ObjectKey = 1)
        {
            return _unitOfWork.MenuRepository.GetMenuByObjectKey(user, company, ObjectKey); 
        }

        public List<UIMenu> GetMenuForReorderService(User user, Company company)
        {
            return _unitOfWork.MenuRepository.GetMenuForReorder(user,company);
        }

        public List<UIMenu> GetMenusByUserAndCompanyService(User user, Company company)
        {
            return _unitOfWork.MenuRepository.GetMenusByUserAndCompany(user,company);
        }

        public IList<UIMenu> GetPinnedMenuService(User user, Company company)
        {
            return _unitOfWork.MenuRepository.GetPinnedMenu(user,company);
        }

        public IList<UIMenu> MenuSearchService(User user, Company company)
        {
            return _unitOfWork.MenuRepository.MenuSearch(user,company);
        }

        public void UpdatePinnedMenuService(User user, Company company, UIMenu request)
        {
             _unitOfWork.MenuRepository.UpdatePinnedMenu(user,company,request);
        }
    }
}
