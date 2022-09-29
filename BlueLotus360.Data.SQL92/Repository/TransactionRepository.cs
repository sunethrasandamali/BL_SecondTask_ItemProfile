using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Transaction;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.SQL92.Definition;
using BlueLotus360.Data.SQL92.Extenstions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Repository
{
    internal class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {
                
        }

        public void SaveGenericTransaction(Company company, User user, BaseServerResponse<BLTransaction> transaction)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "TrnHdr_InsertWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    if (transaction!=null && transaction.Value!=null)
                    {
                        CreateAndAddParameter(dbCommand, "CKy", company.CompanyKey);
                        CreateAndAddParameter(dbCommand, "TrnDt", transaction.Value.TransactionDate);
                        CreateAndAddParameter(dbCommand, "TrnTypKy", transaction.Value.TransactionType.CodeKey);
                        CreateAndAddParameter(dbCommand, "TrnCrnKy", transaction.Value.TransactionCurrency == null ? 1 : transaction.Value.TransactionCurrency.CodeKey);
                        CreateAndAddParameter(dbCommand, "TrnExRate", transaction.Value.TransactionExchangeRate);
                        CreateAndAddParameter(dbCommand, "DocNo", transaction.Value.DocumentNumber);
                        CreateAndAddParameter(dbCommand, "YurRef", transaction.Value.YourReference);
                        CreateAndAddParameter(dbCommand, "YurRefDt", transaction.Value.YourReferenceDate);
                        CreateAndAddParameter(dbCommand, "isRecur", transaction.Value.IsRecurrence);
                        CreateAndAddParameter(dbCommand, "UsrKy", user.UserKey);
                        CreateAndAddParameter(dbCommand, "PrjKy", transaction.Value.TransactionProject == null ? 1 : transaction.Value.TransactionProject.ProjectKey);
                        CreateAndAddParameter(dbCommand, "BUKy", transaction.Value.BussinessUnit == null ? 1 : transaction.Value.BussinessUnit.CodeKey);
                        CreateAndAddParameter(dbCommand, "ObjKy", transaction.Value.ElementKey);
                        CreateAndAddParameter(dbCommand, "AccKy", transaction.Value.Account == null ? 1 : transaction.Value.Account.AccountKey);
                        CreateAndAddParameter(dbCommand, "AccObjKy", transaction.Value.AccountObjectKey);
                        CreateAndAddParameter(dbCommand, "AdrKy", transaction.Value.Address == null ? 1 : transaction.Value.Address.AddressKey);
                        CreateAndAddParameter(dbCommand, "ContraAccObjKy", transaction.Value.ContraAccountObjectKey);
                        CreateAndAddParameter(dbCommand, "ContraAccky", transaction.Value.ContraAccount == null ? 1 : transaction.Value.ContraAccount.AccountKey);
                        CreateAndAddParameter(dbCommand, "AprStsKy", 1);
                        CreateAndAddParameter(dbCommand, "LocKy", transaction.Value.Location == null ? 1 : transaction.Value.Location.CodeKey);
                        CreateAndAddParameter(dbCommand, "HdrTrfLnkKy", 1);
                        CreateAndAddParameter(dbCommand, "Amt", transaction.Value.Amount);
                        CreateAndAddParameter(dbCommand, "Amt1", transaction.Value.Amount1);
                        CreateAndAddParameter(dbCommand, "Amt2", transaction.Value.Amount2);
                        CreateAndAddParameter(dbCommand, "Amt3", transaction.Value.Amount3);
                        CreateAndAddParameter(dbCommand, "Amt4", transaction.Value.Amount4);
                        CreateAndAddParameter(dbCommand, "Amt5", transaction.Value.Amount5);
                        CreateAndAddParameter(dbCommand, "Amt6", transaction.Value.Amount6);
                        CreateAndAddParameter(dbCommand, "PmtTrmKy", transaction.Value.PaymentTerm == null ? 1 : transaction.Value.PaymentTerm.CodeKey);
                        CreateAndAddParameter(dbCommand, "RepAdrKy", transaction.Value.Rep == null ? 1 : transaction.Value.Rep.AddressKey);
                        CreateAndAddParameter(dbCommand, "@FrmTrnKy", transaction.Value.FromTransactionKey);
                        CreateAndAddParameter(dbCommand, "@IsMultiCr", transaction.Value.IsMultiCredit);
                        CreateAndAddParameter(dbCommand, "@isFrmImport", transaction.Value.IsFromImport);
                        CreateAndAddParameter(dbCommand, "@FrmOrdKy", transaction.Value.FromOrderKey);
                        CreateAndAddParameter(dbCommand, "@CdKy1", BaseComboResponse.GetKeyValue(transaction.Value.Code1));
                        CreateAndAddParameter(dbCommand, "@CdKy2", BaseComboResponse.GetKeyValue(transaction.Value.Code2));
                        CreateAndAddParameter(dbCommand, "@IsAct", transaction.Value.IsActive);
                        CreateAndAddParameter(dbCommand, "@IsApr", transaction.Value.IsApproved);
                        CreateAndAddParameter(dbCommand, "@HdrDisAmt", transaction.Value.HeaderDiscountAmount);
                        CreateAndAddParameter(dbCommand, "@DueDt", transaction.Value.DueDate);
                        CreateAndAddParameter(dbCommand, "@MarkUpAmt", transaction.Value.TotalMarkupValue);
                        CreateAndAddParameter(dbCommand, "@TrnMarkUpAmt", transaction.Value.TotalMarkupValue);
                        CreateAndAddParameter(dbCommand, "@MarkUpPer", transaction.Value.MarkupPercentage);
                        CreateAndAddParameter(dbCommand, "@VarChar1", transaction.Value.IsVarcar1On);
                        CreateAndAddParameter(dbCommand, "@Qty1", transaction.Value.Quantity1);
                        CreateAndAddParameter(dbCommand, "@DlryDt", transaction.Value.DeliveryDate);
                    }
                    

                    transaction.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    

                    while (reader.Read())
                    {
                        transaction.Value.TransactionKey = reader.GetColumn<int>("TrnKy");
                        transaction.Value.TransactionNumber = reader.GetColumn<string>("PrefixTrnNo");
                        transaction.Value.IsPersisted = true;
                    }

                    transaction.ExecutionEnded = DateTime.UtcNow;
                }
                catch (Exception exp)
                {
                    transaction.ExecutionEnded = DateTime.UtcNow;
                    transaction.Messages.Add(new ServerResponseMessae()
                    {
                        MessageType = ServerResponseMessageType.Exception,
                        Message = $"Error While Executing Proc {SPName}"
                    });
                    transaction.ExecutionException = exp;
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


            }
        }

        public void UpdateGenericTransaction(Company company, User user, BLTransaction transaction)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "TrnHdr_UpdateWeb";
                BaseServerResponse<BLTransaction> response = new BaseServerResponse<BLTransaction>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                        dbCommand.CreateAndAddParameter("CKy", company.CompanyKey);
                        dbCommand.CreateAndAddParameter("TrnKy", transaction.TransactionKey);
                        dbCommand.CreateAndAddParameter("TrnDt", transaction.TransactionDate);
                        dbCommand.CreateAndAddParameter("TrnCrnKy", transaction.TransactionCurrency == null ? 1 : transaction.TransactionCurrency.CodeKey);
                        dbCommand.CreateAndAddParameter("TrnExRate", transaction.TransactionExchangeRate);
                        dbCommand.CreateAndAddParameter("DocNo", transaction.DocumentNumber);
                        dbCommand.CreateAndAddParameter("YurRef", transaction.YourReference);
                        dbCommand.CreateAndAddParameter("YurRefDt", transaction.YourReferenceDate);
                        dbCommand.CreateAndAddParameter("isRecur", transaction.IsRecurrence);
                        dbCommand.CreateAndAddParameter("UsrKy", user.UserKey);
                        dbCommand.CreateAndAddParameter("PrjKy", transaction.TransactionProject == null ? 1 : transaction.TransactionProject.ProjectKey);
                        dbCommand.CreateAndAddParameter("BUKy", transaction.BussinessUnit == null ? 1 : transaction.BussinessUnit.CodeKey);
                        dbCommand.CreateAndAddParameter("ObjKy", transaction.ElementKey);
                        dbCommand.CreateAndAddParameter("AccKy", transaction.Account == null ? 1 : transaction.Account.AccountKey);
                        dbCommand.CreateAndAddParameter("AccObjKy", transaction.AccountObjectKey);
                        dbCommand.CreateAndAddParameter("AdrKy", transaction.Address == null ? 1 : transaction.Address.AddressKey);
                        dbCommand.CreateAndAddParameter("ContraAccObjKy", transaction.ContraAccountObjectKey);
                        dbCommand.CreateAndAddParameter("ContraAccky", transaction.ContraAccount == null ? 1 : transaction.ContraAccount.AccountKey);
                        dbCommand.CreateAndAddParameter("AprStsKy", 1);
                        dbCommand.CreateAndAddParameter("LocKy", transaction.Location == null ? 1 : transaction.Location.CodeKey);
                        dbCommand.CreateAndAddParameter("Amt", transaction.Amount);
                        dbCommand.CreateAndAddParameter("Amt1", transaction.Amount1);
                        dbCommand.CreateAndAddParameter("Amt2", transaction.Amount2);
                        dbCommand.CreateAndAddParameter("Amt3", transaction.Amount3);
                        dbCommand.CreateAndAddParameter("Amt4", transaction.Amount4);
                        dbCommand.CreateAndAddParameter("Amt5", transaction.Amount5);
                        dbCommand.CreateAndAddParameter("Amt6", transaction.Amount6);
                        dbCommand.CreateAndAddParameter("PmtTrmKy", transaction.PaymentTerm == null ? 1 : transaction.PaymentTerm.CodeKey);
                        dbCommand.CreateAndAddParameter("RepAdrKy", transaction.Rep == null ? 1 : transaction.Rep.AddressKey);
                        dbCommand.CreateAndAddParameter("@IsMultiCr", transaction.IsMultiCredit);
                        dbCommand.CreateAndAddParameter("@CdKy1", BaseComboResponse.GetKeyValue(transaction.Code1));
                        dbCommand.CreateAndAddParameter("@CdKy2", BaseComboResponse.GetKeyValue(transaction.Code2));
                        dbCommand.CreateAndAddParameter("@IsAct", transaction.IsActive);
                        dbCommand.CreateAndAddParameter("@IsApr", transaction.IsApproved);
                        dbCommand.CreateAndAddParameter("@isHold", transaction.IsHold);
                        dbCommand.CreateAndAddParameter("@TmStmp", DateTime.Now.Ticks);
                        dbCommand.CreateAndAddParameter("@MarkUpPer", transaction.MarkupPercentage);
                        dbCommand.CreateAndAddParameter("@TrnMarkUpAmt", transaction.TotalMarkupValue);
                        dbCommand.CreateAndAddParameter("@MarkUpAmt", transaction.TotalMarkupValue);
                        dbCommand.CreateAndAddParameter("@VarChar1", transaction.IsVarcar1On);
                        dbCommand.CreateAndAddParameter("@Qty1", transaction.Quantity1);
                    


                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();



                    while (reader.Read())
                    {
                        transaction.TransactionKey = reader.GetColumn<int>("TrnKy");
                        transaction.TransactionNumber = reader.GetColumn<string>("PrefixTrnNo");
                        transaction.IsPersisted = true;
                    }

                    response.ExecutionEnded = DateTime.UtcNow;
                    response.Value = transaction;
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


            }
        }

        public void SaveOrUpdateTranHeaderSerialNumber(Company company, User user, ItemSerialNumber serialNumber)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "TrnHdrSer_InsertUpdateWeb";
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@TrnKy", serialNumber.TransactionKey);
                    dbCommand.CreateAndAddParameter("@SerNoKy", serialNumber.SerialNumberKey);
                    dbCommand.CreateAndAddParameter("@SerNo", serialNumber.SerialNumber);
                    dbCommand.CreateAndAddParameter("@CSerNo", serialNumber.CustomerSerialNumber);
                    dbCommand.CreateAndAddParameter("@SupWrntyReading", serialNumber.SupplierWarrantyReading);
                    dbCommand.CreateAndAddParameter("@CWrntyReading", serialNumber.CustomerWarrantyReading);
                    dbCommand.CreateAndAddParameter("@SupExpryDt", serialNumber.SupplierExpiryDate);
                    dbCommand.CreateAndAddParameter("@CExpryDt", serialNumber.CustomerExpiryDate);
                    dbCommand.CreateAndAddParameter("@isAct", serialNumber.IsActive);
                    dbCommand.Connection.Open();
                    dbCommand.ExecuteNonQuery();




                }
                catch (Exception exp)
                {
                    
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;


                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }


                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }




            }
        }

        public void SaveTransactionLineItem(Company company, User user, GenericTransactionLineItem lineItem)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "ItmTrn_InsertWeb";
                BaseServerResponse<GenericTransactionLineItem> response = new BaseServerResponse<GenericTransactionLineItem>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", lineItem.ElementKey);
                    dbCommand.CreateAndAddParameter("@TrnKy", lineItem.TransactionKey);
                    dbCommand.CreateAndAddParameter("@EftvDt", lineItem.EffectiveDate);
                    dbCommand.CreateAndAddParameter("@LiNo", lineItem.LineNumber);
                    dbCommand.CreateAndAddParameter("@ItmTrnTrfLnkKy", lineItem.ItemTransferLinkKey);
                    dbCommand.CreateAndAddParameter("@ItmKy", lineItem.TransactionItem.ItemKey);
                    dbCommand.CreateAndAddParameter("@LocKy", lineItem.TransactionLocation.CodeKey);
                    dbCommand.CreateAndAddParameter("@Qty", lineItem.Quantity);
                    dbCommand.CreateAndAddParameter("@TrnQty", lineItem.TransactionQuantity);
                    dbCommand.CreateAndAddParameter("@TrnUnitKy", lineItem.TransactionUnit.UnitKey);
                    dbCommand.CreateAndAddParameter("@Rate", lineItem.Rate);
                    dbCommand.CreateAndAddParameter("@TrnRate", lineItem.TransactionRate);
                    dbCommand.CreateAndAddParameter("@TrnPri", lineItem.TransactionPrice);
                    dbCommand.CreateAndAddParameter("@BuKy", lineItem.BussinessUnit == null ? 1 : lineItem.BussinessUnit.CodeKey);
                    dbCommand.CreateAndAddParameter("@DisAmt", lineItem.DiscountAmount);
                    dbCommand.CreateAndAddParameter("@TrnDisAmt", lineItem.GetLineDiscount());
                    dbCommand.CreateAndAddParameter("@DisPer", lineItem.DiscountPercentage);
                    dbCommand.CreateAndAddParameter("@PrjKy", lineItem.TransactionProject == null ? 1 : lineItem.TransactionProject.ProjectKey);
                    dbCommand.CreateAndAddParameter("@AdrKy", lineItem.Address == null ? 1 : lineItem.Address.AddressKey);
                    dbCommand.CreateAndAddParameter("@ItmPrpKy", lineItem.ItemProperty == null ? 1 : lineItem.ItemProperty.CodeKey);
                    dbCommand.CreateAndAddParameter("@CondStateKy", lineItem.ConditionsState == null ? 1 : lineItem.ConditionsState.CodeKey);
                    dbCommand.CreateAndAddParameter("@isInventory", lineItem.IsInventory);
                    dbCommand.CreateAndAddParameter("@isCosting", lineItem.IsCosting);
                    dbCommand.CreateAndAddParameter("@isSetOff", lineItem.IsSetOff);
                    dbCommand.CreateAndAddParameter("@isAct", lineItem.IsActive);
                    dbCommand.CreateAndAddParameter("@isApr", lineItem.IsApproved);
                    dbCommand.CreateAndAddParameter("@OrdDetKy", lineItem.OrderDetailKey);
                    dbCommand.CreateAndAddParameter("@PreItmTrnKy", lineItem.FromItemTransactionKey);
                    dbCommand.CreateAndAddParameter("@Cd1Ky", lineItem.Code1 == null ? 1 : lineItem.Code1.CodeKey);
                    dbCommand.CreateAndAddParameter("@Cd2Ky", lineItem.Code2 == null ? 1 : lineItem.Code2.CodeKey);
                    dbCommand.CreateAndAddParameter("@Des", lineItem.Description);
                    dbCommand.CreateAndAddParameter("@Rem", lineItem.Remarks);
                    dbCommand.CreateAndAddParameter("@OrdKy", lineItem.OrderKey);
                    dbCommand.CreateAndAddParameter("@Sky", lineItem.Skey);
                    //   dbCommand.CreateAndAddParameter("@QtyPer", lineItem.QuantityPercentage);
                    dbCommand.CreateAndAddParameter("@HdrDisAmt", lineItem.HeaderDiscountAmount);
                    dbCommand.CreateAndAddParameter("@Prj2Ky", lineItem.Project2 == null ? 1 : lineItem.Project2.ProjectKey);
                    dbCommand.CreateAndAddParameter("@Qty2", lineItem.Quantity2);
                    dbCommand.CreateAndAddParameter("@TaskQty", lineItem.TaskQuantity);
                    dbCommand.CreateAndAddParameter("@TaskUnitKy", lineItem.TaskUnit == null ? 1 : lineItem.TaskUnit.UnitKey);
                    dbCommand.CreateAndAddParameter("@FrmNo", lineItem.FromNo);
                    dbCommand.CreateAndAddParameter("@ToNo", lineItem.ToNo);
                    dbCommand.CreateAndAddParameter("@NxtActNo", lineItem.NextActionNo);
                    dbCommand.CreateAndAddParameter("@NxtActDt", lineItem.NextActionDate);
                    dbCommand.CreateAndAddParameter("@NxtActTypKy", lineItem.NextActionType == null ? 1 : lineItem.NextActionType.CodeKey);
                    dbCommand.CreateAndAddParameter("@ItmPackKy", lineItem.ItemPack == null ? 1 : lineItem.ItemPack.CodeKey);
                    dbCommand.CreateAndAddParameter("@ComisPer", lineItem.CommisionPercentage);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp1", lineItem.ItemTaxType1);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp2", lineItem.ItemTaxType2);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp3", lineItem.ItemTaxType3);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp4", lineItem.ItemTaxType4);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp5", lineItem.ItemTaxType5);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp1Per", lineItem.ItemTaxType1Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp2Per", lineItem.ItemTaxType2Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp3Per", lineItem.ItemTaxType3Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp4Per", lineItem.ItemTaxType4Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp5Per", lineItem.ItemTaxType5Per);
                    dbCommand.CreateAndAddParameter("@LCKy", lineItem.LCKey);
                    dbCommand.CreateAndAddParameter("@LoanKy", lineItem.LoanKey);
                    dbCommand.CreateAndAddParameter("@PrcsDetKy", lineItem.ProcessDetailKey);
                    dbCommand.CreateAndAddParameter("@LCDetKy", lineItem.LCDetailKey);
                    dbCommand.CreateAndAddParameter("@LoanDetKy", lineItem.LoanDetailKey);
                    dbCommand.CreateAndAddParameter("@Anl1Ky", lineItem.Analysis1 == null ? 1 : lineItem.Analysis1.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl2Ky", lineItem.Analysis2 == null ? 1 : lineItem.Analysis2.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl3Ky", lineItem.Analysis3 == null ? 1 : lineItem.Analysis3.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl4Ky", lineItem.Analysis4 == null ? 1 : lineItem.Analysis4.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl5Ky", lineItem.Analysis5 == null ? 1 : lineItem.Analysis5.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl6Ky", lineItem.Analysis6 == null ? 1 : lineItem.Analysis6.CodeKey);
                    dbCommand.CreateAndAddParameter("@SlsPri2", lineItem.SalesPrice2);
                    dbCommand.CreateAndAddParameter("@ResrAdrKy", lineItem.ReservationAddress == null ? 1 : lineItem.ReservationAddress.AddressKey);
                    dbCommand.CreateAndAddParameter("@ItmBgtKy", lineItem.ItemBudgetKey);
                    dbCommand.CreateAndAddParameter("@isQty", lineItem.IsQuantiy);
                    dbCommand.CreateAndAddParameter("@Amt1", lineItem.Amount1);
                    dbCommand.CreateAndAddParameter("@Amt2", lineItem.Amount2);
                    dbCommand.CreateAndAddParameter("@Amt3", lineItem.Amount3);
                    dbCommand.CreateAndAddParameter("@Amt4", lineItem.Amount4);
                    dbCommand.CreateAndAddParameter("@Amt5", lineItem.Amount5);
                    dbCommand.CreateAndAddParameter("@Amt6", lineItem.Amount6);
                    dbCommand.CreateAndAddParameter("@Amt7", lineItem.Amount7);
                    dbCommand.CreateAndAddParameter("@Amt8", lineItem.Amount8);
                    dbCommand.CreateAndAddParameter("@Amt9", lineItem.Amount9);
                    dbCommand.CreateAndAddParameter("@Amt10", lineItem.Amount10);
                    dbCommand.CreateAndAddParameter("@LooseQty", lineItem.LooseQuantity);
                    dbCommand.CreateAndAddParameter("@Dt1", lineItem.DateTime1);
                    dbCommand.CreateAndAddParameter("@Dt2", lineItem.DateTime2);
                    dbCommand.CreateAndAddParameter("@Dt3", lineItem.DateTime3);
                    dbCommand.CreateAndAddParameter("@TrnTypKy", lineItem.TransactionType == null ? 1 : lineItem.TransactionType.CodeKey);
                    dbCommand.CreateAndAddParameter("@PrjTaskLocKy", lineItem.ProjectTaskLocation == null ? 1 : lineItem.ProjectTaskLocation.CodeKey);
                    dbCommand.CreateAndAddParameter("@LineAmt", lineItem.GetLineTotalWithDiscount());
                    dbCommand.CreateAndAddParameter("@TrnMarkUpAmt", lineItem.TotalMarkupAmount);
                    dbCommand.CreateAndAddParameter("@MarkUpAmt", lineItem.TotalMarkupAmount);
                    dbCommand.CreateAndAddParameter("@MarkUpPer", lineItem.MarkupPercentage);
                    dbCommand.CreateAndAddParameter("@DlryDt", lineItem.DeliveryDate);

                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        lineItem.ItemTransactionKey = reader.GetColumn<long>("ReturnVal");
                        lineItem.IsPersisted = true;
                    }

                    response.ExecutionEnded = DateTime.UtcNow;
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

                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                        reader.Dispose();

                    }

                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }


                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }



            }
        }

        public void UpdateTransactionLineItem(Company company, User user, GenericTransactionLineItem lineItem)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "ItmTrn_UpdateWeb";
                BaseServerResponse<GenericTransactionLineItem> response = new BaseServerResponse<GenericTransactionLineItem>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@CKy", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", lineItem.ElementKey);
                    dbCommand.CreateAndAddParameter("@TrnKy", lineItem.TransactionKey);
                    dbCommand.CreateAndAddParameter("@ItmTrnKy", lineItem.ItemTransactionKey);
                    dbCommand.CreateAndAddParameter("@EftvDt", lineItem.EffectiveDate);
                    dbCommand.CreateAndAddParameter("@LiNo", lineItem.LineNumber);
                    dbCommand.CreateAndAddParameter("@ItmTrnTrfLnkKy", lineItem.ItemTransferLinkKey);
                    dbCommand.CreateAndAddParameter("@ItmKy", lineItem.TransactionItem.ItemKey);
                    dbCommand.CreateAndAddParameter("@LocKy", lineItem.TransactionLocation.CodeKey);
                    dbCommand.CreateAndAddParameter("@Qty", lineItem.Quantity);
                    dbCommand.CreateAndAddParameter("@TrnQty", lineItem.TransactionQuantity);
                    dbCommand.CreateAndAddParameter("@TrnUnitKy", lineItem.TransactionUnit.UnitKey);
                    dbCommand.CreateAndAddParameter("@Rate", lineItem.Rate);
                    dbCommand.CreateAndAddParameter("@TrnRate", lineItem.TransactionRate);
                    dbCommand.CreateAndAddParameter("@TrnPri", lineItem.TransactionPrice);
                    dbCommand.CreateAndAddParameter("@BuKy", lineItem.BussinessUnit == null ? 1 : lineItem.BussinessUnit.CodeKey);
                    dbCommand.CreateAndAddParameter("@DisAmt", lineItem.DiscountAmount);
                    dbCommand.CreateAndAddParameter("@TrnDisAmt", lineItem.GetLineDiscount());
                    dbCommand.CreateAndAddParameter("@DisPer", lineItem.DiscountPercentage);
                    dbCommand.CreateAndAddParameter("@PrjKy", lineItem.TransactionProject == null ? 1 : lineItem.TransactionProject.ProjectKey);
                    dbCommand.CreateAndAddParameter("@AdrKy", lineItem.Address == null ? 1 : lineItem.Address.AddressKey);
                    dbCommand.CreateAndAddParameter("@ItmPrpKy", lineItem.ItemProperty == null ? 1 : lineItem.ItemProperty.CodeKey);
                    dbCommand.CreateAndAddParameter("@CondStateKy", lineItem.ConditionsState == null ? 1 : lineItem.ConditionsState.CodeKey);
                    dbCommand.CreateAndAddParameter("@isInventory", lineItem.IsInventory);
                    dbCommand.CreateAndAddParameter("@isCosting", lineItem.IsCosting);
                    dbCommand.CreateAndAddParameter("@isSetOff", lineItem.IsSetOff);
                    dbCommand.CreateAndAddParameter("@isAct", lineItem.IsActive);
                    dbCommand.CreateAndAddParameter("@isApr", lineItem.IsApproved);
                    //   dbCommand.CreateAndAddParameter("@OrdDetKy", lineItem.OrderDetailKey);
                    dbCommand.CreateAndAddParameter("@RefItmTrnKy", lineItem.ReferenceItemTransactionKey);
                    dbCommand.CreateAndAddParameter("@Cd1Ky", lineItem.Code1 == null ? 1 : lineItem.Code1.CodeKey);
                    dbCommand.CreateAndAddParameter("@Cd2Ky", lineItem.Code2 == null ? 1 : lineItem.Code2.CodeKey);
                    dbCommand.CreateAndAddParameter("@Des", lineItem.Description == null ? "" : lineItem.Description);
                    dbCommand.CreateAndAddParameter("@Rem", lineItem.Remarks == null ? "" : lineItem.Remarks);
                    dbCommand.CreateAndAddParameter("@OrdKy", lineItem.OrderKey);
                    //    dbCommand.CreateAndAddParameter("@Sky", lineItem.Skey);
                    //dbCommand.CreateAndAddParameter("@QtyPer", lineItem.QuantityPercentage);
                    //   dbCommand.CreateAndAddParameter("@HdrDisAmt", lineItem.HeaderDiscountAmount);
                    dbCommand.CreateAndAddParameter("@Prj2Ky", lineItem.Project2 == null ? 1 : lineItem.Project2.ProjectKey);
                    dbCommand.CreateAndAddParameter("@Qty2", lineItem.Quantity2);
                    dbCommand.CreateAndAddParameter("@TaskQty", lineItem.TaskQuantity);
                    dbCommand.CreateAndAddParameter("@TaskUnitKy", lineItem.TaskUnit == null ? 1 : lineItem.TaskUnit.UnitKey);
                    dbCommand.CreateAndAddParameter("@FrmNo", lineItem.FromNo);
                    dbCommand.CreateAndAddParameter("@ToNo", lineItem.ToNo);
                    dbCommand.CreateAndAddParameter("@NxtActNo", lineItem.NextActionNo);
                    dbCommand.CreateAndAddParameter("@NxtActDt", lineItem.NextActionDate);
                    dbCommand.CreateAndAddParameter("@NxtActTypKy", lineItem.NextActionType == null ? 1 : lineItem.NextActionType.CodeKey);
                    dbCommand.CreateAndAddParameter("@ItmPackKy", lineItem.ItemPack == null ? 1 : lineItem.ItemPack.CodeKey);
                    dbCommand.CreateAndAddParameter("@ComisPer", lineItem.CommisionPercentage);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp1", lineItem.ItemTaxType1);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp2", lineItem.ItemTaxType2);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp3", lineItem.ItemTaxType3);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp4", lineItem.ItemTaxType4);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp5", lineItem.ItemTaxType5);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp1Per", lineItem.ItemTaxType1Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp2Per", lineItem.ItemTaxType2Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp3Per", lineItem.ItemTaxType3Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp4Per", lineItem.ItemTaxType4Per);
                    dbCommand.CreateAndAddParameter("@ItmTaxTyp5Per", lineItem.ItemTaxType5Per);
                    dbCommand.CreateAndAddParameter("@LCKy", lineItem.LCKey);
                    dbCommand.CreateAndAddParameter("@LoanKy", lineItem.LoanKey);
                    dbCommand.CreateAndAddParameter("@PrcsDetKy", lineItem.ProcessDetailKey);
                    dbCommand.CreateAndAddParameter("@LCDetKy", lineItem.LCDetailKey);
                    dbCommand.CreateAndAddParameter("@LoanDetKy", lineItem.LoanDetailKey);
                    dbCommand.CreateAndAddParameter("@Anl1Ky", lineItem.Analysis1 == null ? 1 : lineItem.Analysis1.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl2Ky", lineItem.Analysis2 == null ? 1 : lineItem.Analysis2.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl3Ky", lineItem.Analysis3 == null ? 1 : lineItem.Analysis3.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl4Ky", lineItem.Analysis4 == null ? 1 : lineItem.Analysis4.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl5Ky", lineItem.Analysis5 == null ? 1 : lineItem.Analysis5.CodeKey);
                    dbCommand.CreateAndAddParameter("@Anl6Ky", lineItem.Analysis6 == null ? 1 : lineItem.Analysis6.CodeKey);
                    dbCommand.CreateAndAddParameter("@SlsPri2", lineItem.SalesPrice2);
                    dbCommand.CreateAndAddParameter("@ResrAdrKy", lineItem.ReservationAddress == null ? 1 : lineItem.ReservationAddress.AddressKey);
                    dbCommand.CreateAndAddParameter("@ItmBgtKy", lineItem.ItemBudgetKey);
                    dbCommand.CreateAndAddParameter("@isQty", lineItem.IsQuantiy);
                    dbCommand.CreateAndAddParameter("@Amt1", lineItem.Amount1);
                    dbCommand.CreateAndAddParameter("@Amt2", lineItem.Amount2);
                    dbCommand.CreateAndAddParameter("@Amt3", lineItem.Amount3);
                    dbCommand.CreateAndAddParameter("@Amt4", lineItem.Amount4);
                    dbCommand.CreateAndAddParameter("@Amt5", lineItem.Amount5);
                    dbCommand.CreateAndAddParameter("@Amt6", lineItem.Amount6);
                    dbCommand.CreateAndAddParameter("@Amt7", lineItem.Amount7);
                    dbCommand.CreateAndAddParameter("@Amt8", lineItem.Amount8);
                    dbCommand.CreateAndAddParameter("@Amt9", lineItem.Amount9);
                    dbCommand.CreateAndAddParameter("@Amt10", lineItem.Amount10);
                    dbCommand.CreateAndAddParameter("@LooseQty", lineItem.LooseQuantity);
                    dbCommand.CreateAndAddParameter("@Dt1", lineItem.DateTime1);
                    dbCommand.CreateAndAddParameter("@Dt2", lineItem.DateTime2);
                    dbCommand.CreateAndAddParameter("@Dt3", lineItem.DateTime3);
                    dbCommand.CreateAndAddParameter("@TrnTypKy", lineItem.TransactionType == null ? 1 : lineItem.TransactionType.CodeKey);
                    dbCommand.CreateAndAddParameter("@PrjTaskLocKy", lineItem.ProjectTaskLocation == null ? 1 : lineItem.ProjectTaskLocation.CodeKey);
                    dbCommand.CreateAndAddParameter("@LineAmt", lineItem.GetLineTotalWithDiscount());
                    dbCommand.CreateAndAddParameter("@TmStmp", DateTime.Now.Ticks);
                    //    dbCommand.CreateAndAddParameter("@ItmPrpKy", BaseComboResponse.GetKeyValue(lineItem.ItemProperty));
                    dbCommand.CreateAndAddParameter("@ItmTrnPrp1Ky", BaseComboResponse.GetKeyValue(lineItem.ItemProperty));
                    dbCommand.CreateAndAddParameter("@IsPri", 0);
                    dbCommand.CreateAndAddParameter("@IsVal", 0);
                    //    dbCommand.CreateAndAddParameter("@IsQty",0);
                    dbCommand.CreateAndAddParameter("@IsDisplay", 0);
                    dbCommand.CreateAndAddParameter("@isNoPrnPri", 0);
                    dbCommand.CreateAndAddParameter("@isQlity", 0);
                    dbCommand.CreateAndAddParameter("@isRateInclTT1", 0);
                    dbCommand.CreateAndAddParameter("@TrnMarkUpAmt", lineItem.TotalMarkupAmount);
                    dbCommand.CreateAndAddParameter("@MarkUpAmt", lineItem.TotalMarkupAmount);
                    dbCommand.CreateAndAddParameter("@MarkUpPer", lineItem.MarkupPercentage);
                    dbCommand.CreateAndAddParameter("@DlryDt", lineItem.DeliveryDate);


                    //dbCommand.CreateAndAddParameter("@RepAdrKy", lineItem.Re);
                    //dbCommand.CreateAndAddParameter("@TaskQty", lineItem.TaskQuantity);

                    response.ExecutionStarted = DateTime.UtcNow;
                    dbCommand.Connection.Open();
                    reader = dbCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        //  lineItem.ItemTransactionKey = dataReader.GetColumn<long>("ReturnVal");
                    }


                    response.ExecutionEnded = DateTime.UtcNow;


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

                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }
                        reader.Dispose();

                    }

                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }


                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }



            }
        }

        public void SaveOrUpdateSerialNumber(Company company, User user, ItemSerialNumber serialNumber)
        {

            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader reader = null;
                string SPName = "ItmTrnSer_InsertUpdateWeb";
                BaseServerResponse<ItemSerialNumber> response = new BaseServerResponse<ItemSerialNumber>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;

                    dbCommand.CreateAndAddParameter("@TrnKy", serialNumber.TransactionKey);
                    dbCommand.CreateAndAddParameter("@ItmTrnKy", serialNumber.ItemTransactionKey);
                    dbCommand.CreateAndAddParameter("@SerNoKy", serialNumber.SerialNumberKey);
                    dbCommand.CreateAndAddParameter("@LiNo", serialNumber.LineNumber);
                    dbCommand.CreateAndAddParameter("@SerNo", serialNumber.SerialNumber);
                    dbCommand.CreateAndAddParameter("@CSerNo", serialNumber.CustomerSerialNumber);
                    dbCommand.CreateAndAddParameter("@SupWrntyReading", serialNumber.SupplierWarrantyReading);
                    dbCommand.CreateAndAddParameter("@CWrntyReading", serialNumber.CustomerWarrantyReading);
                    dbCommand.CreateAndAddParameter("@ItmKy", serialNumber.ItemKey);
                    dbCommand.CreateAndAddParameter("@SupExpryDt", serialNumber.SupplierExpiryDate);
                    dbCommand.CreateAndAddParameter("@CExpryDt", serialNumber.CustomerExpiryDate);
                    dbCommand.CreateAndAddParameter("@isAct", serialNumber.IsActive);
                    dbCommand.Connection.Open();
                    dbCommand.ExecuteNonQuery();




                }
                catch (Exception exp)
                {
                   
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;


                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }


                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }




            }
        }

        public void PostAfterTranSaveActions(Company company, User user, long TransactionKey, long ObjectKey)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader dataReader = null;
                string SPName = "PostSaveTrnAction";
                BaseServerResponse<ItemSerialNumber> response = new BaseServerResponse<ItemSerialNumber>();
                try
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;
                    dbCommand.CreateAndAddParameter("@Cky", company.CompanyKey);
                    dbCommand.CreateAndAddParameter("@UsrKy", user.UserKey);
                    dbCommand.CreateAndAddParameter("@TrnKy", TransactionKey);
                    dbCommand.CreateAndAddParameter("@ObjKy", ObjectKey);


                    dbCommand.Connection.Open();
                    dbCommand.ExecuteNonQuery();

                    //while (dataReader.Read())
                    //{
                    //    TransactionKey = dataReader.GetColumn<int>("TrnKy");
                    //}





                }
                catch (Exception exp)
                {
                    //LoginManager.GetDefaultInstance().ErrorLog(exp.Message);
                }

                finally
                {
                    IDbConnection dbConnection = dbCommand.Connection;

                    if (dbConnection.State != ConnectionState.Closed)
                    {
                        dbConnection.Close();
                    }

                    dbCommand.Dispose();
                    dbConnection.Dispose();
                }


            }
        }
    }
}
