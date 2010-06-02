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
	public class GetSellingManagerSaleRecordCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellingManagerSaleRecordCall()
		{
			ApiRequest = new GetSellingManagerSaleRecordRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellingManagerSaleRecordCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellingManagerSaleRecordRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Requests the data in a Selling Manager sale record.
		/// 
		/// This call is subject to change without notice; the
		/// deprecation process is inapplicable to this call.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The item ID associated with the sale record. If not specified, either
		/// TransactionID or OrderID must be specified.
		/// </param>
		///
		/// <param name="TransactionID">
		/// The transaction ID associated with the sale record. If not specified, either
		/// ItemID or OrderID must be specified.
		/// </param>
		///
		/// <param name="OrderID">
		/// The order ID associated with the sale record.
		/// If specified, then the following, if specified in the same call, are ignored:
		/// ItemID and TransactionID.
		/// </param>
		///
		public SellingManagerSoldOrderType GetSellingManagerSaleRecord(string ItemID, string TransactionID, string OrderID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;

			Execute();
			return ApiResponse.SellingManagerSoldOrder;
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
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType"/> for this API call.
		/// </summary>
		public GetSellingManagerSaleRecordRequestType ApiRequest
		{ 
			get { return (GetSellingManagerSaleRecordRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellingManagerSaleRecordResponseType"/> for this API call.
		/// </summary>
		public GetSellingManagerSaleRecordResponseType ApiResponse
		{ 
			get { return (GetSellingManagerSaleRecordResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerSaleRecordRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellingManagerSaleRecordResponseType.SellingManagerSoldOrder"/> of type <see cref="SellingManagerSoldOrderType"/>.
		/// </summary>
		public SellingManagerSoldOrderType SellingManagerSoldOrder
		{ 
			get { return ApiResponse.SellingManagerSoldOrder; }
		}
		

		#endregion

		
	}
}
