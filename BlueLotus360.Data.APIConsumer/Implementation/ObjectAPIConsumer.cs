using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Models;
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
    public class ObjectAPIConsumer : BaseAPIConsumer, IObjectAPIConsumer
    {
        public ObjectAPIConsumer(RestClient restClient) : base(restClient)
        {
        }

        public async Task<BaseServerResponse<UIMenu>> FetchSideMenu()
        {
            BaseAPIRequest request = new();
            var restRequest = new RestRequest("Object/fetchSideMenu");
            var serverResponse = await ExecuteConsumerGetAsync<UIMenu>(restRequest);
            return serverResponse;

        }
    }
}
