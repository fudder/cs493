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
	public class SetPromotionalSaleListingsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetPromotionalSaleListingsCall()
		{
			ApiRequest = new SetPromotionalSaleListingsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetPromotionalSaleListingsCall(ApiContext ApiContext)
		{
			ApiRequest = new SetPromotionalSaleListingsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Changes which item listings are affected by a promotional sale.
		/// </summary>
		/// 
		/// <param name="PromotionalSaleID">
		/// The ID of the promotional sale that you want to add listings to or
		/// delete listings from. 
		/// </param>
		///
		/// <param name="Action">
		/// You must specify either Add or Delete.
		/// 
		/// This field determines whether you are adding listings to, or deleting listings from, the
		/// promotional sale you specify in the PromotionalSaleID field.
		/// 
		/// If you specify Delete, you must specify PromotionalSaleItemIDArray. Delete is applicable
		/// only in cases where you specify PromotionalSaleItemIDArray. Auction or auction/BIN format
		/// listings cannot be added to or deleted from a promotional sale if the item has bids.
		/// </param>
		///
		/// <param name="PromotionalSaleItemIDArrayList">
		/// The IDs of the item listings to be affected
		/// by the action you specify in the Action field.
		/// </param>
		///
		/// <param name="StoreCategoryID">
		/// Adds to the promotional sale all the seller's item listings with
		/// the StoreCategoryID specified in this field.
		/// Requires that you specify Add in the Action field.
		/// </param>
		///
		/// <param name="CategoryID">
		/// Adds to the promotional sale all the seller's item listings with
		/// the CategoryID specified in this field. 
		/// Requires that you specify Add in the Action field.
		/// </param>
		///
		/// <param name="AllFixedPriceItems">
		/// Adds to the promotional sale all the seller's item listings 
		/// that are fixed price items.
		/// Requires that you specify Add in the Action field.
		/// </param>
		///
		/// <param name="AllStoreInventoryItems">
		/// Adds to the promotional sale all the seller's item listings 
		/// that are store inventory items.
		/// Requires that you specify Add in the Action field.
		/// </param>
		///
		/// <param name="AllAuctionItems">
		/// Adds to the promotional sale all the seller's item listings 
		/// that are auction items. Auction and auction/BIN format listings
		/// can be added to free shipping sales only. 
		/// Requires that you specify Add in the Action field.
		/// </param>
		///
		public PromotionalSaleStatusCodeType SetPromotionalSaleListings(long PromotionalSaleID, ModifyActionCodeType Action, ItemIDArrayType PromotionalSaleItemIDArrayList, long StoreCategoryID, long CategoryID, bool AllFixedPriceItems, bool AllStoreInventoryItems, bool AllAuctionItems)
		{
			this.PromotionalSaleID = PromotionalSaleID;
			this.Action = Action;
			this.PromotionalSaleItemIDArrayList = PromotionalSaleItemIDArrayList;
			this.StoreCategoryID = StoreCategoryID;
			this.CategoryID = CategoryID;
			this.AllFixedPriceItems = AllFixedPriceItems;
			this.AllStoreInventoryItems = AllStoreInventoryItems;
			this.AllAuctionItems = AllAuctionItems;

			Execute();
			return ApiResponse.Status;
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
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType"/> for this API call.
		/// </summary>
		public SetPromotionalSaleListingsRequestType ApiRequest
		{ 
			get { return (SetPromotionalSaleListingsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetPromotionalSaleListingsResponseType"/> for this API call.
		/// </summary>
		public SetPromotionalSaleListingsResponseType ApiResponse
		{ 
			get { return (SetPromotionalSaleListingsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.PromotionalSaleID"/> of type <see cref="long"/>.
		/// </summary>
		public long PromotionalSaleID
		{ 
			get { return ApiRequest.PromotionalSaleID; }
			set { ApiRequest.PromotionalSaleID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.Action"/> of type <see cref="ModifyActionCodeType"/>.
		/// </summary>
		public ModifyActionCodeType Action
		{ 
			get { return ApiRequest.Action; }
			set { ApiRequest.Action = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.PromotionalSaleItemIDArray"/> of type <see cref="ItemIDArrayType"/>.
		/// </summary>
		public ItemIDArrayType PromotionalSaleItemIDArrayList
		{ 
			get { return ApiRequest.PromotionalSaleItemIDArray; }
			set { ApiRequest.PromotionalSaleItemIDArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.StoreCategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long StoreCategoryID
		{ 
			get { return ApiRequest.StoreCategoryID; }
			set { ApiRequest.StoreCategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.CategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long CategoryID
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.AllFixedPriceItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AllFixedPriceItems
		{ 
			get { return ApiRequest.AllFixedPriceItems; }
			set { ApiRequest.AllFixedPriceItems = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.AllStoreInventoryItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AllStoreInventoryItems
		{ 
			get { return ApiRequest.AllStoreInventoryItems; }
			set { ApiRequest.AllStoreInventoryItems = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPromotionalSaleListingsRequestType.AllAuctionItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AllAuctionItems
		{ 
			get { return ApiRequest.AllAuctionItems; }
			set { ApiRequest.AllAuctionItems = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="SetPromotionalSaleListingsResponseType.Status"/> of type <see cref="PromotionalSaleStatusCodeType"/>.
		/// </summary>
		public PromotionalSaleStatusCodeType Status
		{ 
			get { return ApiResponse.Status; }
		}
		

		#endregion

		
	}
}
