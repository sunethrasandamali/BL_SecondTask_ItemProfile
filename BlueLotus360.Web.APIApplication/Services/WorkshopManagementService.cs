using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.BookingModule;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Core.Domain.Entity.Order;
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

        public BaseServerResponse<OrderSaveResponse> SaveWorkOrder(Company company, User user, GenericOrder orderDetails)
        {
            OrderHeaderCreateDTO OH = new OrderHeaderCreateDTO();
            OH.DocumentNumber = orderDetails.OrderDocumentNumber;
            OH.AddressKey = orderDetails.OrderCustomer.AddressKey;
            OH.ObjectKey = orderDetails.FormObjectKey;
            OH.AprroceStatusKey = 1;
            // OH.OrderStatusKey = OrderStatus.CodeKey;
            //OH.DeliveryDate = orderDetails.DeliveryDate;
            OH.OrderDate = DateTime.Now;
            OH.OrderType = new CodeBaseResponse();
            OH.OrderType.CodeKey = orderDetails.OrderType.CodeKey;
            OH.AccountKey = 1;
            OH.Description = orderDetails.HeaderDescription;
            OH.PayementTerm = new CodeBaseResponse();
            OH.PayementTerm.CodeKey = orderDetails.OrderPaymentTerm.CodeKey;
            OH.Location2Key = orderDetails.OrderLocation.CodeKey;
            OH.OrderLocation = new CodeBaseResponse();
            OH.OrderLocation.CodeKey = orderDetails.OrderLocation.CodeKey;
            OH.RepAddessKey = orderDetails.OrderRepAddress.AddressKey;
            OH.DiscountPercentage = orderDetails.HeaderLevelDisountPrecentage;
            OH.IsActive = 1;
            OH.IsApproved = 1;
            OH.OrderCategory1Key = (int)orderDetails.OrderCategory1.CodeKey;
            OH.OrderCategory2Key = (int)orderDetails.OrderCategory2.CodeKey;
            OH.ProjectKey = (int)orderDetails.OrderProject.ProjectKey;
            OH.Code1Key = orderDetails.Cd1Ky;
            OH.OrderStatusKey = (int)orderDetails.OrderStatus.CodeKey;

            if (!BaseComboResponse.IsEntityWithDefaultValue(orderDetails.OrderAccount))
            {
                OH.AccountKey = orderDetails.OrderAccount.AccountKey;
            }
            else
            {
                var acc = _unitOfWork.AccountRepository.GetAccountByAddress(orderDetails.OrderCustomer, company, user);
                OH.AccountKey = acc.Value.AccountKey;

            }

            IList<OrderLineCreateDTO> orderLineItems = new List<OrderLineCreateDTO>();
            _unitOfWork.OrderRepository.CreateOrder(OH, company, user);

            if (orderDetails.OrderItems.Count() > 0)
            {
                foreach (GenericOrderItem item in orderDetails.OrderItems)
                {
                    OrderLineCreateDTO lineItem = new OrderLineCreateDTO();
                    lineItem.ItemKey = item.TransactionItem.ItemKey;
                    lineItem.OrderKey = OH.OrderKey;
                    lineItem.TransactionQuantity = item.TransactionQuantity;
                    lineItem.Rate = _unitOfWork.ItemRepository.GetCostPriceByLocAndItmKy(company, new CodeBaseResponse((int)orderDetails.OrderLocation.CodeKey), DateTime.Now, item.TransactionItem.ItemKey);
                    lineItem.TransactionRate = item.TransactionRate;
                    lineItem.AddressKey = OH.AddressKey;

                    lineItem.ObjectKey = orderDetails.FormObjectKey;
                    lineItem.OrderLineLocation = new CodeBaseResponse();
                    lineItem.OrderLineLocation.CodeKey = item.OrderLineLocation.CodeKey;
                    lineItem.CompanyKey = company.CompanyKey;
                    lineItem.UserKey = user.UserKey;
                    lineItem.DiscountPercentage = item.DiscountPercentage;
                    lineItem.AccountKey = OH.AccountKey;
                    //  lineItem.TransactionDiscountAmount = Math.Abs(item.GetLineDiscount());
                    lineItem.LineNumber = item.LineNumber;
                    lineItem.IsActive = item.IsActive;
                    lineItem.OriginalQuantity = item.RequestedQuantity;


                    lineItem.IsApproved = item.IsApproved;
                    lineItem.OrderType = new CodeBaseResponse();
                    lineItem.OrderType.CodeKey = orderDetails.OrderType.CodeKey;
                    lineItem.IsTransfer = item.IsTransfer;
                    lineItem.IsConfirmed = item.IsTransferConfirmed;

                    lineItem.DisocuntAmount = item.DiscountAmount;
                    lineItem.TransactionDiscountAmount = item.DiscountAmount;
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
                    lineItem.Remarks = item.Remark;
                    lineItem.Description = item.Description;

                    //   TotalDiscount += Math.Abs(item.GetLineDiscount()));
                    _unitOfWork.OrderRepository.CreateOrderLineItem(lineItem, company, user, new UIObject() { ObjectId = orderDetails.FormObjectKey });
                }
            }


            _unitOfWork.OrderRepository.PostInterLocationTransfers(company, user, OH.OrderKey, orderDetails.FormObjectKey);


            var ordb = _unitOfWork.OrderRepository.GetGenericOrderByOrderKeyV2(OH.OrderKey, company, user); 
            OrderSaveResponse orderServerResponse = new OrderSaveResponse();
            orderServerResponse.OrderKey = ordb.Value.OrderKey;
            orderServerResponse.OrderNumber = ordb.Value.OrderNumber.ToString();
            orderServerResponse.Prefix = ordb.Value.OrderPrefix.CodeName;

            BaseServerResponse<OrderSaveResponse> orderSaveResponse = new BaseServerResponse<OrderSaveResponse>();
            orderSaveResponse.Value = orderServerResponse;

            return orderSaveResponse;
        }

        public OrderSaveResponse UpdateWorkOrder(Company company, User user, GenericOrder orderDetails)
        {
            OrderHeaderEditDTO OH = new OrderHeaderEditDTO();
            OH.OrderKey = orderDetails.OrderKey;
            OH.OrderLocation = new CodeBaseResponse();
            OH.OrderLocation.CodeKey = orderDetails.OrderLocation.CodeKey;
            OH.OrderDate = orderDetails.OrderDate;
            OH.OrderType = new CodeBaseResponse();
            OH.OrderType.CodeKey = orderDetails.OrderType.CodeKey;
            OH.PayementTerm = new CodeBaseResponse();
            OH.PayementTerm.CodeKey = orderDetails.OrderPaymentTerm.CodeKey;
            OH.DocumentNumber = orderDetails.OrderDocumentNumber;
            OH.DiscountPercentage = orderDetails.HeaderLevelDisountPrecentage;
            OH.OrderAdress = orderDetails.OrderCustomer;
            OH.RepAdress = orderDetails.OrderRepAddress;
            OH.IsActive = orderDetails.IsActive;
            OH.IsApproved = orderDetails.IsApproved;
            OH.OrderNumber = Convert.ToInt32(orderDetails.OrderNumber);
            OH.BussinessUnit = orderDetails.BussinessUnit;
            OH.ObjectKey = orderDetails.FormObjectKey;
            OH.ApproveStatus = orderDetails.OrderApproveState;
            OH.AccountKey = 1;
            OH.Description = orderDetails.HeaderDescription;
            OH.OrderCategory1 = new CodeBaseResponse() { CodeKey= (int)orderDetails.OrderCategory1.CodeKey };
            OH.OrderCategory2 = new CodeBaseResponse() { CodeKey = (int)orderDetails.OrderCategory2.CodeKey };
            OH.ProjectKey = (int)orderDetails.OrderProject.ProjectKey;
            OH.Code1Key = orderDetails.Cd1Ky;
            OH.OrderStatus = orderDetails.OrderStatus;
            if (!BaseComboResponse.IsEntityWithDefaultValue(orderDetails.OrderAccount))
            {
                OH.AccountKey = orderDetails.OrderAccount.AccountKey;
            }
            else
            {
                var acc = _unitOfWork.AccountRepository.GetAccountByAddress(orderDetails.OrderCustomer, company, user);
                OH.AccountKey = acc.Value.AccountKey;
            }

            _unitOfWork.OrderRepository.UpdateGenericOrderHeader(OH, company, user);


            foreach (GenericOrderItem item in orderDetails.OrderItems)
            {
                OrderLineCreateDTO lineItem = new OrderLineCreateDTO();
                if (item.FromOrderDetailKey > 1)
                {

                    lineItem.OrderKey = OH.OrderKey;
                    lineItem.FromOrderDetailKey = item.FromOrderDetailKey;
                    lineItem.OrderType = new CodeBaseResponse();
                    lineItem.OrderType.CodeKey = item.OrderType.CodeKey;
                    lineItem.TransactionQuantity = item.TransactionQuantity;
                    lineItem.Rate = _unitOfWork.ItemRepository.GetCostPriceByLocAndItmKy(company, new CodeBaseResponse((int)orderDetails.OrderLocation.CodeKey), DateTime.Now, item.TransactionItem.ItemKey);
                    lineItem.TransactionRate = item.TransactionRate;
                    lineItem.AddressKey = OH.AddressKey;
                    lineItem.IsActive = item.IsActive;
                    lineItem.IsApproved = item.IsApproved;
                    lineItem.OrderLineLocation = new CodeBaseResponse();
                    lineItem.OrderLineLocation.CodeKey = item.OrderLineLocation.CodeKey;
                    lineItem.BussinessUnitKey = (int)item.BussinessUnit.CodeKey;
                    lineItem.AccountKey = OH.AccountKey;
                    lineItem.LineNumber = item.LineNumber;
                    lineItem.ItemKey = item.TransactionItem != null ? item.TransactionItem.ItemKey : 1;
                    lineItem.OrderItemName = item.TransactionItem != null ? item.TransactionItem.ItemName : "";
                    lineItem.Rate = item.Rate;
                    lineItem.TransactionRate = item.TransactionRate;
                    lineItem.DiscountPercentage = item.DiscountPercentage;
                    lineItem.DisocuntAmount = item.DiscountAmount;
                    lineItem.ObjectKey = orderDetails.FormObjectKey;
                    lineItem.CompanyKey = company.CompanyKey;
                    lineItem.UserKey = user.UserKey;
                    lineItem.OriginalQuantity = item.RequestedQuantity;
                    lineItem.IsTransfer = item.IsTransfer;
                    lineItem.IsConfirmed = item.IsTransferConfirmed;

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
                    lineItem.ProjectKey= (int)orderDetails.OrderProject.ProjectKey; 

                    _unitOfWork.OrderRepository.UpdateGenericOrderLineItem(lineItem, orderDetails.FormObjectKey, company, user);
                }
                else
                {
                    lineItem.ItemKey = item.TransactionItem.ItemKey;
                    lineItem.OrderKey = OH.OrderKey;
                    lineItem.TransactionQuantity = item.TransactionQuantity;
                    lineItem.Rate = _unitOfWork.ItemRepository.GetCostPriceByLocAndItmKy(company, new CodeBaseResponse((int)orderDetails.OrderLocation.CodeKey), DateTime.Now, item.TransactionItem.ItemKey);
                    lineItem.TransactionRate = item.TransactionRate;
                    lineItem.AddressKey = OH.AddressKey;
                    lineItem.ObjectKey = orderDetails.FormObjectKey;
                    lineItem.OrderLineLocation = new CodeBaseResponse();
                    lineItem.OrderLineLocation.CodeKey = item.OrderLineLocation.CodeKey;
                    lineItem.CompanyKey = company.CompanyKey;
                    lineItem.UserKey = user.UserKey;
                    lineItem.DiscountPercentage = item.DiscountPercentage;
                    lineItem.AccountKey = OH.AccountKey;
                    lineItem.LineNumber = item.LineNumber;
                    lineItem.IsActive = 1;
                    lineItem.OriginalQuantity = item.RequestedQuantity;
                    lineItem.IsApproved = 1;
                    lineItem.OrderType = new CodeBaseResponse();
                    lineItem.OrderType.CodeKey = orderDetails.OrderType.CodeKey;
                    lineItem.IsTransfer = item.IsTransfer;
                    lineItem.IsConfirmed = item.IsTransferConfirmed;
                    lineItem.DisocuntAmount = item.DiscountAmount;
                    lineItem.TransactionDiscountAmount = item.DiscountAmount;
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
                    lineItem.ProjectKey = (int)orderDetails.OrderProject.ProjectKey;
                    lineItem.BussinessUnitKey = (int)item.BussinessUnit.CodeKey;

                    _unitOfWork.OrderRepository.CreateOrderLineItem(lineItem, company, user, new UIObject() { ObjectId = orderDetails.FormObjectKey });
                }


            }

            _unitOfWork.OrderRepository.PostInterLocationTransfers(company, user, OH.OrderKey, orderDetails.FormObjectKey);

            var ordb = _unitOfWork.OrderRepository.GetGenericOrderByOrderKeyV2(OH.OrderKey, company, user);
            OrderSaveResponse orderServerResponse = new OrderSaveResponse();
            orderServerResponse.OrderKey = ordb.Value.OrderKey;
            orderServerResponse.OrderNumber = ordb.Value.OrderNumber.ToString();
            orderServerResponse.Prefix = ordb.Value.OrderPrefix.CodeName;



            return orderServerResponse;
        }

        public BaseServerResponse<WorkOrder> OpenWorkOrder(Company company, User user, OrderOpenRequest request)
        {
            var ord = _unitOfWork.OrderRepository.GetGenericOrderByOrderKeyV2(request.OrderKey, company, user);
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
            order.OrderCategory1 = responses.OrderCategory1;    
            order.OrderCategory2 = responses.OrderCategory2;
            order.OrderProject=new ProjectResponse() { ProjectKey=responses.ProjectKey};
            order.OrderStatus = responses.OrderStatus;

            foreach (OrderLineCreateDTO item in itemList)
            {
                if (item.IsActive == 1)
                {
                    GenericOrderItem lineItem = new GenericOrderItem();
                    lineItem.TransactionItem = new ItemResponse() { 
                                                        ItemKey = item.ItemKey, 
                                                        ItemName = item.OrderItemName,
                                                        ItemType=new CodeBaseResponse() { CodeKey=item.ItemTypeKey,Code=item.ItemTypeOurCode,CodeName=item.ItemTypeName}
                                                };
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

        public IList<BookingDetails> GetRecentBooking(Vehicle request, Company company, User user)
        {
            var response = _unitOfWork.WorkShopManagementRepository.RecentBookingDetails(request, company, user);
            return response.Value;
        }
    }
}
