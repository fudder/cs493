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
	public class T_020_GetSearchResultsLibrary : SOAPTestBase
	{
		[Test]
		public void GetSearchResults()
		{
			GetSearchResultsCall api = new GetSearchResultsCall(this.apiContext);
			PriceRangeFilterType pf = new PriceRangeFilterType();
			pf.MinPrice = new AmountType(); 
			pf.MinPrice.Value = 1.0; 
			pf.MinPrice.currencyID = CurrencyCodeType.USD;
			pf.MaxPrice = new AmountType(); 
			pf.MaxPrice.Value = 999.99; 
			pf.MaxPrice.currencyID = CurrencyCodeType.USD;
			api.PriceRangeFilter = pf;
			api.ItemTypeFilter = ItemTypeFilterCodeType.AllItems;
			api.Query = "DVD";
			// Time filter
			System.DateTime calTo = System.DateTime.Now;
			System.DateTime calFrom = calTo.AddDays(-7);
			api.ModTimeFrom = calFrom;
			//api.EndTimeTo = calTo;
			// Pagination
			PaginationType pt = new PaginationType();
			pt.EntriesPerPage = 50; pt.EntriesPerPageSpecified = true;
			pt.PageNumber = 1; pt.PageNumberSpecified = true;
			api.Pagination = pt;
			// Make API call.
			SearchResultItemTypeCollection items = api.GetSearchResults(api.Query);
			Assert.IsNotNull(items);
			Assert.IsTrue(items.Count > 0, "No items found");
			
		}
	}
}