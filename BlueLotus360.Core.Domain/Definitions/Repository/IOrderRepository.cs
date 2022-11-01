using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Core.Domain.Entity;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Order;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Definitions.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(OrderHeaderCreateDTO orderHeader, Company company, User user);
        void CreateOrderLineItem(OrderLineCreateDTO item, Company company, User user, UIObject uiobject);
        void PostInterLocationTransfers(Company company, User user, long OrderKey = 1, long ObjectKey = 1);
        OrderSimpleToWMS GetOrderByOrderKey(int OrderKey, User user);
        void UpdateGenericOrderHeader(OrderHeaderEditDTO orderV3, Company company, User user);
        void UpdateGenericOrderLineItem(OrderLineCreateDTO item, long ObjKy, Company company, User user);
        BaseServerResponse<IList<OrderFindResults>> GenericFindOrders(OrderFindDto dto, Company company, User user);
        BaseServerResponse<OrderHeaderEditDTO> GetGenericOrderByOrderKey(long Orderkey, Company company, User user);
        BaseServerResponse<OrderHeaderEditDTO> GetGenericOrderByOrderKeyV2(long Orderkey, Company company, User user);
        BaseServerResponse<IList<OrderLineCreateDTO>> GetGenericOrderLineItemsByOrderKey(long Orderkey, long ObjKy, Company company, User user);
        CodeBaseResponse OrderStatusFindByOrdKy(Company company, User user, int objky, int ordky);
        BaseServerResponse<IList<GetFromQuotResults>> GenericRetrieveQuotation(GetFromQuoatationDTO request, Company company, User user);
        BaseServerResponse<IList<QuotationDetails>> GenericOpenQuotation(OrderOpenRequest request, Company company, User user);
        BaseServerResponse<WorkOrderAmountByAccount> OrderDetailAccountInsertUpdate(Company company, User user, WorkOrderAmountByAccount accDet);
        BaseServerResponse<IList<WorkOrderAmountByAccount>> OrderDetailAccountSelect(Company company, User user, WorkOrderAmountByAccount accDet);
        int PartnerOrders_Count(Company company, RequestParameters partnerOrder);
        BaseServerResponse<IList<PartnerOrder>> GetAllPartnerOrder(Company company, User user, RequestParameters order);
        BaseServerResponse<APIInformation> GetAPIDetails(Company company, User user, APIRequestParameters request);
        BaseServerResponse<IList<CodeBaseResponse>> GetOrderStatus(Company company);
        BaseServerResponse<APIInformation> GetAPIEndPoints(Company company, APIRequestParameters request);
        BaseServerResponse<PartnerOrder> GetLastOrderSyncTime(Company company, APIRequestParameters request);
        BaseServerResponse<PartnerOrder> GetOrdersFromOrderPlatforms(Company company, User user, PartnerOrder request);
        BaseServerResponse<CodeBaseResponse> GetOrderStatusByPartnerStatus(Company company, CodeBaseResponse codeBase);
        BaseServerResponse<Item> GetItemsByItemCode(Company company, Item item);
    }
}
