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
	public class SetUserPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetUserPreferencesCall()
		{
			ApiRequest = new SetUserPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetUserPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetUserPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Sets the authenticated user's preferences to those specified in the request.
		/// </summary>
		/// 
		/// <param name="BidderNoticePreferences">
		/// The user's bidder notice preferences to be set.
		/// </param>
		///
		/// <param name="CombinedPaymentPreferences">
		/// DO NOT USE THIS FIELD.
		/// 
		/// Instead, use SetShippingDiscountProfiles to set the shipping preferences.
		/// 
		/// The user's combined payment preferences to be set. When you change these
		/// preferences, it can take up to 7 days for the change to have any logical or
		/// functional effect on eBay.
		/// </param>
		///
		/// <param name="CrossPromotionPreferences">
		/// Sets the user's cross promotion preferences.
		/// </param>
		///
		/// <param name="SellerPaymentPreferences">
		/// Sets the user's seller payment preferences.
		/// </param>
		///
		/// <param name="SellerFavoriteItemPreferences">
		/// Ssets the seller's favorite item preferences.
		/// </param>
		///
		/// <param name="EndOfAuctionEmailPreferences">
		/// Sets the seller's end of auction email preferences.
		/// </param>
		///
		/// <param name="EmailShipmentTrackingNumberPreference">
		/// Sets the preference for the email shipment tracking number.
		/// </param>
		///
		/// <param name="UnpaidItemAssistancePreferences">
		/// Sets the preference for the Unpaid Item Assistance mechanism.
		/// </param>
		///
		public void SetUserPreferences(BidderNoticePreferencesType BidderNoticePreferences, CombinedPaymentPreferencesType CombinedPaymentPreferences, CrossPromotionPreferencesType CrossPromotionPreferences, SellerPaymentPreferencesType SellerPaymentPreferences, SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences, EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences, bool EmailShipmentTrackingNumberPreference, UnpaidItemAssistancePreferencesType UnpaidItemAssistancePreferences)
		{
			this.BidderNoticePreferences = BidderNoticePreferences;
			this.CombinedPaymentPreferences = CombinedPaymentPreferences;
			this.CrossPromotionPreferences = CrossPromotionPreferences;
			this.SellerPaymentPreferences = SellerPaymentPreferences;
			this.SellerFavoriteItemPreferences = SellerFavoriteItemPreferences;
			this.EndOfAuctionEmailPreferences = EndOfAuctionEmailPreferences;
			this.EmailShipmentTrackingNumberPreference = EmailShipmentTrackingNumberPreference;
			this.UnpaidItemAssistancePreferences = UnpaidItemAssistancePreferences;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetUserPreferences()
		{
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetUserPreferences(BidderNoticePreferencesType BidderNoticePreferences, CombinedPaymentPreferencesType CombinedPaymentPreferences, CrossPromotionPreferencesType CrossPromotionPreferences, SellerPaymentPreferencesType SellerPaymentPreferences, SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences, EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences)
		{
			this.BidderNoticePreferences = BidderNoticePreferences;
			this.CombinedPaymentPreferences = CombinedPaymentPreferences;
			this.CrossPromotionPreferences = CrossPromotionPreferences;
			this.SellerPaymentPreferences = SellerPaymentPreferences;
			this.SellerFavoriteItemPreferences = SellerFavoriteItemPreferences;
			this.EndOfAuctionEmailPreferences = EndOfAuctionEmailPreferences;

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
		/// Gets or sets the <see cref="SetUserPreferencesRequestType"/> for this API call.
		/// </summary>
		public SetUserPreferencesRequestType ApiRequest
		{ 
			get { return (SetUserPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetUserPreferencesResponseType"/> for this API call.
		/// </summary>
		public SetUserPreferencesResponseType ApiResponse
		{ 
			get { return (SetUserPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.BidderNoticePreferences"/> of type <see cref="BidderNoticePreferencesType"/>.
		/// </summary>
		public BidderNoticePreferencesType BidderNoticePreferences
		{ 
			get { return ApiRequest.BidderNoticePreferences; }
			set { ApiRequest.BidderNoticePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.CombinedPaymentPreferences"/> of type <see cref="CombinedPaymentPreferencesType"/>.
		/// </summary>
		public CombinedPaymentPreferencesType CombinedPaymentPreferences
		{ 
			get { return ApiRequest.CombinedPaymentPreferences; }
			set { ApiRequest.CombinedPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.CrossPromotionPreferences"/> of type <see cref="CrossPromotionPreferencesType"/>.
		/// </summary>
		public CrossPromotionPreferencesType CrossPromotionPreferences
		{ 
			get { return ApiRequest.CrossPromotionPreferences; }
			set { ApiRequest.CrossPromotionPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.SellerPaymentPreferences"/> of type <see cref="SellerPaymentPreferencesType"/>.
		/// </summary>
		public SellerPaymentPreferencesType SellerPaymentPreferences
		{ 
			get { return ApiRequest.SellerPaymentPreferences; }
			set { ApiRequest.SellerPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.SellerFavoriteItemPreferences"/> of type <see cref="SellerFavoriteItemPreferencesType"/>.
		/// </summary>
		public SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences
		{ 
			get { return ApiRequest.SellerFavoriteItemPreferences; }
			set { ApiRequest.SellerFavoriteItemPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.EndOfAuctionEmailPreferences"/> of type <see cref="EndOfAuctionEmailPreferencesType"/>.
		/// </summary>
		public EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences
		{ 
			get { return ApiRequest.EndOfAuctionEmailPreferences; }
			set { ApiRequest.EndOfAuctionEmailPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.EmailShipmentTrackingNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool EmailShipmentTrackingNumberPreference
		{ 
			get { return ApiRequest.EmailShipmentTrackingNumberPreference; }
			set { ApiRequest.EmailShipmentTrackingNumberPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.UnpaidItemAssistancePreferences"/> of type <see cref="UnpaidItemAssistancePreferencesType"/>.
		/// </summary>
		public UnpaidItemAssistancePreferencesType UnpaidItemAssistancePreferences
		{ 
			get { return ApiRequest.UnpaidItemAssistancePreferences; }
			set { ApiRequest.UnpaidItemAssistancePreferences = value; }
		}
		
		

		#endregion

		
	}
}
