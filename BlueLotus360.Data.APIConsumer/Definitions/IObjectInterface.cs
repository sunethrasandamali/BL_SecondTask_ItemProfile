using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.Definitions
{
    public interface IObjectAPIConsumer
    {

        Task<BaseServerResponse<UIMenu>> FetchSideMenu();

        Task<BaseServerResponse<BLUIElement>> FetchObjects(UIMenu uIMenu);

    }
}
