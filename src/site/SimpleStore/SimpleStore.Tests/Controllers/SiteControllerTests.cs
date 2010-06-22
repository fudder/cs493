using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;

using SimpleStore.Web.Controllers;
using SimpleStore.Core;
using SimpleStore.Core.DataInterfaces;
using Rhino.Mocks;
using MvcContrib.TestHelper;

namespace SimpleStore.Tests.Controllers
{
    /// <summary>
    /// Summary description for SiteControllerTests
    /// </summary>
    [TestClass]
    public class SiteControllerTests
    {
        public SiteControllerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CanListFilteredSites()
        {
            SiteController controller = new SiteController(CreateMockSiteRepository());

            ViewResult result =
                controller.MatchingFilter("Does not matter")
                    .AssertViewRendered()
                    .ForView("MatchingFilter");

            Assert.IsNotNull(result.ViewData);
            Assert.IsNotNull(result.ViewData.Model as List<Site>);
            Assert.AreEqual((result.ViewData.Model as List<Site>).Count, 4);
        }

        /// <summary>
        /// In most cases, we'd simply return
        /// IRepository<MyEntity>, but since we're
        /// leveraging a custom Repository method, we need a
        /// custom Repository interface.
        /// </summary>
        public ISiteRepository CreateMockSiteRepository()
        {
            MockRepository mocks = new MockRepository();
            ISiteRepository mockedRepository = mocks.StrictMock<ISiteRepository>();
            Expect.Call(mockedRepository.FindAllMatching(null))
                .IgnoreArguments()
                .Return(CreateSites());

            mocks.Replay(mockedRepository);

            return mockedRepository;
        }

        private List<Site> CreateSites()
        {
            List<Site> Sites =
                new List<Site>();

            Sites.Add(new Site(1));
            Sites.Add(new Site(2));
            Sites.Add(new Site(3));
            Sites.Add(new Site(4));

            return Sites;
        }

    }
}
