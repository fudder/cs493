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
	public class CompleteSaleCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public CompleteSaleCall()
		{
			ApiRequest = new CompleteSaleRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public CompleteSaleCall(ApiContext ApiContext)
		{
			ApiRequest = new CompleteSaleRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to do various tasks after an item transaction or multiple-item
		/// order has been created. Task examples include leaving feedback for the buyer,
		/// changing the paid status, and setting shipment tracking information.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// ID of the listing associated with the transaction that the seller is
		/// completing.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for a transaction from the listing indicated by ItemID.
		/// Call GetItemTransactions or GetSellerTransactions to determine the
		/// appropriate transaction ID. Required for all listing types (pass 0 for
		/// Chinese auctions).
		/// </param>
		///
		/// <param name="FeedbackInfo">
		/// Specifies feedback the seller is leaving for the buyer. The seller can leave
		/// feedback once for a given transaction, and no further modifications can be
		/// made to that feedback entry. If feedback has already been left, FeedbackInfo
		/// is not allowed. Call GetFeedback to determine whether feedback has already
		/// been left.
		/// </param>
		///
		/// <param name="Shipped">
		/// If true, the transaction is marked as shipped in My eBay.
		/// 
		/// If false, the transaction is marked as not shipped in My eBay.
		/// 
		/// If not specified, the shipped status in My eBay is not modified.
		/// </param>
		///
		/// <param name="Paid">
		/// If true, the transaction is marked as paid in My eBay.
		/// 
		/// If false, the transaction is marked as not paid in My eBay.
		/// 
		/// If not specified, the paid status in My eBay is not modified.
		/// </param>
		///
		/// <param name="ListingType">
		/// If included in the request, and with a value of ListingType = Half,
		/// indicates that the given ItemID and TransactionID values are for Half.com.
		/// 
		/// Required for Half.com items.
		/// </param>
		///
		/// <param name="Shipment">
		/// Details about the shipment. Setting the tracking number and carrier
		/// automatically marks the item as shipped (sets Shipped to true).
		/// </param>
		///
		/// <param name="OrderID">
		/// Unique ID for a multi-item order. ItemID and TransactionID are ignored if a
		/// call includes OrderID. CompleteSale applies to the specified order as a
		/// whole (and thus the child transactions associated with the order).
		/// 
		/// Not applicable to Half.com.
		/// </param>
		///
		public void CompleteSale(string ItemID, string TransactionID, FeedbackInfoType FeedbackInfo, bool Shipped, bool Paid, ListingTypeCodeType ListingType, ShipmentType Shipment, string OrderID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.FeedbackInfo = FeedbackInfo;
			this.Shipped = Shipped;
			this.Paid = Paid;
			this.ListingType = ListingType;
			this.Shipment = Shipment;
			this.OrderID = OrderID;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void CompleteSale(string ItemID, string TransactionID, bool Paid, bool Shipped, FeedbackInfoType FeedbackInfo)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.Paid = Paid;
			this.Shipped = Shipped;
			this.FeedbackInfo = FeedbackInfo;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void CompleteSale(string ItemID, string TransactionID, bool Paid, bool Shipped)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.Paid = Paid;
			this.Shipped = Shipped;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>

		public void CompleteSale(string ItemID, string TransactionID, FeedbackInfoType FeedbackInfo, bool Shipped, bool Paid)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.FeedbackInfo = FeedbackInfo;
			this.Shipped = Shipped;
			this.Paid = Paid;

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
		/// Gets or sets the <see cref="CompleteSaleRequestType"/> for this API call.
		/// </summary>
		public CompleteSaleRequestType ApiRequest
		{ 
			get { return (CompleteSaleRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="CompleteSaleResponseType"/> for this API call.
		/// </summary>
		public CompleteSaleResponseType ApiResponse
		{ 
			get { return (CompleteSaleResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.FeedbackInfo"/> of type <see cref="FeedbackInfoType"/>.
		/// </summary>
		public FeedbackInfoType FeedbackInfo
		{ 
			get { return ApiRequest.FeedbackInfo; }
			set { ApiRequest.FeedbackInfo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.Shipped"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Shipped
		{ 
			get { return ApiRequest.Shipped; }
			set { ApiRequest.Shipped = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.Paid"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Paid
		{ 
			get { return ApiRequest.Paid; }
			set { ApiRequest.Paid = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.ListingType"/> of type <see cref="ListingTypeCodeType"/>.
		/// </summary>
		public ListingTypeCodeType ListingType
		{ 
			get { return ApiRequest.ListingType; }
			set { ApiRequest.ListingType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.Shipment"/> of type <see cref="ShipmentType"/>.
		/// </summary>
		public ShipmentType Shipment
		{ 
			get { return ApiRequest.Shipment; }
			set { ApiRequest.Shipment = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
		

		#endregion

		
	}
}
