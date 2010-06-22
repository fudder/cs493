using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleStore.Core.DataInterfaces;
using SimpleStore.Core;
using SimpleStore.Data;

namespace SimpleStore.Tests.Data
{
    [TestClass]
    public class SiteRepositoryTests : RepositoryTestsBase
    {
        protected override void LoadTestData()
        {
            AddSite(0, "CS493", "Senior Capstone Project");
            AddSite(0, "Test Site", "This is for testing");
            AddSite(0, "Senior Frogs", "Senior Frog's House of Tasty Snacks");
            AddSite(0, "The Arboretum", "A premier retirement facility for the discerning senior");
        }

        [TestMethod]
        public void CanLoadSitesMatchingFilter()
        {
            List<Site> matchingSites =
                SiteRepository
                    .FindAllMatching("senior");

            Assert.AreEqual(matchingSites.Count, 3);
        }

        private void AddSite(int siteId,
            string name, string tagline)
        {
            Site Site =
                new Site(siteId)
                {
                    Name = name,
                    Tagline = tagline
                };

            SiteRepository.SaveOrUpdate(Site);
            FlushSessionAndEvict(Site);
        }

        private ISiteRepository SiteRepository = new SiteRepository();
    }
}
