using BlueLotus360.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.Base
{

    public class Order
    {
        private int supplierKey;
        private string itemName;
        private string itemCode;
        private string eAN;
        private int itemKey;
        private int locationKey;
        private decimal priceAfterTax;
        private decimal qty;
        private decimal discount;
        private string trnDate;
        private decimal taxPercentage;
        private decimal unitPrice;
        private int objKy;
        private string docNo;
        private string yurRef;
        private decimal taxValue;
        private decimal subTotalDiscount;
        private Guid posTrnKy;
        private int liNo;
        private string ourCd;
        private int isApr;
        private Guid posItmTrnKy;
        private int wrkstnKy;
        private int trnTypKy;
        private int trnNo;
        private int aprStsKy;
        private int isZeroQty;
        private int trnKy;
        private int itmTrnKy;



        public decimal Qty { get => qty; set => qty = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public int ItemKey { get => itemKey; set => itemKey = value; }
        public int LocationKey { get => locationKey; set => locationKey = value; }
        public int SupplierKey { get => supplierKey; set => supplierKey = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string EAN { get => eAN; set => eAN = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public decimal PriceAfterTax { get => priceAfterTax; set => priceAfterTax = value; }
        public decimal Discount { get => discount; set => discount = value; }
        public decimal TaxPercentage { get => taxPercentage; set => taxPercentage = value; }
        public string TrnDate { get => trnDate; set => trnDate = value; }
        public int ObjKy { get => objKy; set => objKy = value; }
        public string DocNo { get => docNo; set => docNo = value; }
        public string YurRef { get => yurRef; set => yurRef = value; }
        public decimal TaxValue { get => taxValue; set => taxValue = value; }
        public decimal SubTotalDiscount { get => subTotalDiscount; set => subTotalDiscount = value; }
        public Guid PosTrnKy { get => posTrnKy; set => posTrnKy = value; }
        public int LiNo { get => liNo; set => liNo = value; }
        public string OurCd { get => ourCd; set => ourCd = value; }
        public int IsApr { get => isApr; set => isApr = value; }
        public Guid PosItmTrnKy { get => posItmTrnKy; set => posItmTrnKy = value; }
        public int WrkstnKy { get => wrkstnKy; set => wrkstnKy = value; }
        public int TrnTypKy { get => trnTypKy; set => trnTypKy = value; }
        public int TrnNo { get => trnNo; set => trnNo = value; }
        public int AprStsKy { get => aprStsKy; set => aprStsKy = value; }
        public int IsZeroQty { get => isZeroQty; set => isZeroQty = value; }
        public int TrnKy { get => trnKy; set => trnKy = value; }
        public int ItmTrnKy { get => itmTrnKy; set => itmTrnKy = value; }

        public int OrderKey { get; set; }
        public Order()
        {
            OrderKey = 1;
        }
    }

    public class OrderItem : BaseEntity
    {
        public long OrderKey { get; set; } = 1;
        public int OrderDetailKey { get; set; } = 1;

        public CodeBaseResponse OrderType { get; set; }
        public DateTime OrderDate { get; set; }

        public CodeBaseResponse Location { get; set; }
        public CodeBaseResponse BuissenssUnit { get; set; }
        public Address OrderAddress { get; set; }
        public Account OrderAccount { get; set; }
        public int LineNumber { get; set; }

        public Item TransactionItem { get; set; }


        public decimal TransactionQuantity { get; set; }

        public UnitResponse TransactionUnit { get; set; }
        public decimal Rate { get; set; }
        public decimal TransactionRate { get; set; }

        public decimal DiscountPercentage { get; set; }

        public int DirectOverheadPercentage { get; set; }
        public int GeneralOverheadPercentage { get; set; }

        public decimal ProfitPercentage { get; set; }

        public decimal DiscountAmount { get; set; }
        public decimal TransactionDiscountAmount { get; set; }

        public DateTime RequestedDate { get; set; }

        public CodeBaseResponse ItemProperty1 { get; set; }

        public bool IsCodeBase { get; set; }
        public ProjectResponse Project1 { get; set; }
        public ProjectResponse Project2 { get; set; }
        public ProjectResponse Project3 { get; set; }
        public ProjectResponse Project4 { get; set; }
        public ProjectResponse Project5 { get; set; }

        public CodeBaseResponse LCKey { get; set; }
        public CodeBaseResponse LoanKey { get; set; }

        public Process Process1 { get; set; }
        public Process Process2 { get; set; }
        public Process Process3 { get; set; }
        public Process Process4 { get; set; }
        public Process Process5 { get; set; }

        public CodeBaseResponse LoandDetail { get; set; }
        public CodeBaseResponse LCDetail { get; set; }

        public CodeBaseResponse Analysis1 { get; set; }
        public CodeBaseResponse Analysis2 { get; set; }
        public CodeBaseResponse Analysis3 { get; set; }
        public CodeBaseResponse Analysis4 { get; set; }
        public CodeBaseResponse Analysis5 { get; set; }
        public CodeBaseResponse Analysis6 { get; set; }

        public string OrderItemName { get; set; } = "";
        public string Remarks { get; set; } = "";

        public decimal LineNumberRate { get; set; }

        public CodeBaseResponse LineNumberCurrency { get; set; }
        public string DesCription { get; set; } = "";
        public bool ISVirtualItem { get; set; }
        public CodeBaseResponse ItemTaxType1 { get; set; }
        public CodeBaseResponse ItemTaxType2 { get; set; }
        public CodeBaseResponse ItemTaxType3 { get; set; }
        public CodeBaseResponse ItemTaxType4 { get; set; }
        public CodeBaseResponse ItemTaxType5 { get; set; }
        public decimal Amount1 { get; set; }

        public AddressResponse DeliveryAddress { get; set; }
        public AddressResponse ReserveAddress { get; set; }

        public bool IsRateIncludedInTotal { get; set; }

        public decimal AddAlwPercentage { get; set; }
        public decimal OriginalRate { get; set; }

        public decimal ItemTaxPercenrage1 { get; set; }
        public decimal ItemTaxPercenrage2 { get; set; }
        public decimal ItemTaxPercenrage3 { get; set; }
        public decimal ItemTaxPercenrage4 { get; set; }
        public decimal ItemTaxPercenrage5 { get; set; }


        public CodeBaseResponse ApprovePririty { get; set; }

        public CodeBaseResponse ApproveStatus { get; set; }

        public bool IsProduction { get; set; }

        public bool IsNotProduction { get; set; }

        public OrderItem FromOrderItem { get; set; }

        public decimal ConversionRate { get; set; } = 1;

        public decimal TransactionPrice { get; set; }

        public string ItemNumber { get; set; }
        public bool IsSetOff { get; set; }

        public int ParentItemKey { get; set; } = 1;

        public string ParentItemName { get; set; }

        public string ParentItemCode { get; set; }





    }

    public class OrderSaveResponse
    {
        public string OrderNumber { get; set; }
        public string Prefix { get; set; }

        public long OrderKey { get; set; } = 1;
    }

    public class OrderCreateModelSimple : BaseModel
    {
        public DateTime OrderDate { get; set; }
        public string OrderReference { get; set; }
        public string Prefix { get; set; }
        public string OrderType { get; set; }
        public int CustomerReference { get; set; }
        public string PaymentMethodReference { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Remarks { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDate { get; set; } = DateTime.Now;

        public IList<OrderSimpleLineItem> LineItems { get; set; }

        /// <summary>
        /// Following are for Linked Transaction onlly. Like Purchase Return and so on.
        /// </summary>

        public string PreviousTransactionReference { get; set; }
        public string PreviousTransactionType { get; set; }


        public bool ForceEmail { get; set; } = false;

        public decimal DeliveryFee { get; set; }

        public DeliveryDetail deliveryDetail { get; set; }

        public ShippingAddress shippingAddress { get; set; }


        public int LocationKey { get; set; } = 1;


    }

    public class OrderSimpleToWMS : OrderCreateModelSimple
    {
        public string SupplierReference { get; set; }
        public string SupplierName { get; set; }
        public string EXTERNRECEIPTKEY { get; set; }
        public DateTime REQUIREDDELIVERYDATE { get; set; }
        public string SUSR1 { get; set; }
        public long OrderKey { get; set; } = 1;
        public string GenericKey { get; set; } = "1";

        public string STORERKEY { get; set; } = "Kimera";

        public string WMSDispatchReference { get; set; }


        public DateTime TransactionDate { get; set; }



    }


    public class OrderSimpleLineItem
    {
        public string OrderReference { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ProductName { get; set; }

        public int SKU { get; set; }
        public decimal Quantity { get; set; }
        public decimal TransactionRate { get; set; }
        public decimal LineDiscountPercentage { get; set; }
        public decimal LineDiscountAmount { get; set; }

        public decimal LineTotal { get; set; }


        public DateTime DeliveryDate { get; set; }
        public string DeliveryTypeReference { get; set; }
        public string DeliveryAddressReference { get; set; }
        public string CustomerReference { get; set; }
        public int LineNumber { get; set; }


        /// <summary>
        /// Following are only for dispatch
        /// </summary>
        public string BatchID { get; set; }

        public int ProjectKey { get; set; } = 1;

        public int __referenceOutLineKey { get; set; } = 1;

        public int ItemKey { get; set; } = 1;

        public bool FoundInSO { get; set; } = false;

    }

    public class DeliveryDetail
    {
        public decimal base_shipping_amount { get; set; }
        public decimal base_shipping_discount_amount { get; set; }
        public decimal base_shipping_discount_tax_compensation_amnt { get; set; }
        public decimal base_shipping_incl_tax { get; set; }
        public decimal base_shipping_tax_amount { get; set; }
        public decimal shipping_amount { get; set; }
        public decimal shipping_discount_amount { get; set; }
        public decimal shipping_discount_tax_compensation_amount { get; set; }
        public decimal shipping_incl_tax { get; set; }
        public decimal shipping_tax_amount { get; set; }
    }
    public class ShippingAddress
    {
        public string address_type { get; set; }
        public string city { get; set; }
        public string country_id { get; set; }
        public string email { get; set; }
        public int entity_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int parent_id { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public List<string> street { get; set; }
        public string telephone { get; set; }
    }
}
