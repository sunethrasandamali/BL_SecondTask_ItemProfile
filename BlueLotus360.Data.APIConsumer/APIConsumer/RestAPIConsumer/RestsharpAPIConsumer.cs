using BlueLotus360.Data.APIConsumer.Definitions;
using BlueLotus360.Data.APIConsumer.Implementation;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.APIConsumer.RestAPIConsumer
{
    public class RestsharpAPIConsumer
    {
        #region privates
        private RestClient _restClient;
        private static APISettings aPISettins;
        private static RestsharpAPIConsumer _consumer;
        private IAuthenticationConsumer authenticationConsumer;
        private IObjectAPIConsumer objectConsumer;
        #endregion
        private RestsharpAPIConsumer()
        {

            _restClient = new RestClient(aPISettins.BaseURL);
            _restClient.AddDefaultHeader("IntegrationID", aPISettins.ApplicationId);
            _restClient.AddDefaultHeader("Content-Type", "application/json");

        }


        public void AddUserToken(string requestToken)
        {
            var authParam = _restClient.DefaultParameters.TryFind("Authorization");
            if (authParam != null)
            {
                _restClient.DefaultParameters.RemoveParameter(authParam);
            }
            _restClient.AddDefaultHeader("Authorization", $"Bearer {requestToken}");

        }



        public IAuthenticationConsumer AuthenticationConsumer
        {
            get
            {
                if (authenticationConsumer == null)
                {
                    authenticationConsumer = new AuthenticationConsumer(_restClient);
                }
                return authenticationConsumer;
            }
        }

        public IObjectAPIConsumer ObjectConsumer
        {
            get
            {
                if (objectConsumer == null)
                {
                    objectConsumer = new ObjectAPIConsumer(_restClient);
                }
                return objectConsumer;
            }
        }


        public static void Initilize(APISettings settins)
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


    public class APISettings
    {
        private string _applicationId;
        private string _applicationName;
        private string _baseURL;

        public string ApplicationId { get => _applicationId; set => _applicationId = value; }
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }
        public string BaseURL { get => _baseURL; set => _baseURL = value; }

    }
}
