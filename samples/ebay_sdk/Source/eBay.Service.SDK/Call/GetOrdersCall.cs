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
	public class GetOrdersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetOrdersCall()
		{
			ApiRequest = new GetOrdersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetOrdersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetOrdersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the orders for which the authenticated user is a participant, either as
		/// the buyer or the seller. The call returns all the orders that meet the request
		/// specifications.
		/// </summary>
		/// 
		/// <param name="OrderIDList">
		/// A set of orders to retrieve.
		/// 
		/// Not applicable to Half.com.
		/// </param>
		///
		/// <param name="CreateTimeFrom">
		/// The starting date of the date range for the orders to retrieve.
		/// 
		/// Applicable to Half.com.
		/// </param>
		///
		/// <param name="CreateTimeTo">
		/// The ending date of the date range for the orders to retrieve.
		/// 
		/// Applicable to Half.com.
		/// </param>
		///
		/// <param name="OrderRole">
		/// Filters orders based on the role of the user making the GetOrders request.
		/// 
		/// Not applicable to Half.com.
		/// </param>
		///
		/// <param name="OrderStatus">
		/// Filters the returned orders by order status (Active or Completed).
		/// To retrieve orders with a status of Inactive or Cancelled, you must
		/// specify the order IDs (OrderIDArray.OrderID). When you specify
		/// OrderIDArray.OrderID, no other filters are used.
		/// 
		/// For Half.com, you can get some, but not all orders.
		/// Orders on Half.com have different order status values from
		/// eBay orders. When you set ListingType to Half, set OrderStatus
		/// to Shipped. Otherwise, GetOrders may return incomplete information
		/// or have indeterminate results.
		/// </param>
		///
		/// <param name="ListingType">
		/// Specify Half to retrieve Half.com orders.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// Do not use this field if you are retrieving eBay orders.
		/// 
		/// This field cannnot be used as a listing type filter on eBay.com. If not
		/// provided, or if you specify any value other than Half, this field has
		/// no useful effect and the call retrieves eBay orders of all types. Also,
		/// you can't retrieve both eBay and Half.com orders in the same response.
		/// </span>
		/// </param>
		///
		/// <param name="Pagination">
		/// Not applicable to eBay.com. Applicable to Half.com. If many orders are
		/// available, you may need to call GetOrders multiple times to retrieve all
		/// the data. Each result set is returned as a page of entries. Use this
		/// Pagination information to indicate the maximum number of entries to
		/// retrieve per page (i.e., per call), the page number to retrieve, and
		/// other data.
		/// </param>
		///
		public OrderTypeCollection GetOrders(StringCollection OrderIDList, DateTime CreateTimeFrom, DateTime CreateTimeTo, TradingRoleCodeType OrderRole, OrderStatusCodeType OrderStatus, ListingTypeCodeType ListingType, PaginationType Pagination)
		{
			this.OrderIDList = OrderIDList;
			this.CreateTimeFrom = CreateTimeFrom;
			this.CreateTimeTo = CreateTimeTo;
			this.OrderRole = OrderRole;
			this.OrderStatus = OrderStatus;
			this.ListingType = ListingType;
			this.Pagination = Pagination;

			Execute();
			return ApiResponse.OrderArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public OrderTypeCollection GetOrders(StringCollection OrderIDList)
		{
			this.OrderIDList = OrderIDList;
			Execute();
			return OrderList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public OrderTypeCollection GetOrders(TimeFilter CreateTimeFilter, TradingRoleCodeType OrderRole, OrderStatusCodeType OrderStatus)
		{
			this.OrderRole = OrderRole;
			this.OrderStatus = OrderStatus;
			this.CreateTimeFilter = CreateTimeFilter;
			this.OrderIDList = OrderIDList;
			Execute();
			return OrderList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public OrderTypeCollection GetOrders(DateTime CreateTimeFrom, DateTime CreateTimeTo, TradingRoleCodeType OrderRole, OrderStatusCodeType OrderStatus)
		{
			this.OrderRole = OrderRole;
			this.OrderStatus = OrderStatus;
			this.CreateTimeFilter = new TimeFilter(CreateTimeFrom, CreateTimeTo);
			this.OrderIDList = OrderIDList;
			Execute();
			return OrderList;
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
		/// Gets or sets the <see cref="GetOrdersRequestType"/> for this API call.
		/// </summary>
		public GetOrdersRequestType ApiRequest
		{ 
			get { return (GetOrdersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetOrdersResponseType"/> for this API call.
		/// </summary>
		public GetOrdersResponseType ApiResponse
		{ 
			get { return (GetOrdersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.OrderIDArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection OrderIDList
		{ 
			get { return ApiRequest.OrderIDArray; }
			set { ApiRequest.OrderIDArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.CreateTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime CreateTimeFrom
		{ 
			get { return ApiRequest.CreateTimeFrom; }
			set { ApiRequest.CreateTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.CreateTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime CreateTimeTo
		{ 
			get { return ApiRequest.CreateTimeTo; }
			set { ApiRequest.CreateTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.OrderRole"/> of type <see cref="TradingRoleCodeType"/>.
		/// </summary>
		public TradingRoleCodeType OrderRole
		{ 
			get { return ApiRequest.OrderRole; }
			set { ApiRequest.OrderRole = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.OrderStatus"/> of type <see cref="OrderStatusCodeType"/>.
		/// </summary>
		public OrderStatusCodeType OrderStatus
		{ 
			get { return ApiRequest.OrderStatus; }
			set { ApiRequest.OrderStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.ListingType"/> of type <see cref="ListingTypeCodeType"/>.
		/// </summary>
		public ListingTypeCodeType ListingType
		{ 
			get { return ApiRequest.ListingType; }
			set { ApiRequest.ListingType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.CreateTimeFrom"/> and <see cref="GetOrdersRequestType.CreateTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter CreateTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.CreateTimeFrom, ApiRequest.CreateTimeTo); }
			set { 
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.CreateTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.CreateTimeTo = value.TimeTo;
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.HasMoreOrders"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreOrders
		{ 
			get { return ApiResponse.HasMoreOrders; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.OrderArray"/> of type <see cref="OrderTypeCollection"/>.
		/// </summary>
		public OrderTypeCollection OrderList
		{ 
			get { return ApiResponse.OrderArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.OrdersPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int OrdersPerPage
		{ 
			get { return ApiResponse.OrdersPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.ReturnedOrderCountActual"/> of type <see cref="int"/>.
		/// </summary>
		public int ReturnedOrderCountActual
		{ 
			get { return ApiResponse.ReturnedOrderCountActual; }
		}
		

		#endregion

		
	}
}
