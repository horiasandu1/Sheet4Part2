using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sheet4Part2.Models
{
    public class SubOrder
    {
        public SandwichType sTypes { get; set; }
        public SandwichSize sSizes { get; set; }
        public SandwichDeal sDeals { get; set; }
        public int qty { get; set; }


    }
        public enum SandwichType
        {
            TheMichealJackson,
            TheWeeknd,
            TheBackStreetBoys,
            ThePrince,
            TheBeyonce
        }

        public enum SandwichSize
        {
            small,
            medium,
            large
        }

        public enum SandwichDeal
        {
            none,
            drinkAndCookie,
            drinkAndChips
        }
    
}