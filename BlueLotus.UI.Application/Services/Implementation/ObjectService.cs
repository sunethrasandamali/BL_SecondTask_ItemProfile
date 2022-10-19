using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Object;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Implementation
{
    public class ObjectService : BaseService, IAppObjectService
    {
        public ObjectService(BLUIAppContext _context) : base(_context)
        {
        }

        public async Task<BaseServerResponse<BLUIElement>> FetchObjects(UIMenu uIMenu)
        {
            var menu = await _restAPIConsumer.ObjectConsumer.FetchObjects(uIMenu);
            return menu;
        }

        public async Task<BaseServerResponse<UIMenu>> FetchSideMenu()
        {
            var menu = await _restAPIConsumer.ObjectConsumer.FetchSideMenu();
            return menu;
        }
    }
}
