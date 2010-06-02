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
	public class GetSellerTransactionsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellerTransactionsCall()
		{
			ApiRequest = new GetSellerTransactionsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellerTransactionsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellerTransactionsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves transaction information for the user for which the call is made, and
		/// not for any other user. (To retrieve transactions for another seller's listings,
		/// use GetItemTransactions.)
		/// </summary>
		/// 
		/// <param name="ModTimeFrom">
		/// Also see NumberOfDays, which (if used), takes precedence over ModTimeFrom and
		/// ModTimeTo. If you prefer to use ModTimeFrom and ModTimeTo, specify the time range
		/// within which retrieved transactions' statuses were modified. ModTimeFrom is the
		/// earlier (older) date and ModTimeTo is the later (more recent) date. If you specify
		/// ModTimeFrom, but do not specify the other end of the range, the time range is set
		/// to 30 days. The time range between ModTimeFrom to ModTimeTo cannot be greater than
		/// 30 days.
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
		/// </param>
		///
		/// <param name="Pagination">
		/// Child elements control pagination of the output. Use EntriesPerPage property to
		/// control the number of transactions to return per call and PageNumber property to
		/// specify the page of data to return.
		/// </param>
		///
		/// <param name="IncludeFinalValueFee">
		/// Indicates whether to include Final Value Fee (FVF) in the response. For most
		/// listing types, the Final Value Fee is returned in Transaction.FinalValueFee.
		/// The Final Value Fee is returned on a transaction-by-transaction basis for
		/// FixedPriceItem and StoresFixedPrice listing types. For all other listing
		/// types, the Final Value Fee is returned when the listing status is Completed.
		/// This value is not returned if the auction ended with Buy It Now.
		/// 
		/// For Dutch (multi-item) auctions that end with bids (not Buy It Now
		/// purchases), the Final Value Fee is returned in
		/// Item.SellingStatus.FinalValueFee. For Dutch Buy It Now listings, the Final
		/// Value Fee is returned on a transaction-by-transaction basis.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// As of version 619, Dutch-style (multi-item) competitive-bid auctions are
		/// deprecated. eBay throws an error if you submit a Dutch item listing with AddItem
		/// or VerifyAddItem. If you use RelistItem to update a Dutch auction listing, eBay
		/// generates a warning and resets the Quantity value to 1.
		/// </span>
		/// 
		/// </param>
		///
		/// <param name="IncludeContainingOrder">
		/// Whether to retrieve the order information. Default is false.
		/// </param>
		///
		/// <param name="SKUArrayList">
		/// Container for a set of SKUs.
		/// Filters (reduces) the response to only include transactions
		/// for listings that include any of the specified SKUs.
		/// If multiple listings include the same SKU, transactions for
		/// all of them are returned (assuming they also match the other
		/// criteria in the GetSellerTransactions request).
		/// 
		/// You can combine SKUArray with InventoryTrackingMethod.
		/// For example, if you also pass in InventoryTrackingMethod=SKU,
		/// the response only includes transactions for listings that
		/// include InventoryTrackingMethod=SKU and one of the
		/// requested SKUs.
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
		/// </param>
		///
		/// <param name="InventoryTrackingMethod">
		/// Filters the response to only include transactions for listings
		/// that match this InventoryTrackingMethod setting. 
		/// 
		/// For example, if you set this to SKU, the call returns
		/// transactions for your listings that are tracked by SKU.
		/// If you set this to ItemID, the call omits transactions
		/// for your listings that are tracked by SKU.
		/// If you don't pass this in, the call returns all transactions,
		/// regardless of whether they are tracked by SKU or ItemID.
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// To specify InventoryTrackingMethod when you create a listing,
		/// use AddFixedPriceItem or RelistFixedPriceItem.
		/// AddFixedPriceItem and RelistFixedPriceItem are defined in
		/// the Merchant Data API (part of Large Merchant Services).
		/// </span>
		/// 
		/// 
		/// You can combine SKUArray with InventoryTrackingMethod.
		/// For example, if you set this to SKU and you also pass in
		/// SKUArray, the response only includes transactions for listings
		/// that include InventoryTrackingMethod=SKU and one of the
		/// requested SKUs.
		/// </param>
		///
		public TransactionTypeCollection GetSellerTransactions(DateTime ModTimeFrom, DateTime ModTimeTo, PaginationType Pagination, bool IncludeFinalValueFee, bool IncludeContainingOrder, StringCollection SKUArrayList, TransactionPlatformCodeType Platform, int NumberOfDays, InventoryTrackingMethodCodeType InventoryTrackingMethod)
		{
			this.ModTimeFrom = ModTimeFrom;
			this.ModTimeTo = ModTimeTo;
			this.Pagination = Pagination;
			this.IncludeFinalValueFee = IncludeFinalValueFee;
			this.IncludeContainingOrder = IncludeContainingOrder;
			this.SKUArrayList = SKUArrayList;
			this.Platform = Platform;
			this.NumberOfDays = NumberOfDays;
			this.InventoryTrackingMethod = InventoryTrackingMethod;

			Execute();
			return ApiResponse.TransactionArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public TransactionTypeCollection GetSellerTransactions(TimeFilter ModTimeFilter)
		{
			this.ModTimeFilter = ModTimeFilter;
			Execute();
			return TransactionList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public TransactionTypeCollection GetSellerTransactions(DateTime TimeFrom, DateTime TimeTo)
		{
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
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType"/> for this API call.
		/// </summary>
		public GetSellerTransactionsRequestType ApiRequest
		{ 
			get { return (GetSellerTransactionsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellerTransactionsResponseType"/> for this API call.
		/// </summary>
		public GetSellerTransactionsResponseType ApiResponse
		{ 
			get { return (GetSellerTransactionsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.ModTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeFrom
		{ 
			get { return ApiRequest.ModTimeFrom; }
			set { ApiRequest.ModTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.ModTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeTo
		{ 
			get { return ApiRequest.ModTimeTo; }
			set { ApiRequest.ModTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.IncludeFinalValueFee"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFinalValueFee
		{ 
			get { return ApiRequest.IncludeFinalValueFee; }
			set { ApiRequest.IncludeFinalValueFee = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.IncludeContainingOrder"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeContainingOrder
		{ 
			get { return ApiRequest.IncludeContainingOrder; }
			set { ApiRequest.IncludeContainingOrder = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.SKUArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection SKUArrayList
		{ 
			get { return ApiRequest.SKUArray; }
			set { ApiRequest.SKUArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.Platform"/> of type <see cref="TransactionPlatformCodeType"/>.
		/// </summary>
		public TransactionPlatformCodeType Platform
		{ 
			get { return ApiRequest.Platform; }
			set { ApiRequest.Platform = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.NumberOfDays"/> of type <see cref="int"/>.
		/// </summary>
		public int NumberOfDays
		{ 
			get { return ApiRequest.NumberOfDays; }
			set { ApiRequest.NumberOfDays = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.InventoryTrackingMethod"/> of type <see cref="InventoryTrackingMethodCodeType"/>.
		/// </summary>
		public InventoryTrackingMethodCodeType InventoryTrackingMethod
		{ 
			get { return ApiRequest.InventoryTrackingMethod; }
			set { ApiRequest.InventoryTrackingMethod = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.ModTimeFrom"/> and <see cref="GetSellerTransactionsRequestType.ModTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter ModTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.ModTimeFrom, ApiRequest.ModTimeTo); }
			set 
			{
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.ModTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.ModTimeTo = value.TimeTo;
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.HasMoreTransactions"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreTransactions
		{ 
			get { return ApiResponse.HasMoreTransactions; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.TransactionsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int TransactionsPerPage
		{ 
			get { return ApiResponse.TransactionsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.ReturnedTransactionCountActual"/> of type <see cref="int"/>.
		/// </summary>
		public int ReturnedTransactionCountActual
		{ 
			get { return ApiResponse.ReturnedTransactionCountActual; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.Seller"/> of type <see cref="UserType"/>.
		/// </summary>
		public UserType Seller
		{ 
			get { return ApiResponse.Seller; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.TransactionArray"/> of type <see cref="TransactionTypeCollection"/>.
		/// </summary>
		public TransactionTypeCollection TransactionList
		{ 
			get { return ApiResponse.TransactionArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.PayPalPreferred"/> of type <see cref="bool"/>.
		/// </summary>
		public bool PayPalPreferred
		{ 
			get { return ApiResponse.PayPalPreferred; }
		}
		

		#endregion

		
	}
}
