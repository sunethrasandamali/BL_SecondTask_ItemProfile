using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions
{
    public interface IObjectService
    {
        BaseServerResponse<IList<UIObject>>  GetUIObjectsByParent(int ParentKey,Company company,User user);
         
        BaseServerResponse<UIObject>   GetObjectByObjectKey(long ObjectKey,Company company,User user);
    }
}
