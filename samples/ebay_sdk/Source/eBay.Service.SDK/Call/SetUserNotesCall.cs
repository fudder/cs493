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
	public class SetUserNotesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetUserNotesCall()
		{
			ApiRequest = new SetUserNotesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetUserNotesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetUserNotesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables users to add, replace, and delete My eBay notes for
		/// items that are being tracked in the My eBay All Selling and
		/// All Buying areas.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// ID of the item to which the My eBay note will be
		/// attached. Notes can only be added to items that are
		/// currently being tracked in My eBay.
		/// </param>
		///
		/// <param name="Action">
		/// Specifies whether to add/update the note or delete.
		/// </param>
		///
		/// <param name="NoteText">
		/// Text of the note. Maximum 250 characters. Required only
		/// if the Action is AddOrUpdate. This note text will
		/// completely replace any existing My eBay note for the
		/// specified item.
		/// </param>
		///
		/// <param name="TransactionID">
		/// ID of the transaction to which the My eBay note will be
		/// attached. Notes can only be added to transactions that are
		/// currently being tracked in My eBay.
		/// You can see it in the Won list of GetMyeBayBuying if you are the buyer.
		/// You can see it from Sold list of GetMyeBaySelling if you are the seller.
		/// </param>
		///
		/// <param name="VariationSpecificList">
		/// Name-value pairs that identify (match) one variation within the 
		/// listing identified by ItemID. Ignored if used in combination 
		/// with TransactionID.
		/// </param>
		///
		/// <param name="SKU">
		/// Variation-level SKU that uniquely identifes a variation within
		/// the listing identified by ItemID. Only applicable when the
		/// seller listed the item with variation-level SKU (Variation.SKU)
		/// values. Retrieves all the usual Item fields, but limits the
		/// Variations content to the specified variation. 
		/// 
		/// As buyers should not know a variation's SKU, this field should
		/// only be used when the item's seller is setting a note on the 
		/// variation.
		/// 
		/// Ignored if used in combination with TransactionID.
		/// </param>
		///
		public void SetUserNotes(string ItemID, SetUserNotesActionCodeType Action, string NoteText, string TransactionID, NameValueListTypeCollection VariationSpecificList, string SKU)
		{
			this.ItemID = ItemID;
			this.Action = Action;
			this.NoteText = NoteText;
			this.TransactionID = TransactionID;
			this.VariationSpecificList = VariationSpecificList;
			this.SKU = SKU;

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
		/// Gets or sets the <see cref="SetUserNotesRequestType"/> for this API call.
		/// </summary>
		public SetUserNotesRequestType ApiRequest
		{ 
			get { return (SetUserNotesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetUserNotesResponseType"/> for this API call.
		/// </summary>
		public SetUserNotesResponseType ApiResponse
		{ 
			get { return (SetUserNotesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.Action"/> of type <see cref="SetUserNotesActionCodeType"/>.
		/// </summary>
		public SetUserNotesActionCodeType Action
		{ 
			get { return ApiRequest.Action; }
			set { ApiRequest.Action = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.NoteText"/> of type <see cref="string"/>.
		/// </summary>
		public string NoteText
		{ 
			get { return ApiRequest.NoteText; }
			set { ApiRequest.NoteText = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.VariationSpecifics"/> of type <see cref="NameValueListTypeCollection"/>.
		/// </summary>
		public NameValueListTypeCollection VariationSpecificList
		{ 
			get { return ApiRequest.VariationSpecifics; }
			set { ApiRequest.VariationSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiRequest.SKU; }
			set { ApiRequest.SKU = value; }
		}
		
		

		#endregion

		
	}
}
