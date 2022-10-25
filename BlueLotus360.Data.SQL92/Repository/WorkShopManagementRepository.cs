using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.DTOs;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
using BlueLotus360.Core.Domain.Entity.WorkOrder;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class WorkShopManagementRepository : BaseRepository, IWorkShopManagementRepository
    {
        public WorkShopManagementRepository(ISQLDataLayer dataLayer):base(dataLayer) { }

        public BaseServerResponse<IList<Vehicle>> SelectVehicle(VehicleSearch dto, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                IList<Vehicle> list = new List<Vehicle>();
                BaseServerResponse<IList<Vehicle>> response = new BaseServerResponse<IList<Vehicle>>();
                string SPName = "CARVehDetails_FindWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("ObjKy",dto.ObjectKey);
                    dbCommand.CreateAndAddParameter("VehAdrKy",BaseComboResponse.GetKeyValue(dto.VehicleRegistration));
                    dbCommand.CreateAndAddParameter("ItmKy",dto.VehicleSerialNumber!=null? dto.VehicleSerialNumber.ItemKey:1);
                    dbCommand.CreateAndAddParameter("CusAdrKy", BaseComboResponse.GetKeyValue(dto.RegisteredCustomer));
                   

                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.VehicleAddress = new AddressResponse();
                        vehicle.VehicleAddress.AddressKey = reader.GetColumn<int>("VehAdrKy");
                        vehicle.VehicleRegistration = new ItemResponse();
                        vehicle.VehicleRegistration.ItemKey= reader.GetColumn<int>("VehItmKy");
                        vehicle.VehicleRegistration.ItemCode= reader.GetColumn<string>("VehicleNo");
                        vehicle.RegisteredCustomer = new AddressMaster();
                        vehicle.RegisteredCustomer.AddressKey = reader.GetColumn<int>("CusAdrKy");
                        vehicle.RegisteredCustomer.AddressName = reader.GetColumn<string>("CusNm");
                        vehicle.RegisteredCustomer.NIC= reader.GetColumn<string>("NIC");
                        vehicle.RegisteredCustomer.AddressId= reader.GetColumn<string>("Mobile");
                        vehicle.RegisteredCustomer.Address = reader.GetColumn<string>("Address");
                        vehicle.RegisteredCustomer.Email= reader.GetColumn<string>("Email");
                        vehicle.SerialNumber=new ItemSerialNumber();
                        vehicle.SerialNumber.SerialNumber= reader.GetColumn<string>("ChassisNo");
                        vehicle.SerialNumber.EngineNumber= reader.GetColumn<string>("EnginNo");
                        vehicle.Brand = reader.GetColumn<string>("Brand");
                        vehicle.Model= reader.GetColumn<string>("Model");
                        vehicle.Category=new CodeBaseResponse();
                        vehicle.Category.CodeName= reader.GetColumn<string>("Category");
                        vehicle.SubCategory = new CodeBaseResponse();
                        vehicle.SubCategory.CodeName = reader.GetColumn<string>("SubCategory");
                        vehicle.Fuel= reader.GetColumn<string>("FuelTyp");
                        vehicle.PreviousMilage= reader.GetColumn<decimal>("Milage");

                        list.Add(vehicle);
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = list;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }




                }
                catch (Exception exp)
                {
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Messages.Add(new ServerResponseMessae()
                    {
                        MessageType = ServerResponseMessageType.Exception,
                        Message = $"Error While Executing Proc {SPName}"
                    });
                    response.ExecutionException = exp;
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    if (reader!=null)
                    {
                        reader.Dispose();
                    }
                    
                    dbCommand.Dispose();
                    dbConnection.Dispose();

                }

                return response;
            }
        }

        public BaseServerResponse<IList<WorkOrder>> SelectJobhistory(Vehicle dto, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                IList<WorkOrder> list = new List<WorkOrder>();
                BaseServerResponse<IList<WorkOrder>> response = new BaseServerResponse<IList<WorkOrder>>();
                string SPName = "CARJobHostory_SelectWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("ObjKy", dto.ObjectKey);
                    dbCommand.CreateAndAddParameter("AdrKy", BaseComboResponse.GetKeyValue(dto.VehicleAddress));

                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        WorkOrder order = new WorkOrder();
                        order.OrderKey= reader.GetColumn<int>("OrdKy");
                        order.OrderNumber = reader.GetColumn<string>("OrdNo");
                        order.OrderType = new CodeBaseResponse();
                        order.OrderType.CodeName = reader.GetColumn<string>("Type");
                        order.OrderFinishDate = reader.GetColumn<DateTime>("FinDt");
                        order.OrderDate = reader.GetColumn<DateTime>("PrjDt");
                        order.WorkOrderStaus = reader.GetColumn<string>("Status");

                        list.Add(order);
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = list;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }




                }
                catch (Exception exp)
                {
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Messages.Add(new ServerResponseMessae()
                    {
                        MessageType = ServerResponseMessageType.Exception,
                        Message = $"Error While Executing Proc {SPName}"
                    });
                    response.ExecutionException = exp;
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    if (reader != null)
                    {
                        reader.Dispose();
                    }

                    dbCommand.Dispose();
                    dbConnection.Dispose();

                }

                return response;
            }
        }

        public BaseServerResponse<IList<ProjectResponse>> SelectOngoingProjectDetails(Vehicle dto, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                IList<ProjectResponse> list = new List<ProjectResponse>();
                BaseServerResponse<IList<ProjectResponse>> response = new BaseServerResponse<IList<ProjectResponse>>();
                string SPName = "CARProgressingPrjDetails_SelectWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("ObjKy", dto.ObjectKey);
                    dbCommand.CreateAndAddParameter("AdrKy", BaseComboResponse.GetKeyValue(dto.VehicleAddress));

                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        ProjectResponse project = new ProjectResponse();
                        project.ProjectKey= reader.GetColumn<int>("PrjKy");
                        project.ProjectId = reader.GetColumn<string>("PrjID");
                        project.ProjectName = reader.GetColumn<string>("PrjNm");

                        list.Add(project);
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = list;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }




                }
                catch (Exception exp)
                {
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Messages.Add(new ServerResponseMessae()
                    {
                        MessageType = ServerResponseMessageType.Exception,
                        Message = $"Error While Executing Proc {SPName}"
                    });
                    response.ExecutionException = exp;
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    if (reader != null)
                    {
                        reader.Dispose();
                    }

                    dbCommand.Dispose();
                    dbConnection.Dispose();

                }

                return response;
            }
        }
    }
}
