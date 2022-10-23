using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Core.Domain.Entity.Base;
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
    internal class APIRepository : BaseRepository, IAPIRepository
    {
        public APIRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
        }

        public BaseServerResponse<APIInformation> GetAPIInformationByAppId(string appId)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                BaseServerResponse<APIInformation> response = new BaseServerResponse<APIInformation>();
                APIInformation information = new APIInformation();
                string SPName = "BL10API_SelectWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    CreateAndAddParameter(dbCommand, "@integrationId", appId);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    

                    while (reader.Read())
                    {
                        information.APIIntegrationKey = reader.GetColumn<int>("ApiIntgrKy");
                        information.APIIntegrationNmae = reader.GetColumn<string>("ApiIntNm");
                        information.Description = reader.GetColumn<string>("Des");
                        information.ApplicationID = reader.GetColumn<string>("APPID");
                        information.SecretKey = reader.GetColumn<string>("SecretKey");
                        information.MappedCompanyKey = reader.GetColumn<int>("MappedCky");
                        information.MappedUserKey = reader.GetColumn<int>("MappedCky");
                        information.IsLocalOnly = reader.GetColumn<bool>("IsLocalOnly");
                        information.IsActive = reader.GetColumn<int>("IsAct");
                        information.RestrictToIP = reader.GetColumn<string>("RestricrtToIP");
                        information.ISIPFilterd = reader.GetColumn<bool>("ISIPFilterd");
                        information.ValidateTokenOnly = reader.GetColumn<bool>("ValTokenOnly");
                        information.Scheme = reader.GetColumn<string>("Scheme");
                        information.BaseURL = reader.GetColumn<string>("BaseURL");
                        information.AuthenticationType = reader.GetColumn<string>("Type");
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = information;

                }
                catch (Exception exp)
                {
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Messages.Add(new ServerResponseMessae()
                    {
                        MessageType = ServerResponseMessageType.Exception,
                        Message = $"Error While Executing Proc  {SPName}"
                    });
                    response.ExecutionException = exp;
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
