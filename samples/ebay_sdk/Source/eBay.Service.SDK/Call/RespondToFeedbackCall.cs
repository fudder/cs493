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
	public class RespondToFeedbackCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public RespondToFeedbackCall()
		{
			ApiRequest = new RespondToFeedbackRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public RespondToFeedbackCall(ApiContext ApiContext)
		{
			ApiRequest = new RespondToFeedbackRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Replies to feedback that has been left for a user, or posts a
		/// follow-up comment to a feedback comment a user has left for someone else.
		/// </summary>
		/// 
		/// <param name="FeedbackID">
		/// An ID that uniquely identifies the feedback. Retrieve FeedbackIDs with
		/// GetFeedback. Required if ItemID is not specified.
		/// </param>
		///
		/// <param name="ItemID">
		/// Unique identifier of an item to which the feedback is attached. Required if
		/// FeedbackID is not provided.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for a purchase from an
		/// eBay Stores Inventory or basic fixed price
		/// listing. If TransactionID is specified, ItemID
		/// must also be specified.
		/// </param>
		///
		/// <param name="TargetUserID">
		/// User who left the feedback that is being replied to or followed up on.
		/// </param>
		///
		/// <param name="ResponseType">
		/// Specifies whether the response is a reply or a follow-up.
		/// </param>
		///
		/// <param name="ResponseText">
		/// Textual comment that the user who is subject of feedback may leave in
		/// response or rebuttal to the feedback. Alternatively, when the  ResponseType
		/// is FollowUp, this value contains the text of the follow-up comment.
		/// </param>
		///
		public void RespondToFeedback(string FeedbackID, string ItemID, string TransactionID, string TargetUserID, FeedbackResponseCodeType ResponseType, string ResponseText)
		{
			this.FeedbackID = FeedbackID;
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.TargetUserID = TargetUserID;
			this.ResponseType = ResponseType;
			this.ResponseText = ResponseText;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void RespondToFeedback(string TargetUserID, string ItemID, string TransactionID, FeedbackResponseCodeType ResponseType, string ResponseText)
		{
			this.TargetUserID = TargetUserID;
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.ResponseType = ResponseType;
			this.ResponseText = ResponseText;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void RespondToFeedback(string TargetUserID, string ItemID, FeedbackResponseCodeType ResponseType, string ResponseText)
		{
			this.TargetUserID = TargetUserID;
			this.ItemID = ItemID;
			this.ResponseType = ResponseType;
			this.ResponseText = ResponseText;
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
		/// Gets or sets the <see cref="RespondToFeedbackRequestType"/> for this API call.
		/// </summary>
		public RespondToFeedbackRequestType ApiRequest
		{ 
			get { return (RespondToFeedbackRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="RespondToFeedbackResponseType"/> for this API call.
		/// </summary>
		public RespondToFeedbackResponseType ApiResponse
		{ 
			get { return (RespondToFeedbackResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToFeedbackRequestType.FeedbackID"/> of type <see cref="string"/>.
		/// </summary>
		public string FeedbackID
		{ 
			get { return ApiRequest.FeedbackID; }
			set { ApiRequest.FeedbackID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToFeedbackRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToFeedbackRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToFeedbackRequestType.TargetUserID"/> of type <see cref="string"/>.
		/// </summary>
		public string TargetUserID
		{ 
			get { return ApiRequest.TargetUserID; }
			set { ApiRequest.TargetUserID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToFeedbackRequestType.ResponseType"/> of type <see cref="FeedbackResponseCodeType"/>.
		/// </summary>
		public FeedbackResponseCodeType ResponseType
		{ 
			get { return ApiRequest.ResponseType; }
			set { ApiRequest.ResponseType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToFeedbackRequestType.ResponseText"/> of type <see cref="string"/>.
		/// </summary>
		public string ResponseText
		{ 
			get { return ApiRequest.ResponseText; }
			set { ApiRequest.ResponseText = value; }
		}
		
		

		#endregion

		
	}
}
