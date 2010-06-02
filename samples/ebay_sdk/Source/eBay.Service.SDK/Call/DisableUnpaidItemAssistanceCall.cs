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
	public class DisableUnpaidItemAssistanceCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public DisableUnpaidItemAssistanceCall()
		{
			ApiRequest = new DisableUnpaidItemAssistanceRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public DisableUnpaidItemAssistanceCall(ApiContext ApiContext)
		{
			ApiRequest = new DisableUnpaidItemAssistanceRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller who has opted into the automated Unpaid Item Assistance mechanism
		/// to disable that Assistance for an item. The item is identified either by its item
		/// ID / transaction ID pair (regardless of whether a dispute ID yet exists for that
		/// item) or, if a dispute has been created by the Assistance	mechanism, by the
		/// DisputeID. If a dispute had already been created by the Assistance mechanism, it
		/// is converted to a "manual" dispute for the seller to manage like any other
		/// manually-created dispute. disputes.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The eBay ID of the item to exclude from the automated Unpaid Item
		/// Assistance mechanism.  If ItemID is provided, TransactionID
		/// must be provided. The ItemID/TransactionID pairing of tags is
		/// mutually exclusive with DisputeID: provide the pair or
		/// provide DisputeID, but not both.
		/// </param>
		///
		/// <param name="TransactionID">
		/// The eBay ID of a transaction, created when the buyer committed
		/// to purchasing the item. A transaction ID is unique to the item
		/// but not across the entire eBay site. The transaction ID must be
		/// combined with an item ID to uniquely identify an item.
		/// The ItemID/TransactionID pairing of tags is
		/// mutually exclusive with DisputeID: provide the pair or
		/// provide DisputeID, but not both.
		/// </param>
		///
		/// <param name="DisputeID">
		/// The ID for a dispute created by the Unpaid Item Assistance Mechanism.
		/// Mutually exclusive with the ItemID/TransactionID pair.
		/// </param>
		///
		public void DisableUnpaidItemAssistance(string ItemID, string TransactionID, string DisputeID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.DisputeID = DisputeID;

			Execute();
			
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
		/// Gets or sets the <see cref="DisableUnpaidItemAssistanceRequestType"/> for this API call.
		/// </summary>
		public DisableUnpaidItemAssistanceRequestType ApiRequest
		{ 
			get { return (DisableUnpaidItemAssistanceRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="DisableUnpaidItemAssistanceResponseType"/> for this API call.
		/// </summary>
		public DisableUnpaidItemAssistanceResponseType ApiResponse
		{ 
			get { return (DisableUnpaidItemAssistanceResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="DisableUnpaidItemAssistanceRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="DisableUnpaidItemAssistanceRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="DisableUnpaidItemAssistanceRequestType.DisputeID"/> of type <see cref="string"/>.
		/// </summary>
		public string DisputeID
		{ 
			get { return ApiRequest.DisputeID; }
			set { ApiRequest.DisputeID = value; }
		}
		
		

		#endregion

		
	}
}
