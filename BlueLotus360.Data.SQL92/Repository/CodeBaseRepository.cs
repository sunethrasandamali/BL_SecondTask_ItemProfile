﻿using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class CodeBaseRepository : BaseRepository,ICodeBaseRepository
    {
        public CodeBaseRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
        }

        public BaseServerResponse<CodeBaseResponse> GetCodeByOurCodeAndConditionCode(Company company, User user, string OurCode, string ConditionCode)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                BaseServerResponse<CodeBaseResponse> response = new BaseServerResponse<CodeBaseResponse>();
                string SPName = "GetCdKyByOurCdWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ConCd", ConditionCode);
                    dbCommand.CreateAndAddParameter("@OurCd", OurCode);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader() as SqlDataReader;
                    CodeBaseResponse codebase = new(); 
                    while (reader.Read())
                    {

                        codebase.CodeKey = reader.GetColumn<int>("CdKy");
                  

                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = codebase;

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

        public BaseServerResponse<IList<CodeBaseResponse>> GetCodeBaseByObject(Company company, User user, ComboRequestDTO requestDTO)
        {
            IList<CodeBaseResponse> codeBases = new List<CodeBaseResponse>();
            BaseServerResponse <IList<CodeBaseResponse>> response = new BaseServerResponse<IList<CodeBaseResponse>> ();

            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {

                IDataReader dataReader = null;
                string SPName = "CodeNm_SelectMob";
                try
                {

                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", requestDTO.RequestingElementKey);

                    if (requestDTO.AddtionalData != null)
                    {
                        foreach (var item in requestDTO.AddtionalData)
                        {
                            dbCommand.CreateAndAddParameter("@" + item.Key, item.Value);
                        }
                    }

                    response.ExecutionStarted = DateTime.UtcNow;

                    dbCommand.Connection.Open();
                    dataReader = dbCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        CodeBaseResponse codeBase = new CodeBaseResponse(dataReader.GetColumn<int>("CdKy"));
                        codeBase.Code= dataReader.GetColumn<string>("CdNmOnly");
                        codeBase.CodeName = dataReader.GetColumn<string>("CodeNm");
                        codeBase.CodeNameOnly = dataReader.GetColumn<string>("CdNmOnly");
                        codeBase.IsDefault = codeBase.CodeKey == dataReader.GetColumn<int>("DefaultKey");


                        codeBases.Add(codeBase);
                    }

                    response.ExecutionStarted = DateTime.UtcNow;
                    response.Value = codeBases;

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
                return response;
            }

        }
    }
}
