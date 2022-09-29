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
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class ObjectRepository : BaseRepository, IObjectRepository
    {
        public ObjectRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
        }

        public BaseServerResponse<IList<UIObject>> GetUIDefinitions(int ParentKey, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                BaseServerResponse<IList<UIObject>> response = new BaseServerResponse<IList<UIObject>>();
                IList<UIObject> uIObjects = new List<UIObject>();    
                string SPName = "AllObjPrpObjMas_SelectPOS";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    CreateAndAddParameter(dbCommand, "@PrntKy", ParentKey);
                    CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                    CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                    CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();               ;
                    while (reader.Read())
                    {
                        UIObject uiObject = new UIObject();
                        uiObject.Arggreates = GetColumn<string>("Aggregates", reader);
                        uiObject.Alignment = GetColumn<string>("Alignment", reader);
                        uiObject.CssClass = GetColumn<string>("CSSClass", reader);
                        uiObject.DataType = GetColumn<string>("DataType", reader);
                        uiObject.DefaultDate = GetColumn<DateTime>("DefaultDt", reader);
                        uiObject.DefaultValue = GetColumn<string>("DefaultValue", reader);
                        uiObject.EnterKeyAction = GetColumn<string>("EntKyAction", reader);
                        uiObject.FooterTemplate = GetColumn<string>("FooterTemplate", reader);
                        uiObject.Format = GetColumn<string>("Format", reader);
                        uiObject.GroupFooterTemplate = GetColumn<string>("GrpFooterTemplate", reader);
                        uiObject.IsFreeze = GetColumn<bool>("IsFreeze", reader);
                        uiObject.IsEnable = GetColumn<bool>("IsEnable", reader);
                        uiObject.IsMust = GetColumn<bool>("isMust", reader);
                        uiObject.IsVisible = GetColumn<bool>("IsVisible", reader);
                        uiObject.ObjectCaption = GetColumn<string>("ObjCaptn", reader);
                        uiObject.ObjectKey = reader.GetColumn<int>("ObjKy");
                        uiObject.ObjectName = reader.GetColumn<string>("ObjNm");
                        uiObject.ObjectType = reader.GetColumn<string>("ObjTyp");
                        uiObject.OnClickAction = reader.GetColumn<string>("OnClickAction");
                        uiObject.OurCode = reader.GetColumn<string>("OurCd");
                        uiObject.OurCode2 = reader.GetColumn<string>("OurCd2");
                        uiObject.ParentKey = reader.GetColumn<int>("PrntKy");
                        uiObject.Width = reader.GetColumn<int>("Width");
                        uiObject.Level1ObjectName = reader.GetColumn<string>("Lvl1ObjNm");
                        uiObject.URLAction = reader.GetColumn<string>("URLAction");
                        uiObject.URLController = reader.GetColumn<string>("UrlController");
                        uiObject.SO = reader.GetColumn<double>("SO");
                        uiObject.NextObjectName = reader.GetColumn<string>("NxtEntObjNm");
                        uiObject.UIDomId = reader.GetColumn<string>("UiDomId");
                        uiObject.UIDomName = reader.GetColumn<string>("UiDomNm");
                        uiObject.MapId = reader.GetColumn<string>("MapId");
                        uiObject.MapName = reader.GetColumn<string>("MapNm");
                        uiObject.CollectionName = reader.GetColumn<string>("CollectionNm");
                        uiObject.IsAjax = reader.GetColumn<bool>("IsFA");
                        uiObject.ToolTip = reader.GetColumn<string>("ToolTip");
                        uiObject.NextObjectType = reader.GetColumn<string>("NxtObjTyp");
                        uiObject.ReferenceObjectKey = reader.GetColumn<int>("DTObjKy"); 
                        uiObject.ParentCssClass = reader.GetColumn<string>("ParentCssClass"); 
                        uiObject.IconCssClass = reader.GetColumn<string>("IconCssClass");
                        uiObject.IsAllowAdd = reader.GetColumn<bool>("isAlwAdd");
                        uiObject.ObjectTypeKey = reader.GetColumn<int>("thisObjTypKy");
                        uiObject.SPName = reader.GetColumn<string>("SPNm");
                        uiObject.IsAllowUpdate = reader.GetColumn<bool>("isAlwUpdate");
                        uiObject.GridEditMode = reader.GetColumn<byte>("GridEditMode");
                        uiObject.HierachhyType = reader.GetColumn<byte>("HierarchyTyp");
                        uiObject.UpdateURLAction = reader.GetColumn<string>("UpdateUrlAction");
                        uiObject.UpdateURLAction = reader.GetColumn<string>("UpdateUrlController");
                        uiObject.CreateURLAction = reader.GetColumn<string>("CreateUrlAction");
                        uiObject.CreateURLController = reader.GetColumn<string>("CreateUrlController");
                        uiObject.DeleteURLAction = reader.GetColumn<string>("DeleteUrlAction");
                        uiObject.DeleteURLController = reader.GetColumn<string>("DeleteUrlController");
                        uiObject.IsCreateToolBar = reader.GetColumn<bool>("isCreateToolbar");
                        uiObject.IsEnableRowFilter = reader.GetColumn<bool>("isEnableRowFilter");
                        uiObject.DefaultPath = reader.GetColumn<string>("DefaultPath");
                        uiObject.NumberOfRows = reader.GetColumn<short>("NoOfRows");
                        uiObject.ValidationMessae = reader.GetColumn<string>("ValidationMesg");
                        uiObject.ObjectID = reader.GetColumn<string>("ObjID");
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
