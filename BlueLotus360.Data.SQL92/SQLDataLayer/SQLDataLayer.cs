using BlueLotus360.Data.SQL92.Definition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.DataLayer
{
    internal class SQLDataLayer:ISQLDataLayer
    {
        private SqlConnection _dbConnection;
        public string ConnectionString;

        private SqlTransaction _transaction;
        public SQLDataLayer(string connectionstring)
        {
            ConnectionString = connectionstring;
            _dbConnection = new SqlConnection(connectionstring);
        }



        public virtual void ExecuteCommad()
        {

        }

        public virtual void ExecuteFunction()
        {

        }


        public virtual void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_dbConnection != null)
            {
                if (_dbConnection.State != ConnectionState.Open)
                {

                }
                _dbConnection.Open();
                _transaction = _dbConnection.BeginTransaction(isolationLevel);

            }
            else
            {

            }
        }


        public virtual void RollBack()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _dbConnection.Close();
            }
        }
        public virtual void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _dbConnection.Close();
            }
        }


        public SqlConnection GetSqlConnection()
        {
            try
            {
                return new SqlConnection(ConnectionString);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        public virtual IDbCommand GetCommandAccess()
        {
            try
            {
                IDbCommand command = GetSqlConnection().CreateCommand();
                command.CommandTimeout = 300;
                return command;

            }
            catch (Exception exp)
            {
                throw exp;
            }


        }
    }
}
