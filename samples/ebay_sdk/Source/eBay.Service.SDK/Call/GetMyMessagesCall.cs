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
	public class GetMyMessagesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetMyMessagesCall()
		{
			ApiRequest = new GetMyMessagesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetMyMessagesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetMyMessagesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves information about the messages sent to a given user.
		/// </summary>
		/// 
		/// <param name="AlertIDList">
		/// This field will be deprecated in an upcoming release.
		/// This field formerly contained a list
		/// of up to 10 AlertID values.
		/// </param>
		///
		/// <param name="MessageIDList">
		/// Contains a list of up to 10 message ID values.
		/// </param>
		///
		/// <param name="FolderID">
		/// An ID that uniquely identifies the
		/// My Messages folder from which to retrieve messages.
		/// </param>
		///
		/// <param name="StartTime">
		/// The beginning of the date-range filter.
		/// Filtering takes into account the entire timestamp of when messages were sent.
		/// Messages expire after one year.
		/// </param>
		///
		/// <param name="EndTime">
		/// The end of the date-range filter. See StartTime
		/// (which is the beginning of the date-range filter).
		/// </param>
		///
		/// <param name="ExternalMessageIDList">
		/// This field is currently available on the US site. A container for IDs that
		/// uniquely identify messages for a given user. If provided at the time of message
		/// creation, this ID can be used to retrieve messages and will take precedence
		/// over message ID.
		/// </param>
		///
		public MyMessagesSummaryType GetMyMessages(StringCollection AlertIDList, StringCollection MessageIDList, long FolderID, DateTime StartTime, DateTime EndTime, StringCollection ExternalMessageIDList)
		{
			this.AlertIDList = AlertIDList;
			this.MessageIDList = MessageIDList;
			this.FolderID = FolderID;
			this.StartTime = StartTime;
			this.EndTime = EndTime;
			this.ExternalMessageIDList = ExternalMessageIDList;

			Execute();
			return ApiResponse.Summary;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void GetMyMessages()
		{
			this.Execute();
		}

		/// <summary>
		/// For backward compatibility with old wrappers.
		///Used to retrieve information about the messages and alerts sent
		/// to a given user. Depending on the detail level, this information
		/// can include message and alert counts, resolution and flagged
		/// status, message and/or alert headers, and message and/or alert
		/// body text.
		/// <br /><br />
		/// Note that this call requires a DetailLevel in the
		/// request. Omitting the Detail Level returns an error.
		/// <br /><br />
		/// ItemID is not returned with this call. Use GetMemberMessages instead.
		/// </summary>
		/// 
		/// <param name="AlertIDList">
		/// Contains a list of up to 10 AlertID values.
		/// When AlertID values are used as input, you must
		/// generally specify either AlertID values, or
		/// MessageID values, or both.
		/// </param>
		///
		/// <param name="MessageIDList">
		/// Contains a list of up to 10 MessageID values.
		/// When MessageID values are used as input, you must
		/// generally specify either AlertID values, or
		/// MessageID values, or both.
		/// </param>
		///
		/// <param name="FolderID">
		/// An ID that uniquely identifies the My Messages folder from which to retrieve alerts or messages.
		/// </param>
		///
		public MyMessagesSummaryType GetMyMessages(StringCollection AlertIDList, StringCollection MessageIDList, long FolderID)
		{
			this.AlertIDList = AlertIDList;
			this.MessageIDList = MessageIDList;
			this.FolderID = FolderID;

			Execute();
			return ApiResponse.Summary;
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
		/// Gets or sets the <see cref="GetMyMessagesRequestType"/> for this API call.
		/// </summary>
		public GetMyMessagesRequestType ApiRequest
		{ 
			get { return (GetMyMessagesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetMyMessagesResponseType"/> for this API call.
		/// </summary>
		public GetMyMessagesResponseType ApiResponse
		{ 
			get { return (GetMyMessagesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.AlertIDs"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection AlertIDList
		{ 
			get { return ApiRequest.AlertIDs; }
			set { ApiRequest.AlertIDs = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.MessageIDs"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection MessageIDList
		{ 
			get { return ApiRequest.MessageIDs; }
			set { ApiRequest.MessageIDs = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.FolderID"/> of type <see cref="long"/>.
		/// </summary>
		public long FolderID
		{ 
			get { return ApiRequest.FolderID; }
			set { ApiRequest.FolderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiRequest.StartTime; }
			set { ApiRequest.StartTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiRequest.EndTime; }
			set { ApiRequest.EndTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyMessagesRequestType.ExternalMessageIDs"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection ExternalMessageIDList
		{ 
			get { return ApiRequest.ExternalMessageIDs; }
			set { ApiRequest.ExternalMessageIDs = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyMessagesResponseType.Summary"/> of type <see cref="MyMessagesSummaryType"/>.
		/// </summary>
		public MyMessagesSummaryType Summary
		{ 
			get { return ApiResponse.Summary; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyMessagesResponseType.Alerts"/> of type <see cref="MyMessagesAlertTypeCollection"/>.
		/// </summary>
		public MyMessagesAlertTypeCollection AlertList
		{ 
			get { return ApiResponse.Alerts; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyMessagesResponseType.Messages"/> of type <see cref="MyMessagesMessageTypeCollection"/>.
		/// </summary>
		public MyMessagesMessageTypeCollection MessageList
		{ 
			get { return ApiResponse.Messages; }
		}
		

		#endregion

		
	}
}
