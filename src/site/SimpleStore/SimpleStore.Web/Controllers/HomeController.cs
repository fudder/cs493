using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleStore.Services.eBay;

namespace SimpleStore.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            eBayManager ebay = new eBayManager();
            List<string> titles = ebay.GetSales();

            ViewData["items"] = titles;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
