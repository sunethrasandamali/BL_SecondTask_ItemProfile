using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface ITransactionService
    {
        BaseServerResponse<BLTransaction> SaveTransaction(BLTransaction transaction,Company company,User user,UIObject uIObject,CodeBaseResponse trnTyp);
        BaseServerResponse<IList<GenericTransactionFindResponse>> FindTransaction(Company company, User user, TransactionFindRequest request);
        BaseServerResponse<BLTransaction> OpenTransaction(Company company, User user, TransactionOpenRequest request);
        BaseServerResponse<IList<GenericTransactionLineItem>> GetTransactionLineItems(Company company, User user, TransactionOpenRequest request);
    }
}
