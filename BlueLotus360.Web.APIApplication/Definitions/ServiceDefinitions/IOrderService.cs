﻿using BlueLotus360.Core.Domain.DTOs;
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

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface IOrderService
    {
        BaseServerResponse<OrderSaveResponse> SaveOrder(Company company, User user, GenericOrder orderDetails, CodeBaseResponse ordTyp);

        OrderSaveResponse UpdateOrder(Company company, User user, GenericOrder orderDetails, CodeBaseResponse ordTyp);
        BaseServerResponse<IList<OrderFindResults>> FindOrders(OrderFindDto request, Company company, User user,CodeBaseResponse ordTyp);

        BaseServerResponse<GenericOrder> OpenOrder(Company company, User user, OrderOpenRequest request);
        BaseServerResponse<IList<GetFromQuotResults>> RetrieveQuotation(GetFromQuoatationDTO request, Company company, User user, CodeBaseResponse ordTyp, CodeBaseResponse preOrdTyp);

        BaseServerResponse<GenericOrder> OpenQuotation(Company company, User user, OrderOpenRequest request, CodeBaseResponse ordTyp);
        int PartnerOrders_Count(Company company, RequestParameters partnerOrder);
        BaseServerResponse<IList<PartnerOrder>> GetAllPartnerOrder(Company company, User user, RequestParameters order);
        BaseServerResponse<APIInformation> GetAPIDetails(Company company, User user, APIRequestParameters request);
        BaseServerResponse<IList<CodeBaseResponse>> GetOrderStatus(Company company);
        BaseServerResponse<APIInformation> GetAPIEndPoints(Company company, APIRequestParameters request);
        BaseServerResponse<PartnerOrder> GetLastOrderSyncTime(Company company, APIRequestParameters request);

    }
}
