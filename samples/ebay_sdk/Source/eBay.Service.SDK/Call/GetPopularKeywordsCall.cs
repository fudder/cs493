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
	public class GetPopularKeywordsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetPopularKeywordsCall()
		{
			ApiRequest = new GetPopularKeywordsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetPopularKeywordsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetPopularKeywordsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the words that are most frequently submitted by eBay users when
		/// searching for listings.
		/// </summary>
		/// 
		/// <param name="CategoryIDList">
		/// A category ID for which you want keywords returned.
		/// When IncludeChildCategories is true, one and only one
		/// CategoryID is allowed. Otherwise, up
		/// to 100 CategoryIds are allowed.
		/// 
		/// To retrieve the keywords for root category, set one of
		/// the CategoryIDs to -1 or submit no CategoryIDs at all.
		/// </param>
		///
		/// <param name="IncludeChildCategories">
		/// If true, only one CategoryID can be specified, and keywords
		/// are returned for that category and its subcategories.
		/// If false, keywords are returned only for the categories
		/// identified by CategoryID. Default is false.
		/// </param>
		///
		/// <param name="MaxKeywordsRetrieved">
		/// The maximum number of keywords to be retrieved per category
		/// for this call.
		/// </param>
		///
		/// <param name="Pagination">
		/// Details about how many categories to return per
		/// page and which page to view.
		/// </param>
		///
		public CategoryTypeCollection GetPopularKeywords(StringCollection CategoryIDList, bool IncludeChildCategories, int MaxKeywordsRetrieved, PaginationType Pagination)
		{
			this.CategoryIDList = CategoryIDList;
			this.IncludeChildCategories = IncludeChildCategories;
			this.MaxKeywordsRetrieved = MaxKeywordsRetrieved;
			this.Pagination = Pagination;

			Execute();
			return ApiResponse.CategoryArray;
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
		/// Gets or sets the <see cref="GetPopularKeywordsRequestType"/> for this API call.
		/// </summary>
		public GetPopularKeywordsRequestType ApiRequest
		{ 
			get { return (GetPopularKeywordsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetPopularKeywordsResponseType"/> for this API call.
		/// </summary>
		public GetPopularKeywordsResponseType ApiResponse
		{ 
			get { return (GetPopularKeywordsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetPopularKeywordsRequestType.CategoryID"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection CategoryIDList
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetPopularKeywordsRequestType.IncludeChildCategories"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeChildCategories
		{ 
			get { return ApiRequest.IncludeChildCategories; }
			set { ApiRequest.IncludeChildCategories = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetPopularKeywordsRequestType.MaxKeywordsRetrieved"/> of type <see cref="int"/>.
		/// </summary>
		public int MaxKeywordsRetrieved
		{ 
			get { return ApiRequest.MaxKeywordsRetrieved; }
			set { ApiRequest.MaxKeywordsRetrieved = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetPopularKeywordsRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetPopularKeywordsResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetPopularKeywordsResponseType.CategoryArray"/> of type <see cref="CategoryTypeCollection"/>.
		/// </summary>
		public CategoryTypeCollection CategoryList
		{ 
			get { return ApiResponse.CategoryArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetPopularKeywordsResponseType.HasMore"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMore
		{ 
			get { return ApiResponse.HasMore; }
		}
		

		#endregion

		
	}
}
