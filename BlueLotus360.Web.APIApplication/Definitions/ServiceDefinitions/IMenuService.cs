using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface IMenuService
    {
        List<UIMenu> GetMenusByUserAndCompanyService(User user, Company company);
        List<UIMenu> GetMenuForReorderService(User user, Company company);

        IList<UIMenu> MenuSearchService(User user, Company company);

        UIMenu GetMenuByObjectKeyService(User user, Company company, int ObjectKey = 1);
        IList<UIMenu> GetPinnedMenuService(User user, Company company);
        void UpdatePinnedMenuService(User user, Company company, UIMenu request);
    }
}
