using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Report;
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
    internal class CommonRepository:BaseRepository,ICommonRepository
    {
        public CommonRepository(ISQLDataLayer datalayer):base(datalayer)
        {

        }

        public ReportCompanyDetailsResponse GetCompanyDetailsResponse(Company company, User user, ReportCompanyDetailsRequest request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader dataReader = null;
                string SPName = "Company_SelectReportWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText =SPName;
                    dbCommand.CreateAndAddParameter("@CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@BUky", BaseComboResponse.GetKeyValue(request.BussinessUnit));
                    dbCommand.CreateAndAddParameter("@TrnKy", request.TransactionKey);
                    dbCommand.CreateAndAddParameter("@OrdKy", request.OrderKey);
                    dbCommand.CreateAndAddParameter("@EmpKy", request.EmployeeKey);
                    dbCommand.CreateAndAddParameter("@LocKy", BaseComboResponse.GetKeyValue(request.Location));
                    dbCommand.Connection.Open();
                    dataReader = dbCommand.ExecuteReader();
                    ReportCompanyDetailsResponse userPermission = new ReportCompanyDetailsResponse();
                    while (dataReader.Read())
                    {
                        userPermission.CompanyCode = dataReader.GetColumn<string>("CCd");
                        userPermission.CompanyName = dataReader.GetColumn<string>("CNm");
                        userPermission.Address = dataReader.GetColumn<string>("Address");
                        userPermission.Town = dataReader.GetColumn<string>("Town");
                        userPermission.City = dataReader.GetColumn<string>("City");
                        userPermission.Country = dataReader.GetColumn<string>("Country");
                        userPermission.TP1 = dataReader.GetColumn<string>("TP1");
                        userPermission.TP2 = dataReader.GetColumn<string>("TP2");
                        userPermission.TP3 = dataReader.GetColumn<string>("TP3");
                        userPermission.Fax = dataReader.GetColumn<string>("Fax");
                        userPermission.Email = dataReader.GetColumn<string>("Email");
                        userPermission.WebSite = dataReader.GetColumn<string>("WebSite");
                        userPermission.TaxNo = dataReader.GetColumn<string>("TaxNo");
                        userPermission.TaxNo2 = dataReader.GetColumn<string>("TaxNo2");
                        userPermission.EPFRegNo = dataReader.GetColumn<string>("EPFRegNo");
                        userPermission.b64Logo = dataReader.GetColumn<string>("Logo");
                        userPermission.BRNo = dataReader.GetColumn<string>("BRNo");
                        userPermission.BOIRegNo = dataReader.GetColumn<string>("BOIRegNo");
                        userPermission.Remarks = dataReader.GetColumn<string>("CRem");
                    }

                    return userPermission;

                }
                catch (Exception exp)
                {
                    return new ReportCompanyDetailsResponse();
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (dataReader != null)
                    {
                        if (!dataReader.IsClosed)
                        {
                            dataReader.Close();
                        }
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    dataReader.Dispose();
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }

            }
        }

       
    }
}
