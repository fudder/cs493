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
	public class GetSearchResultsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSearchResultsCall()
		{
			ApiRequest = new GetSearchResultsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSearchResultsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSearchResultsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves item listings based on keywords you specify. The keywords can
		/// include wildcards.
		/// </summary>
		/// 
		/// <param name="MotorsGermanySearchable">
		/// Limits the results based on each item's eligibility to appear on the
		/// mobile.de site. If false, excludes eligible items from search results. If
		/// true, queries for eligible items only. If not specified, the search
		/// results are not affected. Only applicable for items listed on the eBay
		/// Germany site (site ID 77) in subcategories of mobile.de search-enabled
		/// categories.
		/// </param>
		///
		/// <param name="Query">
		/// A query that specifies a search string. The search string consists of one or more
		/// keywords to search for in the listing title and/or description.
		/// The words "and" and "or" are treated like any other word. Only use "and",
		/// "or", or "the" if you are searching for listings containing these words.
		/// You can use AND or OR logic by including certain modifiers.
		/// Wildcards (e.g., *) are also supported. Be careful when using spaces before
		/// or after modifiers and wildcards (+, -, or *). See the
		/// eBay Web Services Guide	for a list of valid modifiers and examples.
		/// Query is not applicable in combination with ExternalProductID or ProductID.
		/// </param>
		///
		/// <param name="CategoryID">
		/// Limits the result set to items in the specified category.
		/// If no category ID is specified, all categories
		/// are searched by default.
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// CategoryID does not control whether you will see the
		/// item's categories in the response. Set the value of DetailLevel to
		/// ItemReturnCategories to retrieve each item's primary category and
		/// secondary category (if any) in the response.</span>
		/// 
		/// If the specified category ID doesn't match an existing category
		/// for the site, an invalid-category error message is returned.
		/// Here are a few ways to determine valid categories:
		/// - Use the Categories input field to retrieve
		/// matching categories, and then submit the request again with one of
		/// those categories.
		/// - Find items in all categories but set DetailLevel to
		/// ItemReturnCategories, determine the primary (or secondary)
		/// category ID for a similar item in the results, and then
		/// submit the request again with that category ID.
		/// - Use another call like GetCategories or GetSuggestedCategories to
		/// find a valid category ID.
		/// 
		/// You must pass ProductID, Query, ExternalProductID, or CategoryID
		/// in the request. CategoryID can be used in combination with Query.
		/// It is not allowed with ExternalProductID or ProductID.
		/// If you pass CategoryID without Query, it
		/// must specify a leaf category ID. That is, it cannot be a
		/// meta-category ID (e.g., 267 for "Books").
		/// </param>
		///
		/// <param name="SearchFlagsList">
		/// Secondary search criterion that checks item descriptions for keywords that
		/// match the query, limits the search results to only charity items, limits
		/// the result set to those items with PayPal as a payment method, and/or
		/// provides other criteria to refine the search.
		/// </param>
		///
		/// <param name="PriceRangeFilter">
		/// Limits the result set to just those items where the price is within the
		/// specified range. The PriceRangeFilterType includes a minimum and a maximum
		/// price.
		/// </param>
		///
		/// <param name="ProximitySearch">
		/// Limits the result set to just those items whose location is within a
		/// specified distance of a postal code. The ProximitySearchType includes
		/// a maximum distance and a postal code.
		/// </param>
		///
		/// <param name="ItemTypeFilter">
		/// Filters items based on the ListingType set for the items.
		/// If ItemTypeFilter is not
		/// specified (or if the AllItemTypes value of ItemTypeFilter is specified),
		/// all listing types can be returned unless another relevant filter is
		/// specified.
		/// </param>
		///
		/// <param name="SearchType">
		/// Limits the listings in the result set based on whether they are in the
		/// Gallery. The choices are items in the Gallery or Gallery and non-Gallery
		/// items.
		/// </param>
		///
		/// <param name="UserIdFilter">
		/// Limits the the result set to just those items listed by one or more
		/// specified sellers or those items not listed by the one or more specified
		/// sellers.
		/// </param>
		///
		/// <param name="SearchLocationFilter">
		/// Limits the result set to just those items that meet location criteria:
		/// listed in a specified eBay site, location where the seller has the item,
		/// location from which the user is searching, and/or items listed with a
		/// specified currency.
		/// </param>
		///
		/// <param name="StoreSearchFilter">
		/// Limits the result set to just those items that meet criteria related to
		/// eBay Stores sellers and eBay Stores. Use this to retrieve items listed in
		/// a particular seller's eBay Store or in all store sellers' eBay Stores.
		/// This filter always causes item description text to be searched with the
		/// string specified in the Query field. That is, StoreSearchFilter
		/// forces the type of search that would have occurred if you had specified
		/// SearchInDescription in the SearchFlags field.
		/// </param>
		///
		/// <param name="Order">
		/// Specifies the order in which listings are returned in a result set.
		/// Listings may be sorted by end time, start time, and in other ways listed
		/// in the SearchSortOrderCodeType. Controls the way the listings are
		/// organized in the response (not the details to return for each listing).
		/// For most sites, the default sort order is by items ending soonest. Store
		/// Inventory listings are usually returned after other listing types,
		/// regardless of the sort order.
		/// </param>
		///
		/// <param name="Pagination">
		/// Controls the pagination of the result set. Child elements specify the
		/// maximum number of item listings to return per call and which page of data
		/// to return. Controls the way the listings are organized in the response
		/// (not the details to return for each listing).
		/// </param>
		///
		/// <param name="SearchRequest">
		/// A query consisting of a set of attributes (Item Specifics). Use this kind
		/// of query to search against the Item Specifics in listings (e.g., to search
		/// for a particular shoe size). If the query includes multiple attributes,
		/// the search engine will apply "AND" logic to the query and narrow the
		/// results. Use GetProductFinder to determine the list of valid attributes
		/// and how many are permitted for the specified characteristic set. Retrieves
		/// items along with any buying guide details that are associated with the
		/// specified product finder. Applicable in combination with the Query
		/// argument. Cannot be used in combination with ProductID or
		/// ExternalProductID.
		/// 
		/// If you are searching for tickets, see TicketFinder instead.
		/// </param>
		///
		/// <param name="ProductID">
		/// An exclusive query to retrieve items that were listed with the specified
		/// eBay catalog product. You must pass ProductID, Query, ExternalProductID,
		/// or CategoryID in the request. If you use ProductID, do not use Query,
		/// ExternalProductID, or CategoryID.
		/// 
		/// Some sites (such as eBay US, Germany, Austria, and Switzerland) are updating,
		/// replacing, deleting, or merging some products (as a result of migrating from one
		/// catalog data provider to another). If you specify one of these products, the call may
		/// return a warning, or it may return an error if the product has been deleted.
		/// </param>
		///
		/// <param name="ExternalProductID">
		/// An exclusive query to only retrieve items that were listed with the
		/// specified ISBN or UPC. Only applicable for items that were listed with
		/// Pre-filled Item Information in media categories (Books, Music, DVDs and
		/// Movies, and Video Games). You must pass ProductID, Query,
		/// ExternalProductID, or CategoryID in the request. If you use
		/// ExternalProductID, do not use Query, ProductID, or CategoryID.
		/// </param>
		///
		/// <param name="Categories">
		/// Retrieves statistical (histogram) information about categories that contain items
		/// that match the query. Can also cause the result to include information
		/// about buying guides that are associated with the matching categories.
		/// Does not control the set of listings to return or the details to return
		/// for each listing.
		/// </param>
		///
		/// <param name="TotalOnly">
		/// Retrieves the total quantity of matching items, without returning the item
		/// data. See PaginationResult.TotalNumberOfEntries in the response. If
		/// TotalOnly and Categories.CategoriesOnly are both specified in the request
		/// and their values are inconsistent with each other, TotalOnly overrides
		/// Categories.CategoriesOnly. That is, if TotalOnly is true and
		/// Categories.CategoriesOnly is false, the results include matching
		/// categories but no item data or buying guides. If TotalOnly is false and
		/// Categories.CategoriesOnly is true, the results include matching
		/// categories, item data, and buying guides. If TotalOnly is not specified,
		/// it has no logical effect.
		/// </param>
		///
		/// <param name="EndTimeFrom">
		/// Limits the results to items ending within a time range. EndTimeFrom
		/// specifies the beginning of the time range. Specify a time in the future.
		/// If you specify a time in the past, the current time is used. If specified,
		/// EndTimeTo must also be specified (with a value equal to or later than
		/// EndTimeFrom). Specify the time in GMT. Cannot be used with the ModTimeFrom
		/// filter.
		/// </param>
		///
		/// <param name="EndTimeTo">
		/// Limits the results to items ending within a time range. EndTimeTo specifies
		/// the end of the time range. If specified, EndTimeFrom must also be specified
		/// (with a value equal to or earlier than EndTimeTo). Specify the time in GMT.
		/// Cannot be used with the ModTimeFrom filter.
		/// </param>
		///
		/// <param name="ModTimeFrom">
		/// Limits the results to active items whose status has changed
		/// since the specified time. Specify a time in the past.
		/// Time must be in GMT. Cannot be used with the EndTime filters.
		/// </param>
		///
		/// <param name="IncludeGetItFastItems">
		/// When passed with a value of true, limits the results to Get It Fast listings.
		/// </param>
		///
		/// <param name="PaymentMethod">
		/// Limits the results to items that accept a specific payment method or methods.
		/// </param>
		///
		/// <param name="GranularityLevel">
		/// Optional tag that currently accepts only one value for this call: Coarse.
		/// Other values return an error. If you specify Coarse, the call
		/// returns the fields shown in the
		/// <a href="#GranularityLevel">GranularityLevel table</a>
		/// plus any tags resulting from the detail level you specify.
		/// Controls the fields to return for each listing (not the set of
		/// listings that match the query).
		/// </param>
		///
		/// <param name="ExpandSearch">
		/// Expands search results when a small result set is returned. For example,
		/// on the US site (site ID 0), if a search would normally result in fewer
		/// than 10 items, then if you specify true for this tag, the search results
		/// are expanded. Specifically, the search returns items (if there are
		/// matches) in one or more of the following containers:
		/// InternationalExpansionArray (for items available from international
		/// sellers), FilterRemovedExpansionArray (items that would be returned if
		/// filters such as PriceRangeFilter are removed), StoreExpansionArray (for
		/// items listed in the Store Inventory Format), and
		/// AllCategoriesExpansionArray (for items available if category filters are
		/// removed). Maximum number of items returned in each expansion container is
		/// 6 to 10.
		/// </param>
		///
		/// <param name="Lot">
		/// Limits the results to only those listings for which Item.LotSize is 2 or greater.
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
		/// <param name="Quantity">
		/// Limits the results to listings that offer a certain number of items
		/// matching the query. If Lot is also specified, then Quantity is the number
		/// of lots multiplied by the number of objects in each lot. Use
		/// QuantityOperator to specify that you are seeking listings with quantities
		/// greater than, equal to, or less than Quantity.
		/// </param>
		///
		/// <param name="QuantityOperator">
		/// Limits the results to listings with quantities greater than, equal to, or
		/// less than Quantity. Controls the set of listings to return (not the
		/// details to return for each listing).
		/// </param>
		///
		/// <param name="SellerBusinessType">
		/// Limits the results to those of a particular seller business type such as
		/// commercial or private. Applies only to the following sites: UK, France, and Germany.
		/// </param>
		///
		/// <param name="IncludeCondition">
		/// If true, each item in the result set can also
		/// include the item condition (e.g., New or Used) in the
		/// ItemSpecific property of the response. An item only includes
		/// the condition in the response if the seller filled in the
		/// Item Condition in the Item Specifics section of the listing.
		/// (That is, the condition is not returned if the seller
		/// only put the word "New" in the listing's title.) 
		/// 
		/// Controls the details to return for each listing (not the set of
		/// listings that match the query). 
		/// To control whether to retrieve only new or used items,
		/// see ItemCondition (or SearchRequest).
		/// </param>
		///
		/// <param name="IncludeFeedback">
		/// If true, each item in the result set also includes information about the
		/// seller's feedback. Controls the details to return for each listing (not
		/// the set of listings that match the query).
		/// 
		/// For GetSearchResults, if set to true will also return the seller's User ID.
		/// </param>
		///
		/// <param name="CharityID">
		/// Restricts listings to return only items that support the specified
		/// nonprofit charity organization. Retrieve CharityID values with
		/// GetCharities.
		/// </param>
		///
		/// <param name="LocalSearchPostalCode">
		/// Include local items in returning results near this postal code. This
		/// postal code is the basis for local search.
		/// </param>
		///
		/// <param name="MaxRelatedSearchKeywords">
		/// The maximum number of related keywords to be retrieved.
		/// Use this field if you want the search results to include
		/// recommended keywords (that is, keywords matching one or more of the
		/// original keywords) in a RelatedSearchKeywordArray container.
		/// A value of 0 (the default) means no related search information is processed.
		/// </param>
		///
		/// <param name="AffiliateTrackingDetails">
		/// Container for affiliate tags.
		/// If you use affiliate tags, it is possible to get affiliate commissions
		/// based on calls made by your application.
		/// (See the <a href="https://www.ebaypartnernetwork.com/" target="_blank">eBay Partner Network</a>
		/// for information about commissions.)
		/// Affiliate tags enable the tracking of user activity.
		/// You can use child tags of AffiliateTrackingDetails if you want
		/// call output to include a string that includes
		/// affiliate tracking information.
		/// </param>
		///
		/// <param name="BidRange">
		/// Limits the results to items with a minimum or maximum number
		/// of bids. You also can specify a bid range by specifying
		/// both a minimum and maximum number of bids in one call.
		/// </param>
		///
		/// <param name="ItemCondition">
		/// Limits the results to new or used items, plus items that have no
		/// condition specified.
		/// 
		/// Matches the new or used condition that the seller specified
		/// in the Item Specifics section of the listing.
		/// (That is, this won't specifically match on items where the seller
		/// only put the word "New" in the listing's title.)
		/// 
		/// Only applicable to sites and categories that support a
		/// sitewide (global) item condition. For example, the US site
		/// does not currently support this. See GetCategory2CS.
		/// To search for the item condition on the US site,
		/// use a product finder instead (see SearchRequest).
		/// </param>
		///
		/// <param name="TicketFinder">
		/// Searches for event ticket listings only. If specified, this cannot be empty.
		/// For example, to search for all tickets (with no event, date, city, or quantity constraints),
		/// specify EventType with a value of Any.
		/// If specified, Query is optional. Query is useful when the user wants to search
		/// for a particular event name (like "eric clapton") or a venue that might be
		/// included in the listing title.
		/// If TicketFinder and SearchRequest are both specified in the same request,
		/// SearchRequest is ignored.
		/// </param>
		///
		/// <param name="Group">
		/// You can group Best Match search results by category by specifying BestMatchCategoryGroup
		/// in the Order field. When you specify BestMatchCategoryGroup
		/// in the Order field, you can also specify Group.MaxEntriesPerGroup and/or Group.MaxGroups.
		/// When you specify BestMatchCategoryGroup
		/// in the Order field, there will be fewer results returned because Best Matches
		/// in lower-level (leaf) categories and higher-level categories are taken into account.
		/// There is not a direct correlation between the number of items returned in a 
		/// regular sort (or in a BestMatch sort) and the number of items that are returned 
		/// when you specify BestMatchCategoryGroup in the Order field.
		/// When you specify BestMatchCategoryGroup
		/// in the Order field, not more than 2 pages of results are returned.
		/// See also the GroupCategoryID element in ItemType.
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
		public SearchResultItemTypeCollection GetSearchResults(bool MotorsGermanySearchable, string Query, string CategoryID, SearchFlagsCodeTypeCollection SearchFlagsList, PriceRangeFilterType PriceRangeFilter, ProximitySearchType ProximitySearch, ItemTypeFilterCodeType ItemTypeFilter, SearchTypeCodeType SearchType, UserIdFilterType UserIdFilter, SearchLocationFilterType SearchLocationFilter, SearchStoreFilterType StoreSearchFilter, SearchSortOrderCodeType Order, PaginationType Pagination, SearchRequestType SearchRequest, string ProductID, ExternalProductIDType ExternalProductID, RequestCategoriesType Categories, bool TotalOnly, DateTime EndTimeFrom, DateTime EndTimeTo, DateTime ModTimeFrom, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, GranularityLevelCodeType GranularityLevel, bool ExpandSearch, bool Lot, bool AdFormat, bool FreeShipping, int Quantity, QuantityOperatorCodeType QuantityOperator, SellerBusinessCodeType SellerBusinessType, bool IncludeCondition, bool IncludeFeedback, int CharityID, string LocalSearchPostalCode, int MaxRelatedSearchKeywords, AffiliateTrackingDetailsType AffiliateTrackingDetails, BidRangeType BidRange, ItemConditionCodeType ItemCondition, TicketDetailsType TicketFinder, GroupType Group, bool HideDuplicateItems)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.Query = Query;
			this.CategoryID = CategoryID;
			this.SearchFlagsList = SearchFlagsList;
			this.PriceRangeFilter = PriceRangeFilter;
			this.ProximitySearch = ProximitySearch;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.UserIdFilter = UserIdFilter;
			this.SearchLocationFilter = SearchLocationFilter;
			this.StoreSearchFilter = StoreSearchFilter;
			this.Order = Order;
			this.Pagination = Pagination;
			this.SearchRequest = SearchRequest;
			this.ProductID = ProductID;
			this.ExternalProductID = ExternalProductID;
			this.Categories = Categories;
			this.TotalOnly = TotalOnly;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.ModTimeFrom = ModTimeFrom;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.GranularityLevel = GranularityLevel;
			this.ExpandSearch = ExpandSearch;
			this.Lot = Lot;
			this.AdFormat = AdFormat;
			this.FreeShipping = FreeShipping;
			this.Quantity = Quantity;
			this.QuantityOperator = QuantityOperator;
			this.SellerBusinessType = SellerBusinessType;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.CharityID = CharityID;
			this.LocalSearchPostalCode = LocalSearchPostalCode;
			this.MaxRelatedSearchKeywords = MaxRelatedSearchKeywords;
			this.AffiliateTrackingDetails = AffiliateTrackingDetails;
			this.BidRange = BidRange;
			this.ItemCondition = ItemCondition;
			this.TicketFinder = TicketFinder;
			this.Group = Group;
			this.HideDuplicateItems = HideDuplicateItems;

			Execute();
			return ApiResponse.SearchResultItemArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public SearchResultItemTypeCollection GetSearchResults(string Query)
		{
			this.Query = Query;
			Execute();
			return SearchResultItemList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public SearchResultItemTypeCollection GetSearchResults(ExternalProductIDType ExternalProductID)
		{
			this.ExternalProductID = ExternalProductID;
			Execute();
			return SearchResultItemList;
		}
		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.EndTimeFrom"/> and <see cref="GetSearchResultsRequestType.EndTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter EndTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.EndTimeFrom, ApiRequest.EndTimeTo); }
			set 
			{
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.EndTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.EndTimeTo = value.TimeTo;
			}
		}

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public SearchResultItemTypeCollection GetSearchResults(bool MotorsGermanySearchable, string Query, string CategoryID, SearchFlagsCodeTypeCollection SearchFlagsList, PriceRangeFilterType PriceRangeFilter, ProximitySearchType ProximitySearch, ItemTypeFilterCodeType ItemTypeFilter, SearchTypeCodeType SearchType, UserIdFilterType UserIdFilter, SearchLocationFilterType SearchLocationFilter, SearchStoreFilterType StoreSearchFilter, SearchSortOrderCodeType Order, PaginationType Pagination, SearchRequestType SearchRequest, string ProductID, ExternalProductIDType ExternalProductID, RequestCategoriesType Categories, bool TotalOnly, DateTime EndTimeFrom, DateTime EndTimeTo, DateTime ModTimeFrom, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, GranularityLevelCodeType GranularityLevel, bool ExpandSearch, bool Lot, bool AdFormat, int Quantity, QuantityOperatorCodeType QuantityOperator, SellerBusinessCodeType SellerBusinessType, bool DigitalDelivery, bool IncludeCondition, bool IncludeFeedback, int CharityID)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.Query = Query;
			this.CategoryID = CategoryID;
			this.SearchFlagsList = SearchFlagsList;
			this.PriceRangeFilter = PriceRangeFilter;
			this.ProximitySearch = ProximitySearch;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.UserIdFilter = UserIdFilter;
			this.SearchLocationFilter = SearchLocationFilter;
			this.StoreSearchFilter = StoreSearchFilter;
			this.Order = Order;
			this.Pagination = Pagination;
			this.SearchRequest = SearchRequest;
			this.ProductID = ProductID;
			this.ExternalProductID = ExternalProductID;
			this.Categories = Categories;
			this.TotalOnly = TotalOnly;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.ModTimeFrom = ModTimeFrom;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.GranularityLevel = GranularityLevel;
			this.ExpandSearch = ExpandSearch;
			this.Lot = Lot;
			this.AdFormat = AdFormat;
			this.Quantity = Quantity;
			this.QuantityOperator = QuantityOperator;
			this.SellerBusinessType = SellerBusinessType;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.CharityID = CharityID;

			Execute();
			return ApiResponse.SearchResultItemArray;
		}

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public SearchResultItemTypeCollection GetSearchResults(bool MotorsGermanySearchable, string Query, string CategoryID, SearchFlagsCodeTypeCollection SearchFlagsList, PriceRangeFilterType PriceRangeFilter, ProximitySearchType ProximitySearch, ItemTypeFilterCodeType ItemTypeFilter, SearchTypeCodeType SearchType, UserIdFilterType UserIdFilter, SearchLocationFilterType SearchLocationFilter, SearchStoreFilterType StoreSearchFilter, SearchSortOrderCodeType Order, PaginationType Pagination, SearchRequestType SearchRequest, string ProductID, ExternalProductIDType ExternalProductID, RequestCategoriesType Categories, bool TotalOnly, DateTime EndTimeFrom, DateTime EndTimeTo, DateTime ModTimeFrom, bool IncludeGetItFastItems, bool StoresFixedPrice, PaymentMethodSearchCodeType PaymentMethod, GranularityLevelCodeType GranularityLevel, bool ExpandSearch, bool Lot, bool AdFormat, bool FreeShipping, int Quantity, QuantityOperatorCodeType QuantityOperator, SellerBusinessCodeType SellerBusinessType, bool DigitalDelivery, bool IncludeCondition, bool IncludeFeedback, int CharityID, string LocalSearchPostalCode)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.Query = Query;
			this.CategoryID = CategoryID;
			this.SearchFlagsList = SearchFlagsList;
			this.PriceRangeFilter = PriceRangeFilter;
			this.ProximitySearch = ProximitySearch;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.UserIdFilter = UserIdFilter;
			this.SearchLocationFilter = SearchLocationFilter;
			this.StoreSearchFilter = StoreSearchFilter;
			this.Order = Order;
			this.Pagination = Pagination;
			this.SearchRequest = SearchRequest;
			this.ProductID = ProductID;
			this.ExternalProductID = ExternalProductID;
			this.Categories = Categories;
			this.TotalOnly = TotalOnly;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.ModTimeFrom = ModTimeFrom;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.GranularityLevel = GranularityLevel;
			this.ExpandSearch = ExpandSearch;
			this.Lot = Lot;
			this.AdFormat = AdFormat;
			this.FreeShipping = FreeShipping;
			this.Quantity = Quantity;
			this.QuantityOperator = QuantityOperator;
			this.SellerBusinessType = SellerBusinessType;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.CharityID = CharityID;
			this.LocalSearchPostalCode = LocalSearchPostalCode;

			Execute();
			return ApiResponse.SearchResultItemArray;
		}
		
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public SearchResultItemTypeCollection GetSearchResults(bool MotorsGermanySearchable, string Query, string CategoryID, SearchFlagsCodeTypeCollection SearchFlagsList, PriceRangeFilterType PriceRangeFilter, ProximitySearchType ProximitySearch, ItemTypeFilterCodeType ItemTypeFilter, SearchTypeCodeType SearchType, UserIdFilterType UserIdFilter, SearchLocationFilterType SearchLocationFilter, SearchStoreFilterType StoreSearchFilter, SearchSortOrderCodeType Order, PaginationType Pagination, SearchRequestType SearchRequest, string ProductID, ExternalProductIDType ExternalProductID, RequestCategoriesType Categories, bool TotalOnly, DateTime EndTimeFrom, DateTime EndTimeTo, DateTime ModTimeFrom, bool IncludeGetItFastItems, PaymentMethodSearchCodeType PaymentMethod, GranularityLevelCodeType GranularityLevel, bool ExpandSearch, bool Lot, bool AdFormat, bool FreeShipping, int Quantity, QuantityOperatorCodeType QuantityOperator, SellerBusinessCodeType SellerBusinessType, bool DigitalDelivery, bool IncludeCondition, bool IncludeFeedback, int CharityID, string LocalSearchPostalCode, int MaxRelatedSearchKeywords, AffiliateTrackingDetailsType AffiliateTrackingDetails)
		{
			this.MotorsGermanySearchable = MotorsGermanySearchable;
			this.Query = Query;
			this.CategoryID = CategoryID;
			this.SearchFlagsList = SearchFlagsList;
			this.PriceRangeFilter = PriceRangeFilter;
			this.ProximitySearch = ProximitySearch;
			this.ItemTypeFilter = ItemTypeFilter;
			this.SearchType = SearchType;
			this.UserIdFilter = UserIdFilter;
			this.SearchLocationFilter = SearchLocationFilter;
			this.StoreSearchFilter = StoreSearchFilter;
			this.Order = Order;
			this.Pagination = Pagination;
			this.SearchRequest = SearchRequest;
			this.ProductID = ProductID;
			this.ExternalProductID = ExternalProductID;
			this.Categories = Categories;
			this.TotalOnly = TotalOnly;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.ModTimeFrom = ModTimeFrom;
			this.IncludeGetItFastItems = IncludeGetItFastItems;
			this.PaymentMethod = PaymentMethod;
			this.GranularityLevel = GranularityLevel;
			this.ExpandSearch = ExpandSearch;
			this.Lot = Lot;
			this.AdFormat = AdFormat;
			this.FreeShipping = FreeShipping;
			this.Quantity = Quantity;
			this.QuantityOperator = QuantityOperator;
			this.SellerBusinessType = SellerBusinessType;
			this.IncludeCondition = IncludeCondition;
			this.IncludeFeedback = IncludeFeedback;
			this.CharityID = CharityID;
			this.LocalSearchPostalCode = LocalSearchPostalCode;

			Execute();
			return ApiResponse.SearchResultItemArray;
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
		/// Gets or sets the <see cref="GetSearchResultsRequestType"/> for this API call.
		/// </summary>
		public GetSearchResultsRequestType ApiRequest
		{ 
			get { return (GetSearchResultsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSearchResultsResponseType"/> for this API call.
		/// </summary>
		public GetSearchResultsResponseType ApiResponse
		{ 
			get { return (GetSearchResultsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.MotorsGermanySearchable"/> of type <see cref="bool"/>.
		/// </summary>
		public bool MotorsGermanySearchable
		{ 
			get { return ApiRequest.MotorsGermanySearchable; }
			set { ApiRequest.MotorsGermanySearchable = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Query"/> of type <see cref="string"/>.
		/// </summary>
		public string Query
		{ 
			get { return ApiRequest.Query; }
			set { ApiRequest.Query = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.SearchFlags"/> of type <see cref="SearchFlagsCodeTypeCollection"/>.
		/// </summary>
		public SearchFlagsCodeTypeCollection SearchFlagsList
		{ 
			get { return ApiRequest.SearchFlags; }
			set { ApiRequest.SearchFlags = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.PriceRangeFilter"/> of type <see cref="PriceRangeFilterType"/>.
		/// </summary>
		public PriceRangeFilterType PriceRangeFilter
		{ 
			get { return ApiRequest.PriceRangeFilter; }
			set { ApiRequest.PriceRangeFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ProximitySearch"/> of type <see cref="ProximitySearchType"/>.
		/// </summary>
		public ProximitySearchType ProximitySearch
		{ 
			get { return ApiRequest.ProximitySearch; }
			set { ApiRequest.ProximitySearch = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ItemTypeFilter"/> of type <see cref="ItemTypeFilterCodeType"/>.
		/// </summary>
		public ItemTypeFilterCodeType ItemTypeFilter
		{ 
			get { return ApiRequest.ItemTypeFilter; }
			set { ApiRequest.ItemTypeFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.SearchType"/> of type <see cref="SearchTypeCodeType"/>.
		/// </summary>
		public SearchTypeCodeType SearchType
		{ 
			get { return ApiRequest.SearchType; }
			set { ApiRequest.SearchType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.UserIdFilter"/> of type <see cref="UserIdFilterType"/>.
		/// </summary>
		public UserIdFilterType UserIdFilter
		{ 
			get { return ApiRequest.UserIdFilter; }
			set { ApiRequest.UserIdFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.SearchLocationFilter"/> of type <see cref="SearchLocationFilterType"/>.
		/// </summary>
		public SearchLocationFilterType SearchLocationFilter
		{ 
			get { return ApiRequest.SearchLocationFilter; }
			set { ApiRequest.SearchLocationFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.StoreSearchFilter"/> of type <see cref="SearchStoreFilterType"/>.
		/// </summary>
		public SearchStoreFilterType StoreSearchFilter
		{ 
			get { return ApiRequest.StoreSearchFilter; }
			set { ApiRequest.StoreSearchFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Order"/> of type <see cref="SearchSortOrderCodeType"/>.
		/// </summary>
		public SearchSortOrderCodeType Order
		{ 
			get { return ApiRequest.Order; }
			set { ApiRequest.Order = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.SearchRequest"/> of type <see cref="SearchRequestType"/>.
		/// </summary>
		public SearchRequestType SearchRequest
		{ 
			get { return ApiRequest.SearchRequest; }
			set { ApiRequest.SearchRequest = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ProductID"/> of type <see cref="string"/>.
		/// </summary>
		public string ProductID
		{ 
			get { return ApiRequest.ProductID; }
			set { ApiRequest.ProductID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ExternalProductID"/> of type <see cref="ExternalProductIDType"/>.
		/// </summary>
		public ExternalProductIDType ExternalProductID
		{ 
			get { return ApiRequest.ExternalProductID; }
			set { ApiRequest.ExternalProductID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Categories"/> of type <see cref="RequestCategoriesType"/>.
		/// </summary>
		public RequestCategoriesType Categories
		{ 
			get { return ApiRequest.Categories; }
			set { ApiRequest.Categories = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.TotalOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool TotalOnly
		{ 
			get { return ApiRequest.TotalOnly; }
			set { ApiRequest.TotalOnly = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.EndTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeFrom
		{ 
			get { return ApiRequest.EndTimeFrom; }
			set { ApiRequest.EndTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.EndTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeTo
		{ 
			get { return ApiRequest.EndTimeTo; }
			set { ApiRequest.EndTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ModTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeFrom
		{ 
			get { return ApiRequest.ModTimeFrom; }
			set { ApiRequest.ModTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.IncludeGetItFastItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeGetItFastItems
		{ 
			get { return ApiRequest.IncludeGetItFastItems; }
			set { ApiRequest.IncludeGetItFastItems = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.PaymentMethod"/> of type <see cref="PaymentMethodSearchCodeType"/>.
		/// </summary>
		public PaymentMethodSearchCodeType PaymentMethod
		{ 
			get { return ApiRequest.PaymentMethod; }
			set { ApiRequest.PaymentMethod = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.GranularityLevel"/> of type <see cref="GranularityLevelCodeType"/>.
		/// </summary>
		public GranularityLevelCodeType GranularityLevel
		{ 
			get { return ApiRequest.GranularityLevel; }
			set { ApiRequest.GranularityLevel = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ExpandSearch"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ExpandSearch
		{ 
			get { return ApiRequest.ExpandSearch; }
			set { ApiRequest.ExpandSearch = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Lot"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Lot
		{ 
			get { return ApiRequest.Lot; }
			set { ApiRequest.Lot = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.AdFormat"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AdFormat
		{ 
			get { return ApiRequest.AdFormat; }
			set { ApiRequest.AdFormat = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.FreeShipping"/> of type <see cref="bool"/>.
		/// </summary>
		public bool FreeShipping
		{ 
			get { return ApiRequest.FreeShipping; }
			set { ApiRequest.FreeShipping = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Quantity"/> of type <see cref="int"/>.
		/// </summary>
		public int Quantity
		{ 
			get { return ApiRequest.Quantity; }
			set { ApiRequest.Quantity = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.QuantityOperator"/> of type <see cref="QuantityOperatorCodeType"/>.
		/// </summary>
		public QuantityOperatorCodeType QuantityOperator
		{ 
			get { return ApiRequest.QuantityOperator; }
			set { ApiRequest.QuantityOperator = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.SellerBusinessType"/> of type <see cref="SellerBusinessCodeType"/>.
		/// </summary>
		public SellerBusinessCodeType SellerBusinessType
		{ 
			get { return ApiRequest.SellerBusinessType; }
			set { ApiRequest.SellerBusinessType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.IncludeCondition"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeCondition
		{ 
			get { return ApiRequest.IncludeCondition; }
			set { ApiRequest.IncludeCondition = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.IncludeFeedback"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFeedback
		{ 
			get { return ApiRequest.IncludeFeedback; }
			set { ApiRequest.IncludeFeedback = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.CharityID"/> of type <see cref="int"/>.
		/// </summary>
		public int CharityID
		{ 
			get { return ApiRequest.CharityID; }
			set { ApiRequest.CharityID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.LocalSearchPostalCode"/> of type <see cref="string"/>.
		/// </summary>
		public string LocalSearchPostalCode
		{ 
			get { return ApiRequest.LocalSearchPostalCode; }
			set { ApiRequest.LocalSearchPostalCode = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.MaxRelatedSearchKeywords"/> of type <see cref="int"/>.
		/// </summary>
		public int MaxRelatedSearchKeywords
		{ 
			get { return ApiRequest.MaxRelatedSearchKeywords; }
			set { ApiRequest.MaxRelatedSearchKeywords = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.AffiliateTrackingDetails"/> of type <see cref="AffiliateTrackingDetailsType"/>.
		/// </summary>
		public AffiliateTrackingDetailsType AffiliateTrackingDetails
		{ 
			get { return ApiRequest.AffiliateTrackingDetails; }
			set { ApiRequest.AffiliateTrackingDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.BidRange"/> of type <see cref="BidRangeType"/>.
		/// </summary>
		public BidRangeType BidRange
		{ 
			get { return ApiRequest.BidRange; }
			set { ApiRequest.BidRange = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.ItemCondition"/> of type <see cref="ItemConditionCodeType"/>.
		/// </summary>
		public ItemConditionCodeType ItemCondition
		{ 
			get { return ApiRequest.ItemCondition; }
			set { ApiRequest.ItemCondition = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.TicketFinder"/> of type <see cref="TicketDetailsType"/>.
		/// </summary>
		public TicketDetailsType TicketFinder
		{ 
			get { return ApiRequest.TicketFinder; }
			set { ApiRequest.TicketFinder = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.Group"/> of type <see cref="GroupType"/>.
		/// </summary>
		public GroupType Group
		{ 
			get { return ApiRequest.Group; }
			set { ApiRequest.Group = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSearchResultsRequestType.HideDuplicateItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HideDuplicateItems
		{ 
			get { return ApiRequest.HideDuplicateItems; }
			set { ApiRequest.HideDuplicateItems = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.SearchResultItemArray"/> of type <see cref="SearchResultItemTypeCollection"/>.
		/// </summary>
		public SearchResultItemTypeCollection SearchResultItemList
		{ 
			get { return ApiResponse.SearchResultItemArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.ItemsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int ItemsPerPage
		{ 
			get { return ApiResponse.ItemsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.HasMoreItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreItems
		{ 
			get { return ApiResponse.HasMoreItems; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.CategoryArray"/> of type <see cref="CategoryTypeCollection"/>.
		/// </summary>
		public CategoryTypeCollection CategoryReturnList
		{ 
			get { return ApiResponse.CategoryArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.BuyingGuideDetails"/> of type <see cref="BuyingGuideDetailsType"/>.
		/// </summary>
		public BuyingGuideDetailsType BuyingGuideDetails
		{ 
			get { return ApiResponse.BuyingGuideDetails; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.SpellingSuggestion"/> of type <see cref="SpellingSuggestionType"/>.
		/// </summary>
		public SpellingSuggestionType SpellingSuggestion
		{ 
			get { return ApiResponse.SpellingSuggestion; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.RelatedSearchKeywordArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection RelatedSearchKeywordList
		{ 
			get { return ApiResponse.RelatedSearchKeywordArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSearchResultsResponseType.DuplicateItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool DuplicateItems
		{ 
			get { return ApiResponse.DuplicateItems; }
		}
		

		#endregion

		
	}
}
