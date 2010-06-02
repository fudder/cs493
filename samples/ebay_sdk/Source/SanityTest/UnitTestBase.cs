#region Copyright
//	Copyright (c) 2007 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion

using System;
using NUnit.Framework;

namespace AllTestsSuite
{
	/// <summary>
	/// Summary description for UnitTestBase.
	/// </summary>
	/// 
	//[TestFixture]
	public class UnitTestBase
	{
		public UnitTestBase()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[TestFixtureSetUp]
		public virtual void TestFixtureSetup(){}

		[TestFixtureTearDown]
		public virtual void TestFixtureTearDown(){}

		[SetUp]
		public virtual void Setup(){}

		[TearDown]
		public virtual void TearDown(){}
	}
}
