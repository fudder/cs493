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
	public class T_030_GetProductSearchPageLibrary : SOAPTestBase
	{
		private const string childrenBookCategory = "279";//this is children book category id.

		[Test]
		public void GetProductSearchPage()
		{
			Assert.IsNotNull(TestData.Category2CS);
			//
			Int32Collection l = new Int32Collection();
			for(int i = 0; i < TestData.Category2CS.Count; i++ )
			{
			CategoryType c = TestData.Category2CS[i];
			if( c.ProductSearchPageAvailableSpecified && c.ProductSearchPageAvailable
			&& c.CharacteristicsSets != null && c.CharacteristicsSets.Count > 0
			)
			{
			l.Add(c.CharacteristicsSets[0].AttributeSetID);
			break;
			}
			}
			//
			GetProductSearchPageCall api = new GetProductSearchPageCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			   DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);

			api.AttributeSetIDList = l;
			// Make API call.
			ProductSearchPageTypeCollection searchPages = api.GetProductSearchPage();
			Assert.IsNotNull(searchPages);
			Assert.IsTrue(searchPages.Count > 0);
			TestData.ProductSearchPages = searchPages;
			
		}

		
		[Test]
		public void GetProductSearchPageFull()
		{
			Assert.IsNotNull(TestData.Category2CS2);
			//here comes out hard code.
			//the category should be children books category.
			Assert.IsTrue((string.Compare(TestData.Category2CS2.CategoryID,childrenBookCategory,true)==0));
			Int32Collection attributeSets = new Int32Collection();
			CategoryType category = TestData.Category2CS2;
			Assert.Greater(category.CharacteristicsSets.Count,0);
			for(int i=0; i< category.CharacteristicsSets.Count;i++)
			{
				attributeSets.Add(category.CharacteristicsSets[i].AttributeSetID);
			}
			Assert.Greater(attributeSets.Count,0);
			GetProductSearchPageCall api = new GetProductSearchPageCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.AttributeSetIDList = attributeSets;
			api.Execute();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(api.ApiResponse.ProductSearchPage);
			Assert.Greater(api.ApiResponse.ProductSearchPage.Count,0);
			//the children category's SearchCharacteristicsSet property has value.
			Assert.IsNotNull(api.ApiResponse.ProductSearchPage[0].SearchCharacteristicsSet);
			Assert.Greater(api.ApiResponse.ProductSearchPage[0].SearchCharacteristicsSet.Characteristics.Count,0);
			//cache the children's mapping data.
			TestData.ProductSearchPages2 = api.ApiResponse.ProductSearchPage;


		}
	}
}