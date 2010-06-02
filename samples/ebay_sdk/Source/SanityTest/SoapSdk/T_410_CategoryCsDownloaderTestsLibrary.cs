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
using eBay.Service.SDK.Attribute;
using System.Collections;
using System.Collections.Specialized;

#endregion

namespace AllTestsSuite.T_110_AllAttributesLibraryTestsSuite
{
	[TestFixture]
	public class T_020_CategoryCSDownloaderTestsLibrary : SOAPTestBase
	{
		private CategoryCSDownloader catCsDownloader;

		public void init() 
		{
			catCsDownloader = new CategoryCSDownloader(apiContext);
		}

		//[Test]
		public void GetVCSIdMap()
		{
			init();
			int catId = 378;
			Hashtable vcsIdMap = catCsDownloader.GetVCSIdMap(catId);
			Assert.IsNotNull(vcsIdMap);
			IDictionaryEnumerator iter = vcsIdMap.GetEnumerator();
			while(iter.MoveNext()) 
			{
				CharacteristicsSetType[] charSetArray = (CharacteristicsSetType[])iter.Value;
				Assert.IsNotNull(charSetArray);
				Assert.Greater(charSetArray.Length, 0);
				for(int i = 0; i < charSetArray.Length; i++) 
				{
					Console.WriteLine(charSetArray[i].AttributeSetID.ToString());
				}
			}	
			CharacteristicsSetType[] charSetArray1 = (CharacteristicsSetType[])vcsIdMap[catId.ToString()];
			Console.WriteLine(charSetArray1[0].AttributeSetID.ToString());
		}
	
		[Test]
		public void GetVCSIdArray()
		{
			init();
			int catId = 378;
			int[] vcsIds = catCsDownloader.GetVCSIdArray(catId);
			Assert.IsNotNull(vcsIds);
			for(int i = 0; i < vcsIds.Length; i++) 
			{
				Console.WriteLine(vcsIds[i].ToString());
			}
		}

		[Test]
		public void GetVCSId()
		{
			init();
			int catId = 279;
			int vcsId = catCsDownloader.GetVCSId(catId);
			Assert.Greater(vcsId, 0);
			Console.WriteLine(vcsId.ToString());
		}
	}
}