using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface ITransactionRepository
    {
        BaseServerResponse<BLTransaction> SaveGenericTransaction(Company company, User user, BaseServerResponse<BLTransaction> transaction);
        void UpdateGenericTransaction(Company company, User user, BLTransaction transaction);
        void SaveOrUpdateTranHeaderSerialNumber(Company company, User user, ItemSerialNumber serialNumber);
        void SaveTransactionLineItem(Company company, User user, GenericTransactionLineItem lineItem);
        void UpdateTransactionLineItem(Company company, User user, GenericTransactionLineItem lineItem);
        void SaveOrUpdateSerialNumber(Company company, User user, ItemSerialNumber serialNumber);
        void PostAfterTranSaveActions(Company company, User user, long TransactionKey, long ObjectKey);
        BaseServerResponse<IList<GenericTransactionFindResponse>> GenericFindTransaction(Company company, User user, TransactionFindRequest request);
        BaseServerResponse<BLTransaction> GenericOpenTransaction(Company company, User user, TransactionOpenRequest trnRequest);
        BaseServerResponse<IList<GenericTransactionLineItem>> GenericallyGetTransactionLineItems(Company company, User user, TransactionOpenRequest request);
        BaseServerResponse<BLTransaction> GenericOpenTransactionV2(Company company, User user, TransactionOpenRequest trnRequest);
    }
}
