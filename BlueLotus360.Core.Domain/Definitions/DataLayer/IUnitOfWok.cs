using BlueLotus360.Core.Domain.Definitions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.DataLayer
{
    public interface IUnitOfWork
    {

      
        IUserRepository UserRepository { get;  }

        ICompanyRepository CompanyRepository { get; }
        IAPIRepository APIRepository { get; }
        IObjectRepository ObjectRepository { get; }
        ICodeBaseRepository CodeBaseRepository { get; }



    }
}
