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
            SampleItems = new List<ItemExtended>();
            InsertSampleDate();            
        }

        private IList<ItemExtended> SampleItems { get; set; } 



        private void InsertSampleDate()
        {
            SampleItems.Add(new ItemExtended()
            {
                ItemCode = "CAL-OC-BL-LEM",
                ItemName = "Calypso Ocean Blue Lemonade",
                SalesPrice = 2.79M,
                ItemKey = 1440645,
                ItemCategory7 = new CodeBaseResponse(457385),
                Base64ImageDocument = "calypsooblemonade.jpg"

            });

            SampleItems.Add(new ItemExtended()
            {
                ItemCode = "CAL-OC-PP-LEM",
                ItemName = "Calypso Paradise Punch  Lemonade",
                SalesPrice = 2.79M,
                ItemKey = 1440781,
                ItemCategory7 = new CodeBaseResponse(457385),
                Base64ImageDocument = "calypsopplemonade.jpg"

            }); 
        }



        public IList<ItemExtended> FilterItemByCat(long Cat7Ky)
        {
            return SampleItems.Where(x=>x.ItemCategory7.CodeKey==Cat7Ky).ToList();
        }

    }



    public class BLAppOrder
    {
        public bool IsCustomerSelected { get; set; }
    }
}
