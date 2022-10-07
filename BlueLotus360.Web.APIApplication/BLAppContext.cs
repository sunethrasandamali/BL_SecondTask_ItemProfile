using BlueLotus360.Core.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Web.APIApplication
{
    public class BLAppContext
    {
        public bool IsUserLoggedIn { get; set; }
        public User ApplicationUser { get; set; }
        public Company ApplicationCompany { get; set; }
    }
}
