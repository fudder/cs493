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
	public class GetProductFamilyMembersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetProductFamilyMembersCall()
		{
			ApiRequest = new GetProductFamilyMembersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetProductFamilyMembersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetProductFamilyMembersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 		/// GetProductFamilyMembers is intended to be used combination with GetProductSearchResults.
		/// If a search result returned from GetProductSearchResults does not return all
		/// product versions in a family, and if the user wants to see more versions (editions)
		/// of the product, you can use GetProductFamilyMembers to retrieve all versions of the product.
		/// That is, if GetProductSearchResultsonly returns the product family header (ParentProduct),
		/// use this call to zoom in on a particular family of product versions.
		/// (This situation usually occurs when you call GetProductSearchResults and more more
		/// matches are found than the MaxChildrenPerFamily value you specified.)
		/// 
		/// The structure of tGetProductFamilyMembers is similar to that of GetProductSearchResults.
		/// Instead of passing in a query, you pass in a product ID. This product ID is used to
		/// find all the members of the product family that the specified product is a member of.
		/// The results are compatible with the results from GetProductSearchResults,
		/// so similar application logic can be used to handle both requests and responses.
		/// This call supports batch requests. This means you can retrieve products in
		/// multiple families by using a single request. To perform a batch request,
		/// pass an array of ProductSearch objects in the call.
		/// 
		/// For each ProductSearch object, GetProductFamilyMembers returns a list of all the
		/// products in the specified product family. Each product is represented as a list of
		/// attributes (Item Specifics) plus other identifying information, such as a product ID
		/// and a stock photo.
		/// 
		/// Once the user selects a product from the results, pass its ID in a GetProductSellingPages
		/// request to retrieve more detailed information about the product, including a set of
		/// optional Item Specifics that the seller can use in addition to the
		/// pre-filled Item Specifics (see GetProductSellingPages). 
		/// 
		/// To use this data in a listing, pass the product ID and the optional Item Specifics
		/// in the seller's listing request (AddItem).
		/// </summary>
		/// 
		/// <param name="ProductSearchList">
		/// Specifies the ID of a product in the family to be retrieved,
		/// along with pagination and sorting instructions.
		/// ProductSearch is a required input.
		/// </param>
		///
		public ProductSearchResultTypeCollection GetProductFamilyMembers(ProductSearchTypeCollection ProductSearchList)
		{
			this.ProductSearchList = ProductSearchList;

			Execute();
			return ApiResponse.ProductSearchResult;
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
		/// Gets or sets the <see cref="GetProductFamilyMembersRequestType"/> for this API call.
		/// </summary>
		public GetProductFamilyMembersRequestType ApiRequest
		{ 
			get { return (GetProductFamilyMembersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetProductFamilyMembersResponseType"/> for this API call.
		/// </summary>
		public GetProductFamilyMembersResponseType ApiResponse
		{ 
			get { return (GetProductFamilyMembersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetProductFamilyMembersRequestType.ProductSearch"/> of type <see cref="ProductSearchTypeCollection"/>.
		/// </summary>
		public ProductSearchTypeCollection ProductSearchList
		{ 
			get { return ApiRequest.ProductSearch; }
			set { ApiRequest.ProductSearch = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductFamilyMembersResponseType.DataElementSets"/> of type <see cref="DataElementSetTypeCollection"/>.
		/// </summary>
		public DataElementSetTypeCollection DataElementSetList
		{ 
			get { return ApiResponse.DataElementSets; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetProductFamilyMembersResponseType.ProductSearchResult"/> of type <see cref="ProductSearchResultTypeCollection"/>.
		/// </summary>
		public ProductSearchResultTypeCollection ProductSearchResultList
		{ 
			get { return ApiResponse.ProductSearchResult; }
		}
		

		#endregion

		
	}
}
