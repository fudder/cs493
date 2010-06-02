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
	public class T_330_GetProductsLibrary : SOAPTestBase
	{
		[Test]
		public void GetProducts()
		{
			GetProductsCall api = new GetProductsCall(this.apiContext);
			//
			ProductSearchType prodSearchType = new ProductSearchType();
			prodSearchType.ProductID = "556677";
			prodSearchType.AttributeSetID = 123;
			prodSearchType.ProductReferenceID = "44462740";
			//
			ProductSortCodeType productSortCodeType = ProductSortCodeType.PopularityAsc;
			//
			AffiliateTrackingDetailsType affTrackingDetailsType = new AffiliateTrackingDetailsType();
			affTrackingDetailsType.TrackingID = "trackId";
			affTrackingDetailsType.AffiliateUserID = "UserId";
			affTrackingDetailsType.TrackingPartnerCode = "PartnerCode";
			//
			api.Site = SiteCodeType.US;
		
			try 
			{
				CharacteristicsSetProductHistogramType products = 
					api.GetProducts(prodSearchType, productSortCodeType, true, false, true, false, affTrackingDetailsType,true);					                
			} 
			catch(ApiException apie) 
			{
				Console.WriteLine("ApiException: " + apie.Message);
			}  
			catch(SdkException sdke) 
			{
				Assert.Fail("SdkException: " + sdke.Message);
			}

		}
	}
}