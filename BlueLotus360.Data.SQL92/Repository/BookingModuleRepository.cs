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
    }
}
