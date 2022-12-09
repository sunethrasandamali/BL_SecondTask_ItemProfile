using BlueLotus360.Core.Domain.Definitions.DataLayer;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.BookingModule;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication.Services
{
    public class BookingModuleService : IBookingModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseServerResponse<IList<CustomerDetailsByVehicle>> GetBookingCustomerDetails(Company company, User user, BookingVehicleDetails request)
        {
            return _unitOfWork.BookingModuleRepository.GetBookingCustomerDetails(company, user, request);
        }

		public BaseServerResponse<IList<BookingDetails>> GetBookingDetailsOnCalender(Company company, User user, BookingDetails request)
		{
            return _unitOfWork.BookingModuleRepository.GetBookingDetailsOnCalender(company, user, request);
		}
	}
}
