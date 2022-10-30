using BlueLotus.UI.Application.Context;
using BlueLotus.UI.Application.Services.Defintions;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Extended;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Implementation
{
    public class CodeBaseService : BaseService, ICodeBaseService
    {
        public CodeBaseService(BLUIAppContext _context) : base(_context)
        {
        }

        public Task<BaseServerResponse<IList<CodeBase>>> ReadProductCategories(ComboRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
