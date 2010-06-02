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

namespace AllTestsSuite.T_040_CatalogTestsSuite
{
	[TestFixture]
	public class T_060_GetProductFamilyMembersLibrary : SOAPTestBase
	{
		[Test]
		public void GetProductFamilyMembers()
		{
			Assert.IsNotNull(TestData.ProductSearchResults);
			GetProductFamilyMembersCall api = new GetProductFamilyMembersCall(this.apiContext);
			ProductFamilyTypeCollection fm = TestData.ProductSearchResults[0].AttributeSet[0].ProductFamilies;
			ProductType parent = fm[0].ParentProduct;
			ProductSearchType ps = new ProductSearchType();
			ps.AttributeSetID = parent.CharacteristicsSet.AttributeSetID;
			ps.ProductID = parent.productID;
			api.ProductSearchList = new ProductSearchTypeCollection();
			api.ProductSearchList.Add(ps);
			// Make API call.
			api.Execute();
			ProductSearchResultTypeCollection results = api.ApiResponse.ProductSearchResult;
			Assert.IsNotNull(results);
			Assert.IsTrue(results.Count > 0);
		}
	}
}