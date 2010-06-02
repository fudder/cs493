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
	public class GetProductsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetProductsCall()
		{
			ApiRequest = new GetProductsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetProductsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetProductsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Searches for stock information and reviews for certain kinds of products,
		/// such as a particular digital camera model.
		/// <p>
		/// GetProducts is designed to be useful to applications that support
		/// shopping comparison, product reviews, or basic supply and
		/// demand data.
		/// </p>
		/// <p>
		/// GetProducts also supports tracking so that members of the
		/// eBay Affiliates Program can get commissions for driving traffic to eBay.
		/// </p>
		/// <p class="tablenote"><b>Note:</b>
		/// For selling use cases, use GetProductSearchResults and
		/// GetProductSellingPages instead.
		/// </p>
		/// <p>
		/// To use this call, you typically pass in keywords, and GetProducts finds
		/// products with matching words in the product title, description, and/or
		/// Item Specifics.
		/// <p>
		/// For each product of interest, you call GetProducts again to retrieve
		/// additional details that would be useful to buyers:
		/// </p>
		/// <ul>
		/// <li>Top reviews of the product by eBay members,
		/// including part of the review text, plus links to the full text on the
		/// eBay Web site.</li>
		/// <li>Relevant buying guides (shopping advice) written by
		/// eBay members and by eBay staff, including part of the guide text,
		/// plus links to the full text
		/// on the eBay Web site.</li>
		/// <li>Up to 200 matching items on eBay (if any). (To find more matching
		/// items, use GetSearchResults.)</li>
		/// </ul>
		/// <p>
		/// <span class="tablenote"><b>Note:</b>
		/// As catalog queries can take longer than item queries,
		/// GetProducts can be slower than GetSearchResults.
		/// Also, due to the way product data is cached, you may get a faster response
		/// when you run the same query a second time.</span>
		/// </summary>
		/// 
		/// <param name="ProductSearch">
		/// Contains the fields that form the search query. You can query
		/// against keywords, an eBay product reference ID (not to be confused
		/// with an eBay product ID), or external product ID (like an ISBN).
		/// </param>
		///
		/// <param name="ProductSort">
		/// Sorts the list of products returned. This is mostly only useful
		/// with QueryKeywords. (When you use ExternalProductID or
		/// ProductReferenceID, eBay usually only returns one product.)
		/// </param>
		///
		/// <param name="IncludeItemArray">
		/// If true, the response includes items (if any) that match the
		/// product specified in ExternalProductID or ProductReferenceID.
		/// Not applicable with QueryKeywords.
		/// </param>
		///
		/// <param name="IncludeReviewDetails">
		/// If true, the response includes up to 20 reviews (if any)
		/// for the product specified in ExternalProductID or
		/// ProductReferenceID.
		/// The reviews are sorted by most helpful (most votes) first.
		/// When you include review details, please note that
		/// response times may be longer than 60 seconds.
		/// Not applicable with QueryKeywords.
		/// </param>
		///
		/// <param name="IncludeBuyingGuideDetails">
		/// If true, the response includes up to 5 buying guides (if any)
		/// for the product specified in ExternalProductID or
		/// ProductReferenceID.
		/// Not applicable with QueryKeywords.
		/// </param>
		///
		/// <param name="IncludeHistogram">
		/// If true, the response includes a histogram that lists the
		/// number of matching products found and the domains in which
		/// they were found. (A domain is like a high-level category.)
		/// Including the histogram can affect the call's performance.
		/// You may see significantly slower response times when many
		/// matching products are found.
		/// </param>
		///
		/// <param name="AffiliateTrackingDetails">
		/// See the
		/// <a href="https://www.ebaypartnernetwork.com/" target="_blank">eBay Partner Network</a>.
		/// eBay uses the values in AffiliateTrackingDetails to build a View Item URL
		/// string, in order to include that string in the response.
		/// When a user clicks through the URL to eBay,
		/// you may get a commission (see the URL above).
		/// Only applicable when IncludeItemArray is specified
		/// (because the View Item URL is only returned in item information,
		/// not in product information).
		/// </param>
		///
		/// <param name="HideDuplicateItems">
		/// Specifies whether or not to remove duplicate items from search results.
		/// When set to true, and there are duplicate items for an item in the
		/// search results, the subsequent duplicates will not appear in the
		/// results.
		/// Item listings are considered duplicates in the following
		/// conditions: 
		/// <ul>
		/// <li>Items are listed by the same seller</li>
		/// <li>Items have exactly the same item title</li>
		/// <li>Items have similar listing formats</li>
		/// <ul>
		/// <li>Auctions: Auction Items, Auction BIN items, Multi-Quantity
		/// Auctions, and Multi-Quantity Auctions BIN items</li>
		/// <li>Fixed Price: Fixed Price, Multi-quantity Fixed Price, Fixed
		/// Price with Best Offer, and Store Inventory Format items</li>
		/// <li>Classified Ads</li>
		/// </ul>
		/// </ul>
		/// For Auctions, items must also have the same price and number of bids to
		/// be considered duplicates.
		/// 
		/// Filtering of duplicate item listings is not supported on all sites.
		/// For GetProducts, this filter only works when IncludeItemArray is set to
		/// true.
		/// </param>
		///
		public CharacteristicsSetProductHistogramType GetProducts(ProductSearchType ProductSearch, ProductSortCodeType ProductSort, bool IncludeItemArray, bool IncludeReviewDetails, bool IncludeBuyingGuideDetails, bool IncludeHistogram, AffiliateTrackingDetailsType AffiliateTrackingDetails, bool HideDuplicateItems)
		{
			this.ProductSearch = ProductSearch;
			this.ProductSort = ProductSort;
			this.IncludeItemArray = IncludeItemArray;
			this.IncludeReviewDetails = IncludeReviewDetails;
			this.IncludeBuyingGuideDetails = IncludeBuyingGuideDetails;
			this.IncludeHistogram = IncludeHistogram;
			this.AffiliateTrackingDetails = AffiliateTrackingDetails;
			this.HideDuplicateItems = HideDuplicateItems;

			Execute();
			return ApiResponse.CharacteristicsSetProductHistogram;
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
		/// Gets or sets the <see cref="GetProductsRequestType"/> for this API call.
		/// </summary>
		public GetProductsRequestType ApiRequest
		{ 
			get { return (GetProductsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetProductsResponseType"/> for this API call.
		/// </summary>
		public GetProductsResponseType ApiResponse
		{ 
			get { return (GetProductsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.ProductSearch"/> of type <see cref="ProductSearchType"/>.
		/// </summary>
		public ProductSearchType ProductSearch
		{ 
			get { return ApiRequest.ProductSearch; }
			set { ApiRequest.ProductSearch = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.ProductSort"/> of type <see cref="ProductSortCodeType"/>.
		/// </summary>
		public ProductSortCodeType ProductSort
		{ 
			get { return ApiRequest.ProductSort; }
			set { ApiRequest.ProductSort = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.IncludeItemArray"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeItemArray
		{ 
			get { return ApiRequest.IncludeItemArray; }
			set { ApiRequest.IncludeItemArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.IncludeReviewDetails"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeReviewDetails
		{ 
			get { return ApiRequest.IncludeReviewDetails; }
			set { ApiRequest.IncludeReviewDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.IncludeBuyingGuideDetails"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeBuyingGuideDetails
		{ 
			get { return ApiRequest.IncludeBuyingGuideDetails; }
			set { ApiRequest.IncludeBuyingGuideDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.IncludeHistogram"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeHistogram
		{ 
			get { return ApiRequest.IncludeHistogram; }
			set { ApiRequest.IncludeHistogram = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.AffiliateTrackingDetails"/> of type <see cref="AffiliateTrackingDetailsType"/>.
		/// </summary>
		public AffiliateTrackingDetailsType AffiliateTrackingDetails
		{ 
			get { return ApiRequest.AffiliateTrackingDetails; }
			set { ApiRequest.AffiliateTrackingDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductsRequestType.HideDuplicateItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HideDuplicateItems
		{ 
			get { return ApiRequest.HideDuplicateItems; }
			set { ApiRequest.HideDuplicateItems = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.CharacteristicsSetProductHistogram"/> of type <see cref="CharacteristicsSetProductHistogramType"/>.
		/// </summary>
		public CharacteristicsSetProductHistogramType CharacteristicsSetProductHistogram
		{ 
			get { return ApiResponse.CharacteristicsSetProductHistogram; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.ApproximatePages"/> of type <see cref="int"/>.
		/// </summary>
		public int ApproximatePages
		{ 
			get { return ApiResponse.ApproximatePages; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.HasMore"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMore
		{ 
			get { return ApiResponse.HasMore; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.TotalProducts"/> of type <see cref="int"/>.
		/// </summary>
		public int TotalProducts
		{ 
			get { return ApiResponse.TotalProducts; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.Product"/> of type <see cref="CatalogProductTypeCollection"/>.
		/// </summary>
		public CatalogProductTypeCollection ProductList
		{ 
			get { return ApiResponse.Product; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.ItemArray"/> of type <see cref="ItemTypeCollection"/>.
		/// </summary>
		public ItemTypeCollection ItemList
		{ 
			get { return ApiResponse.ItemArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.BuyingGuideDetails"/> of type <see cref="BuyingGuideDetailsType"/>.
		/// </summary>
		public BuyingGuideDetailsType BuyingGuideDetails
		{ 
			get { return ApiResponse.BuyingGuideDetails; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductsResponseType.DuplicateItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool DuplicateItems
		{ 
			get { return ApiResponse.DuplicateItems; }
		}
		

		#endregion

		
	}
}
