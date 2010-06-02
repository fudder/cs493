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
	public class GetItemTransactionsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetItemTransactionsCall()
		{
			ApiRequest = new GetItemTransactionsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetItemTransactionsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetItemTransactionsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves transaction information for a specified itemID. The call returns zero, one,
		/// or multiple transactions, depending on the number of items sold from the listing.
		/// 
		/// You can retrieve transaction data for a specific time range or number of days. If you don't specify a
		/// a range or number of days, transaction data will be returned for the past 30 days.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique item ID for a listing that has transactions
		/// (purchases). When you use ItemID alone, eBay returns
		/// all available transactions that are associated with the
		/// listing. Also see other input filters (such as the
		/// time filters) for ways to reduce the number of
		/// transactions returned.
		/// 
		/// If a listing has a Quantity greater than 1, and one
		/// or more items were purchased separately, the call can
		/// return multiple transactions. To uniquely
		/// identify and retrieve a particular transaction, use
		/// both ItemID and TransactionID together.
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// GetItemTransactions doesn't support SKU as an input because this
		/// call requires an identifier that is unique across your active
		/// and ended listings. Even when InventoryTrackingMethod is set to
		/// SKU in a listing, the SKU is only unique across your active
		/// listings (not your ended listings). To retrieve transactions
		/// by SKU, use GetSellerTransactions instead.
		/// </span>
		/// </param>
		///
		/// <param name="ModTimeFrom">
		/// Also see NumberOfDays, which (if used), takes precedence over ModTimeFrom and
		/// ModTimeTo. If you prefer to use ModTimeFrom and ModTimeTo, specify the time range
		/// within which retrieved transactions' statuses were modified. ModTimeFrom is the
		/// earlier (older) date and ModTimeTo is the later (more recent) date. If you specify
		/// ModTimeFrom, but do not specify the other end of the range, the time range is set
		/// to 30 days. The time range between ModTimeFrom to ModTimeTo cannot be greater than
		/// 30 days.
		/// 
		/// If you don't specify ModTimeFrom and ModTimeTo, NumberOfDays with a default of 30
		/// days will be used.
		/// </param>
		///
		/// <param name="ModTimeTo">
		/// Also see NumberOfDays, which (if used), takes precedence over ModTimeFrom and
		/// ModTimeTo. If you prefer to use ModTimeFrom and ModTimeTo, specify the time range
		/// within which retrieved transactions' statuses were modified. ModTimeFrom is the
		/// earlier (older) date and ModTimeTo is the later (more recent) date. If you specify
		/// ModTimeTo, but do not specify the other end of the range, the time range is set to
		/// 30 days. The time range between ModTimeFrom to ModTimeTo cannot be greater than 30
		/// days.
		/// 
		/// If you don't specify ModTimeFrom and ModTimeTo, NumberOfDays with a default of 30
		/// days will be used.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Identifies one transaction for a listing. For Chinese auction listings
		/// (single-item listings for which there can be only one transaction),
		/// TransactionID is always 0, and for multi-quantity listings (for which
		/// there can be multiple transactions), TransactionID has a non-0 value. If
		/// TransactionID is provided, details are returned for the transaction,
		/// regardless of any time range you might have specified (e.g. ModTimeFrom,
		/// NumberOfDays). To determine the valid transaction IDs for a listing, you
		/// typically need to have previously executed GetItemTransactionsCall or
		/// GetSellerTransactionsCall and stored all the listing's transactions.
		/// </param>
		///
		/// <param name="Pagination">
		/// Child elements control pagination of the output. Use EntriesPerPage
		/// property to control the number of transactions to return per call and
		/// PageNumber property to specify the page of data to return.
		/// </param>
		///
		/// <param name="IncludeFinalValueFee">
		/// Indicates whether to include a Final Value Fee (FVF) in the response. For
		/// most listing types, the Final Value Fee is returned in
		/// Transaction.FinalValueFee. The final value fee is returned on a
		/// transaction-by-transaction basis for FixedPriceItem and StoresFixedPrice
		/// listing types. For all other listing types, the Final Value Fee is
		/// returned when the listing status is Completed. This value is not returned
		/// if the auction ended with Buy It Now.
		/// 
		/// For Dutch (multi-item) auctions that end with bids (not Buy It Now
		/// purchases), the Final Value Fee is returned in
		/// Item.SellingStatus.FinalValueFee. For Dutch Buy It Now listings, the Final
		/// Value Fee is returned on a transaction-by-transaction basis.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// As of version 619, Dutch-style (multi-item) competitive-bid auctions are deprecated.
		/// eBay throws an error if you submit a Dutch item listing with AddItem
		/// or VerifyAddItem. If you use RelistItem to update a Dutch auction listing,
		/// eBay generates a warning and resets the Quantity value to 1.
		/// </span>
		/// 
		/// </param>
		///
		/// <param name="IncludeContainingOrder">
		/// Whether to retrieve the order information. Default is false.
		/// </param>
		///
		/// <param name="Platform">
		/// Name of the eBay co-branded site upon which the transaction was made.
		/// This will serve as a filter for the transactions to get emitted in the response.
		/// </param>
		///
		/// <param name="NumberOfDays">
		/// NumberOfDays enables you to specify the number of days' worth of new and modified
		/// transactions that you want to retrieve. The call response contains the
		/// transactions whose status was modified within the specified number of days since
		/// the API call was made. NumberOfDays is often preferable to using the ModTimeFrom
		/// and ModTimeTo filters because you only need to specify one value. If you use
		/// NumberOfDays, then ModTimeFrom and ModTimeTo are ignored. For this field, one day
		/// is defined as 24 hours.
		/// 
		/// If you don't specify ModTimeFrom and ModTimeTo, NumberOfDays with a default of 30
		/// will be used.
		/// </param>
		///
		/// <param name="IncludeVariations">
		/// If true, all variations defined for the item are returned in the
		/// Item-level details, including variations that have no
		/// transactions. (If false, the applicable variations are still
		/// returned in the Transaction-level details.) This information is
		/// intended to help sellers to reconcile their local inventory with
		/// eBay's records while processing transactions (without requiring
		/// a separate call to GetItem).
		/// </param>
		///
		public TransactionTypeCollection GetItemTransactions(string ItemID, DateTime ModTimeFrom, DateTime ModTimeTo, string TransactionID, PaginationType Pagination, bool IncludeFinalValueFee, bool IncludeContainingOrder, TransactionPlatformCodeType Platform, int NumberOfDays, bool IncludeVariations)
		{
			this.ItemID = ItemID;
			this.ModTimeFrom = ModTimeFrom;
			this.ModTimeTo = ModTimeTo;
			this.TransactionID = TransactionID;
			this.Pagination = Pagination;
			this.IncludeFinalValueFee = IncludeFinalValueFee;
			this.IncludeContainingOrder = IncludeContainingOrder;
			this.Platform = Platform;
			this.NumberOfDays = NumberOfDays;
			this.IncludeVariations = IncludeVariations;

			Execute();
			return ApiResponse.TransactionArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public TransactionTypeCollection GetItemTransactions(string ItemID, TimeFilter ModTimeFilter)
		{
			this.ItemID = ItemID;
			this.ModTimeFilter = ModTimeFilter;
			Execute();
			return TransactionList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public TransactionTypeCollection GetItemTransactions(string ItemID, DateTime TimeFrom, DateTime TimeTo)
		{
			this.ItemID = ItemID;
			this.ModTimeFilter = new TimeFilter(TimeFrom, TimeTo);
			Execute();
			return TransactionList;
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
		/// Gets or sets the <see cref="GetItemTransactionsRequestType"/> for this API call.
		/// </summary>
		public GetItemTransactionsRequestType ApiRequest
		{ 
			get { return (GetItemTransactionsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetItemTransactionsResponseType"/> for this API call.
		/// </summary>
		public GetItemTransactionsResponseType ApiResponse
		{ 
			get { return (GetItemTransactionsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.ModTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeFrom
		{ 
			get { return ApiRequest.ModTimeFrom; }
			set { ApiRequest.ModTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.ModTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeTo
		{ 
			get { return ApiRequest.ModTimeTo; }
			set { ApiRequest.ModTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.IncludeFinalValueFee"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFinalValueFee
		{ 
			get { return ApiRequest.IncludeFinalValueFee; }
			set { ApiRequest.IncludeFinalValueFee = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.IncludeContainingOrder"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeContainingOrder
		{ 
			get { return ApiRequest.IncludeContainingOrder; }
			set { ApiRequest.IncludeContainingOrder = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.Platform"/> of type <see cref="TransactionPlatformCodeType"/>.
		/// </summary>
		public TransactionPlatformCodeType Platform
		{ 
			get { return ApiRequest.Platform; }
			set { ApiRequest.Platform = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.NumberOfDays"/> of type <see cref="int"/>.
		/// </summary>
		public int NumberOfDays
		{ 
			get { return ApiRequest.NumberOfDays; }
			set { ApiRequest.NumberOfDays = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.IncludeVariations"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeVariations
		{ 
			get { return ApiRequest.IncludeVariations; }
			set { ApiRequest.IncludeVariations = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetItemTransactionsRequestType.ModTimeFrom"/> and <see cref="GetItemTransactionsRequestType.ModTimeTo"/> of type <see cref="ModTimeFilter"/>.
		/// </summary>
		public TimeFilter ModTimeFilter
		{ 
			get 
			{ 
				return new TimeFilter(ApiRequest.ModTimeFrom, ApiRequest.ModTimeTo); 
			}
			set 
			{
				ApiRequest.ModTimeFrom = value.TimeFrom;
				ApiRequest.ModTimeTo = value.TimeTo; 
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.HasMoreTransactions"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreTransactions
		{ 
			get { return ApiResponse.HasMoreTransactions; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.TransactionsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int TransactionsPerPage
		{ 
			get { return ApiResponse.TransactionsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.ReturnedTransactionCountActual"/> of type <see cref="int"/>.
		/// </summary>
		public int ReturnedTransactionCountActual
		{ 
			get { return ApiResponse.ReturnedTransactionCountActual; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiResponse.Item; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.TransactionArray"/> of type <see cref="TransactionTypeCollection"/>.
		/// </summary>
		public TransactionTypeCollection TransactionList
		{ 
			get { return ApiResponse.TransactionArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemTransactionsResponseType.PayPalPreferred"/> of type <see cref="bool"/>.
		/// </summary>
		public bool PayPalPreferred
		{ 
			get { return ApiResponse.PayPalPreferred; }
		}
		

		#endregion

		
	}
}
