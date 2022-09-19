using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Extenstions
{
    internal static class Extensions
    {

        public static IDbDataParameter CreateAndAddParameter(this IDbCommand command, string ParameterName, object Value,
            ParameterDirection direction = ParameterDirection.Input, DbType sqlDb = DbType.String)
        {
            IDbDataParameter dbDataParameter = command.CreateParameter();
            dbDataParameter.ParameterName = ParameterName;

            if (Value != null && Value.GetType() == typeof(DateTime))
            {
                DateTime dt = (DateTime)Value;
                if (dt.Year == 1)
                {
                    Value = new DateTime(1900, 1, 1);
                }

            }

            dbDataParameter.Value = Value;
            command.Parameters.Add(dbDataParameter);
            return dbDataParameter;

        }

        public static T GetColumn<T>(this IDataReader dataReader, string columnName)
        {
            try
            {
                columnName = columnName.Replace("@", "");
                if (dataReader[columnName] != DBNull.Value)
                {
                    return (T)Convert.ChangeType(dataReader[columnName], typeof(T));
                }
                else
                {
                    if (typeof(T) == typeof(DateTime))
                    {
                        return (T)Convert.ChangeType(new DateTime(1901, 01, 01), typeof(T));

                    }

                    return default(T);
                }
            }
            catch (Exception exp)
            {
                return default(T);
            }


        }

    }
}
