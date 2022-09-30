using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(ISQLDataLayer dataLayer):base(dataLayer)
        {

        }
        public decimal GetCostPriceByLocAndItmKy(Company company, CodeBaseResponse location, DateTime effectiveDate, long ItemKey, int ProjectKey = 1)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {

                decimal CostPrice = 0;
                string SPName = "GetItmCostByItmKy_SPWrapper";
                IDataReader reader = null;
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@Dt", effectiveDate.ToString("yyyy/MM/dd"));
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@LocKy", location.CodeKey);
                    dbCommand.CreateAndAddParameter("@ItmKy", ItemKey);
                    dbCommand.CreateAndAddParameter("@PrjKy", ProjectKey);
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        CostPrice = reader.GetColumn<decimal>("CostPrice");
                    }


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
                        reader.Dispose();
                    }
                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }
                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }

                return CostPrice;


            }
        }
    }
}
