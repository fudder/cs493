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
	public class GetBestOffersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetBestOffersCall()
		{
			ApiRequest = new GetBestOffersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetBestOffersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetBestOffersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the best offers associated with an ItemID according to the
		/// BestOfferStatus filter (the default is Active).
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The item for which Best Offer information is to be returned.
		/// If you are a buyer and you have a valid best offer,
		/// then your best-offer information will be returned for the item you specify.
		/// </param>
		///
		/// <param name="BestOfferID">
		/// Need not be specified by a buyer or a seller.
		/// The BestOfferID is the specific Best Offer you want information about.
		/// If you are the seller, you can get a list of all best offers
		/// (according to BestOfferStatus) by omitting this field.
		/// </param>
		///
		/// <param name="BestOfferStatus">
		/// A filter that specifies which Best Offers to return for an item (such as countered,
		/// expired, or accepted). Active is the default.
		/// </param>
		///
		/// <param name="Pagination">
		/// Specifies how to create virtual pages in the returned list (such as total
		/// number of entries and total number of pages to return).
		/// Default for EntriesPerPage with GetBestOffers is 20.
		/// </param>
		///
		public BestOfferTypeCollection GetBestOffers(string ItemID, string BestOfferID, BestOfferStatusCodeType BestOfferStatus, PaginationType Pagination)
		{
			this.ItemID = ItemID;
			this.BestOfferID = BestOfferID;
			this.BestOfferStatus = BestOfferStatus;
			this.Pagination = Pagination;

			Execute();
			return ApiResponse.BestOfferArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public BestOfferTypeCollection GetBestOffers(string ItemID)
		{
			this.ItemID = ItemID;
			Execute();
			return BestOfferList;
		}
		
		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.ItemBestOffersArray"/> of type <see cref="ItemBestOffersTypeCollection"/>.
		/// </summary>
		public ItemBestOffersTypeCollection ItemBestOffersList
		{ 
			get {
				if (ApiResponse.ItemBestOffersArray == null)
					return null;
				return ApiResponse.ItemBestOffersArray.ItemBestOffers; }
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
		/// Gets or sets the <see cref="GetBestOffersRequestType"/> for this API call.
		/// </summary>
		public GetBestOffersRequestType ApiRequest
		{ 
			get { return (GetBestOffersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetBestOffersResponseType"/> for this API call.
		/// </summary>
		public GetBestOffersResponseType ApiResponse
		{ 
			get { return (GetBestOffersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.BestOfferID"/> of type <see cref="string"/>.
		/// </summary>
		public string BestOfferID
		{ 
			get { return ApiRequest.BestOfferID; }
			set { ApiRequest.BestOfferID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.BestOfferStatus"/> of type <see cref="BestOfferStatusCodeType"/>.
		/// </summary>
		public BestOfferStatusCodeType BestOfferStatus
		{ 
			get { return ApiRequest.BestOfferStatus; }
			set { ApiRequest.BestOfferStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.BestOfferArray"/> of type <see cref="BestOfferTypeCollection"/>.
		/// </summary>
		public BestOfferTypeCollection BestOfferList
		{ 
			get { return ApiResponse.BestOfferArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiResponse.Item; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.ItemBestOffersArray"/> of type <see cref="ItemBestOffersArrayType"/>.
		/// </summary>
		public ItemBestOffersArrayType ItemBestOffersArray
		{ 
			get { return ApiResponse.ItemBestOffersArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		

		#endregion

		
	}
}
