using BlueLotus360.Core.Domain.Entity.API;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.UberEats;
using BlueLotus360.Web.APIApplication.Definitions.ServiceDefinitions;

namespace BlueLotus360.Web.API.Integrations.Uber
{
    public class UberProvisionHandler
    {
        IOrderService _orderService;
        public UberProvisionHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public APIInformation GetCommonUberDetails(User user)
        {
            APIRequestParameters request = new APIRequestParameters()
            {
                LocationKey = 1,
                BUKy=1,
                APIIntegrationName = "Ubereats",
                APIName = "Ubereats",
                EndPointName = ""
            };
            Company company = new Company();
            if (request.APIIntegrationName == "Ubereats")
            {
                company.CompanyKey = 1;
            }
            APIInformation APIInfo = _orderService.GetAPIDetails(company, user, request).Value;
            return APIInfo;
        }

        public APIInformation GetEndPoint(int ApiIntegrationKey,string EndpointName)
        {
            APIRequestParameters endpointrequest = new APIRequestParameters()
            {
                LocationKey = 1,
                BUKy=1,
                APIIntegrationKey = ApiIntegrationKey,
                EndPointName = EndpointName
            };
            APIInformation endpointInfo = _orderService.GetAPIEndPoints(new Company(), endpointrequest).Value;
            return endpointInfo;
        }

        public void InsertAuthEndpoint(string code,int ApiIntegrationKey,string EndPointURL,int CompanyKey)
        {
            APIRequestParameters endpoint = new APIRequestParameters()
            {

                APIIntegrationKey = ApiIntegrationKey,
                EndPointName = UberEndpointURLS.AuthCode.ToString(),
                EndPointToken = code,
                EndPointURL = EndPointURL,
                TokenValidTillTime= DateTime.Now.AddMinutes(9)
        };
            Company Assignedcompany = new Company();
            Assignedcompany.CompanyKey = CompanyKey;
            _orderService.InsertApiEndPoint(endpoint, Assignedcompany);
        }
    }
}
