using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.UI.Application.Context
{
    public class BLUIAppContext
    {
        public User ApplicationUser { get; set; }
        public Company ApllicationCompany { get; set; }
        public string ApplicationToken { get; set; }

        public bool IsUserLoggedIn { get; set; }
        public bool IsCompanyPicked { get; set; }

        public bool IsCompleteAuthOK { get { return IsCompanyPicked && IsUserLoggedIn; } }

        public string InstanceID { get; private set; }
        public BLUIAppContext()
        {
            InstanceID = Guid.NewGuid().ToString();
        }

    }
}
