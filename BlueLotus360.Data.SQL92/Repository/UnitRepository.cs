using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
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
    internal class UnitRepository : BaseRepository, IUnitRepository
    {
        public UnitRepository(ISQLDataLayer dataLayer) : base(dataLayer)
        {

        }

        public IList<UnitResponse> GetUnits(UnitComboRequestDTO dto, Company company, User user)
        {
            using (IDbCommand dbCommand = _dataLayer.GetCommandAccess())
            {
                IDataReader dataReader = null;
                IList<UnitResponse> units = new List<UnitResponse>();
                string SPName = "GetItemMultiUnits_Web";
                try
                {
                    UnitResponse unit;
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SPName;  /// This Returns all the Columns form ItmMas
					CreateAndAddParameter(dbCommand, "@Cky", company.CompanyKey);
                    CreateAndAddParameter(dbCommand, "@ItmKy", dto.ItemKey);
                    CreateAndAddParameter(dbCommand, "@TrnTypKy", dto.TransactionTypeKey);
                    CreateAndAddParameter(dbCommand, "@ObjKy", dto.RequestingElementKey);

                    dbCommand.Connection.Open();
                    dataReader = dbCommand.ExecuteReader();


                    while (dataReader.Read())
                    {
                        unit = new UnitResponse();
                        unit.UnitKey = dataReader.GetColumn<int>("Unitky");
                        unit.UnitName = dataReader.GetColumn<string>("Unit");
                        unit.IsDefault = dataReader.GetColumn<bool>("isDef");
                        units.Add(unit);
                    }


                    return units;
                }
                catch (Exception exp)
                {
                    throw exp;
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
