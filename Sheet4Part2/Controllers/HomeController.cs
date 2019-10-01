using Sheet4Part2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet4Part2.Controllers
{
    public class HomeController : Controller
    {
        public static double taxAccumulator;
        public static double incomeAccumulator;
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Receipt (SubOrder order)
        {
            SubReceipt receipt = new SubReceipt();

            double[] subPrices = new double[]
            {
                10.99,
                11.99,
                12.99,
                13.99,
                14.99
            };

            double[] sizePrices = new double[]
            {
                1.50,
                2.00,
                3.00
            };

            double[] mealDealPrices = new double[]
            {
                0.00,
                1.99,
                2.49
            };

            receipt.SandwichType = Enum.GetName(typeof(SandwichType), order.sTypes);
            receipt.SandwichSize = Enum.GetName(typeof(SandwichSize), order.sSizes);
            receipt.SandwichDeal = Enum.GetName(typeof(SandwichDeal), order.sDeals);

 
            double subPrice = subPrices[(int)order.sTypes];
            double subSize = sizePrices[(int)order.sSizes];
            double subDeal = mealDealPrices[(int)order.sDeals];

            receipt.subPrice = Math.Round(subPrice * subSize, 2);
            receipt.mealDealPrice = subDeal;
            receipt.sandwichAndMealPrice = Math.Round(subPrice * subSize, 2)+subDeal;

            return View(receipt);
        }
    }
}