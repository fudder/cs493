using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpArch.Testing.NHibernate;

namespace SimpleStore.Tests.Data
{
    /// <summary>
    /// 
    /// ! Replacing SharpArch\SharpArch.Testing.NUnit\NHibernate\RepositoryTestsBase so I can use VS Testing
    /// 
    /// Provides a base class for running unit tests against an in-memory database created
    /// during test execution.  This builds the database using the connection details within
    /// NHibernate.config.  If you'd prefer unit testing against a "live" development database
    /// such as a SQL Server instance, then use <see cref="DatabaseRepositoryTestsBase" /> instead.
    /// If you'd prefer a more behavior driven approach to testing against the in-memory database,
    /// use <see cref="RepositoryBehaviorSpecificationTestsBase" /> instead.
    /// </summary>
    [TestClass]
    public abstract class RepositoryTestsBase
    {
        [TestInitialize]
        public virtual void SetUp()
        {
            RepositoryTestsHelper.InitializeDatabase();

            LoadTestData();
        }

        [TestCleanup]
        public virtual void TearDown()
        {
            RepositoryTestsHelper.Shutdown();
        }

        protected void FlushSessionAndEvict(object instance)
        {
            RepositoryTestsHelper.FlushSessionAndEvict(instance);
        }

        protected abstract void LoadTestData();
    }
}