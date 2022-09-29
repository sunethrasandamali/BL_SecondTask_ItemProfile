using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class TransactionService : ITransactionService
    {
        public readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseServerResponse<BLTransaction> SaveTransaction(BLTransaction transaction, Company company, User user,UIObject uIObject)
        {
                       
           
            //if (BaseComboResponse.GetKeyValue(transaction.Address) < 11)
            //{
            //    transaction.Address = UOW.AccountRepository.GetAddressByAccount(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, transaction.Account.AccountKey);
            //}
            //if (!transaction.IsPersisted)
            //{
            //    UOW.TransactionRepository.SaveGenericTransaction(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, transaction);

            //}
            //else if (transaction.IsPersisted)
            //{
            //    UOW.TransactionRepository.UpdateGenericTransaction(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, transaction);
            //}

            //if (transaction.SerialNumber != null && !string.IsNullOrWhiteSpace(transaction.SerialNumber.SerialNumber))
            //{
            //    transaction.SerialNumber.TransactionKey = transaction.TransactionKey;
            //    UOW.TransactionRepository.SaveOrUpdateTranHeaderSerialNumber(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, transaction.SerialNumber);
            //}

            //foreach (GenericTransactionLineItem line in transaction.InvoiceLineItems)
            //{
            //    line.ElementKey = transaction.ElementKey;
            //    line.TransactionKey = transaction.TransactionKey;
            //    line.TransactionType = transaction.TransactionType;
            //    line.Address = transaction.Address;
            //    line.TransactionLocation = transaction.Location;
            //    line.EffectiveDate = transaction.TransactionDate;
            //    line.DeliveryDate = transaction.DeliveryDate;
            //    if (!line.IsPersisted)
            //    {
            //        UOW.TransactionRepository.SaveTransactionLineItem(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, line);
            //    }
            //    else if (line.IsPersisted && line.IsDirty)
            //    {
            //        UOW.TransactionRepository.UpdateTransactionLineItem(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, line);
            //    }


            //    foreach (ItemSerialNumber serialNumber in line.SerialNumbers)
            //    {
            //        serialNumber.ItemTransactionKey = line.ItemTransactionKey;
            //        serialNumber.ItemKey = line.TransactionItem.ItemKey;
            //        serialNumber.PersistingElementKey = transaction.ElementKey;
            //        UOW.TransactionRepository.SaveOrUpdateSerialNumber(Auth.AuthenticatedCompany, Auth.AuthenticatedUser, serialNumber);
            //    }

            //}
            //UOW.TransactionRepository.PostAfterTranSaveActions(Auth.AuthenticatedCompany,
            //    Auth.AuthenticatedUser, transaction.TransactionKey, transaction.ElementKey);

            return new BaseServerResponse<BLTransaction>();
        }

    }
}
