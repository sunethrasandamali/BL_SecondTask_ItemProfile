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
        void SaveGenericTransaction(Company company, User user, BaseServerResponse<BLTransaction> transaction);
        void UpdateGenericTransaction(Company company, User user, BLTransaction transaction);
        void SaveOrUpdateTranHeaderSerialNumber(Company company, User user, ItemSerialNumber serialNumber);
        void SaveTransactionLineItem(Company company, User user, GenericTransactionLineItem lineItem);
        void UpdateTransactionLineItem(Company company, User user, GenericTransactionLineItem lineItem);
        void SaveOrUpdateSerialNumber(Company company, User user, ItemSerialNumber serialNumber);
        void PostAfterTranSaveActions(Company company, User user, long TransactionKey, long ObjectKey);
    }
}
