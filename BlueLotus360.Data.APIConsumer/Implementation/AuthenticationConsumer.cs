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
    public class AuthenticationConsumer : IAuthenticationConsumer
    {
        RestClient _restClient;
        public AuthenticationConsumer(RestClient restClient)
        {
            _restClient = restClient;
        }
        
        public async Task<BaseServerResponse<UserAuthenticationResponse>> AuthenticateUser(UserAuthenticationRequest request)
        {
            BaseServerResponse<UserAuthenticationResponse> serverResponse = new BaseServerResponse<UserAuthenticationResponse>();
            var restRequest = new RestRequest("Authentication/authenticate");
            restRequest.AddJsonBody(request);
            RestResponse restResponse = await _restClient.ExecuteAsync(restRequest);
            return serverResponse;
        }
    }
}
