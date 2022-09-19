using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Responses
{
    public class BaseServerResponse<T> where T : class
    {
        public T Value { get; set; }

        public IList<ServerResponseMessae> Messages { get; set; }

        public BaseServerResponse()
        {
            Messages=new List<ServerResponseMessae>();  
        }

        public Exception ExecutionException   { get; set; }

        public DateTime ExecutionStarted { get; set; }
        public DateTime ExecutionEnded { get; set; }

        public TimeSpan GetExecutionTimeSpan()
        {
            return ExecutionEnded - ExecutionStarted;
        }

    }


    public enum ServerResponseMessageType
    {
        ConnectionFaliure=3,
        Exception =2,
        Success=1,
    }

    public class ServerResponseMessae
    {
        public ServerResponseMessageType MessageType { get; set; }
        public string Message { get; set; }
    }
}
