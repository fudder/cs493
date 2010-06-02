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
	public class GetPictureManagerDetailsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetPictureManagerDetailsCall()
		{
			ApiRequest = new GetPictureManagerDetailsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetPictureManagerDetailsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetPictureManagerDetailsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// <table>
		/// <tr>
		/// <td class="notebox">
		/// <b>Note:</b> This call will soon be deprecated. Use accordingly.
		/// </td>
		/// </tr>
		/// </table>
		/// 
		/// Requests information about folders or pictures in a Picture Manager account
		/// or the account settings.
		/// </summary>
		/// 
		/// <param name="FolderID">
		/// The ID of a folder in the user's Picture Manager album for which you want information.
		/// If you specify both FolderID and PictureURL, the picture must exist
		/// in the folder.
		/// </param>
		///
		/// <param name="PictureURL">
		/// The URL of a picture in the user's Picture Manager album.
		/// If you specify both FolderID and PictureURL, the picture must
		/// exist in the folder.
		/// </param>
		///
		/// <param name="PictureManagerDetailLevel">
		/// The type of information you want returned, about pictures and folders,
		/// the account subscription, or both. Use this element rather than the generic DetailLevel element defined in AbstractRequestType. You can use the following values: ReturnAll, ReturnSubscription, or ReturnPicture.
		/// </param>
		///
		public PictureManagerDetailsType GetPictureManagerDetails(int FolderID, string PictureURL, PictureManagerDetailLevelCodeType PictureManagerDetailLevel)
		{
			this.FolderID = FolderID;
			this.PictureURL = PictureURL;
			this.PictureManagerDetailLevel = PictureManagerDetailLevel;

			Execute();
			return ApiResponse.PictureManagerDetails;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public PictureManagerDetailsType GetPictureManagerDetails(PictureManagerDetailLevelCodeType PictureManagerDetailLevel)
		{
			this.PictureManagerDetailLevel = PictureManagerDetailLevel;
			Execute();
			return this.PictureManagerDetails;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public PictureManagerDetailsType GetPictureManagerDetails(int FolderID, PictureManagerDetailLevelCodeType PictureManagerDetailLevel)
		{
			this.FolderID = FolderID;
			this.PictureManagerDetailLevel = PictureManagerDetailLevel;
			Execute();
			return this.PictureManagerDetails;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public PictureManagerDetailsType GetPictureManagerDetails(string PictureURL, PictureManagerDetailLevelCodeType PictureManagerDetailLevel)
		{
			this.PictureURL = PictureURL;
			this.PictureManagerDetailLevel = PictureManagerDetailLevel;
			Execute();
			return this.PictureManagerDetails;
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
		/// Gets or sets the <see cref="GetPictureManagerDetailsRequestType"/> for this API call.
		/// </summary>
		public GetPictureManagerDetailsRequestType ApiRequest
		{ 
			get { return (GetPictureManagerDetailsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetPictureManagerDetailsResponseType"/> for this API call.
		/// </summary>
		public GetPictureManagerDetailsResponseType ApiResponse
		{ 
			get { return (GetPictureManagerDetailsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetPictureManagerDetailsRequestType.FolderID"/> of type <see cref="int"/>.
		/// </summary>
		public int FolderID
		{ 
			get { return ApiRequest.FolderID; }
			set { ApiRequest.FolderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetPictureManagerDetailsRequestType.PictureURL"/> of type <see cref="string"/>.
		/// </summary>
		public string PictureURL
		{ 
			get { return ApiRequest.PictureURL; }
			set { ApiRequest.PictureURL = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetPictureManagerDetailsRequestType.PictureManagerDetailLevel"/> of type <see cref="PictureManagerDetailLevelCodeType"/>.
		/// </summary>
		public PictureManagerDetailLevelCodeType PictureManagerDetailLevel
		{ 
			get { return ApiRequest.PictureManagerDetailLevel; }
			set { ApiRequest.PictureManagerDetailLevel = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetPictureManagerDetailsResponseType.PictureManagerDetails"/> of type <see cref="PictureManagerDetailsType"/>.
		/// </summary>
		public PictureManagerDetailsType PictureManagerDetails
		{ 
			get { return ApiResponse.PictureManagerDetails; }
		}
		

		#endregion

		
	}
}
