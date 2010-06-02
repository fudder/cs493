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
	public class AddDisputeCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddDisputeCall()
		{
			ApiRequest = new AddDisputeRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddDisputeCall(ApiContext ApiContext)
		{
			ApiRequest = new AddDisputeRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to create a new Unpaid Item dispute. (Item Not Received
		/// disputes can only be created via the eBay web site.)
		/// </summary>
		/// 
		/// <param name="DisputeExplanation">
		/// An explanation of the dispute that supplements the
		/// DisputeReason. The allowed value depends on the value of
		/// DisputeReason.
		/// </param>
		///
		/// <param name="DisputeReason">
		/// The top-level reason for the Unpaid Item Dispute.
		/// DisputeReasonCodeType has several possible values. However, only
		/// BuyerHasNotPaid and TransactionMutuallyCanceled apply to
		/// AddDispute--you can only use AddDisputeCall to create Unpaid
		/// Item disputes.
		/// </param>
		///
		/// <param name="ItemID">
		/// The eBay ID of the item in dispute, an item which has been
		/// sold but not yet paid for.
		/// </param>
		///
		/// <param name="TransactionID">
		/// The eBay ID of a transaction, created when the buyer committed
		/// to purchasing the item. A transaction ID is unique to the item
		/// but not across the entire eBay site. The transaction ID must be
		/// combined with an item ID to uniquely identify an item.
		/// </param>
		///
		public string AddDispute(DisputeExplanationCodeType DisputeExplanation, DisputeReasonCodeType DisputeReason, string ItemID, string TransactionID)
		{
			this.DisputeExplanation = DisputeExplanation;
			this.DisputeReason = DisputeReason;
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;

			Execute();
			return ApiResponse.DisputeID;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public string AddDispute(string ItemID, string TransactionID, DisputeReasonCodeType DisputeReason, DisputeExplanationCodeType DisputeExplanation)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.DisputeReason = DisputeReason;
			this.DisputeExplanation = DisputeExplanation;
			Execute();
			return this.DisputeID;
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
		/// Gets or sets the <see cref="AddDisputeRequestType"/> for this API call.
		/// </summary>
		public AddDisputeRequestType ApiRequest
		{ 
			get { return (AddDisputeRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddDisputeResponseType"/> for this API call.
		/// </summary>
		public AddDisputeResponseType ApiResponse
		{ 
			get { return (AddDisputeResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeRequestType.DisputeExplanation"/> of type <see cref="DisputeExplanationCodeType"/>.
		/// </summary>
		public DisputeExplanationCodeType DisputeExplanation
		{ 
			get { return ApiRequest.DisputeExplanation; }
			set { ApiRequest.DisputeExplanation = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeRequestType.DisputeReason"/> of type <see cref="DisputeReasonCodeType"/>.
		/// </summary>
		public DisputeReasonCodeType DisputeReason
		{ 
			get { return ApiRequest.DisputeReason; }
			set { ApiRequest.DisputeReason = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddDisputeResponseType.DisputeID"/> of type <see cref="string"/>.
		/// </summary>
		public string DisputeID
		{ 
			get { return ApiResponse.DisputeID; }
		}
		

		#endregion

		
	}
}
