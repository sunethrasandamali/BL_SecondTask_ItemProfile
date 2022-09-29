using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class ObjectRepository : BaseRepository, IObjectRepository
    {
        public ObjectRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
        }
        public long GetEntityCount(Company company)
        {
            throw new NotImplementedException();
        }
        public void Create(UIObject uiObject)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                SqlDataReader sqlDataReader = null;

                try
                {

                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = "ObjMasV3_InsertWeb";
                    dbCommand.CreateAndAddParameter("@PrntKy", uiObject.ParentKey);
                    dbCommand.CreateAndAddParameter("@ObjNm", uiObject.ObjectName);

                    dbCommand.CreateAndAddParameter("@ObjTypKy", uiObject.UiObjectType.ObjectTypeKey);
                    dbCommand.CreateAndAddParameter("@ObjCaptn", uiObject.ObjectCaption);
                    dbCommand.CreateAndAddParameter("@OurCd", uiObject.OurCode);
                    dbCommand.CreateAndAddParameter("@OurCd2", uiObject.OurCode2);
                    dbCommand.CreateAndAddParameter("@UrlAction", uiObject.UrlAction);
                    dbCommand.CreateAndAddParameter("@UrlController", uiObject.UrlController);
                    dbCommand.CreateAndAddParameter("@Width", uiObject.Width);
                    //dbCommand.CreateAndAddParameter("@NxtEntObjNm", uiObject.NextObjectName);
                    dbCommand.CreateAndAddParameter("@CollectionNm", uiObject.CollectionName);
                    dbCommand.CreateAndAddParameter("@MapNm", uiObject.MapName);
                    dbCommand.CreateAndAddParameter("@MapId", uiObject.MapKey);


                    dbCommand.CreateAndAddParameter("@UiDomNm", uiObject.UiDomName);
                    dbCommand.CreateAndAddParameter("@UiDomId", uiObject.UiDomId);



                    dbCommand.CreateAndAddParameter("@CssClass", uiObject.CssClass);
                    dbCommand.CreateAndAddParameter("@OnClickAction", uiObject.OnClickAction);
                    dbCommand.CreateAndAddParameter("@EntKyAction", uiObject.EnterKeyAction);
                    dbCommand.CreateAndAddParameter("@DefaultValue", uiObject.DefaultValue);
                    dbCommand.CreateAndAddParameter("@DefaultPath", uiObject.DefaultPath);
                    dbCommand.CreateAndAddParameter("@isAct", uiObject.IsActive);
                    dbCommand.CreateAndAddParameter("@isAjaxForm", uiObject.IsAjaxForm);
                    dbCommand.CreateAndAddParameter("@isMust", uiObject.IsMust);
                    dbCommand.CreateAndAddParameter("@isVisible", uiObject.IsVisible);
                    dbCommand.CreateAndAddParameter("@ToolTip", uiObject.ToolTip);
                    dbCommand.CreateAndAddParameter("@ReferenceObjectKey", uiObject.ReferenceObjectKey);
                    dbCommand.CreateAndAddParameter("@ParentCssClass", uiObject.ParentCssClass);
                    dbCommand.CreateAndAddParameter("@Format", uiObject.Format);
                    dbCommand.CreateAndAddParameter("@IconCss", uiObject.IconCss);
                    dbCommand.CreateAndAddParameter("@SpNm", uiObject.StoredPorcedureName);
                    dbCommand.CreateAndAddParameter("@SpParamMapNm", uiObject.ParameterName);
                    dbCommand.CreateAndAddParameter("@ReportPath", uiObject.ReportPath);
                    dbCommand.CreateAndAddParameter("@ReportName", uiObject.ReportName);
                    dbCommand.CreateAndAddParameter("@ObjID", uiObject.ObjectUniqueID);


                    dbCommand.Connection.Open();

                    sqlDataReader = dbCommand.ExecuteReader() as SqlDataReader;


                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            uiObject.ObjectId = sqlDataReader.GetColumn<int>("NewRecKy");

                        }
                    }



                }
                catch (Exception exp)
                {
                    throw exp;
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;
                    if (sqlDataReader != null)
                    {
                        if (!sqlDataReader.IsClosed)
                        {
                            sqlDataReader.Close();
                        }
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    sqlDataReader.Dispose();
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }

            }
        }
        public void Update(UIObject entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(UIObject entity)
        {
            throw new NotImplementedException();
        }
        public BaseServerResponse<UIObject> GetByID(Guid Id)
        {
            throw new NotImplementedException();
        }

        public BaseServerResponse<UIObject> GetByID(int Id)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                string SPName = "ObjMasV3_SelectRecWeb";
                SqlDataReader sqlDataReader = null;
                BaseServerResponse<UIObject> response = new BaseServerResponse<UIObject>();
                try
                {

                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    CreateAndAddParameter(dbCommand, "ObjKy", Id);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();

                    sqlDataReader = dbCommand.ExecuteReader() as SqlDataReader;

                    UIObject uiObject = new UIObject();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            uiObject.Aggregates = GetColumn<string>("Aggregates", sqlDataReader);
                            uiObject.Alignment = GetColumn<string>("Alignment", sqlDataReader);
                            uiObject.CssClass = GetColumn<string>("CSSClass", sqlDataReader);
                            uiObject.DataType = GetColumn<string>("DataType", sqlDataReader);
                            uiObject.DefaultDate = GetColumn<DateTime>("DefaultDt", sqlDataReader);
                            uiObject.DefaultValue = GetColumn<string>("DefaultValue", sqlDataReader);
                            uiObject.DefaultPath = GetColumn<string>("DefaultPath", sqlDataReader);
                            uiObject.EnterKeyAction = GetColumn<string>("EntKyAction", sqlDataReader);
                            uiObject.FooterTemplate = GetColumn<string>("FooterTemplate", sqlDataReader);
                            uiObject.Format = GetColumn<string>("Format", sqlDataReader);
                            uiObject.GroupFooterTemplate = GetColumn<string>("GrpFooterTemplate", sqlDataReader);
                            uiObject.IsFreeze = GetColumn<bool>("IsFreeze", sqlDataReader);
                            uiObject.IsEnable = GetColumn<bool>("IsEnable", sqlDataReader);
                            uiObject.IsMust = GetColumn<bool>("isMust", sqlDataReader);
                            uiObject.IsVisible = GetColumn<bool>("IsVisible", sqlDataReader);
                            uiObject.ObjectCaption = GetColumn<string>("ObjCaptn", sqlDataReader);
                            uiObject.ObjectId = sqlDataReader.GetColumn<int>("ObjKy");
                            uiObject.ObjectName = sqlDataReader.GetColumn<string>("ObjNm");
                            uiObject.ObjectType = sqlDataReader.GetColumn<string>("ObjectType");
                            uiObject.OnClickAction = sqlDataReader.GetColumn<string>("OnClickAction");
                            uiObject.OurCode = sqlDataReader.GetColumn<string>("OurCd");
                            uiObject.OurCode2 = sqlDataReader.GetColumn<string>("OurCd2");
                            uiObject.ParentKey = sqlDataReader.GetColumn<int>("PrntKy");
                            uiObject.Width = sqlDataReader.GetColumn<int>("Width");
                            //uiObject.UiSection = sqlDataReader.GetColumn<string>("Lvl1ObjNm");
                            uiObject.UrlAction = sqlDataReader.GetColumn<string>("URLAction");
                            uiObject.UrlController = sqlDataReader.GetColumn<string>("UrlController");
                            uiObject.SortingOrder = sqlDataReader.GetColumn<decimal>("SO");
                            uiObject.NextObjectName = sqlDataReader.GetColumn<string>("NxtEntObjNm");
                            uiObject.UiDomId = sqlDataReader.GetColumn<string>("UiDomId");
                            uiObject.UiDomName = sqlDataReader.GetColumn<string>("UiDomNm");
                            uiObject.MapKey = sqlDataReader.GetColumn<string>("MapId");
                            uiObject.MapName = sqlDataReader.GetColumn<string>("MapNm");
                            uiObject.CollectionName = sqlDataReader.GetColumn<string>("CollectionNm");
                            uiObject.IsAjaxForm = sqlDataReader.GetColumn<bool>("IsFA");
                            uiObject.ToolTip = sqlDataReader.GetColumn<string>("ToolTip");
                            uiObject.IsActive = sqlDataReader.GetColumn<byte>("isAct");
                            uiObject.UiObjectType = new UIObjectType()
                            {
                                ObjectType = sqlDataReader.GetColumn<string>("ObjectType"),
                                ObjectTypeKey = sqlDataReader.GetColumn<int>("ObjTypKy"),

                            };
                            uiObject.ReferenceObjectKey = sqlDataReader.GetColumn<int>("DTObjKy"); //DTObjKy
                            uiObject.ParentCssClass = sqlDataReader.GetColumn<string>("ParentCssClass"); //DTObjKy
                            uiObject.IconCss = sqlDataReader.GetColumn<string>("IconCssClass");
                            uiObject.IsOption66Active = sqlDataReader.GetColumn<bool>("isCd66");

                            uiObject.ParameterName = sqlDataReader.GetColumn<string>("SpParamMapNm");
                            uiObject.StoredPorcedureName = sqlDataReader.GetColumn<string>("SpNm");
                            uiObject.ReportPath = sqlDataReader.GetColumn<string>("ReportPath");
                            uiObject.IsVisible = sqlDataReader.GetColumn<bool>("IsVisible");
                            uiObject.IsOption1Active = sqlDataReader.GetColumn<bool>("isCd01");
                            uiObject.IsOption2Active = sqlDataReader.GetColumn<bool>("isCd02");
                            uiObject.IsOption3Active = sqlDataReader.GetColumn<bool>("isCd03");
                            uiObject.IsOption4Active = sqlDataReader.GetColumn<bool>("isCd04");
                            uiObject.IsOption5Active = sqlDataReader.GetColumn<bool>("isCd05");
                            uiObject.IsOption6Active = sqlDataReader.GetColumn<bool>("isCd06");
                            uiObject.ReportName = sqlDataReader.GetColumn<string>("ReportName");
                            uiObject.ObjectUniqueID = sqlDataReader.GetColumn<string>("ObjID");

                            uiObject.ReadAction = sqlDataReader.GetColumn<string>("ReadAction");
                            uiObject.ReadController = sqlDataReader.GetColumn<string>("ReadController");


                            uiObject.CreateAction = sqlDataReader.GetColumn<string>("CreateURLAction");
                            uiObject.CreateController = sqlDataReader.GetColumn<string>("CreateURLController");

                            uiObject.UpdateAction = sqlDataReader.GetColumn<string>("UpdateURLAction");
                            uiObject.UpdateController = sqlDataReader.GetColumn<string>("UpdateUrlController");

                            uiObject.DeleteAction = sqlDataReader.GetColumn<string>("DeleteURLAction");
                            uiObject.DeleteController = sqlDataReader.GetColumn<string>("DeleteURLController");


                        }
                    }

                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = uiObject;
                    

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
                    if (sqlDataReader != null)
                    {
                        if (!sqlDataReader.IsClosed)
                        {
                            sqlDataReader.Close();
                        }
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    sqlDataReader.Dispose();
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }
                return response;
            }
        }

        public BaseServerResponse<IList<UIObject>> GetUIDefinitions(int ParentKey, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader sqlDataReader = null;
                BaseServerResponse<IList<UIObject>> response = new BaseServerResponse<IList<UIObject>>();
                IList<UIObject> uIObjects = new List<UIObject>();
                string SPName = "AllObjPrpObjMas_SelectPOS";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    CreateAndAddParameter(dbCommand, "@PrntKy", ParentKey);
                    CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                    CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    sqlDataReader = dbCommand.ExecuteReader(); ;
                    while (sqlDataReader.Read())
                    {
                        UIObject uiObject = new UIObject();
                        uiObject.Aggregates = GetColumn<string>("Aggregates", sqlDataReader);
                        uiObject.Alignment = GetColumn<string>("Alignment", sqlDataReader);
                        uiObject.CssClass = GetColumn<string>("CSSClass", sqlDataReader);
                        uiObject.DataType = GetColumn<string>("DataType", sqlDataReader);
                        uiObject.DefaultDate = GetColumn<DateTime>("DefaultDt", sqlDataReader);
                        uiObject.DefaultValue = GetColumn<string>("DefaultValue", sqlDataReader);
                        uiObject.EnterKeyAction = GetColumn<string>("EntKyAction", sqlDataReader);
                        uiObject.FooterTemplate = GetColumn<string>("FooterTemplate", sqlDataReader);
                        uiObject.Format = GetColumn<string>("Format", sqlDataReader);
                        uiObject.GroupFooterTemplate = GetColumn<string>("GrpFooterTemplate", sqlDataReader);
                        uiObject.IsFreeze = GetColumn<bool>("IsFreeze", sqlDataReader);
                        uiObject.IsEnable = GetColumn<bool>("IsEnable", sqlDataReader);
                        uiObject.IsMust = GetColumn<bool>("isMust", sqlDataReader);
                        uiObject.IsVisible = GetColumn<bool>("IsVisible", sqlDataReader);
                        uiObject.ObjectCaption = GetColumn<string>("ObjCaptn", sqlDataReader);
                        uiObject.ObjectId = sqlDataReader.GetColumn<int>("ObjKy");
                        uiObject.ObjectName = sqlDataReader.GetColumn<string>("ObjNm");
                        uiObject.ObjectType = sqlDataReader.GetColumn<string>("ObjTyp");
                        uiObject.OnClickAction = sqlDataReader.GetColumn<string>("OnClickAction");
                        uiObject.OurCode = sqlDataReader.GetColumn<string>("OurCd");
                        uiObject.OurCode2 = sqlDataReader.GetColumn<string>("OurCd2");
                        uiObject.ParentKey = sqlDataReader.GetColumn<int>("PrntKy");
                        uiObject.Width = sqlDataReader.GetColumn<int>("Width");
                        uiObject.UiSection = sqlDataReader.GetColumn<string>("Lvl1ObjNm");
                        uiObject.UrlAction = sqlDataReader.GetColumn<string>("URLAction");
                        uiObject.UrlController = sqlDataReader.GetColumn<string>("UrlController");
                        uiObject.SortingOrder = sqlDataReader.GetColumn<decimal>("SO");
                        uiObject.NextObjectName = sqlDataReader.GetColumn<string>("NxtEntObjNm");
                        uiObject.UiDomId = sqlDataReader.GetColumn<string>("UiDomId");
                        uiObject.UiDomName = sqlDataReader.GetColumn<string>("UiDomNm");
                        uiObject.MapKey = sqlDataReader.GetColumn<string>("MapId");
                        uiObject.MapName = sqlDataReader.GetColumn<string>("MapNm");
                        uiObject.CollectionName = sqlDataReader.GetColumn<string>("CollectionNm");
                        uiObject.IsAjaxForm = sqlDataReader.GetColumn<bool>("IsFA");
                        uiObject.ToolTip = sqlDataReader.GetColumn<string>("ToolTip");
                        uiObject.NextObjectType = sqlDataReader.GetColumn<string>("NxtObjTyp");
                        uiObject.ReferenceObjectKey = sqlDataReader.GetColumn<int>("DTObjKy"); //DTObjKy

                        uiObject.ParentCssClass = sqlDataReader.GetColumn<string>("ParentCssClass"); //DTObjKy
                        uiObject.IconCss = sqlDataReader.GetColumn<string>("IconCssClass");
                        uiObject.HasPermisonToAdd = sqlDataReader.GetColumn<bool>("isAlwAdd");
                        uiObject.ObjectTypeKey = sqlDataReader.GetColumn<int>("thisObjTypKy");
                        uiObject.StoredPorcedureName = sqlDataReader.GetColumn<string>("SPNm");
                        uiObject.IsAllowEdit = sqlDataReader.GetColumn<bool>("isAlwUpdate");
                        uiObject.GridEditMode = sqlDataReader.GetColumn<sbyte>("GridEditMode");
                        uiObject.HierarchyType = sqlDataReader.GetColumn<sbyte>("HierarchyTyp");
                        uiObject.UpdateAction = sqlDataReader.GetColumn<string>("UpdateUrlAction");
                        uiObject.UpdateController = sqlDataReader.GetColumn<string>("UpdateUrlController");
                        uiObject.CreateAction = sqlDataReader.GetColumn<string>("CreateUrlAction");
                        uiObject.CreateController = sqlDataReader.GetColumn<string>("CreateUrlController");

                        uiObject.DeleteAction = sqlDataReader.GetColumn<string>("DeleteUrlAction");
                        uiObject.DeleteController = sqlDataReader.GetColumn<string>("DeleteUrlController");
                        uiObject.IsCreateToolBar = sqlDataReader.GetColumn<bool>("isCreateToolbar");
                        uiObject.IsEnableRowFilter = sqlDataReader.GetColumn<bool>("isEnableRowFilter");
                        uiObject.DefaultPath = sqlDataReader.GetColumn<string>("DefaultPath");
                        uiObject.NoOfRows = sqlDataReader.GetColumn<decimal>("NoOfRows");
                        uiObject.ValidationMessage = sqlDataReader.GetColumn<string>("ValidationMesg");
                        uiObject.ObjectUniqueID = sqlDataReader.GetColumn<string>("ObjID");
                        uIObjects.Add(uiObject);


                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = uIObjects;

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
                    if (sqlDataReader != null && !sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
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
