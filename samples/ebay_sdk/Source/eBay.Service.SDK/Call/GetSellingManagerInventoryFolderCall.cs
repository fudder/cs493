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
	public class GetSellingManagerInventoryFolderCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellingManagerInventoryFolderCall()
		{
			ApiRequest = new GetSellingManagerInventoryFolderRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellingManagerInventoryFolderCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellingManagerInventoryFolderRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves Selling Manager inventory folders.
		/// This call is subject to change without notice; the deprecation process is
		/// inapplicable to this call.
		/// </summary>
		/// 
		/// <param name="FolderID">
		/// If a FolderID is submitted, all child-folders below this folder will be returned.
		/// </param>
		///
		/// <param name="MaxDepth">
		/// Specifies the number of levels of subfolders to be returned.
		/// </param>
		///
		/// <param name="FullRecursion">
		/// Displays the entire tree of a user's folders. If this is provided, the other two values
		/// need not be given.
		/// </param>
		///
		public SellingManagerFolderDetailsType GetSellingManagerInventoryFolder(long FolderID, int MaxDepth, bool FullRecursion)
		{
			this.FolderID = FolderID;
			this.MaxDepth = MaxDepth;
			this.FullRecursion = FullRecursion;

			Execute();
			return ApiResponse.Folder;
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
		/// Gets or sets the <see cref="GetSellingManagerInventoryFolderRequestType"/> for this API call.
		/// </summary>
		public GetSellingManagerInventoryFolderRequestType ApiRequest
		{ 
			get { return (GetSellingManagerInventoryFolderRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellingManagerInventoryFolderResponseType"/> for this API call.
		/// </summary>
		public GetSellingManagerInventoryFolderResponseType ApiResponse
		{ 
			get { return (GetSellingManagerInventoryFolderResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerInventoryFolderRequestType.FolderID"/> of type <see cref="long"/>.
		/// </summary>
		public long FolderID
		{ 
			get { return ApiRequest.FolderID; }
			set { ApiRequest.FolderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerInventoryFolderRequestType.MaxDepth"/> of type <see cref="int"/>.
		/// </summary>
		public int MaxDepth
		{ 
			get { return ApiRequest.MaxDepth; }
			set { ApiRequest.MaxDepth = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellingManagerInventoryFolderRequestType.FullRecursion"/> of type <see cref="bool"/>.
		/// </summary>
		public bool FullRecursion
		{ 
			get { return ApiRequest.FullRecursion; }
			set { ApiRequest.FullRecursion = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellingManagerInventoryFolderResponseType.Folder"/> of type <see cref="SellingManagerFolderDetailsType"/>.
		/// </summary>
		public SellingManagerFolderDetailsType Folder
		{ 
			get { return ApiResponse.Folder; }
		}
		

		#endregion

		
	}
}
