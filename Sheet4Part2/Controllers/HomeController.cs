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
        public static List<SubOrder> subsList = new List<SubOrder>();
        // GET: Home
        
        public ActionResult Totals()
        {
            SubReceipt receipt = (SubReceipt)Session["Order"];
            return View(receipt);
        }
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
            //Get the name
            receipt.SandwichType = Enum.GetName(typeof(SandwichType), order.sTypes);
            receipt.SandwichSize = Enum.GetName(typeof(SandwichSize), order.sSizes);
            receipt.SandwichDeal = Enum.GetName(typeof(SandwichDeal), order.sDeals);
            receipt.quantity = order.qty;
            //Get the value
            double subPrice = subPrices[(int)order.sTypes];
            double subSize = sizePrices[(int)order.sSizes];
            double subDeal = mealDealPrices[(int)order.sDeals];

            receipt.subPrice = Math.Round(subPrice * subSize, 2);
            receipt.mealDealPrice = subDeal;
            receipt.sandwichAndMealPrice = Math.Round(subPrice * subSize, 2)+subDeal;
            receipt.accumulateIncome();
            receipt.accumulateTaxes();

            subsList.Add(order);

            Session["Order"] = receipt;
            Session["OrderList"] = subsList;
            
            return View(receipt);
        }
    }
}