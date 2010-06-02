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
	public class T_080_GetCategoryListingsLibrary : SOAPTestBase
	{
		[Test]
		public void GetCategoryListings()
		{
			GetCategoryListingsCall api = new GetCategoryListingsCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			//api.CategoryID = "37906";
			api.CategoryID = "279";
			api.ItemTypeFilter = ItemTypeFilterCodeType.AllItems;
			api.Currency = CurrencyCodeType.USD;
			api.OrderBy = CategoryListingsOrderCodeType.SortByPriceAsc;
			// Pagination
			PaginationType pt = new PaginationType();
			pt.EntriesPerPage = 50; 
			pt.EntriesPerPageSpecified = true;
			pt.PageNumber = 1; 
			pt.PageNumberSpecified = true;
			api.Pagination = pt;
			// Make API call.
			ItemTypeCollection items = api.GetCategoryListings(api.CategoryID);
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(items);
			Assert.IsTrue(items.Count > 0);
			TestData.CategoryListings = items;
			
		}
		
	}
}