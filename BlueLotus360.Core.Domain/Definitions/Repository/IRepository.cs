using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface IRepository<T> where T : BaseEntity

    {

        void Create(T entity);
        BaseServerResponse<T> GetByID(int Id);
        BaseServerResponse<T> GetByID(Guid Id);
        void Update(T entity);
        void Delete(T entity);
        long GetEntityCount(Company company);


    }
}
