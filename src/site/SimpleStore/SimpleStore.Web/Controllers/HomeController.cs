﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleStore.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Prototype()
        {
            return View();
        }

        public ActionResult Source()
        {
            return View();
        }
    }
}
