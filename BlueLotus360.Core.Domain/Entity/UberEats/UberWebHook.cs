using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Entity.UberEats
{
    public class UberWebHook
    {
        public class UberWebhookResponseModel
        {
            public string Event_type { get; set; }
            public string Event_id { get; set; }
            public int Event_time { get; set; }
            public Meta Meta { get; set; }
            public string Resource_href { get; set; }
        }

        public class Meta
        {
            public string Resource_id { get; set; }
            public string Status { get; set; }
            public string User_id { get; set; }
        }

        public class DelegateSubscriber
        {
            public delegate void IncomingWebHookEvent(EventArgs args);
        }
    }
}
