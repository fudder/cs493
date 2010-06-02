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
	public class GetHighBiddersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetHighBiddersCall()
		{
			ApiRequest = new GetHighBiddersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetHighBiddersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetHighBiddersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a list of high bidders for the Dutch auction specified in the ItemId
		/// property of the request. A seller specifies a unique item ID in this call to
		/// determine which buyers are winning bidders and how many items each buyer can
		/// purchase. Note that bidder information is anonymous to everyone except the bidder and
		/// the seller during an active auction.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique item ID that identifies the Dutch auction listing for which to
		/// retrieve a list of the high bidders.
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
		public OfferTypeCollection GetHighBidders(string ItemID)
		{
			this.ItemID = ItemID;

			Execute();
			return ApiResponse.BidArray;
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
		/// Gets or sets the <see cref="GetHighBiddersRequestType"/> for this API call.
		/// </summary>
		public GetHighBiddersRequestType ApiRequest
		{ 
			get { return (GetHighBiddersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetHighBiddersResponseType"/> for this API call.
		/// </summary>
		public GetHighBiddersResponseType ApiResponse
		{ 
			get { return (GetHighBiddersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetHighBiddersRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetHighBiddersResponseType.BidArray"/> of type <see cref="OfferTypeCollection"/>.
		/// </summary>
		public OfferTypeCollection BidList
		{ 
			get { return ApiResponse.BidArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetHighBiddersResponseType.ListingStatus"/> of type <see cref="ListingStatusCodeType"/>.
		/// </summary>
		public ListingStatusCodeType ListingStatus
		{ 
			get { return ApiResponse.ListingStatus; }
		}
		

		#endregion

		
	}
}
