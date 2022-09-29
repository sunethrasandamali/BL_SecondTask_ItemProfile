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
            var trnTyp = _unitOfWork.CodeBaseRepository.GetCodeByOurCodeAndConditionCode(company, user, uIObject.OurCode, "TrnTyp");
            CodeBaseResponse TransactionType = trnTyp.Value;

            transaction.TransactionType = new CodeBaseResponse();
            transaction.TransactionType.CodeKey = TransactionType.CodeKey;

            if (BaseComboResponse.GetKeyValue(transaction.Address) < 11)
            {
                var address = _unitOfWork.AccountRepository.GetAddressByAccount(company, user, transaction.Account.AccountKey);
                if(address!=null)
                    transaction.Address = address.Value;
            }
            if (!transaction.IsPersisted)
            {
                _unitOfWork.TransactionRepository.SaveGenericTransaction(company, user, new BaseServerResponse<BLTransaction>() { Value = transaction });

            }
            else if (transaction.IsPersisted)
            {
                _unitOfWork.TransactionRepository.UpdateGenericTransaction(company, user, transaction );
            }

            if (transaction.SerialNumber != null && !string.IsNullOrWhiteSpace(transaction.SerialNumber.SerialNumber))
            {
                transaction.SerialNumber.TransactionKey = transaction.TransactionKey;
                _unitOfWork.TransactionRepository.SaveOrUpdateTranHeaderSerialNumber(company, user, transaction.SerialNumber);
            }

            foreach (GenericTransactionLineItem line in transaction.InvoiceLineItems)
            {
                line.ElementKey = transaction.ElementKey;
                line.TransactionKey = transaction.TransactionKey;
                line.TransactionType = transaction.TransactionType;
                line.Address = transaction.Address;
                line.TransactionLocation = transaction.Location;
                line.EffectiveDate = transaction.TransactionDate;
                line.DeliveryDate = transaction.DeliveryDate;
                if (!line.IsPersisted)
                {
                    _unitOfWork.TransactionRepository.SaveTransactionLineItem(company, user, line);
                }
                else if (line.IsPersisted && line.IsDirty)
                {
                    _unitOfWork.TransactionRepository.UpdateTransactionLineItem(company, user, line);
                }


                foreach (ItemSerialNumber serialNumber in line.SerialNumbers)
                {
                    serialNumber.ItemTransactionKey = line.ItemTransactionKey;
                    serialNumber.ItemKey = line.TransactionItem.ItemKey;
                    serialNumber.PersistingElementKey = transaction.ElementKey;
                    _unitOfWork.TransactionRepository.SaveOrUpdateSerialNumber(company, user, serialNumber);
                }

            }
            _unitOfWork.TransactionRepository.PostAfterTranSaveActions(company, user, transaction.TransactionKey, transaction.ElementKey);

            return new BaseServerResponse<BLTransaction>();
        }

    }
}
