using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus360.Core.Domain.Entity.Transaction
{
    public class BLTransaction : BaseEntity
    {
        public long TransactionKey { get; set; } = 1;
        public string TransactionNumber { get; set; }
        public long ElementKey { get; set; } = 1;
        public CodeBaseSimple TransactionType { get; set; } = new CodeBaseSimple();
        public decimal Amount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal HeaderDiscountAmount { get; set; }
        public CodeBaseSimple TransactionCurrency { get; set; } = new CodeBaseSimple();
        public decimal TransactionExchangeRate { get; set; }
        public string DocumentNumber { get; set; }
        public string YourReference { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public DateTime YourReferenceDate { get; set; }
        public CodeBaseSimple PaymentTerm { get; set; } = new CodeBaseSimple();
        public int IsPrinted { get; set; }
        public int IsRecurrence { get; set; }
        public DateTime ReminderDate { get; set; }
        public int IsLocked { get; set; }
        public CodeBaseSimple AccessLevel { get; set; } = new CodeBaseSimple();
        public CodeBaseSimple ConfidentialLevel { get; set; } = new CodeBaseSimple();
        public CodeBaseSimple ApproveState { get; set; } = new CodeBaseSimple();
        public long ObjectKey { get; set; } = 1;
        public Project TransactionProject { get; set; }
        public CodeBaseSimple BussinessUnit { get; set; } = new CodeBaseSimple();
        public long HeaderTransferLinkKey = 1;
        public long ContraAccountObjectKey { get; set; } = 1;
        public Account ContraAccount { get; set; } = new Account();
        public CodeBaseSimple Location { get; set; } = new CodeBaseSimple();
        public string Description { get; set; } = "";
        public string Remarks { get; set; } = "";
        public Item CustomItem { get; set; } = new Item();
        public CodeBaseSimple Shift { get; set; } = new CodeBaseSimple();
        public decimal CommisionPercentage { get; set; }

        public int IsQuantityPosted { get; set; }
        public int IsValuePosted { get; set; }
        public int IsItemTrnValue { get; set; }
        public decimal Amount1 { get; set; }
        public decimal Amount2 { get; set; }
        public decimal Amount3 { get; set; }
        public decimal Amount4 { get; set; }
        public decimal Amount5 { get; set; }
        public decimal Amount6 { get; set; }
        public string OtherNumber { get; set; }
        public CodeBaseSimple Code1 { get; set; } = new CodeBaseSimple();
        public CodeBaseSimple Code2 { get; set; } = new CodeBaseSimple();
        public Address Rep { get; set; }
        public decimal RepCommissionPercentage { get; set; }
        public long OrderDetailKey { get; set; } = 1;
        public long AccountObjectKey { get; set; } = 1;
        public Account Account { get; set; } = new Account();
        public Address Address { get; set; } = new Address();
        public long OrderNumberKey { get; set; } = 1;
        public Address Address1 { get; set; } = new Address();
        public Address Address2 { get; set; } = new Address();
        public long FromOrderKey { get; set; } = 1;
        public long FromTransactionKey { get; set; } = 1;
        public long RecurenceDeliveryKey { get; set; } = 1;
        public string TransactionImageFilePath { get; set; }
        public int IsMultiCredit { get; set; }
        public decimal ItemTaxType1 { get; set; }
        public decimal ItemTaxType2 { get; set; }
        public decimal ItemTaxType3 { get; set; }
        public decimal ItemTaxType4 { get; set; }
        public decimal ItemTaxType5 { get; set; }
        public bool IsFromImport { get; set; }
        public bool IsHold { get; set; }
        public bool IsBlock { get; set; }
        public CodeBaseSimple ApproveReason { get; set; } = new CodeBaseSimple();

        public ItemSerialNumber SerialNumber { get; set; }


        public DateTime DeliveryDate { get; set; }
        //
        public DateTime DueDate { get; set; }
        public string Prefix { get; set; }
        public string PreviewURL { get; set; }
        public int EntUsrKy { get; set; }
        public IList<GenericTransactionLineItem> InvoiceLineItems { get; set; }

        public decimal TotalMarkupValue { get; set; }
        public decimal MarkupPercentage { get; set; }

        public bool IsVarcar1On { get; set; }
        public decimal Quantity1 { get; set; }

        public BLTransaction()
        {
            Location = new CodeBaseSimple();
            PaymentTerm = new CodeBaseSimple();
            Address = new Address();
            InvoiceLineItems = new List<GenericTransactionLineItem>();
            YourReferenceDate = DateTime.Now;
            SerialNumber = new ItemSerialNumber();
        }


        public decimal GetOrderTotalWithDiscounts()
        {
            return InvoiceLineItems.Sum(x => x.GetLineTotalWithDiscount());
        }

        public decimal GetOrderTotalWithoutDiscounts()
        {
            return InvoiceLineItems.Sum(x => x.GetLineTotalWithoutDiscount());
        }

        public decimal GetOrderRateTotal()
        {
            return InvoiceLineItems.Sum(x => x.TransactionRate);
        }

        public decimal GetOrderDiscountTotal()
        {
            return InvoiceLineItems.Sum(d => d.GetLineDiscount());
        }

        public decimal GetQuantityTotal()
        {
            return InvoiceLineItems.Sum(q => q.TransactionQuantity);
        }


        public void AddGridItems(GenericTransactionLineItem item)
        {
            InvoiceLineItems.Add(item);

        }


    }
}
