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
	public class SetPictureManagerDetailsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetPictureManagerDetailsCall()
		{
			ApiRequest = new SetPictureManagerDetailsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetPictureManagerDetailsCall(ApiContext ApiContext)
		{
			ApiRequest = new SetPictureManagerDetailsRequestType();
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
		/// Creates, updates, or deletes Picture Manager account settings, folders, or pictures.
		/// </summary>
		/// 
		/// <param name="PictureManagerDetails">
		/// Specifies the setting or folder to create, update, or delete, or the
		/// picture to update. You cannot upload or delete pictures using
		/// SetPictureManagerDetails; you must use the eBay site.
		/// </param>
		///
		/// <param name="Action">
		/// Specifies the action to take on the setting, folder, or picture.
		/// The values Add and Delete apply only to folders.
		/// </param>
		///
		public void SetPictureManagerDetails(PictureManagerDetailsType PictureManagerDetails, PictureManagerActionCodeType Action)
		{
			this.PictureManagerDetails = PictureManagerDetails;
			this.Action = Action;

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
		/// Gets or sets the <see cref="SetPictureManagerDetailsRequestType"/> for this API call.
		/// </summary>
		public SetPictureManagerDetailsRequestType ApiRequest
		{ 
			get { return (SetPictureManagerDetailsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetPictureManagerDetailsResponseType"/> for this API call.
		/// </summary>
		public SetPictureManagerDetailsResponseType ApiResponse
		{ 
			get { return (SetPictureManagerDetailsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetPictureManagerDetailsRequestType.PictureManagerDetails"/> of type <see cref="PictureManagerDetailsType"/>.
		/// </summary>
		public PictureManagerDetailsType PictureManagerDetails
		{ 
			get { return ApiRequest.PictureManagerDetails; }
			set { ApiRequest.PictureManagerDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetPictureManagerDetailsRequestType.Action"/> of type <see cref="PictureManagerActionCodeType"/>.
		/// </summary>
		public PictureManagerActionCodeType Action
		{ 
			get { return ApiRequest.Action; }
			set { ApiRequest.Action = value; }
		}
		
		

		#endregion

		
	}
}
