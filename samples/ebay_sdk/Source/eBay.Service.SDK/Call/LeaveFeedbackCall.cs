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
	public class LeaveFeedbackCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public LeaveFeedbackCall()
		{
			ApiRequest = new LeaveFeedbackRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public LeaveFeedbackCall(ApiContext ApiContext)
		{
			ApiRequest = new LeaveFeedbackRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a user to leave feedback about another user at the conclusion of a successful
		/// sales transaction (item sold).
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The ID of an item. Specify the ID for the item of the transaction of the
		/// users. The transaction must not have been created more than 60 days before
		/// your attempt to leave feedback.
		/// </param>
		///
		/// <param name="CommentText">
		/// Textual comment that explains, clarifies, or justifies the feedback
		/// score specified in CommentType.
		/// </param>
		///
		/// <param name="CommentType">
		/// Score for the feedback being left. May be Positive, Neutral, or Negative.
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// Sellers can not leave neutral or negative feedback for buyers. In addition,
		/// buyers can not leave neutral or negative feedback within 7 days from the end of
		/// the transaction for active PowerSellers who have been on eBay for 12 months.
		/// </span> ;
		/// </param>
		///
		/// <param name="TransactionID">
		/// The item purchase transaction from the listing specified in ItemID for
		/// which the feedback is being left. Required if the listing identified in
		/// ItemID is a multi-item fixed-price listing.
		/// <span class="tablenote"><strong>Note:</strong>
		/// As of version 619, Dutch-style (multi-item) competitive-bid auctions are
		/// deprecated. eBay throws an error if you submit a Dutch item listing with
		/// AddItem or VerifyAddItem. If you use RelistItem to update a Dutch auction
		/// listing, eBay generates a warning and resets the Quantity value to 1.
		/// </span>
		/// 
		/// </param>
		///
		/// <param name="TargetUser">
		/// Specifies the recipient user about whom the feedback is being left.
		/// </param>
		///
		/// <param name="SellerItemRatingDetailArrayList">
		/// Container for detailed seller ratings (DSRs). If a buyer is providing DSRs,
		/// they are specified in this container. Sellers have access to the number of
		/// ratings they've received, as well as to the averages of the DSRs they've
		/// received in each DSR area (i.e., to the average of ratings in the
		/// item-description area, etc.).
		/// </param>
		///
		public string LeaveFeedback(string ItemID, string CommentText, CommentTypeCodeType CommentType, string TransactionID, string TargetUser, ItemRatingDetailsTypeCollection SellerItemRatingDetailArrayList)
		{
			this.ItemID = ItemID;
			this.CommentText = CommentText;
			this.CommentType = CommentType;
			this.TransactionID = TransactionID;
			this.TargetUser = TargetUser;
			this.SellerItemRatingDetailArrayList = SellerItemRatingDetailArrayList;

			Execute();
			return ApiResponse.FeedbackID;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public string LeaveFeedback(string TargetUser, string ItemID, string TransactionID, CommentTypeCodeType CommentType, string CommentText)
		{
			this.TargetUser = TargetUser;
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.CommentType = CommentType;
			this.CommentText = CommentText;
			Execute();
			return FeedbackID;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public string LeaveFeedback(string TargetUser, string ItemID, CommentTypeCodeType CommentType, string CommentText)
		{
			this.TargetUser = TargetUser;
			this.ItemID = ItemID;
			this.CommentType = CommentType;
			this.CommentText = CommentText;
			Execute();
			return FeedbackID;
		}
		
				
		///
		/// For backward compatibility with old wrappers
		/// 
		///
		public string LeaveFeedback(string ItemID, string CommentText, CommentTypeCodeType CommentType, string TransactionID, string TargetUser)
		{
			this.ItemID = ItemID;
			this.CommentText = CommentText;
			this.CommentType = CommentType;
			this.TransactionID = TransactionID;
			this.TargetUser = TargetUser;

			Execute();
			return ApiResponse.FeedbackID;
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
		/// Gets or sets the <see cref="LeaveFeedbackRequestType"/> for this API call.
		/// </summary>
		public LeaveFeedbackRequestType ApiRequest
		{ 
			get { return (LeaveFeedbackRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="LeaveFeedbackResponseType"/> for this API call.
		/// </summary>
		public LeaveFeedbackResponseType ApiResponse
		{ 
			get { return (LeaveFeedbackResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.CommentText"/> of type <see cref="string"/>.
		/// </summary>
		public string CommentText
		{ 
			get { return ApiRequest.CommentText; }
			set { ApiRequest.CommentText = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.CommentType"/> of type <see cref="CommentTypeCodeType"/>.
		/// </summary>
		public CommentTypeCodeType CommentType
		{ 
			get { return ApiRequest.CommentType; }
			set { ApiRequest.CommentType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.TargetUser"/> of type <see cref="string"/>.
		/// </summary>
		public string TargetUser
		{ 
			get { return ApiRequest.TargetUser; }
			set { ApiRequest.TargetUser = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.SellerItemRatingDetailArray"/> of type <see cref="ItemRatingDetailsTypeCollection"/>.
		/// </summary>
		public ItemRatingDetailsTypeCollection SellerItemRatingDetailArrayList
		{ 
			get { return ApiRequest.SellerItemRatingDetailArray; }
			set { ApiRequest.SellerItemRatingDetailArray = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="LeaveFeedbackResponseType.FeedbackID"/> of type <see cref="string"/>.
		/// </summary>
		public string FeedbackID
		{ 
			get { return ApiResponse.FeedbackID; }
		}
		

		#endregion

		
	}
}
