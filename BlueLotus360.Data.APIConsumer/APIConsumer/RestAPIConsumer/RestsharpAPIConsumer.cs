using BlueLotus360.Data.APIConsumer.Definitions;
using BlueLotus360.Data.APIConsumer.Implementation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer
{
    public class RestsharpAPIConsumer
    {
        #region privates
        private RestClient _restClient;
        private static APISettins aPISettins;
        private static RestsharpAPIConsumer _consumer;
        private RestsharpAPIConsumer()
        {

            _restClient = new RestClient(aPISettins.BaseURL);
            _restClient.AddDefaultHeader("IntegrationID", aPISettins.ApplicationId);
            _restClient.AddDefaultHeader("Content-Type", "application/json");

        }

        private IAuthenticationConsumer authenticationConsumer;

        public IAuthenticationConsumer AuthenticationConsumer
        {
            get
            {
                if(authenticationConsumer == null)
                {
                    authenticationConsumer = new AuthenticationConsumer(_restClient);
                }
                return authenticationConsumer;
            }
        }
        #endregion

        public static void Initilize(APISettins settins)
        {
             aPISettins = settins;

            if (_consumer == null)
            {
                _consumer = new RestsharpAPIConsumer();
            }
        }
        public static RestsharpAPIConsumer GetDefaultAPIConsumner()
        {
            if (_consumer == null)
            {
                throw new InvalidOperationException();
            }
            return _consumer;
        }





    }


    public class APISettins
    {
        private string _applicationId;
        private string _applicationName;
        private string _baseURL;

        public string ApplicationId { get => _applicationId; set => _applicationId = value; }
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }
        public string BaseURL { get => _baseURL; set => _baseURL = value; }
    }
}
