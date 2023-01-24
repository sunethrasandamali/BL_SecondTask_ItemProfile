using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.ItemProfileMobile;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface IItemProfileMobileRepository
    {
        BaseServerResponse<IList<ItemSelectList>> GetItemProfileList(Company company, User user, ItemSelectListRequest request);
        bool InsertItem(Company company, User user, ItemSelectList request);
        bool UpdateItem(Company company, User user, ItemSelectList request);

    }
}
