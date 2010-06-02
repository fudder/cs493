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
	public class T_020_GetProductFinderLibrary : SOAPTestBase
	{
		[Test]
		public void GetProductFinder()
		{
			Assert.IsNotNull(TestData.Category2CS);
			GetProductFinderCall api = new GetProductFinderCall(this.apiContext);
			api.DetailLevelList = new DetailLevelCodeTypeCollection();
			api.DetailLevelList.Add(DetailLevelCodeType.ReturnAll) ;
			//
			Int32Collection l = new Int32Collection();
			for(int i = 0; i < TestData.Category2CS.Count; i++ )
			{
			CategoryType c = TestData.Category2CS[i];
			if( c.ProductFinderIDs != null && c.ProductFinderIDs.Count > 0 )
			{
			for(int n = 0; n < c.ProductFinderIDs.Count; n++ )
			l.Add(c.ProductFinderIDs[n].ProductFinderID);
			break;
			}
			}
			//
			//int[] ids = new int[l.Count()];
			//for(int i = 0; i < l.Count(); i++)
			//ids[i] = ((Integer)l.get(i)).intValue();
			api.ProductFinderIDList = l;
			// Make API call.
			String pfData = api.GetProductFinder();
			
		}


		/// <summary>
		/// there is no appororiate category whose ProductFinderBuySide is false.
		/// </summary>
		///[Test]
		public void GetProductFinderFull()
		{
			Assert.IsNotNull(TestData.Category2CS);
			GetProductFinderCall api = new GetProductFinderCall(this.apiContext);
			api.DetailLevelList = new DetailLevelCodeTypeCollection();
			api.DetailLevelList.Add(DetailLevelCodeType.ReturnAll) ;
			CategoryType category = TestData.Category2CS2;
			Assert.IsNotNull(category.ProductFinderIDs);
			Assert.Greater(category.ProductFinderIDs.Count,0);
			Assert.IsTrue(category.ProductFinderIDs[0].ProductFinderBuySideSpecified==false);
			
			//get all product finder id
			Int32Collection productFinderIDs = new Int32Collection();
			for(int i=0; i<category.ProductFinderIDs.Count;i++)
			{
				productFinderIDs.Add(category.ProductFinderIDs[i].ProductFinderID);
			}
			
			//it must contain value.
			Assert.Greater(productFinderIDs.Count,0);
			api.ProductFinderIDList = productFinderIDs;

			//execute call.
			api.Execute();

			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			//the product finder data must return value.
			Assert.Greater(api.ApiResponse.ProductFinderData.Length,0);
		}

	}
}