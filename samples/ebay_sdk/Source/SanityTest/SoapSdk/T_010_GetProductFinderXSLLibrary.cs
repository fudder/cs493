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
	public class T_010_GetProductFinderXSLLibrary : SOAPTestBase
	{
		[Test]
		public void GetProductFinderXSL()
		{
			GetProductFinderXSLCall api = new GetProductFinderXSLCall(this.apiContext);
			api.DetailLevelList = new DetailLevelCodeTypeCollection();
			api.DetailLevelList.Add(DetailLevelCodeType.ReturnAll) ;
			// Make API call.
			XSLFileTypeCollection xsl = api.GetProductFinderXSL();
			
		}

		[Test]
		public void GetProductFinderXSLFull()
		{
			GetProductFinderXSLCall api = new GetProductFinderXSLCall(this.apiContext);
			api.DetailLevelList = new DetailLevelCodeTypeCollection();
			api.DetailLevelList.Add(DetailLevelCodeType.ReturnAll) ;
			// Make API call.
			XSLFileTypeCollection xsl = api.GetProductFinderXSL();

			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			//the following property must return their values.
			Assert.IsNotNull(xsl);
			Assert.Greater(xsl.Count,0);
			Assert.Greater(xsl[0].FileName.Length,0);
			Assert.Greater(xsl[0].FileVersion.Length,0);
			Assert.Greater(xsl[0].FileContent.Length,0);
		}
	}
}