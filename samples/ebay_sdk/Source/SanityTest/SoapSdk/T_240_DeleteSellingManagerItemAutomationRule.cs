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
using System.Xml;
using System.IO;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.SDK.Attribute;
using eBay.Service.Util;
#endregion
namespace AllTestsSuite.T_120_SellingManagerTestsSuite
{
	/// <summary>
	/// Summary description for T_240_DeleteSellingManagerItemAutomationRule.
	/// </summary>
	[TestFixture]
	public class T_240_DeleteSellingManagerItemAutomationRule : SOAPTestBase
	{
		[Test]
		public void DeleteSellingManagerItemAutomationRule()
		{
			Assert.IsTrue(TestData.ItemId!=string.Empty);
			DeleteSellingManagerItemAutomationRuleCall api = new DeleteSellingManagerItemAutomationRuleCall(apiContext);
			api.ItemID=TestData.ItemId;
			api.DeleteAutomatedRelistingRule=true;
			api.Execute();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
		}
	}
}
