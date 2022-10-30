using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Extended;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Services.Defintions
{
    public interface ICodeBaseService
    {
        Task<BaseServerResponse<IList<CodeBase>>> ReadProductCategories(ComboRequestDTO requestDTO);
    }
}
