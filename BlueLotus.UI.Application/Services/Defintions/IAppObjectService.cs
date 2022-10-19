using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Defintions
{
    public interface IAppObjectService
    {
        Task<BaseServerResponse<UIMenu>>FetchSideMenu();
    }
}
