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
	public class GetSellingManagerEmailLogCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellingManagerEmailLogCall()
		{
			ApiRequest = new GetSellingManagerEmailLogRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellingManagerEmailLogCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellingManagerEmailLogRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a log of emails sent, or scheduled to be sent, to buyers.
		/// This call is subject to change without notice; the deprecation process is
		/// inapplicable to this call.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique ID for the item associated with the email.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique ID for the transaction associated with the email.
		/// </param>
		///
		/// <param name="OrderID">
		/// Unique ID for a multi-item order associated with the email. If specified,
		/// ItemID and TransactionID are ignored if specified in the same call.
		/// </param>
		///
		/// <param name="EmailDateRange">
		/// Specifies the earliest (oldest) and latest (most recent) dates to use in a
		/// date range filter based on email sent date. Each of the time ranges can be
		/// up to 90 days.
		/// </param>
		///
		public SellingManagerEmailLogTypeCollection GetSellingManagerEmailLog(string ItemID, long TransactionID, string OrderID, TimeRangeType EmailDateRange)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.EmailDateRange = EmailDateRange;

			Execute();
			return ApiResponse.EmailLog;
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
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType"/> for this API call.
		/// </summary>
		public GetSellingManagerEmailLogRequestType ApiRequest
		{ 
			get { return (GetSellingManagerEmailLogRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellingManagerEmailLogResponseType"/> for this API call.
		/// </summary>
		public GetSellingManagerEmailLogResponseType ApiResponse
		{ 
			get { return (GetSellingManagerEmailLogResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.TransactionID"/> of type <see cref="long"/>.
		/// </summary>
		public long TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerEmailLogRequestType.EmailDateRange"/> of type <see cref="TimeRangeType"/>.
		/// </summary>
		public TimeRangeType EmailDateRange
		{ 
			get { return ApiRequest.EmailDateRange; }
			set { ApiRequest.EmailDateRange = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellingManagerEmailLogResponseType.EmailLog"/> of type <see cref="SellingManagerEmailLogTypeCollection"/>.
		/// </summary>
		public SellingManagerEmailLogTypeCollection EmailLogList
		{ 
			get { return ApiResponse.EmailLog; }
		}
		

		#endregion

		
	}
}
