using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class WorkshopManagementService:IWorkshopManagementService
    {
        public readonly IUnitOfWork _unitOfWork;

        public WorkshopManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Vehicle> GetVehicleDetails(VehicleSearch request,Company company,User user)
        {
            var response =_unitOfWork.WorkShopManagementRepository.SelectVehicle(request, company, user);
            return response.Value;
        }

        public IList<WorkOrder> GetJobHistoryDetails(Vehicle request, Company company, User user)
        {
            var response = _unitOfWork.WorkShopManagementRepository.SelectJobhistory(request, company, user);
            return response.Value;
        }

        public IList<ProjectResponse> GetProgressingProjectDetails(Vehicle request, Company company, User user)
        {
            var response = _unitOfWork.WorkShopManagementRepository.SelectOngoingProjectDetails(request, company, user);
            return response.Value;
        }

        public BaseServerResponse<WorkOrder> OpenWorkOrder(Company company, User user, OrderOpenRequest request)
        {
            var ord = _unitOfWork.OrderRepository.GetGenericOrderByOrderKey(request.OrderKey, company, user);
            OrderHeaderEditDTO responses = ord.Value;

            var ordDet = _unitOfWork.OrderRepository.GetGenericOrderLineItemsByOrderKey(request.OrderKey, responses.ObjectKey, company, user);
            IList<OrderLineCreateDTO> itemList = ordDet.Value;

            WorkOrder order = new WorkOrder();
            order.OrderLocation = responses.OrderLocation;
            order.OrderCustomer = responses.OrderAdress;
            order.OrderRepAddress = responses.RepAdress;
            order.OrderAccount = new AccountResponse();
            order.HeaderLevelDisountPrecentage = responses.DiscountPercentage;
            order.OrderKey = responses.OrderKey;
            order.OrderNumber = responses.OrderNumber.ToString();
            order.OrderDocumentNumber = responses.DocumentNumber;
            order.OrderDate = responses.OrderDate;
            order.OrderPaymentTerm = responses.PayementTerm;
            order.OrderType = responses.OrderType;
            order.FormObjectKey = responses.ObjectKey;
            order.IsActive = responses.IsActive;
            order.IsApproved = responses.IsApproved;
            order.HeaderDescription = responses.Description;
            order.OrderPrefix = responses.OrderPrefix;
            order.OrderApproveState = _unitOfWork.OrderRepository.OrderStatusFindByOrdKy(company, user, order.FormObjectKey, order.OrderKey);

            foreach (OrderLineCreateDTO item in itemList)
            {
                if (item.IsActive == 1)
                {
                    GenericOrderItem lineItem = new GenericOrderItem();
                    lineItem.TransactionItem = new ItemResponse() { ItemKey = item.ItemKey, ItemName = item.OrderItemName };
                    lineItem.TransactionQuantity = item.TransactionQuantity;
                    lineItem.Rate = _unitOfWork.ItemRepository.GetCostPriceByLocAndItmKy(company, new CodeBaseResponse(item.OrderLineLocation != null ? (int)item.OrderLineLocation.CodeKey : 1), DateTime.Now, item.ItemKey);
                    lineItem.TransactionRate = item.TransactionRate;
                    lineItem.ObjectKey = item.ObjectKey;
                    lineItem.OrderLineLocation = item.OrderLineLocation;
                    lineItem.CompanyKey = company.CompanyKey;
                    lineItem.UserKey = user.UserKey;
                    lineItem.DiscountPercentage = item.DiscountPercentage;
                    lineItem.LineNumber = item.LineNumber;
                    lineItem.IsActive = item.IsActive;
                    lineItem.RequestedQuantity = item.OriginalQuantity;
                    lineItem.IsApproved = item.IsApproved;
                    lineItem.IsTransfer = item.IsTransfer;
                    lineItem.IsTransferConfirmed = item.IsConfirmed;
                    lineItem.DiscountAmount = item.DisocuntAmount;
                    lineItem.ItemTaxType1 = item.ItemTaxType1;
                    lineItem.ItemTaxType2 = item.ItemTaxType2;
                    lineItem.ItemTaxType3 = item.ItemTaxType3;
                    lineItem.ItemTaxType4 = item.ItemTaxType4;
                    lineItem.ItemTaxType5 = item.ItemTaxType5;
                    lineItem.ItemTaxType1Per = item.ItemTaxType1Per;
                    lineItem.ItemTaxType2Per = item.ItemTaxType2Per;
                    lineItem.ItemTaxType3Per = item.ItemTaxType3Per;
                    lineItem.ItemTaxType4Per = item.ItemTaxType4Per;
                    lineItem.ItemTaxType5Per = item.ItemTaxType5Per;
                    lineItem.FromOrderDetailKey = item.FromOrderDetailKey;
                    lineItem.Remark = item.Remarks;
                    lineItem.Description = item.Description;
                    //lineItem.CarmartAmount=
                    //lineItem.PrincipleAmount=
                    //lineItem.CarmartPrecentage=
                    //lineItem.PrinciplePrecentage=

                    order.OrderItems.Add(lineItem);
                }

            }

            BaseServerResponse<WorkOrder> response = new BaseServerResponse<WorkOrder>();
            response.Value = order;

            return response;
        }
    }
}
