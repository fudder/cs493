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
	public class SendInvoiceCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SendInvoiceCall()
		{
			ApiRequest = new SendInvoiceRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SendInvoiceCall(ApiContext ApiContext)
		{
			ApiRequest = new SendInvoiceRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to send an invoice to a buyer involved in a single transaction
		/// or order.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// eBay's ID for the item from which the transaction was created.
		/// If OrderID is not provided, both ItemID (or SKU) and
		/// TransactionID must be provided to uniquely identify
		/// a single transaction.
		/// </param>
		///
		/// <param name="TransactionID">
		/// ID for the transaction with which the item was sold.
		/// If OrderID is not provided, both ItemID and
		/// TransactionID must be provided.
		/// For Chinese auctions, the value passed in the TransactionId
		/// argument must be 0 or the call will fail with an error.
		/// Call GetItemTransactions or GetSellerTransactions to
		/// determine the correct transaction ID.
		/// </param>
		///
		/// <param name="OrderID">
		/// Unique ID for a multi-transaction order.
		/// Either this OrderID must be specified or ItemID (or SKU) plus
		/// TransactionID must be specified.
		/// If OrderID is specified, ItemID, TransactionID, and SKU are
		/// ignored if present in the same request. Changes to the
		/// checkout status are applied to the specified order as a whole
		/// (and thus to the child transactions associated with the order).
		/// </param>
		///
		/// <param name="InternationalShippingServiceOptionsList">
		/// If the buyer's shipping address is international, use this to offer up to
		/// three shipping services, and omit all domestic ShippingServiceOptions. Any
		/// shipping insurance cost specified should be the same for all services
		/// offered.
		/// 
		/// Not applicable to invoices for digital listings.
		/// </param>
		///
		/// <param name="ShippingServiceOptionsList">
		/// If the buyer's shipping address is domestic, use this to offer up to
		/// three shipping services, and omit all InternationalShippingServiceOptions. Any
		/// shipping insurance cost specified should be the same for all services
		/// offered.
		/// 
		/// Not applicable to invoices for digital listings.
		/// </param>
		///
		/// <param name="SalesTax">
		/// The details of the sales tax added to the invoice.
		/// </param>
		///
		/// <param name="InsuranceOption">
		/// Specifies whether insurance fee is required. An InsuranceOption value of
		/// IncludedInShippingHandling cannot be used if the item will use calculated
		/// shipping. Some shipping carriers automatically include shipping insurance
		/// for qualifying items.
		/// 
		/// Not applicable to invoices for digital listings.
		/// </param>
		///
		/// <param name="InsuranceFee">
		/// Insurance cost, as set by seller, if ShippingType = 1.
		/// Specify if InsuranceOption is optional or required. Must
		/// be greater than zero value if a value of Optional or Required is passed in
		/// InsuranceOption. Value specified should be the total cost of insuring the
		/// item.
		/// 
		/// Not applicable to invoices for digital listings.
		/// </param>
		///
		/// <param name="PaymentMethodsList">
		/// Optional ability for the seller to add certain payment methods on
		/// transaction if they were not originally specified on the item.  Valid
		/// values are PayPal in the US, and MoneyXferAcceptedInCheckout (CIP+) in
		/// Germany.
		/// </param>
		///
		/// <param name="PayPalEmailAddress">
		/// Provide PayPal email address if the payment method added is PayPal.
		/// For digital listings, this must be an email address associated with
		/// a verified PayPal Premier or Business account.
		/// </param>
		///
		/// <param name="CheckoutInstructions">
		/// Seller's Payment instructions/message to the buyer and return policy.
		/// Default is null.
		/// </param>
		///
		/// <param name="EmailCopyToSeller">
		/// Specifies whether the seller wishes to be copied on the invoice email that
		/// will be sent to the buyer. Default will be true.
		/// </param>
		///
		/// <param name="CODCost">
		/// Italy site (site ID 101) only.
		/// Enables you to specify the cash-on-delivery (COD) cost, for COD shipping.
		/// </param>
		///
		/// <param name="SKU">
		/// The seller's unique identifier for an item that is being tracked
		/// by this SKU. If OrderID is not provided, both SKU (or ItemID) and
		/// TransactionID must be provided to uniquely identify
		/// a single transaction.
		/// 
		/// This field can only be used when you listed the item by using
		/// AddFixedPriceItem or RelistFixedPriceItem,
		/// and you set Item.InventoryTrackingMethod to SKU at
		/// the time the item was listed. (These criteria are necessary to
		/// uniquely identify the listing by a SKU.)
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// AddFixedPriceItem and RelistFixedPriceItem are defined in
		/// the Merchant Data API (part of Large Merchant Services).
		/// </span>
		/// </param>
		///
		public void SendInvoice(string ItemID, string TransactionID, string OrderID, InternationalShippingServiceOptionsTypeCollection InternationalShippingServiceOptionsList, ShippingServiceOptionsTypeCollection ShippingServiceOptionsList, SalesTaxType SalesTax, InsuranceOptionCodeType InsuranceOption, AmountType InsuranceFee, BuyerPaymentMethodCodeTypeCollection PaymentMethodsList, string PayPalEmailAddress, string CheckoutInstructions, bool EmailCopyToSeller, AmountType CODCost, string SKU)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.InternationalShippingServiceOptionsList = InternationalShippingServiceOptionsList;
			this.ShippingServiceOptionsList = ShippingServiceOptionsList;
			this.SalesTax = SalesTax;
			this.InsuranceOption = InsuranceOption;
			this.InsuranceFee = InsuranceFee;
			this.PaymentMethodsList = PaymentMethodsList;
			this.PayPalEmailAddress = PayPalEmailAddress;
			this.CheckoutInstructions = CheckoutInstructions;
			this.EmailCopyToSeller = EmailCopyToSeller;
			this.CODCost = CODCost;
			this.SKU = SKU;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SendInvoice(string ItemID, string TransactionID, ShippingServiceOptionsTypeCollection ShippingServiceOptionsList)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.ShippingServiceOptionsList = ShippingServiceOptionsList;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SendInvoice(string OrderID)
		{
			this.OrderID = OrderID;
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
		/// Gets or sets the <see cref="SendInvoiceRequestType"/> for this API call.
		/// </summary>
		public SendInvoiceRequestType ApiRequest
		{ 
			get { return (SendInvoiceRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SendInvoiceResponseType"/> for this API call.
		/// </summary>
		public SendInvoiceResponseType ApiResponse
		{ 
			get { return (SendInvoiceResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.InternationalShippingServiceOptions"/> of type <see cref="InternationalShippingServiceOptionsTypeCollection"/>.
		/// </summary>
		public InternationalShippingServiceOptionsTypeCollection InternationalShippingServiceOptionsList
		{ 
			get { return ApiRequest.InternationalShippingServiceOptions; }
			set { ApiRequest.InternationalShippingServiceOptions = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.ShippingServiceOptions"/> of type <see cref="ShippingServiceOptionsTypeCollection"/>.
		/// </summary>
		public ShippingServiceOptionsTypeCollection ShippingServiceOptionsList
		{ 
			get { return ApiRequest.ShippingServiceOptions; }
			set { ApiRequest.ShippingServiceOptions = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.SalesTax"/> of type <see cref="SalesTaxType"/>.
		/// </summary>
		public SalesTaxType SalesTax
		{ 
			get { return ApiRequest.SalesTax; }
			set { ApiRequest.SalesTax = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.InsuranceOption"/> of type <see cref="InsuranceOptionCodeType"/>.
		/// </summary>
		public InsuranceOptionCodeType InsuranceOption
		{ 
			get { return ApiRequest.InsuranceOption; }
			set { ApiRequest.InsuranceOption = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.InsuranceFee"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType InsuranceFee
		{ 
			get { return ApiRequest.InsuranceFee; }
			set { ApiRequest.InsuranceFee = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.PaymentMethods"/> of type <see cref="BuyerPaymentMethodCodeTypeCollection"/>.
		/// </summary>
		public BuyerPaymentMethodCodeTypeCollection PaymentMethodsList
		{ 
			get { return ApiRequest.PaymentMethods; }
			set { ApiRequest.PaymentMethods = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.PayPalEmailAddress"/> of type <see cref="string"/>.
		/// </summary>
		public string PayPalEmailAddress
		{ 
			get { return ApiRequest.PayPalEmailAddress; }
			set { ApiRequest.PayPalEmailAddress = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.CheckoutInstructions"/> of type <see cref="string"/>.
		/// </summary>
		public string CheckoutInstructions
		{ 
			get { return ApiRequest.CheckoutInstructions; }
			set { ApiRequest.CheckoutInstructions = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.EmailCopyToSeller"/> of type <see cref="bool"/>.
		/// </summary>
		public bool EmailCopyToSeller
		{ 
			get { return ApiRequest.EmailCopyToSeller; }
			set { ApiRequest.EmailCopyToSeller = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.CODCost"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType CODCost
		{ 
			get { return ApiRequest.CODCost; }
			set { ApiRequest.CODCost = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiRequest.SKU; }
			set { ApiRequest.SKU = value; }
		}
		
		

		#endregion

		
	}
}
