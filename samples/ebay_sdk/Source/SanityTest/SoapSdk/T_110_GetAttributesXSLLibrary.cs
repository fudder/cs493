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
	public class T_110_GetAttributesXSLLibrary : SOAPTestBase
	{
		[Test]
		public void GetAttributesXSL()
		{
			GetAttributesXSLCall api = new GetAttributesXSLCall(this.apiContext);
			// Return version number only.
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			// Make API call.
			XSLFileTypeCollection files = api.GetAttributesXSL();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(files);
			Assert.IsTrue(files.Count > 0);
			Assert.IsNotNull(files[0].FileName);
			Assert.IsNotNull(files[0].FileVersion);
			Assert.IsNotNull(files[0].FileContent);
			
		}
	}
}