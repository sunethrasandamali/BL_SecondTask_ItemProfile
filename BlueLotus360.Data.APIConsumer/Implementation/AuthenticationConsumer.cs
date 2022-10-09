using BlueLotus360.Core.Domain.Models;
using BlueLotus360.Core.Domain.Responses;
using BlueLotus360.Data.APIConsumer.Definitions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.Implementation
{
    public class AuthenticationConsumer : BaseAPIConsumer, IAuthenticationConsumer
    {

        public AuthenticationConsumer(RestClient restClient) : base(restClient)
        {

        }

        public async Task<BaseServerResponse<UserAuthenticationResponse>> AuthenticateUserAsync(UserAuthenticationRequest request)
        {
            var restRequest = new RestRequest("Authentication/authenticate");
            restRequest.AddJsonBody(request);
            var serverResponse = await ExecuteConsumerRequestAsync<UserAuthenticationResponse>(restRequest);
            return serverResponse;
        }
    }

    public class BaseAPIConsumer
    {
        protected RestClient _restClient;
        public BaseAPIConsumer(RestClient restClient)
        {
            _restClient = restClient;
        }


        protected async Task<BaseServerResponse<T>> ExecuteConsumerRequestAsync<T>(RestRequest restRequest) where T : class
        {
            BaseServerResponse<T> response = new BaseServerResponse<T>();
            RestResponse<T> restResponse = await _restClient.ExecutePostAsync<T>(restRequest);
            if (restResponse.IsSuccessful)
            {
                response.Value = restResponse.Data;
            }
            return response;

        }
    }
}
