using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public  interface IMenuRepository
    {
        List<UIMenu> GetMenusByUserAndCompany(User user, Company company);
        List<UIMenu> GetMenuForReorder(User user, Company company);

        IList<UIMenu> MenuSearch(User user, Company company);

        UIMenu GetMenuByObjectKey(User user, Company company, int ObjectKey = 1);
        IList<UIMenu> GetPinnedMenu(User user, Company company);
        void UpdatePinnedMenu(User user, Company company, UIMenu request);
    }
}
