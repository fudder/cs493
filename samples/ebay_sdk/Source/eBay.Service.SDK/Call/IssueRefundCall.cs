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
	public class IssueRefundCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public IssueRefundCall()
		{
			ApiRequest = new IssueRefundRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public IssueRefundCall(ApiContext ApiContext)
		{
			ApiRequest = new IssueRefundRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Issues a refund for a single Half.com transaction. This can only be
		/// called by a seller. A refund may only be issued for a specific
		/// transaction. Sellers do not have the ability to issue a general
		/// refund (a refund not tied to a transaction) to a buyer.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// ID of the Half.com item associated with the refund payment to the buyer.
		/// To uniquely identify a transaction, you need to specify both ItemID
		/// and TransactionID. Use GetSellerPayments to determine the item ID
		/// and transaction ID associated with the original sale payment.
		/// </param>
		///
		/// <param name="TransactionID">
		/// ID of the Half.com transaction associated with the refund payment.
		/// To uniquely identify a transaction, you need to specify both ItemID
		/// and TransactionID. Use GetSellerPayments to determine the item ID
		/// and transaction ID associated with the original sale payment.
		/// </param>
		///
		/// <param name="RefundReason">
		/// Explanation of the reason that the refund is being issued.
		/// </param>
		///
		/// <param name="RefundType">
		/// Explanation of the costs that the refund amount covers.
		/// </param>
		///
		/// <param name="RefundAmount">
		/// The amount the seller wants to refund to the buyer, in US Dollars (USD).
		/// Must be greater than 0.00. Half.com allows a maximum of the original item
		/// sale price (transaction price plus original shipping reimbursement) plus
		/// return shipping costs (the amount the buyer paid to return the item).
		/// Typically, the return shipping cost is based on the current cost of
		/// shipping the individual item (not the discounted cost calculated during
		/// the original checkout for a multi-item order). You can also issue a
		/// partial refund for the amount you want the buyer to receive. If
		/// RefundType=Full or RefundType=FullPlusShipping and you do not pass
		/// RefundAmount in the request, Half.com will calculate the refund amount for
		/// you. If you pass RefundAmount in the request, the amount you specify will
		/// override Half.com's calculated value. Required if RefundType=
		/// CustomOrPartial.
		/// </param>
		///
		/// <param name="RefundMessage">
		/// Note to the buyer. Cannot include HTML.
		/// </param>
		///
		public AmountType IssueRefund(string ItemID, string TransactionID, RefundReasonCodeType RefundReason, RefundTypeCodeType RefundType, AmountType RefundAmount, string RefundMessage)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.RefundReason = RefundReason;
			this.RefundType = RefundType;
			this.RefundAmount = RefundAmount;
			this.RefundMessage = RefundMessage;

			Execute();
			return ApiResponse.RefundFromSeller;
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
		/// Gets or sets the <see cref="IssueRefundRequestType"/> for this API call.
		/// </summary>
		public IssueRefundRequestType ApiRequest
		{ 
			get { return (IssueRefundRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="IssueRefundResponseType"/> for this API call.
		/// </summary>
		public IssueRefundResponseType ApiResponse
		{ 
			get { return (IssueRefundResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="IssueRefundRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="IssueRefundRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="IssueRefundRequestType.RefundReason"/> of type <see cref="RefundReasonCodeType"/>.
		/// </summary>
		public RefundReasonCodeType RefundReason
		{ 
			get { return ApiRequest.RefundReason; }
			set { ApiRequest.RefundReason = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="IssueRefundRequestType.RefundType"/> of type <see cref="RefundTypeCodeType"/>.
		/// </summary>
		public RefundTypeCodeType RefundType
		{ 
			get { return ApiRequest.RefundType; }
			set { ApiRequest.RefundType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="IssueRefundRequestType.RefundAmount"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType RefundAmount
		{ 
			get { return ApiRequest.RefundAmount; }
			set { ApiRequest.RefundAmount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="IssueRefundRequestType.RefundMessage"/> of type <see cref="string"/>.
		/// </summary>
		public string RefundMessage
		{ 
			get { return ApiRequest.RefundMessage; }
			set { ApiRequest.RefundMessage = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="IssueRefundResponseType.RefundFromSeller"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType RefundFromSeller
		{ 
			get { return ApiResponse.RefundFromSeller; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="IssueRefundResponseType.TotalRefundToBuyer"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType TotalRefundToBuyer
		{ 
			get { return ApiResponse.TotalRefundToBuyer; }
		}
		

		#endregion

		
	}
}
