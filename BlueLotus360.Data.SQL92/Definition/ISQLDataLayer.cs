using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.SQL92.Definition
{
    internal interface ISQLDataLayer
    {
        void Commit();
        void ExecuteCommad();
        void ExecuteFunction();
        IDbCommand GetCommandAccess();
        void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void RollBack();

    }
}
