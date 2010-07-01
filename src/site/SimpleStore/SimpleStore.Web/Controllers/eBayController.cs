using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleStore.Services.eBay;
using eBay.Service.Core.Soap;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Controllers
{
    public class eBayController : Controller
    {
        //
        // GET: /eBay/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int id = 0)
        {
            eBayCategoryModel viewModel = new eBayCategoryModel();
            eBayManager ebay = new eBayManager();
            int level = 1;

            if (id > 0)
            {
                viewModel.BreadCrumb = ebay.GetCategoryBreadCrumb(id);
                level = viewModel.BreadCrumb.Count + 1;
            }

            viewModel.Categories = ebay.GetCategories(id, level);

            return View(viewModel);
        }

        public ActionResult Selling()
        {
            eBayManager ebay = new eBayManager();
            return View(ebay.GetSales());
        }

    }
}
