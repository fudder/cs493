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
	public class T_040_GetProductSearchResultsLibrary : SOAPTestBase
	{
		private const int ISBN13ATTRIBUTEID=63739;// 63739 is the ISBN-13's attribute id.
		private const string ISBN="9781594130014";//ISBN-13,it is an ISBN number of harry potter and the chamber of secrets
		private const string  PSPACATEGORYID="279";// It is an ProductSearchPageAvailable category id.

		[Test]
		public void GetProductSearchResults()
		{
			this.apiContext.Timeout = 360000;
			GetProductSearchResultsCall api = new GetProductSearchResultsCall(this.apiContext);
			ProductSearchType ps = new ProductSearchType();
			//ps.AttributeSetID = 1785;// Cell phones
			ps.MaxChildrenPerFamily = 20; ps.MaxChildrenPerFamilySpecified = true;
			ps.AvailableItemsOnly = false; ps.AvailableItemsOnlySpecified = true;
			ps.QueryKeywords = "Nokia";
			StringCollection ids = new StringCollection();
			ids.Add("1785");
			ps.CharacteristicSetIDs = ids;
			// Pagination
			PaginationType pt = new PaginationType();
			pt.EntriesPerPage = 50; pt.EntriesPerPageSpecified = true;
			pt.PageNumber = 1; pt.PageNumberSpecified = true;
			ps.Pagination = pt;

			ProductSearchTypeCollection pstc = new ProductSearchTypeCollection();
			pstc.Add(ps);
			// Make API call.
			ProductSearchResultTypeCollection results = api.GetProductSearchResults(pstc);
			Assert.IsNotNull(results);
			Assert.IsTrue(results.Count > 0);
			TestData.ProductSearchResults = results;
			Assert.IsNotNull(TestData.ProductSearchResults);
			Assert.IsTrue(TestData.ProductSearchResults.Count > 0);
			
		}


		/// <summary>
		/// use isbn no of harry potter to search this book.
		/// </summary>
		[Test]
		public void GetProductSearchResultsFull()
		{
			bool isbnExisting=false;
			Int32Collection attributes=new Int32Collection();

			Assert.IsNotNull(TestData.ProductSearchPages2);
			Assert.Greater(TestData.ProductSearchPages2.Count,0);
			Assert.Greater(TestData.ProductSearchPages2[0].SearchCharacteristicsSet.Characteristics.Count,0);
			
			//check whether the call is success.
			Assert.AreEqual(string.Compare(TestData.Category2CS2.CategoryID,PSPACATEGORYID,true),0);
			CharacteristicsSetTypeCollection characteristics = TestData.Category2CS2.CharacteristicsSets;

			//confirm that the category was in the mapping category.
			Assert.IsNotNull(characteristics);
			Assert.Greater(characteristics.Count,0);

			foreach(CharacteristicsSetType characteristic in characteristics)
			{
				attributes.Add(characteristic.AttributeSetID);
			}


			//check the isbn-13 attribute id exists and its value has not been changed.
			CharacteristicTypeCollection chs = TestData.ProductSearchPages2[0].SearchCharacteristicsSet.Characteristics;
			foreach(CharacteristicType charactersic in chs)
			{
				//check whether the isbn attribute can be used
				if(charactersic.AttributeID==ISBN13ATTRIBUTEID && (string.Compare(charactersic.Label.Name,"ISBN-13",true)==0))
				{
					isbnExisting=true;
					break;
				}
			}

			Assert.IsTrue(isbnExisting,"the isbn attribute id is not existing or has been changed!");
			//using GetProductSearchResults call to find products.
			ProductSearchType productSearch=new ProductSearchType();
			productSearch.AttributeSetID=attributes[0];
			SearchAttributesTypeCollection searchAttributes=new SearchAttributesTypeCollection();
			SearchAttributesType searchAttribute=new SearchAttributesType();
			searchAttribute.AttributeID=ISBN13ATTRIBUTEID;
			ValTypeCollection vals=new ValTypeCollection();
			ValType val=new ValType();
			val.ValueLiteral=ISBN;
			vals.Add(val);
			searchAttribute.ValueList=vals;
			searchAttributes.Add(searchAttribute);
			productSearch.SearchAttributes=searchAttributes;
			GetProductSearchResultsCall searchResultsCall=new GetProductSearchResultsCall(this.apiContext);
			searchResultsCall.ProductSearchList=new ProductSearchTypeCollection(new ProductSearchType[]{productSearch});
			searchResultsCall.Execute();
			//check whether the call is success.
			Assert.IsTrue(searchResultsCall.ApiResponse.Ack==AckCodeType.Success || searchResultsCall.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.Greater(searchResultsCall.ApiResponse.ProductSearchResult.Count,0);
			Assert.AreEqual(int.Parse(searchResultsCall.ApiResponse.ProductSearchResult[0].NumProducts),1);
			Assert.Greater(searchResultsCall.ApiResponse.ProductSearchResult[0].AttributeSet.Count,0);
			Assert.Greater(searchResultsCall.ApiResponse.ProductSearchResult[0].AttributeSet[0].ProductFamilies.Count,0);
			Assert.IsFalse(searchResultsCall.ApiResponse.ProductSearchResult[0].AttributeSet[0].ProductFamilies[0].hasMoreChildren);
			Assert.IsNotNull(searchResultsCall.ApiResponse.ProductSearchResult[0].AttributeSet[0].ProductFamilies[0].ParentProduct.productID);
			TestData.ProductSearchResults2 = searchResultsCall.ApiResponse.ProductSearchResult;
		}
	}
}