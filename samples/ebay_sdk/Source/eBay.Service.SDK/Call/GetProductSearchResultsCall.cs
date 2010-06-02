#region Copyright
//	Copyright (c) 2008, 2009 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion

#region Namespaces
using System;
using System.Runtime.InteropServices;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using eBay.Service.Util;
#endregion

namespace eBay.Service.Call
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class GetProductSearchResultsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetProductSearchResultsCall()
		{
			ApiRequest = new GetProductSearchResultsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetProductSearchResultsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetProductSearchResultsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Searches for Pre-filled Item Information within one or more characteristic sets.
		/// This kind of search is only applicable in the context of the Sell Your Item use
		/// case. Use the response to present the seller with a list of products found in a
		/// catalog. (For buy-side searches, use GetSearchResults.)
		/// 
		/// See the Attributes and Catalogs section of the eBay Web Services guide for
		/// background information and terminology definitions, as well as information about
		/// how to use this call in the Sell Your Item flow.
		/// 
		/// You can use this call to search for different products at the same time. That is,
		/// this call can perform batch searches.
		/// 
		/// Given an array of ProductSearch properties that are configured with a list of
		/// search attributes or keywords (and other information), GetProductSearchResults
		/// searches an eBay catalog for products that match each query. Some queries can be
		/// configured to also specify a sort order for the results.
		/// 
		/// To configure a ProductSearch object to search by attributes, you need a valid
		/// combination of search attributes. If you want to use a sort order other than the
		/// default order, you also need a valid sort attribute. We offer two calls that
		/// return product search and sort attributes. Use GetCategory2CS to determine which
		/// one of these calls you can use for a given category. At least one approach is
		/// offered for each catalog-enabled category, and some cases, both are
		/// offered.
		/// 
		/// <b>GetProductSearchPage</b>: Use this call when you want to configure
		/// a simple query that consists of a single search attribute (with a value). This
		/// retrieves a single product or a very short list of search results to choose from.
		/// Some products are fairly easy to find based on a single attribute. For example, in
		/// Consumer Electronics categories (Digital Cameras, Cell Phones, and PDAs), you can
		/// specify a unique (or nearly unique) identifier, like a part number. In Media
		/// categories (Books, DVDs &amp; Movies, Music, and Video Games), you can specify a
		/// descriptive name, like a title. 
		/// 
		/// <b>GetProductFinder</b>: Use this call when you want to configure a
		/// complex query. In the Sell Your Item flow, this is a complex query against the
		/// eBay product catalog. Currently, this type of search is available in Consumer
		/// Electronics categories only. In this type of search, you specify values for
		/// multiple attributes, like Brand and Resolution (i.e., number of megapixels). This
		/// retrieves a list of matching products. This approach is useful when the user does
		/// not know the part number, or a product does not have a single, distinguishing
		/// feature that is easy to search on. For example, searching for a digital camera
		/// based solely on the brand would likely yield far too many results to be useful.
		/// Searching on the brand, product line, and resolution will retrieve a much shorter
		/// list of results. 
		/// 
		/// Alternatively, you can search on a particular keyword that appears in a product's
		/// title or Item Specifics. For this, you use GetProductSearchResults and and pass in
		/// one or more text strings (with optional wildcards) in ProductSearch.QueryKeywords.
		/// 
		/// 
		/// When you use a keyword query, the search criteria are not restricted to the
		/// results of a product search page or product finder, so the criteria are not tied
		/// to a particular characteristic set. This means you can search across multiple
		/// characteristic sets using the same query. This is useful when the user wants to
		/// broaden their search across multiple categories. For example, a seller who sells
		/// Jazz books, Jazz CDs, and Jazz movies may want to search for "Bird" across
		/// multiple categories. Specify the characteristic set IDs of interest by using
		/// CharacteristicSetIDs. 
		/// 
		/// GetProductSearchResults returns a list of matching products, if any. Each product
		/// is represented as a list of attributes (Item Specifics) plus other identifying
		/// information, such as a product ID and a stock photo. 
		/// 
		/// Once the user selects a product from the list (this may require a call to
		/// GetProductFamilyMembers to retrieve additional products to choose from), pass its
		/// ID in a GetProductSellingPages request to retrieve more detailed information about
		/// each product, including a set of optional Item Specifics that the seller can use
		/// in addition to the pre-filled Item Specifics (see GetProductSellingPages).
		/// 
		/// 
		/// To use this data in a listing, pass the product ID and the optional Item Specifics
		/// in the seller's listing request (AddItem).
		/// </summary>
		/// 
		/// <param name="ProductSearchList">
		/// Specifies the keywords or attributes that make up the product query, with
		/// pagination instructions. ProductSearch is a required input. To search for
		/// multiple different products at the same time (i.e., to perform a batch
		/// search), pass in multiple ProductSearch properties.
		/// </param>
		///
		public ProductSearchResultTypeCollection GetProductSearchResults(ProductSearchTypeCollection ProductSearchList)
		{
			this.ProductSearchList = ProductSearchList;

			Execute();
			return ApiResponse.ProductSearchResult;
		}



		#endregion




		#region Properties
		/// <summary>
		/// The base interface object.
		/// </summary>
		/// <remarks>This property is reserved for users who have difficulty querying multiple interfaces.</remarks>
		public ApiCall ApiCallBase
		{
			get { return this; }
		}

		/// <summary>
		/// Gets or sets the <see cref="GetProductSearchResultsRequestType"/> for this API call.
		/// </summary>
		public GetProductSearchResultsRequestType ApiRequest
		{ 
			get { return (GetProductSearchResultsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetProductSearchResultsResponseType"/> for this API call.
		/// </summary>
		public GetProductSearchResultsResponseType ApiResponse
		{ 
			get { return (GetProductSearchResultsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductSearchResultsRequestType.ProductSearch"/> of type <see cref="ProductSearchTypeCollection"/>.
		/// </summary>
		public ProductSearchTypeCollection ProductSearchList
		{ 
			get { return ApiRequest.ProductSearch; }
			set { ApiRequest.ProductSearch = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductSearchResultsResponseType.DataElementSets"/> of type <see cref="DataElementSetTypeCollection"/>.
		/// </summary>
		public DataElementSetTypeCollection DataElementSetList
		{ 
			get { return ApiResponse.DataElementSets; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductSearchResultsResponseType.ProductSearchResult"/> of type <see cref="ProductSearchResultTypeCollection"/>.
		/// </summary>
		public ProductSearchResultTypeCollection ProductSearchResultList
		{ 
			get { return ApiResponse.ProductSearchResult; }
		}
		

		#endregion

		
	}
}
