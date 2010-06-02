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
	public class AddDisputeResponseCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddDisputeResponseCall()
		{
			ApiRequest = new AddDisputeResponseRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddDisputeResponseCall(ApiContext ApiContext)
		{
			ApiRequest = new AddDisputeResponseRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Allows a seller to respond to or close an Item Not Received dispute.
		/// This can be used to add a comment to an Unpaid Item Dispute
		/// only if the request version was lower than 637 when the
		/// dispute was created.
		/// </summary>
		/// 
		/// <param name="DisputeID">
		/// The unique identifier of the dispute,
		/// returned when the dispute was created.
		/// </param>
		///
		/// <param name="MessageText">
		/// The text of a comment or response being posted to the dispute. Required
		/// when DisputeActivity is SellerAddInformation, SellerComment, or
		/// SellerPaymentNotReceived; otherwise, optional.
		/// </param>
		///
		/// <param name="DisputeActivity">
		/// The type of activity the seller is taking on the dispute.
		/// The allowed value is determined by the current value of
		/// DisputeState, returned by GetDispute or GetUserDisputes.
		/// Some values are for Unpaid Item disputes and some are for Item
		/// Not Received disputes.
		/// </param>
		///
		/// <param name="ShippingCarrierUsed">
		/// The shipping carrier used for the item in dispute. Required if DisputeActivity
		/// is SellerShippedItem; otherwise, optional.
		/// </param>
		///
		/// <param name="ShipmentTrackNumber">
		/// The shipper's tracking number for the item being shipped. Required
		/// if DisputeActivity is SellerShippedItem; otherwise, optional.
		/// </param>
		///
		/// <param name="ShippingTime">
		/// The date the item under dispute was shipped. Required if DisputeActivity
		/// is SellerShippedItem; otherwise, optional.
		/// </param>
		///
		public void AddDisputeResponse(string DisputeID, string MessageText, DisputeActivityCodeType DisputeActivity, string ShippingCarrierUsed, string ShipmentTrackNumber, DateTime ShippingTime)
		{
			this.DisputeID = DisputeID;
			this.MessageText = MessageText;
			this.DisputeActivity = DisputeActivity;
			this.ShippingCarrierUsed = ShippingCarrierUsed;
			this.ShipmentTrackNumber = ShipmentTrackNumber;
			this.ShippingTime = ShippingTime;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void AddDisputeResponse(string DisputeID, string MessageText, DisputeActivityCodeType DisputeActivity)
		{
			this.DisputeID = DisputeID;
			this.MessageText = MessageText;
			this.DisputeActivity = DisputeActivity;
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
		/// Gets or sets the <see cref="AddDisputeResponseRequestType"/> for this API call.
		/// </summary>
		public AddDisputeResponseRequestType ApiRequest
		{ 
			get { return (AddDisputeResponseRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddDisputeResponseResponseType"/> for this API call.
		/// </summary>
		public AddDisputeResponseResponseType ApiResponse
		{ 
			get { return (AddDisputeResponseResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeResponseRequestType.DisputeID"/> of type <see cref="string"/>.
		/// </summary>
		public string DisputeID
		{ 
			get { return ApiRequest.DisputeID; }
			set { ApiRequest.DisputeID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeResponseRequestType.MessageText"/> of type <see cref="string"/>.
		/// </summary>
		public string MessageText
		{ 
			get { return ApiRequest.MessageText; }
			set { ApiRequest.MessageText = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeResponseRequestType.DisputeActivity"/> of type <see cref="DisputeActivityCodeType"/>.
		/// </summary>
		public DisputeActivityCodeType DisputeActivity
		{ 
			get { return ApiRequest.DisputeActivity; }
			set { ApiRequest.DisputeActivity = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeResponseRequestType.ShippingCarrierUsed"/> of type <see cref="string"/>.
		/// </summary>
		public string ShippingCarrierUsed
		{ 
			get { return ApiRequest.ShippingCarrierUsed; }
			set { ApiRequest.ShippingCarrierUsed = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeResponseRequestType.ShipmentTrackNumber"/> of type <see cref="string"/>.
		/// </summary>
		public string ShipmentTrackNumber
		{ 
			get { return ApiRequest.ShipmentTrackNumber; }
			set { ApiRequest.ShipmentTrackNumber = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddDisputeResponseRequestType.ShippingTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ShippingTime
		{ 
			get { return ApiRequest.ShippingTime; }
			set { ApiRequest.ShippingTime = value; }
		}
		
		

		#endregion

		
	}
}
