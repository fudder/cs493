#region Copyright
//	Copyright (c) 2007 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion

#region Namespaces
using System;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
#endregion

namespace AllTestsSuite.T_030_CategoryTestsSuite
{
	[TestFixture]
	public class T_090_GetSuggestedCategoriesLibrary : SOAPTestBase
	{
		[Test]
		public void GetSuggestedCategories()
		{
			GetSuggestedCategoriesCall api = new GetSuggestedCategoriesCall(this.apiContext);
			api.Query = "DVD";
			SuggestedCategoryTypeCollection cats = api.GetSuggestedCategories(api.Query);
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success||api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(cats);
			Assert.IsTrue(cats.Count > 0);
			//check the category number is right
			Assert.AreEqual(cats.Count,api.ApiResponse.CategoryCount);
		}
	}
}