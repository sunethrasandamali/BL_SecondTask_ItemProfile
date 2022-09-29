using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class ObjectService : IObjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ObjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public BaseServerResponse<UIObject> GetObjectByObjectKey(long ObjectKey, Company company, User user)
        {
            throw new NotImplementedException();
        }

        public BaseServerResponse<IList<UIObject>> GetUIObjectsByParent(int ParentKey, Company company, User user)
        {
            return _unitOfWork.ObjectRepository.GetUIDefinitions(ParentKey,company, user);
        }
    }
}
