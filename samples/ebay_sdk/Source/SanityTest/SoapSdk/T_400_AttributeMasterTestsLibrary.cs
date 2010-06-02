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
using System.Threading;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using eBay.Service.SDK.Attribute;
using System.Xml;
using MSXML2;
using System.IO;

#endregion

namespace AllTestsSuite.T_110_AllAttributesLibraryTestsSuite
{

	[TestFixture]
	public class T_010_AttributesMasterTestsLibrary : SOAPTestBase
	{
		private const int CATEGORYID=279;
		AttributesMaster master;
		ICategoryCSProvider catCsDownloader;
		IAttributesXmlProvider xmlDownLoader;
		IAttributesXslProvider xslDownLoader;

		public void init() 
		{
			master = new AttributesMaster();
			catCsDownloader = new CategoryCSDownloader(apiContext);
			master.CategoryCSProvider = catCsDownloader;
			xmlDownLoader = new AttributesXmlDownloader(apiContext);
			master.XmlProvider = xmlDownLoader;
			xslDownLoader = new AttributesXslDownloader(apiContext);
			master.XslProvider = xslDownLoader;

		}

		private void releaseResource()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		[Test]
		public void RenderHtml()
		{
			init();
			Int32Collection catIds = new Int32Collection();
			catIds.Add(CATEGORYID);
			IAttributeSetCollection siteWideAttrSets = master.GetSiteWideAttributeSetsForCategories(catIds);
			AttributeSet retPolicySet = master.GetReturnPolicyAttributeSet(siteWideAttrSets);
			IAttributeSetCollection retPolicySetCollection = new AttributeSetCollection();
			retPolicySetCollection.Add(retPolicySet);
			string tableText = master.RenderHtml(retPolicySetCollection, null);
			DOMDocument30 xmlDoc = master.getXmlToRenderDoc();
			//TextWriter writer = new StreamWriter("C:\\SDK\\48514.xml");
			string xmlString = xmlDoc.xml;
			Console.WriteLine(xmlString);
			releaseResource();
		}

		[Test]
		public void GetItemSpecificAttributeSetsForCategories()
		{
			this.apiContext=ApiContextLoader.LoadApiContext("");
			init();
			Int32Collection catIds = new Int32Collection();
			catIds.Add(CATEGORYID);
			IAttributeSetCollection itemAttrSets = master.GetItemSpecificAttributeSetsForCategories(catIds);
			releaseResource();
			Assert.IsNotNull(itemAttrSets);
			Assert.AreEqual(1, itemAttrSets.Count);
		}

		[Test]
		public void GetReturnPolicyAttributeSet()
		{
			init();
			Int32Collection catIds = new Int32Collection();
			catIds.Add(CATEGORYID);
			IAttributeSetCollection siteWideAttrSets = master.GetSiteWideAttributeSetsForCategories(catIds);
			releaseResource();
			Assert.IsNotNull(siteWideAttrSets);
			Assert.AreEqual(1, siteWideAttrSets.Count);
			AttributeSet retPolicySet = master.GetReturnPolicyAttributeSet(siteWideAttrSets);
			Assert.IsNotNull(retPolicySet);
		}

		[Test]
		public void GetSiteWideAttributeSetsForCategories()
		{
			init();
			Int32Collection catIds = new Int32Collection();
			catIds.Add(378);
			IAttributeSetCollection siteWideAttrSets = master.GetSiteWideAttributeSetsForCategories(catIds);
			releaseResource();
			Assert.IsNotNull(siteWideAttrSets);
			Assert.AreEqual(1, siteWideAttrSets.Count);
		}
	
	}
}