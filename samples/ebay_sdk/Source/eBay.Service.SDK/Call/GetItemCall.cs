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
	public class GetItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetItemCall()
		{
			ApiRequest = new GetItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetItemCall(ApiContext ApiContext)
		{
			ApiRequest = new GetItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns item data (title, description, price information, seller information, and so on)
		/// for the specified item ID.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Specifies the item ID that uniquely identifies the item listing for which
		/// to retrieve the data.
		/// 
		/// ItemID is a required input in most cases. SKU can be used instead in certain
		/// cases (see the description of SKU). If both ItemID and SKU are specified for
		/// items where the inventory tracking method is ItemID, ItemID takes precedence.
		/// </param>
		///
		/// <param name="IncludeWatchCount">
		/// Indicates if the caller wants to include watch count for that item in the
		/// response. You must be the seller of the item to retrieve the watch count.
		/// </param>
		///
		/// <param name="IncludeCrossPromotion">
		/// Specifies whether or not to include cross-promotion information for
		/// the item in the call response.
		/// 
		/// With a request version of 485 or higher, the default is false (do not
		/// include cross-promotion details). Set to true to retrieve cross-promotion
		/// information for the item. Cross-promotion information is returned in
		/// Item.CrossPromotion.PromotedItem.PromotionDetails.
		/// A promoted item will now contain multiple PromotionDetails containers.
		/// 
		/// With a request version lower than 485, the default is true (include
		/// cross-promotions). Set the value to false if you do not want to retrieve
		/// cross-promotion information. Cross-promotion information, PromotedPrice
		/// and PromotedPriceType, are returned in Item.CrossPromotion.PromotedItem.
		/// If a promoted item has multiple PromotedPriceType and PromotedPrice value
		/// pairs, only the last pair is returned.
		/// </param>
		///
		/// <param name="IncludeItemSpecifics">
		/// If true, the response returns the ItemSpecifics node
		/// (if the listing has custom Item Specifics).
		/// 
		/// Item Specifics are well-known aspects of items in a given
		/// category. For example, items in a washer and dryer category
		/// might have an aspect like Type=Top-Loading; whereas
		/// items in a jewelry category might have an aspect like
		/// Gemstone=Amber.
		/// 
		/// (This does not cause the response to include ID-based
		/// attributes. To also retrieve ID-based attributes,
		/// pass DetailLevel in the request with the value
		/// ItemReturnAttributes or ReturnAll.)
		/// </param>
		///
		/// <param name="IncludeTaxTable">
		/// If true, an associated tax table is returned in the response.
		/// If no tax table is associated with the item, then no
		/// tax table is returned, even if IncludeTaxTable is set to true.
		/// </param>
		///
		/// <param name="SKU">
		/// Retrieves an item that was listed by the user identified
		/// in AuthToken and that is being tracked by this SKU.
		/// 
		/// A SKU (stock keeping unit) is an identifier defined by a seller.
		/// Some sellers use SKUs to track complex flows of products
		/// and information on the client side.
		/// eBay preserves the SKU on the item, enabling you
		/// to obtain it before and after a transaction is created.
		/// (SKU is recommended as an alternative to
		/// ApplicationData.)
		/// 
		/// In GetItem, SKU can only be used to retrieve one of your
		/// own items, where you listed the item by using AddFixedPriceItem
		/// or RelistFixedPriceItem,
		/// and you set Item.InventoryTrackingMethod to SKU at
		/// the time the item was listed. (These criteria are necessary to
		/// uniquely identify the listing by a SKU.)
		/// 
		/// Either ItemID or SKU is required in the request.
		/// If both are passed, they must refer to the same item,
		/// and that item must have InventoryTrackingMethod set to SKU.
		/// </param>
		///
		/// <param name="VariationSKU">
		/// Variation-level SKU that uniquely identifes a Variation within
		/// the listing identified by ItemID. Only applicable when the
		/// seller listed the item with Variation-level SKU (Variation.SKU)
		/// values. Retrieves all the usual Item fields, but limits the
		/// Variations content to the specified Variation.
		/// If not specified, the response includes all Variations.
		/// </param>
		///
		/// <param name="VariationSpecificList">
		/// Name-value pairs that identify one or more Variations within the
		/// listing identified by ItemID. Only applicable when the seller
		/// listed the item with Variations. Retrieves all the usual Item
		/// fields, but limits the Variations content to the specified
		/// Variation(s). If the specified pairs do not match any Variation,
		/// eBay returns all Variations.
		/// 
		/// To retrieve only one variation, specify the full set of
		/// name/value pairs that match all the name-value pairs of one
		/// Variation. 
		/// 
		/// To retrieve multiple variations (using a wildcard),
		/// specify one or more name/value pairs that partially match the
		/// desired variations. For example, if the listing contains
		/// Variations for shirts in different colors and sizes, specify
		/// Color as Red (and no other name/value pairs) to retrieve
		/// all the red shirts in all sizes (but no other colors).
		/// </param>
		///
		/// <param name="TransactionID">
		/// Identifies a single transaction for a listing. A transaction begins when
		/// a winning bidder or buyer is determined, and ends when the buyer finishes
		/// the checkout process.
		/// 
		/// Since you can change active multiple-quantity fixed price listings
		/// even after one of the items has been purchased, the transaction ID is associated
		/// with a snapshot of the item data at the time of the purchase.
		/// 
		/// After one item in a multi-quantity listing has been sold, sellers can not change
		/// the values in the Title, Primary Category, Secondary Category, Listing Duration,
		/// and Listing Type fields. However, all other fields are editable.
		/// 
		/// Specifying a TransactionID in the GetItemRequest allows you to retrieve
		/// a snapshot of the listing as it was when the transaction was created.
		/// </param>
		///
		/// <param name="IncludeItemCompatibilityList">
		/// This field is used for Parts Compatiblity, which is currently supported
		/// for limited categories in the Sandbox only. For more information, please
		/// see the <a
		/// href="http://developer.ebay.com/DevZone/XML/docs/WebHelp/ReleaseNotes.html#653PartsCompatibility"
		/// >release notes</a>.
		/// 
		/// If true, any compatible applications associated with the item will be
		/// returned in the response (<b
		/// class="con">Item.ItemCompatibilityList</b>). If no compatible
		/// applications have been specified for the item, then no item
		/// compatibilities will be returned.
		/// 
		/// If false or not specified, the response will return a compatibility count
		/// (ItemCompatibilityCount) when parts compatibilities have been specified
		/// for the item.
		/// </param>
		///
		public ItemType GetItem(string ItemID, bool IncludeWatchCount, bool IncludeCrossPromotion, bool IncludeItemSpecifics, bool IncludeTaxTable, string SKU, string VariationSKU, NameValueListTypeCollection VariationSpecificList, string TransactionID, bool IncludeItemCompatibilityList)
		{
			this.ItemID = ItemID;
			this.IncludeWatchCount = IncludeWatchCount;
			this.IncludeCrossPromotion = IncludeCrossPromotion;
			this.IncludeItemSpecifics = IncludeItemSpecifics;
			this.IncludeTaxTable = IncludeTaxTable;
			this.SKU = SKU;
			this.VariationSKU = VariationSKU;
			this.VariationSpecificList = VariationSpecificList;
			this.TransactionID = TransactionID;
			this.IncludeItemCompatibilityList = IncludeItemCompatibilityList;

			Execute();
			return ApiResponse.Item;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemType GetItem(string ItemID)
		{
			this.ItemID = ItemID;
			Execute();
			return Item;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemType GetItem(string ItemID, bool IncludeWatchCount)
		{
			this.ItemID = ItemID;
			this.IncludeWatchCount = IncludeWatchCount;

			Execute();
			return ApiResponse.Item;
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
		/// Gets or sets the <see cref="GetItemRequestType"/> for this API call.
		/// </summary>
		public GetItemRequestType ApiRequest
		{ 
			get { return (GetItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetItemResponseType"/> for this API call.
		/// </summary>
		public GetItemResponseType ApiResponse
		{ 
			get { return (GetItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeWatchCount"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeWatchCount
		{ 
			get { return ApiRequest.IncludeWatchCount; }
			set { ApiRequest.IncludeWatchCount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeCrossPromotion"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeCrossPromotion
		{ 
			get { return ApiRequest.IncludeCrossPromotion; }
			set { ApiRequest.IncludeCrossPromotion = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeItemSpecifics"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeItemSpecifics
		{ 
			get { return ApiRequest.IncludeItemSpecifics; }
			set { ApiRequest.IncludeItemSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeTaxTable"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeTaxTable
		{ 
			get { return ApiRequest.IncludeTaxTable; }
			set { ApiRequest.IncludeTaxTable = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiRequest.SKU; }
			set { ApiRequest.SKU = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.VariationSKU"/> of type <see cref="string"/>.
		/// </summary>
		public string VariationSKU
		{ 
			get { return ApiRequest.VariationSKU; }
			set { ApiRequest.VariationSKU = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.VariationSpecifics"/> of type <see cref="NameValueListTypeCollection"/>.
		/// </summary>
		public NameValueListTypeCollection VariationSpecificList
		{ 
			get { return ApiRequest.VariationSpecifics; }
			set { ApiRequest.VariationSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeItemCompatibilityList"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeItemCompatibilityList
		{ 
			get { return ApiRequest.IncludeItemCompatibilityList; }
			set { ApiRequest.IncludeItemCompatibilityList = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemResponseType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiResponse.Item; }
		}
		

		#endregion

		
	}
}
