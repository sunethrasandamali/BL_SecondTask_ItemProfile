using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Extended;
using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.Definitions
{
    public interface ICodeBaseConsumer
    {
        Task<BaseServerResponse<IList<CodeBase>>> ReadCategories(ComboRequestDTO request);

    }
}
