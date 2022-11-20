using BlueLotus360.Core.Domain.DTOs.RequestDTO;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Entity.Extended;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.APIConsumer.Definitions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.Implementation
{
    public class AddressConsumer : BaseAPIConsumer, IAddressConsumer
    {
        public AddressConsumer(RestClient restClient) : base(restClient)
        {
        }

        public async Task<BaseServerResponse<IList<AddressResponse>>> GetMAUIAddress(ComboRequestDTO requestDTO)
        {
            var restRequest = new RestRequest("Address/readMAUIAddress");
            restRequest.AddJsonBody(requestDTO);
            var serverResponse = await ExecuteConsumerPostAsync<IList<AddressResponse>>(restRequest);
            return serverResponse;
        }
    }
}
