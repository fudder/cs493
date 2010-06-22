using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleStore.Core;
using SimpleStore.Core.DataInterfaces;
using SharpArch.Core;
using SharpArch.Web;

namespace SimpleStore.Web.Controllers
{
    public class SiteController : Controller
    {
        private readonly ISiteRepository siteRepository;

        public SiteController(ISiteRepository siteRepository) 
        {
            Check.Require(siteRepository != null, "siteRepository may not be null");
            this.siteRepository = siteRepository;
        } 

        public ActionResult MatchingFilter(string filter) {
            List<Site> matchingSites = siteRepository.FindAllMatching(filter);
            return View("MatchingFilter", matchingSites);
        }

    }
}
