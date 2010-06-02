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
	public class GetPictureManagerOptionsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetPictureManagerOptionsCall()
		{
			ApiRequest = new GetPictureManagerOptionsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetPictureManagerOptionsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetPictureManagerOptionsRequestType();
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
		/// Requests a list of Picture Manager options and allowed values,
		/// such as subscription type and picture display.
		/// </summary>
		/// 
		public PictureManagerSubscriptionTypeCollection GetPictureManagerOptions()
		{

			Execute();
			return ApiResponse.Subscription;
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
		/// Gets or sets the <see cref="GetPictureManagerOptionsRequestType"/> for this API call.
		/// </summary>
		public GetPictureManagerOptionsRequestType ApiRequest
		{ 
			get { return (GetPictureManagerOptionsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetPictureManagerOptionsResponseType"/> for this API call.
		/// </summary>
		public GetPictureManagerOptionsResponseType ApiResponse
		{ 
			get { return (GetPictureManagerOptionsResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetPictureManagerOptionsResponseType.Subscription"/> of type <see cref="PictureManagerSubscriptionTypeCollection"/>.
		/// </summary>
		public PictureManagerSubscriptionTypeCollection SubscriptionList
		{ 
			get { return ApiResponse.Subscription; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetPictureManagerOptionsResponseType.PictureType"/> of type <see cref="PictureManagerPictureDisplayTypeCollection"/>.
		/// </summary>
		public PictureManagerPictureDisplayTypeCollection PictureTypeList
		{ 
			get { return ApiResponse.PictureType; }
		}
		

		#endregion

		
	}
}
