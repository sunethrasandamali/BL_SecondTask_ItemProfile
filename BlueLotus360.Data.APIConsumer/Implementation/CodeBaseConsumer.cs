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
    public class CodeBaseConsumer : BaseAPIConsumer, ICodeBaseConsumer
    {
        public CodeBaseConsumer(RestClient restClient) : base(restClient)
        {
        }

        public async Task<BaseServerResponse<IList<CodeBase>>> ReadCategories(BaseComboResponse request)
        {
            var restRequest = new RestRequest("Codebase/readCategories");
            restRequest.AddJsonBody(request);
            var serverResponse = await ExecuteConsumerPostAsync<IList<CodeBase>>(restRequest);
            return serverResponse;
        }
    }
}
