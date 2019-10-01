using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sheet4Part2.Models
{
    public class SubReceipt
    {
        public static double federalTax = 0.05;
        public static double provincialTax = 0.09975;
        public string SandwichType { get; set; }
        public string SandwichSize { get; set; }
        public string SandwichDeal { get; set; }
        public double subPrice { get; set; }
        public double mealDealPrice { get; set; }
        public double sandwichAndMealPrice { get; set; }
   

    

        public double getTaxes()
        {
            return Math.Round(subPrice * (federalTax + provincialTax), 2);
        }
        public double getTotalPrice()
        {
            return sandwichAndMealPrice + getTaxes();
        }


        public DateTime getDate()
        {
            return DateTime.UtcNow;
        }
    }
}