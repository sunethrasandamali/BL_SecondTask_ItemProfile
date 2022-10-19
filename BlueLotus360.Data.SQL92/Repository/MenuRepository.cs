using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class MenuRepository :BaseRepository,IMenuRepository
    {
        public MenuRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {

        }

        public UIMenu GetMenuByObjectKey(User user, Company company, int ObjectKey = 1)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            UIMenu menu = new UIMenu();
            string SPName = "GetAllCompanyMenuAccessSingle";
            try
            {
                dbCommand = _dataLayer.GetCommandAccess();

                dbCommand.Connection.Open();

                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = SPName;
                CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey); 
                CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                CreateAndAddParameter(dbCommand, "@ObjKy", ObjectKey);

                reader = dbCommand.ExecuteReader();

                while (reader.Read())
                {
                    menu = new UIMenu();


                    if (reader["ObjKy"] != DBNull.Value)
                    {
                        menu.MenuId = Convert.ToInt32(reader["ObjKy"]);
                    }
                    if (reader["ObjCd"] != DBNull.Value)
                    {
                        menu.MenuCode = Convert.ToString(reader["ObjCd"]);
                    }
                    if (reader["ObjNm"] != DBNull.Value)
                    {
                        menu.MenuName = Convert.ToString(reader["ObjNm"]);
                    }
                    if (reader["ObjCaptn"] != DBNull.Value)
                    {
                        menu.MenuCaption = Convert.ToString(reader["ObjCaptn"]);
                    }
                    if (reader["URLController"] != DBNull.Value)
                    {
                        menu.ControllerName = Convert.ToString(reader["URLController"]);
                    }
                    if (reader["URLAction"] != DBNull.Value)
                    {
                        menu.ControllerAction = Convert.ToString(reader["URLAction"]);
                    }
                    if (reader["CSSClass"] != DBNull.Value)
                    {
                        menu.CustomeStyle = Convert.ToString(reader["CSSClass"]);
                    }
                    if (reader["Target"] != DBNull.Value)
                    {
                        menu.Target = Convert.ToString(reader["Target"]);
                    }
                    if (reader["PrntKy"] != DBNull.Value)
                    {
                        menu.ParentId = Convert.ToInt32(reader["PrntKy"]);
                    }
                    if (reader["OurCd"] != DBNull.Value)
                    {
                        menu.OurCode = Convert.ToString(reader["OurCd"]);
                    }
                    if (reader["OurCd2"] != DBNull.Value)
                    {
                        menu.OurCode2 = Convert.ToString(reader["OurCd2"]);
                    }


                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
            return menu;
        }

        public List<UIMenu> GetMenuForReorder(User user, Company company)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            List<UIMenu> menues = new List<UIMenu>();
            string SPName = "GetAllMenuForReorder";
            try
            {
                dbCommand = _dataLayer.GetCommandAccess();

                dbCommand.Connection.Open();


                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = SPName;
                CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey); //ALEX
                CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                reader = dbCommand.ExecuteReader();
                UIMenu menu;
                while (reader.Read())
                {
                    menu = new UIMenu();


                    if (reader["ObjKy"] != DBNull.Value)
                    {
                        menu.MenuId = Convert.ToInt32(reader["ObjKy"]);
                    }
                    if (reader["ObjCd"] != DBNull.Value)
                    {
                        menu.MenuCode = Convert.ToString(reader["ObjCd"]);
                    }
                    if (reader["ObjNm"] != DBNull.Value)
                    {
                        menu.MenuName = Convert.ToString(reader["ObjNm"]);
                    }
                    if (reader["ObjCaptn"] != DBNull.Value)
                    {
                        menu.MenuCaption = Convert.ToString(reader["ObjCaptn"]);
                    }
                    if (reader["URLController"] != DBNull.Value)
                    {
                        menu.ControllerName = Convert.ToString(reader["URLController"]);
                    }
                    if (reader["URLAction"] != DBNull.Value)
                    {
                        menu.ControllerAction = Convert.ToString(reader["URLAction"]);
                    }
                    if (reader["CSSClass"] != DBNull.Value)
                    {
                        menu.CustomeStyle = Convert.ToString(reader["CSSClass"]);
                    }
                    if (reader["Target"] != DBNull.Value)
                    {
                        menu.Target = Convert.ToString(reader["Target"]);
                    }
                    if (reader["PrntKy"] != DBNull.Value)
                    {
                        menu.ParentId = Convert.ToInt32(reader["PrntKy"]);
                    }
                    if (reader["OurCd"] != DBNull.Value)
                    {
                        menu.OurCode = Convert.ToString(reader["OurCd"]);
                    }
                    menues.Add(menu);


                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
            return menues;
        }

        public List<UIMenu> GetMenusByUserAndCompany(User user, Company company)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            List<UIMenu> menues = new List<UIMenu>();
            string SPName = "GetAllCompanyMenuAccessBLLite";
            try
            {
                dbCommand = _dataLayer.GetCommandAccess();

                dbCommand.Connection.Open();


                dbCommand.CommandType = CommandType.StoredProcedure;
                //dbCommand.CommandText = "GetAllCompanyMenuAccessWasm";
                dbCommand.CommandText = SPName;
                CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey); 
                CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                reader = dbCommand.ExecuteReader();
                UIMenu menu;
                while (reader.Read())
                {
                    menu = new UIMenu();


                    if (reader["ObjKy"] != DBNull.Value)
                    {
                        menu.MenuId = Convert.ToInt32(reader["ObjKy"]);
                    }
                    if (reader["ObjCd"] != DBNull.Value)
                    {
                        menu.MenuCode = Convert.ToString(reader["ObjCd"]);
                    }
                    if (reader["ObjNm"] != DBNull.Value)
                    {
                        menu.MenuName = Convert.ToString(reader["ObjNm"]);
                    }
                    if (reader["ObjCaptn"] != DBNull.Value)
                    {
                        menu.MenuCaption = Convert.ToString(reader["ObjCaptn"]);
                    }
                    if (reader["URLController"] != DBNull.Value)
                    {
                        menu.ControllerName = Convert.ToString(reader["URLController"]);
                    }
                    if (reader["URLAction"] != DBNull.Value)
                    {
                        menu.ControllerAction = Convert.ToString(reader["URLAction"]);
                    }
                    if (reader["CSSClass"] != DBNull.Value)
                    {
                        menu.CustomeStyle = Convert.ToString(reader["CSSClass"]);
                    }
                    if (reader["Target"] != DBNull.Value)
                    {
                        menu.Target = Convert.ToString(reader["Target"]);
                    }
                    if (reader["PrntKy"] != DBNull.Value)
                    {
                        menu.ParentId = Convert.ToInt32(reader["PrntKy"]);
                    }
                    if (reader["OurCd"] != DBNull.Value)
                    {
                        menu.OurCode = Convert.ToString(reader["OurCd"]);
                    }
                    if (reader["IsDebug"] != DBNull.Value)
                    {
                        menu.IsDebug = Convert.ToBoolean(reader["IsDebug"]);
                    }


                    if (reader["IconCSSClass"] != DBNull.Value)
                    {
                        menu.MenuIcon = Convert.ToString(reader["IconCSSClass"]);
                    }
                    menues.Add(menu);


                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
            return menues;
        }

        public List<UIMenu> GetMobileMenusByUserAndCompany(User user, Company company)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            List<UIMenu> menues = new List<UIMenu>();
            string SPName = "GetAllCompanyMenuAccessBLLite";
            try
            {
                dbCommand = _dataLayer.GetCommandAccess();

                dbCommand.Connection.Open();


                dbCommand.CommandType = CommandType.StoredProcedure;
                //dbCommand.CommandText = "GetAllCompanyMenuAccessWasm";
                dbCommand.CommandText = SPName;
                CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                reader = dbCommand.ExecuteReader();
                UIMenu menu;
                while (reader.Read())
                {
                    menu = new UIMenu();


                    if (reader["ObjKy"] != DBNull.Value)
                    {
                        menu.MenuId = Convert.ToInt32(reader["ObjKy"]);
                    }
                    if (reader["ObjCd"] != DBNull.Value)
                    {
                        menu.MenuCode = Convert.ToString(reader["ObjCd"]);
                    }
                    if (reader["ObjNm"] != DBNull.Value)
                    {
                        menu.MenuName = Convert.ToString(reader["ObjNm"]);
                    }
                    if (reader["ObjCaptn"] != DBNull.Value)
                    {
                        menu.MenuCaption = Convert.ToString(reader["ObjCaptn"]);
                    }
                    if (reader["URLController"] != DBNull.Value)
                    {
                        menu.ControllerName = Convert.ToString(reader["URLController"]);
                    }
                    if (reader["URLAction"] != DBNull.Value)
                    {
                        menu.ControllerAction = Convert.ToString(reader["URLAction"]);
                    }
                    if (reader["CSSClass"] != DBNull.Value)
                    {
                        menu.CustomeStyle = Convert.ToString(reader["CSSClass"]);
                    }
                    if (reader["Target"] != DBNull.Value)
                    {
                        menu.Target = Convert.ToString(reader["Target"]);
                    }
                    if (reader["PrntKy"] != DBNull.Value)
                    {
                        menu.ParentId = Convert.ToInt32(reader["PrntKy"]);
                    }
                    if (reader["OurCd"] != DBNull.Value)
                    {
                        menu.OurCode = Convert.ToString(reader["OurCd"]);
                    }
                    if (reader["IsDebug"] != DBNull.Value)
                    {
                        menu.IsDebug = Convert.ToBoolean(reader["IsDebug"]);
                    }


                    if (reader["IconCSSClass"] != DBNull.Value)
                    {
                        menu.MenuIcon = Convert.ToString(reader["IconCSSClass"]);
                    }
                    menues.Add(menu);


                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
            return menues;
        }

        public IList<UIMenu> GetPinnedMenu(User user, Company company)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            IList<UIMenu> menues = new List<UIMenu>();
            string SPName = "MenuSearch_SelectWeb";
            try
            {
                dbCommand = _dataLayer.GetCommandAccess();

                dbCommand.Connection.Open();


                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = SPName;

                CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                CreateAndAddParameter(dbCommand, "@txt", "");
                CreateAndAddParameter(dbCommand, "@isPinned", null);
                CreateAndAddParameter(dbCommand, "@ObjKy", 1);
                CreateAndAddParameter(dbCommand, "@isBLLite", 1);
                reader = dbCommand.ExecuteReader();
                UIMenu menu;
                while (reader.Read())
                {
                    menu = new UIMenu();

                    if (reader["ObjCaptn"] != DBNull.Value)
                    {
                        menu.MenuCaption = Convert.ToString(reader["ObjCaptn"]);
                    }
                    if (reader["isPinned"] != DBNull.Value)
                    {
                        menu.Ispinned = Convert.ToBoolean(reader["isPinned"]);
                    }
                    if (reader["UsrObjKy"] != DBNull.Value)
                    {
                        menu.UserObjectKey = Convert.ToInt64(reader["UsrObjKy"]);
                    }
                    if (reader["ObjKy"] != DBNull.Value)
                    {
                        menu.MenuId = Convert.ToInt32(reader["ObjKy"]);
                    }
                    if (reader["URLController"] != DBNull.Value)
                    {
                        menu.ControllerName = Convert.ToString(reader["URLController"]);
                    }
                    if (reader["URLAction"] != DBNull.Value)
                    {
                        menu.ControllerAction = Convert.ToString(reader["URLAction"]);
                    }

                    menues.Add(menu);


                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
            return menues;
        }

        public IList<UIMenu> MenuSearch(User user, Company company)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            List<UIMenu> menues = new List<UIMenu>();
            string SPName = "MenuSearch_SelectWeb";
            try
            {
                dbCommand = _dataLayer.GetCommandAccess();

                dbCommand.Connection.Open();

                dbCommand.CommandType = CommandType.StoredProcedure;
                dbCommand.CommandText = SPName;
                CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                reader = dbCommand.ExecuteReader();
                UIMenu menu;
                while (reader.Read())
                {
                    menu = new UIMenu();


                    if (reader["ObjKy"] != DBNull.Value)
                    {
                        menu.MenuId = Convert.ToInt32(reader["ObjKy"]);
                    }
                    if (reader["ObjCd"] != DBNull.Value)
                    {
                        menu.MenuCode = Convert.ToString(reader["ObjCd"]);
                    }
                    if (reader["ObjNm"] != DBNull.Value)
                    {
                        menu.MenuName = Convert.ToString(reader["ObjNm"]);
                    }
                    if (reader["ObjCaptn"] != DBNull.Value)
                    {
                        menu.MenuCaption = Convert.ToString(reader["ObjCaptn"]);
                    }
                    if (reader["URLController"] != DBNull.Value)
                    {
                        menu.ControllerName = Convert.ToString(reader["URLController"]);
                    }
                    if (reader["URLAction"] != DBNull.Value)
                    {
                        menu.ControllerAction = Convert.ToString(reader["URLAction"]);
                    }
                    if (reader["CSSClass"] != DBNull.Value)
                    {
                        menu.CustomeStyle = Convert.ToString(reader["CSSClass"]);
                    }
                    //if (reader["Target"] != DBNull.Value)
                    //{
                    //    menu.Target = Convert.ToString(reader["Target"]);
                    //}
                    if (reader["PrntKy"] != DBNull.Value)
                    {
                        menu.ParentId = Convert.ToInt32(reader["PrntKy"]);
                    }
                    if (reader["OurCd"] != DBNull.Value)
                    {
                        menu.OurCode = Convert.ToString(reader["OurCd"]);
                    }
                    menues.Add(menu);


                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }
            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
            return menues;
        }

        public void UpdatePinnedMenu(User user, Company company, UIMenu request)
        {
            IDataReader reader = null;
            IDbCommand dbCommand = null;
            string SPName = "MenuSearch_UpdateWeb";
            try
            {


                for (int i = 0; i < request.SubMenus.Count; i++)
                {
                    dbCommand = _dataLayer.GetCommandAccess();
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    CreateAndAddParameter(dbCommand, "@UsrKy", user.UserKey);
                    CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                    CreateAndAddParameter(dbCommand, "@LoggedUsrKy ", user.UserKey);
                    CreateAndAddParameter(dbCommand, "@isPinned", request.SubMenus[i].Ispinned ? 1 : 0);
                    CreateAndAddParameter(dbCommand, "@ObjKy", request.SubMenus[i].MenuId);
                    CreateAndAddParameter(dbCommand, "@Des", "");
                    CreateAndAddParameter(dbCommand, "@UsrObjKy", request.SubMenus[i].UserObjectKey);

                    dbCommand.Connection.Open();
                    dbCommand.ExecuteNonQuery();


                }

                if (dbCommand.Connection.State != ConnectionState.Closed)
                {
                    dbCommand.Connection.Close();
                }

            }
            catch (Exception exp)
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }

            }
        }
    }
}
