using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.MastrerData;
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
    internal class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(ISQLDataLayer dataLayer) : base(dataLayer) { }

        public ProjectResponse CreateProjectHeader(Company company, User user, Project request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                ProjectResponse response = new ProjectResponse();
                string SPName = "PrjHdr_InsertWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@PrjNo", request.ProjectNumber ??"");
                    dbCommand.CreateAndAddParameter("@PrjID", request.ProjectID ?? "");
                    if (!string.IsNullOrEmpty(request.ProjectName))
                    {
                        dbCommand.CreateAndAddParameter("@PrjNm", request.ProjectName);
                    }
                    dbCommand.CreateAndAddParameter("@PrjTypKy", BaseComboResponse.GetKeyValue(request.ProjectType));
                    dbCommand.CreateAndAddParameter("@PrntKy", request.ParentKey);
                    dbCommand.CreateAndAddParameter("@Alias", request.Alias??"");
                    dbCommand.CreateAndAddParameter("@ItmKy", request.Item.ItemKey);
                    dbCommand.CreateAndAddParameter("@PrjStsKy", BaseComboResponse.GetKeyValue(request.ProjectStatus));
                    dbCommand.CreateAndAddParameter("@isAct", request.IsActive);
                    dbCommand.CreateAndAddParameter("@isApr",request.IsApproved);
                    dbCommand.CreateAndAddParameter("@isAlwTrn", request.IsAllowTransaction);
                    dbCommand.CreateAndAddParameter("@isPrnt", request.IsParent);
                    dbCommand.CreateAndAddParameter("@PrjStDt", request.ProjectStartDate);
                    dbCommand.CreateAndAddParameter("@FinDt", request.ProjectEndDate);
                    dbCommand.CreateAndAddParameter("@Adrky", BaseComboResponse.GetKeyValue(request.Address));

                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    
                    while (reader.Read())
                    {
                        response.ProjectKey= reader.GetColumn<int>("PrjKy");
                    }

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    

                }
                catch (Exception exp)
                {
                    throw exp;
                }
                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        };
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    reader.Dispose();
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }
                return response;
            }
        }
    }
}
