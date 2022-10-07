using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.DataLayer;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class AddressRepository :BaseRepository,IAddressRepository
    {
        public AddressRepository(ISQLDataLayer datalayer):base(datalayer)
        {

        }

        public BaseServerResponse<IList<AddressResponse>> GetAddresses(Company company, User user, ComboRequestDTO dto)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "AdrIDNm_SelectMob";
                BaseServerResponse<IList<AddressResponse>> response = new BaseServerResponse<IList<AddressResponse>>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    IList<AddressResponse> addresses = new List<AddressResponse>();
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", dto.RequestingElementKey);
                    dbCommand.CreateAndAddParameter("@SearchVal", dto.SearchQuery);

                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        AddressResponse address = new AddressResponse()
                        {
                            AddressKey = reader.GetColumn<int>("AdrKy"),
                            AddressName = reader.GetColumn<string>("AdrIdNm"),
                            IsDefault = reader.GetColumn<int>("AdrKy") == reader.GetColumn<int>("DefaultKey")
                        };




                        addresses.Add(address);
                        
                    }
                    
                    response.ExecutionEnded= DateTime.UtcNow;
                    response.Value = addresses;






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
                return response;
            }
        }
    }
}
