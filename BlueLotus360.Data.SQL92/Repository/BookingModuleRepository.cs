using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.BookingModule;
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
    internal class BookingModuleRepository : BaseRepository, IBookingModuleRepository
    {
        public BookingModuleRepository(ISQLDataLayer datalayer) : base(datalayer)
        {
            
        }
        public BaseServerResponse<IList<CustomerDetailsByVehicle>> GetBookingCustomerDetails(Company company, User user, BookingVehicleDetails request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess()) 
            {
                IDataReader reader = null;
                string SPName = "BookingCusAdrDetailsByVeh_SelectWeb";
                BaseServerResponse<IList<CustomerDetailsByVehicle>> responses = new BaseServerResponse<IList<CustomerDetailsByVehicle>>();
                IList<CustomerDetailsByVehicle> list = new List<CustomerDetailsByVehicle>();

                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", request.ElementKey);
                    dbCommand.CreateAndAddParameter("@AdrKy", request.Registration.AddressKey);

                    responses.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        CustomerDetailsByVehicle response = new CustomerDetailsByVehicle();

                        response.Code = reader.GetColumn<string>("Code");
                        response.Customer.AddressKey = reader.GetColumn<int>("AdrKy");
                        response.Customer.AddressId = reader.GetColumn<string>("AdrID");
                        response.Customer.AddressName = reader.GetColumn<string>("AdrNm");
                        response.Mobile = reader.GetColumn<string>("Mobile");

                        list.Add(response);
                    }

                    responses.ExecutionEnded = DateTime.UtcNow;
                    responses.Value = list;
                }
                catch (Exception exp)
                {
                    throw exp;
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }

                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }

                return responses;
            }
        }

		public BaseServerResponse<IList<BookingDetails>> GetBookingDetailsOnCalender(Company company, User user, BookingDetails request)
		{
			using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
			{
				IDataReader reader = null;
				string SPName = "BookingPrcsDet_SelectWeb";
				BaseServerResponse<IList<BookingDetails>> responses = new BaseServerResponse<IList<BookingDetails>>();
				IList<BookingDetails> list = new List<BookingDetails>();

				try
				{
					dbCommand.CommandType = CommandType.StoredProcedure;
					dbCommand.CommandText = SPName;

					dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
					dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
					dbCommand.CreateAndAddParameter("@ObjKy", request.ElementKey);
					dbCommand.CreateAndAddParameter("@FrmDt", request.FromDate);
					dbCommand.CreateAndAddParameter("@ToDt", request.ToDate);

					responses.ExecutionStarted = DateTime.UtcNow;
					dbCommand.Connection.Open();
					reader = dbCommand.ExecuteReader();

					while (reader.Read())
					{
						BookingDetails response = new BookingDetails();

						response.Id = reader.GetColumn<int>("Id");
						response.ProcessDetailsKey = reader.GetColumn<int>("PrcsDetKy");
						response.ProjectKey = reader.GetColumn<int>("PrjKy");
						response.TaskID = reader.GetColumn<int>("TaskID");
						response.TaskName = reader.GetColumn<string>("TaskNm");
						response.RequestedDate = reader.GetColumn<DateTime>("ReqDt");
						response.Registration.AddressKey = reader.GetColumn<int>("VehAdrKy");
						response.CustomerAddressKey = reader.GetColumn<int>("CusAdrKy");
						response.Registration.AddressName = reader.GetColumn<string>("VehId");
						response.CustomerName = reader.GetColumn<string>("CusNm");
						response.ServiceType.CodeKey = reader.GetColumn<int>("PrjCat3Ky");
						response.ServiceType.CodeName = reader.GetColumn<string>("PrjCat3Nm");
						response.Milage = reader.GetColumn<decimal>("Milage");
						response.Remark = reader.GetColumn<string>("Rem");
						response.Mobile = reader.GetColumn<string>("Mobile");

						list.Add(response);
					}

					responses.ExecutionEnded = DateTime.UtcNow;
					responses.Value = list;
				}
				catch (Exception exp)
				{
					throw exp;
				}

				finally
				{
					IDbConnection dbConnection = dbCommand.Connection;
					if (reader != null && !reader.IsClosed)
					{
						reader.Close();
					}

					if (dbConnection.State != ConnectionState.Closed)
					{
						dbConnection.Close();
					}

					dbCommand.Dispose();
					dbConnection.Dispose();
				}

				return responses;
			}
		}
	}
}
