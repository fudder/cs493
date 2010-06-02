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

using UnitTests.Helper;
#endregion

namespace AllTestsSuite.T_030_CategoryTestsSuite
{
	[TestFixture]
	public class T_030_GetCategory2CSLibrary : SOAPTestBase
	{

		[Test]
		public void GetCategory2CS()
		{
			GetCategory2CSCall api = new GetCategory2CSCall(this.apiContext);
			// Return version only
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.CategoryID = "279";   //Children's Book

			//api.CategoryID = "64355";   //Cell Phones
			api.Timeout = 300000;

			string message=string.Empty;

			// Make API call.
			CategoryTypeCollection cats = api.GetCategory2CS();

			Assert.IsNotNull(cats);
			Assert.IsNotNull(api.AttributeSystemVersionResponse);
			int ver = Int32.Parse(api.AttributeSystemVersionResponse);
			Assert.IsTrue(ver > 0);
			Assert.IsNotNull(api.SiteWideCharacteristicList);
			TestData.Category2CS = cats;
			
			IAttributesMaster attrMaster = new AttributesMaster();
			ICategoryCSProvider catCSDownLoader = new CategoryCSDownloader(apiContext);
			attrMaster.CategoryCSProvider = catCSDownLoader;
			int[] catIds = catCSDownLoader.GetSiteWideCharSetsAttrIds("48514");
			Assert.IsNotNull(catIds);
		}


		/// <summary>
		/// the media category including Books, DVD & Movies, Music, or Video Games should be catalog-enabled.
		/// if the catalog-enabled property is true, the characterctic property also contains information accordingly.
		/// use GetCategory2CSCall to check whether that principle is true.
		/// </summary>
		[Test]
		public void GetCategory2CSFull()
		{
			//pls do not change this category id. It may have some negative effects on GetProductFinderCall
			string mediaCategory="279";//this is children's book whick blongs to Media category and is catalog-enabled.
			CategoryType categoryTmp=null;
			bool isValid,isSuccess;
			string message;
			
			//check whether the category is valid.
			isSuccess=CategoryHelper.IsValidCategory(this.apiContext,ref mediaCategory,out isValid,out message);
			Assert.IsTrue(isSuccess,message);
			Assert.IsTrue(isValid,"this category is not valid");

			GetCategory2CSCall api = new GetCategory2CSCall(this.apiContext);
			// Return all message.
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.CategoryID = mediaCategory.ToString();

			// Make API call.
			CategoryTypeCollection categories = api.GetCategory2CS();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(categories);
			Assert.Greater(categories.Count,0);
			foreach(CategoryType category in categories)
			{
				if(string.Compare(category.CategoryID,mediaCategory,true)==0)
				{
					categoryTmp=category;
					break;
				}
			}
			
			//the media category should be catalog-enabled and contains attributeset id accordingly.
			Assert.IsNotNull(categoryTmp);
			Assert.IsTrue(categoryTmp.CatalogEnabled);
			Assert.IsTrue(categoryTmp.ProductSearchPageAvailable);
			Assert.IsNotNull(categoryTmp.CharacteristicsSets);
			Assert.Greater(categoryTmp.CharacteristicsSets.Count,0);
			Assert.Greater(categoryTmp.CharacteristicsSets[0].AttributeSetID,0);

			TestData.Category2CS2=categoryTmp;
		}

	}
}