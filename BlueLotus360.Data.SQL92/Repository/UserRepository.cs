using BlueLotus360.Core.Domain.Definitions.Repository;
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
    internal class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
        }
       
        public BaseServerResponse<User> GetUserByUserId(string userId)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "GetUserByUserName";
                BaseServerResponse<User> response = new BaseServerResponse<User>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    CreateAndAddParameter(dbCommand, "@UsrNm", userId);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    User user = new User();
                    while (reader.Read())
                    {
                        user.UserKey = reader.GetColumn<int>("UsrKy");
                        user.UserID = reader.GetColumn<string>("UsrId");
                        user.HashedPassword = reader.GetColumn<string>("Password");
                        user.UserAddress = new Address (reader.GetColumn<long>("AdrKy"));
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = user;                 

                }
                catch (Exception exp)
                {
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Messages.Add(new ServerResponseMessae()
                    {
                        MessageType=ServerResponseMessageType.Exception,
                        Message= $"Error While Executing Proc {SPName}"
                    });
                    response.ExecutionException = exp;
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if(reader != null && !reader.IsClosed)
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
