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

namespace AllTestsSuite.T_020_OtherTestsSuite
{
	[TestFixture]
	public class T_040_GetPopularKeywordsLibrary : SOAPTestBase
	{
		[Test]
		public void GetPopularKeywords()
		{
			GetPopularKeywordsCall api = new GetPopularKeywordsCall(this.apiContext);
			// Pagination
			PaginationType pt = new PaginationType();
			pt.EntriesPerPage = 50; pt.EntriesPerPageSpecified = true;
			pt.PageNumber = 1; pt.PageNumberSpecified = true;
			api.Pagination = pt;
			api.MaxKeywordsRetrieved = 100;
			StringCollection catIdList = new StringCollection();
			catIdList.Add("-1");
			api.CategoryIDList = catIdList;
			// Make API call
			api.Execute();
			CategoryTypeCollection words = api.ApiResponse.CategoryArray;
			Assert.IsTrue(words.Count > 0, "No keywords found");
			Boolean hasMore = api.ApiResponse.HasMore;
			
		}
	}
}