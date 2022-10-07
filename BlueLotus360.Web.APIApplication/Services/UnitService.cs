using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class UnitService:IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IList<UnitResponse> GetItemMultiUnit(UnitComboRequestDTO dto, Company company, User user)
        {
            object ItemKey;
            if (dto.AddtionalData.TryGetValue("ItemKey", out ItemKey))
            {
                long value = 1;
                value = Convert.ToInt64(ItemKey.ToString());
                dto.ItemKey = value;
            }

            IList<UnitResponse> UnitResponses = _unitOfWork.UnitMasRepository.GetUnits(dto, company, user);
            return UnitResponses;
        }
    }
}
