using BlueLotus360.Core.Domain.Definitions.Repository;
using BlueLotus360.Core.Domain.Entity.Base;
using BlueLotus360.Core.Domain.Responses;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Data.APIConsumer.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly RestClient restClient;
        public UserRepository(RestClient restClient)
        {
            this.restClient = restClient;
            
        }

        public BaseServerResponse<User> GetUserByUserId(string userId)
        {

            var restRequest = new RestRequest("User\authenticate",Method.Post);
        }
    }
}
