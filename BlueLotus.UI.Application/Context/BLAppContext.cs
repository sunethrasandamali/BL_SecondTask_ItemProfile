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
                Base64ImageDocument = "calypsooblemonade.jpg",
                Description = "Some say if you hold a big seashell to your ear, you can hear the ocean waves crashing. " +
                              "Jojo says, hold an Ocean Blue Lemonade to your mouth instead." +
                              " It’s a whole tidal wave of blue raspberry flavor that you can hear with your taste buds. " +
                              "And it’s loud!",
                DefaultDiscountPercentage = 5


            }) ;

            SampleItems.Add(new ItemExtended()
            {
                ItemCode = "CAL-OC-PP-LEM",
                ItemName = "Calypso Paradise Punch  Lemonade",
                SalesPrice = 2.79M,
                ItemKey = 1440781,
                ItemCategory7 = new CodeBaseResponse(457385),
                Base64ImageDocument = "calypsopplemonade.jpg",
                Description= "There’s not just one single ‘slice of paradise.’ There are, in fact, SEVERAL slices of paradise." +
                " There are orange slices, pineapple slices, lemon slices, and if grape and cherry could be sliced," +
                " we’d put them on the list too.",


            }); 


            SampleItems.Add(new ItemExtended()
            {
                ItemCode = "AR-PE-GR-TE",
                ItemName = "Arizona Green Tea 100ml",
                SalesPrice = 3.99M,
                ItemKey = 1441755,
                ItemCategory7 = new CodeBaseResponse(458205),
                Base64ImageDocument = "arizonagreentea.jpg",
                Description= "Craving something that's just a little bit sweet? Then reach for an AriZona Georgia Peach Green Tea BIG AZ CAN™. " +
                "The combination of real peach juice and premium green tea make for a refreshingly delicious drink. Just the right amount of Panax Ginseng and " +
                "See Bee® Orange Honey add flavorful finishing touches. "

            }); 

  SampleItems.Add(new ItemExtended()
            {
                ItemCode = "AR-CC-UU",
                ItemName = "Arizona  Cucumber Refresh 100ml",
                SalesPrice = 3.49M,
                ItemKey = 1441756,
                ItemCategory7 = new CodeBaseResponse(458205),
                Base64ImageDocument = "arizonacucumber.jpg",
                Description= "AriZona Green Tea is looking and tasting cool as a Cucumber with this revamp. Cucumber Green Tea BIG AZ CAN™ with Citrus " +
                "is light and refreshing with a clean finish, keeping you well hydrated while getting your Green Tea fix.",
                DefaultDiscountPercentage=7
               
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
