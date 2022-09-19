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
    internal class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
        }

        public BaseServerResponse<IList<Company>> GetUserAssociatedCompanies(User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                BaseServerResponse<IList<Company>> response = new BaseServerResponse<IList<Company>>();
                string SPName = "Company_LookUpPOS";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    IList<Company> companies = new List<Company>();
                    while (reader.Read())
                    {
                        Company company = new Company();
                        company.CompanyName = reader.GetColumn<string>("CNm");
                        company.CompanyKey = reader.GetColumn<int>("Cky");
                        company.CompanyCode = reader.GetColumn<string>("CCd");
                        companies.Add(company);
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = companies;

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
