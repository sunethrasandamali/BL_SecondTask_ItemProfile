using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.ItemProfileMobile;
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
    internal class ItemProfileMobileRepository : BaseRepository, IItemProfileMobileRepository
    {
        public ItemProfileMobileRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {

        }

        //GetItemList
        public BaseServerResponse<IList<ItemSelectList>> GetItemProfileList(Company company, User user, ItemSelectListRequest request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "ItmMasV2_SelectWeb";
                BaseServerResponse<IList<ItemSelectList>> responses = new BaseServerResponse<IList<ItemSelectList>>();
                IList<ItemSelectList> itemList = new List<ItemSelectList>();


                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@usrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", request.ElementKey);
                    dbCommand.CreateAndAddParameter("@ItmTypKy", request.ItmTypKy);
                    //dbCommand.CreateAndAddParameter("@Dept", request.Dept);
                    //dbCommand.CreateAndAddParameter("@Cat", request.Cat);
                    //dbCommand.CreateAndAddParameter("@FrmRow", request.FrmRow);
                    //dbCommand.CreateAndAddParameter("@ToRow", request.ToRow);
                    //dbCommand.CreateAndAddParameter("@OnlyisAct", request.OnlyisAct);
                    //dbCommand.CreateAndAddParameter("@ItmCd", request.ItmCd);
                    //dbCommand.CreateAndAddParameter("@ItmNm", request.ItmNm);

                    responses.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        ItemSelectList response = new ItemSelectList();

                        response.ItmKy = reader.GetColumn<int>("ItmKy");
                        response.ItemCode = reader.GetColumn<string>("ItmCd");
                        response.ItemName = reader.GetColumn<string>("ItmNm");

                        response.ItemType.CodeKey = reader.GetColumn<int>("ItmTypKy");
                        response.ItemType.Code = reader.GetColumn<string>("ItmTypCd");
                        response.ItemType.CodeName = reader.GetColumn<string>("ItmTypNm");

                        response.ItemUnit.UnitKey = reader.GetColumn<int>("UnitKy");
                        response.ItemUnit.UnitName = reader.GetColumn<string>("Unit");

                        response.ParentItem.ItemKey = reader.GetColumn<int>("PrntKy");
                        response.ParentItem.ItemCode = reader.GetColumn<string>("PrntItmCd");
                        response.ParentItem.ItemName = reader.GetColumn<string>("PrntItmNm");

                        response.IsAct = Convert.ToBoolean(reader.GetColumn<byte>("isAct"));
                        response.IsApprove = Convert.ToBoolean(reader.GetColumn<byte>("isApr"));


                        itemList.Add(response);
                    }

                    responses.ExecutionEnded = DateTime.UtcNow;
                    responses.Value = itemList;

                    //if (!reader.IsClosed)
                    //{
                    //    reader.Close();
                    //}

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
                        //if (!reader.IsClosed)
                        //{
                        //    reader.Close();
                        //};
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    if(reader != null)
                    {
                        reader.Dispose();
                    }
                    
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }

                return responses;
            }
        }

        //InsertItem
        public bool InsertItem(Company company, User user, ItemSelectList request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "ItmMas_InsertWeb";
                //bool responses;

                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@usrKy", user.UserKey);

                    dbCommand.CreateAndAddParameter("@ItmCd", request.ItemCode);
                    dbCommand.CreateAndAddParameter("@ItmNm", request.ItemName);
                    dbCommand.CreateAndAddParameter("@ItmTypKy", request.ItemType.CodeKey);
                    dbCommand.CreateAndAddParameter("@UnitKy", request.ItemUnit.UnitKey);

                    dbCommand.CreateAndAddParameter("@isAct", Convert.ToInt32(request.IsAct));
                    dbCommand.CreateAndAddParameter("@isApr", Convert.ToInt32(request.IsApprove));

                    //responses.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    while (reader.Read())
                    {

                    }

                    //responses.ExecutionEnded = DateTime.UtcNow;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    return true;
                    
                }

                catch (Exception exp)
                {
                    return false;
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
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                    
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }

            }
        }

        //UpdateItem
        public bool UpdateItem(Company company, User user, ItemSelectList request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "ItmMasV2_UpdateWeb";
                //bool responses;

                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@usrKy", user.UserKey);

                    dbCommand.CreateAndAddParameter("@ItmKy", request.ItmKy);
                    dbCommand.CreateAndAddParameter("@ItmCd", request.ItemCode);
                    dbCommand.CreateAndAddParameter("@ItmNm", request.ItemName);

                    dbCommand.CreateAndAddParameter("@ItmTypKy", request.ItemType.CodeKey);

                    dbCommand.CreateAndAddParameter("@UnitKy", request.ItemUnit.UnitKey);

                    dbCommand.CreateAndAddParameter("@isAct", Convert.ToInt32(request.IsAct));
                    dbCommand.CreateAndAddParameter("@isApr", Convert.ToInt32(request.IsApprove));

                   // responses.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    while (reader.Read())
                    {

                    }

                    //responses.ExecutionEnded = DateTime.UtcNow;

                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    return true;

                }
                catch (Exception exp)
                {
                    return false;
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
            }
        }
    }

        
}
