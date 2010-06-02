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
	public class T_050_GetProductSellingPagesLibrary : SOAPTestBase
	{
		[Test]
		public void GetProductSellingPages()
		{
			
			Assert.IsNotNull(TestData.ProductSearchResults);
			ProductTypeCollection al = new ProductTypeCollection();
			
			ProductFamilyTypeCollection fm = TestData.ProductSearchResults[0].AttributeSet[0].ProductFamilies;
			for(int i = 0; i < fm.Count; i++ )
			{
				if( fm[i].FamilyMembers != null &&
					fm[i].FamilyMembers.Count > 0 )
				{
					ProductType pt = fm[i].FamilyMembers[0];
                    pt.ProductReferenceID = null;
					pt.stockPhotoURL = null;
					al.Add(pt);
					// Only retrieve 3 pages
					if( al.Count >= 1 )
						break;
				}
			}
			
			GetProductSellingPagesCall api = new GetProductSellingPagesCall(this.apiContext);
			api.ProductList = al;
			api.UseCase = ProductUseCaseCodeType.AddItem;
			// Make API call.
			String sellingPage = api.GetProductSellingPages(api.UseCase, api.ProductList);
			Assert.IsNotNull(sellingPage);
			
		}


		[Test]
		public void GetProductSellingPagesFull()
		{
			
			Assert.IsNotNull(TestData.ProductSearchResults2);
			ProductTypeCollection al = new ProductTypeCollection();
			
			ProductFamilyTypeCollection fm = TestData.ProductSearchResults2[0].AttributeSet[0].ProductFamilies;
			for(int i = 0; i < fm.Count; i++ )
			{
				if( fm[i].FamilyMembers != null &&
					fm[i].FamilyMembers.Count > 0 )
				{
					ProductType pt = fm[i].FamilyMembers[0];
                    pt.ProductReferenceID = null;
					pt.stockPhotoURL = null;
					al.Add(pt);
				}
			}
			
			GetProductSellingPagesCall api = new GetProductSellingPagesCall(this.apiContext);
			api.ProductList = al;
			api.UseCase = ProductUseCaseCodeType.AddItem;
			// Make API call.
			api.Execute();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(api.ApiResponse.ProductSellingPagesData);		
			Assert.Greater(api.ApiResponse.ProductSellingPagesData.Length,0);		
		}
	}
}