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
	public class GetUserPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetUserPreferencesCall()
		{
			ApiRequest = new GetUserPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetUserPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetUserPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the specified user preferences for the authenticated caller.
		/// </summary>
		/// 
		/// <param name="ShowBidderNoticePreferences">
		/// If true, returns a seller's preferences for receiving bidder notices.
		/// </param>
		///
		/// <param name="ShowCombinedPaymentPreferences">
		/// DO NOT USE THIS FIELD.
		/// Use 'GetShippingDiscountProfiles' to access similar information.
		/// 
		/// If true, returns a seller's preferences for accepting payments
		/// that combine item purchases into one order.
		/// </param>
		///
		/// <param name="ShowCrossPromotionPreferences">
		/// If true, returns a seller's cross-promotion preferences (such as
		/// whether cross-promotions are enabled) and which sort filters they use.
		/// </param>
		///
		/// <param name="ShowSellerPaymentPreferences">
		/// If true, returns a seller's payment preferences, such as whether the seller
		/// accepts PayPal, displays a Pay Now button, and so on.
		/// </param>
		///
		/// <param name="ShowEndOfAuctionEmailPreferences">
		/// If true, returns the seller's end-of-auction email preferences.
		/// </param>
		///
		/// <param name="ShowSellerFavoriteItemPreferences">
		/// If true, returns the seller's preferences for displaying items on a buyer's
		/// favorite sellers page and in the favorite sellers email digest.
		/// </param>
		///
		/// <param name="ShowProStoresPreferences">
		/// If true, returns the seller's ProStores checkout preferences.
		/// </param>
		///
		/// <param name="ShowEmailShipmentTrackingNumberPreference">
		/// If true, returns the seller's preferences related to emailing shipment
		/// tracking numbers.
		/// </param>
		///
		/// <param name="ShowSellerExcludeShipToLocationPreference">
		/// If true, returns a list of locations to where the seller will not ship
		/// items. The returned list is the seller's default ExcludeShipToLocations
		/// setting that is set in My eBay. Sellers can override these default
		/// settings using ExcludeShipToLocation when they list an item.
		/// </param>
		///
		/// <param name="ShowUnpaidItemAssistancePreference">
		/// If true, returns the preference for the Unpaid Item Assistance mechanism.
		/// </param>
		///
		public BidderNoticePreferencesType GetUserPreferences(bool ShowBidderNoticePreferences, bool ShowCombinedPaymentPreferences, bool ShowCrossPromotionPreferences, bool ShowSellerPaymentPreferences, bool ShowEndOfAuctionEmailPreferences, bool ShowSellerFavoriteItemPreferences, bool ShowProStoresPreferences, bool ShowEmailShipmentTrackingNumberPreference, bool ShowSellerExcludeShipToLocationPreference, bool ShowUnpaidItemAssistancePreference)
		{
			this.ShowBidderNoticePreferences = ShowBidderNoticePreferences;
			this.ShowCombinedPaymentPreferences = ShowCombinedPaymentPreferences;
			this.ShowCrossPromotionPreferences = ShowCrossPromotionPreferences;
			this.ShowSellerPaymentPreferences = ShowSellerPaymentPreferences;
			this.ShowEndOfAuctionEmailPreferences = ShowEndOfAuctionEmailPreferences;
			this.ShowSellerFavoriteItemPreferences = ShowSellerFavoriteItemPreferences;
			this.ShowProStoresPreferences = ShowProStoresPreferences;
			this.ShowEmailShipmentTrackingNumberPreference = ShowEmailShipmentTrackingNumberPreference;
			this.ShowSellerExcludeShipToLocationPreference = ShowSellerExcludeShipToLocationPreference;
			this.ShowUnpaidItemAssistancePreference = ShowUnpaidItemAssistancePreference;

			Execute();
			return ApiResponse.BidderNoticePreferences;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void GetUserPreferences(bool ShowBidderNoticePreferences, bool ShowCombinedPaymentPreferences, bool ShowCrossPromotionPreferences, bool ShowSellerPaymentPreferences, bool ShowSellerFavoriteItemPreferences)
		{
			this.ShowBidderNoticePreferences = ShowBidderNoticePreferences;
			this.ShowCombinedPaymentPreferences = ShowCombinedPaymentPreferences;
			this.ShowCrossPromotionPreferences = ShowCrossPromotionPreferences;
			this.ShowSellerPaymentPreferences = ShowSellerPaymentPreferences;
			this.ShowSellerFavoriteItemPreferences = ShowSellerFavoriteItemPreferences;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public BidderNoticePreferencesType GetUserPreferences(bool ShowBidderNoticePreferences, bool ShowCombinedPaymentPreferences, bool ShowCrossPromotionPreferences, bool ShowSellerPaymentPreferences, bool ShowEndOfAuctionEmailPreferences, bool ShowSellerFavoriteItemPreferences)
		{
			this.ShowBidderNoticePreferences = ShowBidderNoticePreferences;
			this.ShowCombinedPaymentPreferences = ShowCombinedPaymentPreferences;
			this.ShowCrossPromotionPreferences = ShowCrossPromotionPreferences;
			this.ShowSellerPaymentPreferences = ShowSellerPaymentPreferences;
			this.ShowEndOfAuctionEmailPreferences = ShowEndOfAuctionEmailPreferences;
			this.ShowSellerFavoriteItemPreferences = ShowSellerFavoriteItemPreferences;

			Execute();
			return ApiResponse.BidderNoticePreferences;
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
		/// Gets or sets the <see cref="GetUserPreferencesRequestType"/> for this API call.
		/// </summary>
		public GetUserPreferencesRequestType ApiRequest
		{ 
			get { return (GetUserPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetUserPreferencesResponseType"/> for this API call.
		/// </summary>
		public GetUserPreferencesResponseType ApiResponse
		{ 
			get { return (GetUserPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowBidderNoticePreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowBidderNoticePreferences
		{ 
			get { return ApiRequest.ShowBidderNoticePreferences; }
			set { ApiRequest.ShowBidderNoticePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowCombinedPaymentPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowCombinedPaymentPreferences
		{ 
			get { return ApiRequest.ShowCombinedPaymentPreferences; }
			set { ApiRequest.ShowCombinedPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowCrossPromotionPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowCrossPromotionPreferences
		{ 
			get { return ApiRequest.ShowCrossPromotionPreferences; }
			set { ApiRequest.ShowCrossPromotionPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerPaymentPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerPaymentPreferences
		{ 
			get { return ApiRequest.ShowSellerPaymentPreferences; }
			set { ApiRequest.ShowSellerPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowEndOfAuctionEmailPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowEndOfAuctionEmailPreferences
		{ 
			get { return ApiRequest.ShowEndOfAuctionEmailPreferences; }
			set { ApiRequest.ShowEndOfAuctionEmailPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerFavoriteItemPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerFavoriteItemPreferences
		{ 
			get { return ApiRequest.ShowSellerFavoriteItemPreferences; }
			set { ApiRequest.ShowSellerFavoriteItemPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowProStoresPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowProStoresPreferences
		{ 
			get { return ApiRequest.ShowProStoresPreferences; }
			set { ApiRequest.ShowProStoresPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowEmailShipmentTrackingNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowEmailShipmentTrackingNumberPreference
		{ 
			get { return ApiRequest.ShowEmailShipmentTrackingNumberPreference; }
			set { ApiRequest.ShowEmailShipmentTrackingNumberPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerExcludeShipToLocationPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerExcludeShipToLocationPreference
		{ 
			get { return ApiRequest.ShowSellerExcludeShipToLocationPreference; }
			set { ApiRequest.ShowSellerExcludeShipToLocationPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowUnpaidItemAssistancePreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowUnpaidItemAssistancePreference
		{ 
			get { return ApiRequest.ShowUnpaidItemAssistancePreference; }
			set { ApiRequest.ShowUnpaidItemAssistancePreference = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.BidderNoticePreferences"/> of type <see cref="BidderNoticePreferencesType"/>.
		/// </summary>
		public BidderNoticePreferencesType BidderNoticePreferences
		{ 
			get { return ApiResponse.BidderNoticePreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.CombinedPaymentPreferences"/> of type <see cref="CombinedPaymentPreferencesType"/>.
		/// </summary>
		public CombinedPaymentPreferencesType CombinedPaymentPreferences
		{ 
			get { return ApiResponse.CombinedPaymentPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.CrossPromotionPreferences"/> of type <see cref="CrossPromotionPreferencesType"/>.
		/// </summary>
		public CrossPromotionPreferencesType CrossPromotionPreferences
		{ 
			get { return ApiResponse.CrossPromotionPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerPaymentPreferences"/> of type <see cref="SellerPaymentPreferencesType"/>.
		/// </summary>
		public SellerPaymentPreferencesType SellerPaymentPreferences
		{ 
			get { return ApiResponse.SellerPaymentPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerFavoriteItemPreferences"/> of type <see cref="SellerFavoriteItemPreferencesType"/>.
		/// </summary>
		public SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences
		{ 
			get { return ApiResponse.SellerFavoriteItemPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.EndOfAuctionEmailPreferences"/> of type <see cref="EndOfAuctionEmailPreferencesType"/>.
		/// </summary>
		public EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences
		{ 
			get { return ApiResponse.EndOfAuctionEmailPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.EmailShipmentTrackingNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool EmailShipmentTrackingNumberPreference
		{ 
			get { return ApiResponse.EmailShipmentTrackingNumberPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.ProStoresPreference"/> of type <see cref="ProStoresCheckoutPreferenceType"/>.
		/// </summary>
		public ProStoresCheckoutPreferenceType ProStoresPreference
		{ 
			get { return ApiResponse.ProStoresPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.UnpaidItemAssistancePreferences"/> of type <see cref="UnpaidItemAssistancePreferencesType"/>.
		/// </summary>
		public UnpaidItemAssistancePreferencesType UnpaidItemAssistancePreferences
		{ 
			get { return ApiResponse.UnpaidItemAssistancePreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerExcludeShipToLocationPreferences"/> of type <see cref="SellerExcludeShipToLocationPreferencesType"/>.
		/// </summary>
		public SellerExcludeShipToLocationPreferencesType SellerExcludeShipToLocationPreferences
		{ 
			get { return ApiResponse.SellerExcludeShipToLocationPreferences; }
		}
		

		#endregion

		
	}
}
