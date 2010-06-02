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
	public class GetCategoryListingsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetCategoryListingsCall()
		{
			ApiRequest = new GetCategoryListingsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetCategoryListingsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetCategoryListingsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns items in a specified category, with the ability to filter the items
		/// in various ways.
		/// </summary>
		/// 
		/// <param name="MotorsGermanySearchable">
		/// Filters the response based on each item's eligibility to appear on the
		/// mobile.de site. If false, excludes eligible items from search results. If
		/// true, queries for eligible items only. If not specified, the search
		/// results are not affected. Only applicable for items listed on the eBay
		/// Germany site (site ID 77) in subcategories of mobile.de search-enabled
		/// categories.
		/// </param>
		///
		/// <param name="CategoryID">
		/// Specifies the category for which to retrieve item listings.
		/// </param>
		///
		/// <param name="AdFormat">
		/// Restricts listings to return only items that have the Ad Format feature.
		/// If true, the values of ItemTypeFilter and
		/// StoreSearchFilter are ignored (if they are specified). That is, "AND"
		/// logic is not applied.
		/// </param>
		///
		/// <param name="FreeShipping">
		/// If true, only items with free shipping for the user's location are
		/// returned. The user's location is determined from the site ID specified
		/// in the request. If false, no filtering is done via this attribute. A
		/// listing is not considered a free shipping listing if it requires
		/// insurance or requires pick up or requires a shipping surcharge.
		/// </param>
		///
		/// <param name="Currency">
		/// A currency value. Limits the result set to just those items listed
		/// using a specified currency. Not applicable to US eBay Motors searches.
		/// </param>
		///
		/// <param name="ItemTypeFilter">
		/// Filters items based on the ListingType set for the items.
		/// If ItemTypeFilter is not specified (or if the
		/// AllItemTypes value of ItemTypeFilter is specified), all listing types can
		/// be returned unless another relevant filter is specified.
		/// </param>
		///
		/// <param name="SearchType">
		/// Specifies whether to limit the item listings to just those that are
		/// category featured or super featured or all items.
		/// </param>
		///
		/// <param name="OrderBy">
		/// Specifies the order in which the item listings returned will be sorted.
		/// Store Inventory listings are usually returned after other listing types,
		/// regardless of the sort order.
		/// </param>
		///
		/// <param name="Pagination">
		/// Controls the pagination of the result set. Child elements specify the
		/// maximum number of item listings to return per call and which page of data
		/// to return.
		/// </param>
		///
		/// <param name="SearchLocation">
		/// Limits the result set to just those items that meet location criteria:
		/// listed in a specified eBay site, location where the seller has the item,
		/// location from which the user is searching, and/or items listed with a
		/// specified currency.
		/// </param>
		///
		/// <param name="ProximitySearch">
		/// Limits the result set to just those items that meet proximity search
		/// criteria: postal code and max distance.
		/// </param>
		///
		/// <param name="IncludeGetItFastItems">
		/// When passed with a value of true, limits the results to Get It Fast listings.
		/// </param>
		///
		/// <param name="PaymentMethod">
		/// Specifies items that accept a specific payment method or methods.
		/// </param>
		///
		/// <param name="IncludeCondition">
		/// If true, each item in the result set can also include the item
		/// condition (whether the item is new or used).
		/// The item's condition is returned in Item.AttributeSetArray.
		/// An item only includes condition attribute if the item's seller
		/// filled in the Item Condition in the Item Specifics section of the
		/// listing. (That is, the condition is not returned if the seller
		/// only put the word "New" in the listing's title.)
		/// </param>
		///
		/// <param name="IncludeFeedback">
		/// If true, each item in the result set also includes information about the
		/// seller's feedback.
		/// </param>
		///
		/// <param name="LocalSearchPostalCode">
		/// Include local items in returning results near this postal code. This
		/// postal code is the basis for local search.
		/// </param>
		///
		/// <param name="MaxRelatedSearchKeywords">
		/// The maximum number of related keywords to be retrieved.
		/// Use this field if you want the results to include
		/// recommended keywords (that is, keywords matching the category ID)
		/// in a RelatedSearchKeywordArray container.
		/// A value of 0 (the default) means no related search information is processed.
		/// </param>
		///
		/// <param name="Group">
		/// You can group Best Match search results by category. To group
		/// by category, put the BestMatchCategoryGroup value
		/// in the OrderBy field.
		/// When you use the BestMatchCategoryGroup value,
		/// you can include group
		/// parameters in your call. Note
		/// that there will be significanty fewer results returned with a BestMatchCategoryGroup sort because the results account
		/// for Best Matches in lower-level
		/// (leaf) as well as higher-level categories.
		/// There is not a direct correlation between the number of results returned in a regular sort or
		/// the number of results returned with a BestMatch sort, and the results that are returned by
		/// the BestMatchCategoryGroup sort. You should not receive more
		/// than 2 pages of results with
		/// this type of sort. See also
		/// the new GroupCategoryID element
		/// in ItemType.
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
		/// </param>
		///
		public ItemTypeCollection GetCategoryListings(bool MotorsGermanySearchable, string CategoryID, bool AdFormat, bool FreeShipping, CurrencyCodeType Currency, ItemTypeFilterCodeType ItemTypeFilter, CategoryListingsSearchCodeType SearchType, CategoryListingsOrderCodeType OrderBy, PaginationType Pagination, SearchLocationType SearchLocation, ProximitySearchType ProximitySearch, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, bool IncludeCondition, bool IncludeFeedback, string LocalSearchPostalCode, int MaxRelatedSearchKeywords, GroupType Group, bool HideDuplicateItems)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.CategoryID = CategoryID;
			this.AdFormat = AdFormat;
			this.FreeShipping = FreeShipping;
			this.Currency = Currency;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.OrderBy = OrderBy;
			this.Pagination = Pagination;
			this.SearchLocation = SearchLocation;
			this.ProximitySearch = ProximitySearch;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.LocalSearchPostalCode = LocalSearchPostalCode;
			this.MaxRelatedSearchKeywords = MaxRelatedSearchKeywords;
			this.Group = Group;
			this.HideDuplicateItems = HideDuplicateItems;

			Execute();
			return ApiResponse.ItemArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetCategoryListings(string CategoryID)
		{
			this.CategoryID = CategoryID;
			Execute();
			return ItemList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetCategoryListings(bool MotorsGermanySearchable, string CategoryID, CurrencyCodeType Currency, ItemTypeFilterCodeType ItemTypeFilter, CategoryListingsSearchCodeType SearchType, CategoryListingsOrderCodeType OrderBy, PaginationType Pagination, SearchLocationType SearchLocation, ProximitySearchType ProximitySearch, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, bool IncludeCondition, bool IncludeFeedback)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.CategoryID = CategoryID;
			this.Currency = Currency;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.OrderBy = OrderBy;
			this.Pagination = Pagination;
			this.SearchLocation = SearchLocation;
			this.ProximitySearch = ProximitySearch;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;

			Execute();
			return ApiResponse.ItemArray;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetCategoryListings(bool MotorsGermanySearchable, string CategoryID, bool AdFormat, CurrencyCodeType Currency, ItemTypeFilterCodeType ItemTypeFilter, bool StoresFixedPrice, CategoryListingsSearchCodeType SearchType, CategoryListingsOrderCodeType OrderBy, PaginationType Pagination, SearchLocationType SearchLocation, ProximitySearchType ProximitySearch, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, bool IncludeCondition, bool IncludeFeedback, string LocalSearchPostalCode)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.CategoryID = CategoryID;
			this.AdFormat = AdFormat;
			this.Currency = Currency;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.OrderBy = OrderBy;
			this.Pagination = Pagination;
			this.SearchLocation = SearchLocation;
			this.ProximitySearch = ProximitySearch;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.LocalSearchPostalCode = LocalSearchPostalCode;

			Execute();
			return ApiResponse.ItemArray;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		
		public ItemTypeCollection GetCategoryListings(bool MotorsGermanySearchable, string CategoryID, bool AdFormat, bool FreeShipping, CurrencyCodeType Currency, ItemTypeFilterCodeType ItemTypeFilter, bool StoresFixedPrice, CategoryListingsSearchCodeType SearchType, CategoryListingsOrderCodeType OrderBy, PaginationType Pagination, SearchLocationType SearchLocation, ProximitySearchType ProximitySearch, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, bool IncludeCondition, bool IncludeFeedback, string LocalSearchPostalCode)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.CategoryID = CategoryID;
			this.AdFormat = AdFormat;
			this.FreeShipping = FreeShipping;
			this.Currency = Currency;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.OrderBy = OrderBy;
			this.Pagination = Pagination;
			this.SearchLocation = SearchLocation;
			this.ProximitySearch = ProximitySearch;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.LocalSearchPostalCode = LocalSearchPostalCode;

			Execute();
			return ApiResponse.ItemArray;
		}

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetCategoryListings(bool MotorsGermanySearchable, string CategoryID, bool AdFormat, bool FreeShipping, CurrencyCodeType Currency, ItemTypeFilterCodeType ItemTypeFilter, CategoryListingsSearchCodeType SearchType, CategoryListingsOrderCodeType OrderBy, PaginationType Pagination, SearchLocationType SearchLocation, ProximitySearchType ProximitySearch, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, bool IncludeCondition, bool IncludeFeedback, string LocalSearchPostalCode, int MaxRelatedSearchKeywords)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.CategoryID = CategoryID;
			this.AdFormat = AdFormat;
			this.FreeShipping = FreeShipping;
			this.Currency = Currency;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.OrderBy = OrderBy;
			this.Pagination = Pagination;
			this.SearchLocation = SearchLocation;
			this.ProximitySearch = ProximitySearch;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.LocalSearchPostalCode = LocalSearchPostalCode;
			this.MaxRelatedSearchKeywords = MaxRelatedSearchKeywords;

			Execute();
			return ApiResponse.ItemArray;
		}

		/// <summary>
		/// For generic support . 
		/// </summary>
		public ItemTypeCollection GetCategoryListings(GetCategoryListingsRequestType request)
		{
			this.MotorsGermanySearchable = request.MotorsGermanySearchable;
			this.CategoryID = request.CategoryID;
			this.AdFormat = request.AdFormat;
			this.FreeShipping = request.FreeShipping;
			this.Currency = request.Currency;
			this.ItemTypeFilter = request.ItemTypeFilter;
			this.SearchType = request.SearchType;
			this.OrderBy = request.OrderBy;
			this.Pagination = request.Pagination;
			this.SearchLocation = request.SearchLocation;
			this.ProximitySearch = request.ProximitySearch;
			this.IncludeGetItFastItems = request.IncludeGetItFastItems;
			this.PaymentMethod = request.PaymentMethod;
			this.IncludeCondition = request.IncludeCondition;
			this.IncludeFeedback = request.IncludeFeedback;
			this.LocalSearchPostalCode = request.LocalSearchPostalCode;
			this.MaxRelatedSearchKeywords = request.MaxRelatedSearchKeywords;

			Execute();
			return ApiResponse.ItemArray;
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
		/// Gets or sets the <see cref="GetCategoryListingsRequestType"/> for this API call.
		/// </summary>
		public GetCategoryListingsRequestType ApiRequest
		{ 
			get { return (GetCategoryListingsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetCategoryListingsResponseType"/> for this API call.
		/// </summary>
		public GetCategoryListingsResponseType ApiResponse
		{ 
			get { return (GetCategoryListingsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.MotorsGermanySearchable"/> of type <see cref="bool"/>.
		/// </summary>
		public bool MotorsGermanySearchable
		{ 
			get { return ApiRequest.MotorsGermanySearchable; }
			set { ApiRequest.MotorsGermanySearchable = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.AdFormat"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AdFormat
		{ 
			get { return ApiRequest.AdFormat; }
			set { ApiRequest.AdFormat = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.FreeShipping"/> of type <see cref="bool"/>.
		/// </summary>
		public bool FreeShipping
		{ 
			get { return ApiRequest.FreeShipping; }
			set { ApiRequest.FreeShipping = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.Currency"/> of type <see cref="CurrencyCodeType"/>.
		/// </summary>
		public CurrencyCodeType Currency
		{ 
			get { return ApiRequest.Currency; }
			set { ApiRequest.Currency = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.ItemTypeFilter"/> of type <see cref="ItemTypeFilterCodeType"/>.
		/// </summary>
		public ItemTypeFilterCodeType ItemTypeFilter
		{ 
			get { return ApiRequest.ItemTypeFilter; }
			set { ApiRequest.ItemTypeFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.SearchType"/> of type <see cref="CategoryListingsSearchCodeType"/>.
		/// </summary>
		public CategoryListingsSearchCodeType SearchType
		{ 
			get { return ApiRequest.SearchType; }
			set { ApiRequest.SearchType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.OrderBy"/> of type <see cref="CategoryListingsOrderCodeType"/>.
		/// </summary>
		public CategoryListingsOrderCodeType OrderBy
		{ 
			get { return ApiRequest.OrderBy; }
			set { ApiRequest.OrderBy = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.SearchLocation"/> of type <see cref="SearchLocationType"/>.
		/// </summary>
		public SearchLocationType SearchLocation
		{ 
			get { return ApiRequest.SearchLocation; }
			set { ApiRequest.SearchLocation = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.ProximitySearch"/> of type <see cref="ProximitySearchType"/>.
		/// </summary>
		public ProximitySearchType ProximitySearch
		{ 
			get { return ApiRequest.ProximitySearch; }
			set { ApiRequest.ProximitySearch = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.IncludeGetItFastItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeGetItFastItems
		{ 
			get { return ApiRequest.IncludeGetItFastItems; }
			set { ApiRequest.IncludeGetItFastItems = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.PaymentMethod"/> of type <see cref="PaymentMethodSearchCodeType"/>.
		/// </summary>
		public PaymentMethodSearchCodeType PaymentMethod
		{ 
			get { return ApiRequest.PaymentMethod; }
			set { ApiRequest.PaymentMethod = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.IncludeCondition"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeCondition
		{ 
			get { return ApiRequest.IncludeCondition; }
			set { ApiRequest.IncludeCondition = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.IncludeFeedback"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFeedback
		{ 
			get { return ApiRequest.IncludeFeedback; }
			set { ApiRequest.IncludeFeedback = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.LocalSearchPostalCode"/> of type <see cref="string"/>.
		/// </summary>
		public string LocalSearchPostalCode
		{ 
			get { return ApiRequest.LocalSearchPostalCode; }
			set { ApiRequest.LocalSearchPostalCode = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.MaxRelatedSearchKeywords"/> of type <see cref="int"/>.
		/// </summary>
		public int MaxRelatedSearchKeywords
		{ 
			get { return ApiRequest.MaxRelatedSearchKeywords; }
			set { ApiRequest.MaxRelatedSearchKeywords = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.Group"/> of type <see cref="GroupType"/>.
		/// </summary>
		public GroupType Group
		{ 
			get { return ApiRequest.Group; }
			set { ApiRequest.Group = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryListingsRequestType.HideDuplicateItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HideDuplicateItems
		{ 
			get { return ApiRequest.HideDuplicateItems; }
			set { ApiRequest.HideDuplicateItems = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.ItemArray"/> of type <see cref="ItemTypeCollection"/>.
		/// </summary>
		public ItemTypeCollection ItemList
		{ 
			get { return ApiResponse.ItemArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.SubCategories"/> of type <see cref="CategoryTypeCollection"/>.
		/// </summary>
		public CategoryTypeCollection SubCategoryList
		{ 
			get { return ApiResponse.SubCategories; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.ItemsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int ItemsPerPage
		{ 
			get { return ApiResponse.ItemsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.HasMoreItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreItems
		{ 
			get { return ApiResponse.HasMoreItems; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.BuyingGuideDetails"/> of type <see cref="BuyingGuideDetailsType"/>.
		/// </summary>
		public BuyingGuideDetailsType BuyingGuideDetails
		{ 
			get { return ApiResponse.BuyingGuideDetails; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.RelatedSearchKeywordArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection RelatedSearchKeywordList
		{ 
			get { return ApiResponse.RelatedSearchKeywordArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryListingsResponseType.DuplicateItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool DuplicateItems
		{ 
			get { return ApiResponse.DuplicateItems; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		public CategoryType Category
		{ 
			get { return ApiResponse.Category; }
		}


		#endregion

		
	}
}
