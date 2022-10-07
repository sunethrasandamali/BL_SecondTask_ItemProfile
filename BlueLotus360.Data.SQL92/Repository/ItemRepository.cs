using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public BaseServerResponse<IList<ItemSimple>> GetItemsForTransaction(Company company, User user, ComboRequestDTO FilterOptions)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                SqlDataReader sqlDataReader = null;
                string SPName = "ItmCdNm_SelectMob";
                BaseServerResponse<IList<ItemSimple>> response = new BaseServerResponse<IList<ItemSimple>>();
                try
                {
                    IList<ItemSimple> items = new List<ItemSimple>();
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", FilterOptions.RequestingElementKey);
                    dbCommand.CreateAndAddParameter("@PreKy", FilterOptions.PreviousKey);
                    dbCommand.CreateAndAddParameter("@TrnTypKy", FilterOptions.TransactionTypeKey);
                    dbCommand.CreateAndAddParameter("@SearchVal", FilterOptions.SearchQuery);
                    response.ExecutionStarted = DateTime.UtcNow;

                    dbCommand.Connection.Open();

                    sqlDataReader = dbCommand.ExecuteReader() as SqlDataReader;


                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            ItemSimple item = new ItemSimple()
                            {
                                ItemKey = sqlDataReader.GetColumn<int>("ItmKy"),
                                ItemName = sqlDataReader.GetColumn<string>("ItmCdNm"),
                                FilterKey = sqlDataReader.GetColumn<int>("ColorKy"),
                                IsDefault = sqlDataReader.GetColumn<int>("ItmKy") == sqlDataReader.GetColumn<int>("DefaultKey")
                            };


                            items.Add(item);


                        }
                    }
                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = items;



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

        public ItemRateResponse GetItemRate(RateRetrivalModel dto, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                ItemRateResponse response = new ItemRateResponse();
                SqlDataReader sqlDataReader = null;
                string SPName = "ItmRateDisTax_SelectWeb";
                try
                {

                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@ItmKy", dto.ItemKey);
                    dbCommand.CreateAndAddParameter("@EftvDt", dto.EffectiveDate);
                    dbCommand.CreateAndAddParameter("@LocKy", dto.LocationKey);
                    dbCommand.CreateAndAddParameter("@TrnTypKy", dto.TransactionTypeKey);
                    dbCommand.CreateAndAddParameter("@BUKy", dto.BussienssUnitKey);
                    dbCommand.CreateAndAddParameter("@PrjKy", dto.ProjectKey);
                    dbCommand.CreateAndAddParameter("@AdrKy", dto.AddressKey);
                    dbCommand.CreateAndAddParameter("@AccKy", dto.AccountKey);
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@Cd1Ky", dto.Code1Key);
                    dbCommand.CreateAndAddParameter("@Cd2Ky", dto.Code2Key);
                    dbCommand.Connection.Open();
                    sqlDataReader = dbCommand.ExecuteReader() as SqlDataReader;


                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            response.TransactionRate = sqlDataReader.GetColumn<decimal>("TrnRate");
                            response.DiscountPercentage = sqlDataReader.GetColumn<decimal>("DisPer");
                            response.ItemTaxType1 = sqlDataReader.GetColumn<decimal>("ItmTaxTyp1Per");
                            response.ItemTaxType2 = sqlDataReader.GetColumn<decimal>("ItmTaxTyp2Per");
                            response.ItemTaxType3 = sqlDataReader.GetColumn<decimal>("ItmTaxTyp3Per");
                            response.ItemTaxType4 = sqlDataReader.GetColumn<decimal>("ItmTaxTyp4Per");
                            response.ItemTaxType5 = sqlDataReader.GetColumn<decimal>("ItmTaxTyp5Per");
                            response.Rate = sqlDataReader.GetColumn<decimal>("CostPri");
                            response.SplitLength = sqlDataReader.GetColumn<decimal>("SplitLength");
                            response.MarkUpPercentage = sqlDataReader.GetColumn<decimal>("MarkUpPer");
                            response.MinimumSalesPrice = sqlDataReader.GetColumn<decimal>("MinSlsPri");
                            response.Weight = sqlDataReader.GetColumn<decimal>("Weight");
                            response.Length = sqlDataReader.GetColumn<decimal>("Length");
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
                return response;

            }
        }

        public StockAsAtResponse GetStockAsAtByLocation(Company company, User user, StockAsAtRequest request)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                StockAsAtResponse stockResponse = new StockAsAtResponse();
                string SPName = "ItmCurStk_SelectWeb";

                IDataReader reader = null;
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", request.ElementKey);
                    dbCommand.CreateAndAddParameter("@ItmKy", request.ItemKey);
                    dbCommand.CreateAndAddParameter("@PrjKy", request.ProjectKey);
                    dbCommand.CreateAndAddParameter("@LocKy", request.LocationKey);



                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        stockResponse.ItemKey = reader.GetColumn<long>("ItmKy");
                        stockResponse.StockAsAt = reader.GetColumn<decimal>("CurStk");

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

                return stockResponse;


            }
        }
    }
}
