using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sheet4Part2.Models;

namespace Sheet4Part2.Models
{
    public class SubReceipt
    {
        public static double taxAccumulator=0;
        public static double incomeAccumulator=0;

        public static double federalTax = 0.05;
        public static double provincialTax = 0.09975;
        public string SandwichType { get; set; }
        public string SandwichSize { get; set; }
        public string SandwichDeal { get; set; }
        public double subPrice { get; set; }
        public double mealDealPrice { get; set; }
        public double sandwichAndMealPrice { get; set; }
        public int quantity { get; set; }
   
        
    

        public double getTaxes()
        {
            return Math.Round((subPrice+mealDealPrice) * ((federalTax + provincialTax)*quantity), 2);
        }

        public void accumulateTaxes()
        {
            taxAccumulator += ((subPrice+mealDealPrice) * (federalTax + provincialTax) * quantity);

        }

        public void accumulateIncome()
        {
            incomeAccumulator += sandwichAndMealPrice * quantity;

        }

        public double getSubTotal()
        {
            return (sandwichAndMealPrice * quantity);
        }
        public double getTotalPrice()
        {
            
            return (sandwichAndMealPrice*quantity) + getTaxes();
        }


        public DateTime getDate()
        {
            return DateTime.UtcNow;
        }
    }
}