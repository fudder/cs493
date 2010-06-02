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
	public class ReviseCheckoutStatusCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ReviseCheckoutStatusCall()
		{
			ApiRequest = new ReviseCheckoutStatusRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ReviseCheckoutStatusCall(ApiContext ApiContext)
		{
			ApiRequest = new ReviseCheckoutStatusRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// A seller can use this call to update the payment details and status
		/// of a transaction or order.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique ID for the item associated with the checkout. A transaction is
		/// uniquely identified by one of two means: (a) You provide a TransactionID
		/// and ItemID. (This is the preferred approach.), OR, (b) You provide a
		/// BuyerID and ItemID and eBay identifies only one transaction for that
		/// combination (an error is returned if there are multiple transactions for
		/// that combination). Note: If all three are provided (that is, BuyerID,
		/// ItemID and TransactionID), BuyerID is ignored.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique ID for the transaction associated with the checkout. For Chinese
		/// auctions, the value passed in the TransactionID argument must be 0 or the
		/// call will fail with an error. For all other auction types, TransactionID
		/// accepts the actual, nonzero transaction ID. Call GetItemTransactionsCall
		/// or GetSellerTransactionsCall to determine the correct transaction ID. A
		/// transaction is uniquely identified by one of two means: (a) You provide a
		/// TransactionID and ItemID. (This is the preferred approach.), OR, (b) You
		/// provide a BuyerID and ItemID and eBay identifies only one transaction for
		/// that combination (an error is returned if there are multiple transactions
		/// for that combination). Note: If all three are provided (that is, BuyerID,
		/// ItemID and TransactionID), BuyerID is ignored.
		/// </param>
		///
		/// <param name="OrderID">
		/// Unique ID for a multi-item order. If specified, ItemID and
		/// TransactionID are ignored if specified in the same call.
		/// Changes to the checkout status are applied to the specified
		/// order as a whole (and thus the child transactions
		/// associated with the order).
		/// </param>
		///
		/// <param name="AmountPaid">
		/// The total amount paid by the buyer. For a US eBay Motors item,
		/// AmountPaid is the total amount paid by the buyer for the deposit.
		/// AmountPaid is optional if CheckoutStatus is Incomplete and required if it
		/// is Complete.
		/// </param>
		///
		/// <param name="PaymentMethodUsed">
		/// Payment method used by the buyer.
		/// Required if CheckoutStatus is Complete.
		/// (Please note that only PayPal can set this value to PayPal.)
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// Required or allowed payment methods vary by site and category. Refer to
		/// <a href="http://developer.ebay.com/DevZone/XML/docs/WebHelp/wwhelp/wwhimpl/js/html/wwhelp.htm?context=eBay_XML_API&topic=PaymentMethodDifferences">
		/// Payment Method Differences (PaymentMethod)</a> in the eBay
		/// Trading API Guide for information to help you determine which payment
		/// methods you are required or allowed to specify.
		/// </span>
		/// 
		/// </param>
		///
		/// <param name="CheckoutStatus">
		/// The current status of the checkout process for the transaction.
		/// </param>
		///
		/// <param name="ShippingService">
		/// The shipping service selected by the buyer from among the shipping
		/// services offered by the seller (such as UPS Ground). For a list of valid
		/// values that you can cache for future use, call GeteBayDetails with
		/// DetailName set to ShippingServiceDetails.
		/// </param>
		///
		/// <param name="ShippingIncludedInTax">
		/// An indicator of whether shipping costs were included in the
		/// taxable amount. For Third-Party Checkout applications.
		/// </param>
		///
		/// <param name="CheckoutMethod">
		/// Not supported.
		/// </param>
		///
		/// <param name="InsuranceType">
		/// The insurance option selected by the buyer.
		/// </param>
		///
		/// <param name="PaymentStatus">
		/// Marks the transaction status as Paid or awaiting payment
		/// in My eBay. If you specify Paid, My eBay shows an icon
		/// to indicate that the transaction status is Paid.
		/// If Pending, it means the transaction is awaiting payment.
		/// (Some applications may use Pending when the buyer has paid 
		/// but the funds have not yet been sent to the seller's financial 
		/// institution.)
		/// </param>
		///
		/// <param name="AdjustmentAmount">
		/// Discount or charge agreed to by the buyer and seller. A positive value
		/// indicates that the amount is an extra charge being paid to the seller by
		/// the buyer. A negative value indicates that the amount is a discount given
		/// to the buyer by the seller.
		/// </param>
		///
		/// <param name="ShippingAddress">
		/// For internal use.
		/// </param>
		///
		/// <param name="BuyerID">
		/// eBay ID for the buyer in the transaction being revised. A transaction is
		/// uniquely identified by one of two means: (a) You provide a TransactionID
		/// and ItemID. (This is the preferred approach.), OR, (b) You provide a
		/// BuyerID and ItemID and eBay identifies only one transaction for that
		/// combination (an error is returned if there are multiple transactions for
		/// that combination). Note: If all three are provided (that is, BuyerID,
		/// ItemID and TransactionID), BuyerID is ignored.
		/// </param>
		///
		/// <param name="ShippingInsuranceCost">
		/// Amount of money paid for insurance. For Third Party Checkout
		/// applications.
		/// </param>
		///
		/// <param name="SalesTax">
		/// Amount of money paid for sales tax. For Third-Party Checkout
		/// applications.
		/// </param>
		///
		/// <param name="ShippingCost">
		/// Amount of money paid for shipping. For Third-party Checkout
		/// applications.
		/// </param>
		///
		/// <param name="EncryptedID">
		/// Not supported.
		/// </param>
		///
		/// <param name="ExternalTransaction">
		/// </param>
		///
		/// <param name="MultipleSellerPaymentID">
		/// Not supported.
		/// </param>
		///
		/// <param name="CODCost">
		/// Italy site (site ID 101) only.
		/// Enables you to specify the cash-on-delivery (COD) cost, for COD shipping.
		/// </param>
		///
		public void ReviseCheckoutStatus(string ItemID, string TransactionID, string OrderID, AmountType AmountPaid, BuyerPaymentMethodCodeType PaymentMethodUsed, CompleteStatusCodeType CheckoutStatus, string ShippingService, bool ShippingIncludedInTax, CheckoutMethodCodeType CheckoutMethod, InsuranceSelectedCodeType InsuranceType, RCSPaymentStatusCodeType PaymentStatus, AmountType AdjustmentAmount, AddressType ShippingAddress, string BuyerID, AmountType ShippingInsuranceCost, AmountType SalesTax, AmountType ShippingCost, string EncryptedID, ExternalTransactionType ExternalTransaction, string MultipleSellerPaymentID, AmountType CODCost)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.AmountPaid = AmountPaid;
			this.PaymentMethodUsed = PaymentMethodUsed;
			this.CheckoutStatus = CheckoutStatus;
			this.ShippingService = ShippingService;
			this.ShippingIncludedInTax = ShippingIncludedInTax;
			this.CheckoutMethod = CheckoutMethod;
			this.InsuranceType = InsuranceType;
			this.PaymentStatus = PaymentStatus;
			this.AdjustmentAmount = AdjustmentAmount;
			this.ShippingAddress = ShippingAddress;
			this.BuyerID = BuyerID;
			this.ShippingInsuranceCost = ShippingInsuranceCost;
			this.SalesTax = SalesTax;
			this.ShippingCost = ShippingCost;
			this.EncryptedID = EncryptedID;
			this.ExternalTransaction = ExternalTransaction;
			this.MultipleSellerPaymentID = MultipleSellerPaymentID;
			this.CODCost = CODCost;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void ReviseCheckoutStatus(string ItemID, string TransactionID, CompleteStatusCodeType CheckoutStatus)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.CheckoutStatus = CheckoutStatus;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void ReviseCheckoutStatus(string OrderID, CompleteStatusCodeType CheckoutStatus)
		{
			this.OrderID = OrderID;
			this.TransactionID = TransactionID;
			this.CheckoutStatus = CheckoutStatus;
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
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType"/> for this API call.
		/// </summary>
		public ReviseCheckoutStatusRequestType ApiRequest
		{ 
			get { return (ReviseCheckoutStatusRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ReviseCheckoutStatusResponseType"/> for this API call.
		/// </summary>
		public ReviseCheckoutStatusResponseType ApiResponse
		{ 
			get { return (ReviseCheckoutStatusResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.AmountPaid"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType AmountPaid
		{ 
			get { return ApiRequest.AmountPaid; }
			set { ApiRequest.AmountPaid = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.PaymentMethodUsed"/> of type <see cref="BuyerPaymentMethodCodeType"/>.
		/// </summary>
		public BuyerPaymentMethodCodeType PaymentMethodUsed
		{ 
			get { return ApiRequest.PaymentMethodUsed; }
			set { ApiRequest.PaymentMethodUsed = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.CheckoutStatus"/> of type <see cref="CompleteStatusCodeType"/>.
		/// </summary>
		public CompleteStatusCodeType CheckoutStatus
		{ 
			get { return ApiRequest.CheckoutStatus; }
			set { ApiRequest.CheckoutStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ShippingService"/> of type <see cref="string"/>.
		/// </summary>
		public string ShippingService
		{ 
			get { return ApiRequest.ShippingService; }
			set { ApiRequest.ShippingService = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ShippingIncludedInTax"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShippingIncludedInTax
		{ 
			get { return ApiRequest.ShippingIncludedInTax; }
			set { ApiRequest.ShippingIncludedInTax = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.CheckoutMethod"/> of type <see cref="CheckoutMethodCodeType"/>.
		/// </summary>
		public CheckoutMethodCodeType CheckoutMethod
		{ 
			get { return ApiRequest.CheckoutMethod; }
			set { ApiRequest.CheckoutMethod = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.InsuranceType"/> of type <see cref="InsuranceSelectedCodeType"/>.
		/// </summary>
		public InsuranceSelectedCodeType InsuranceType
		{ 
			get { return ApiRequest.InsuranceType; }
			set { ApiRequest.InsuranceType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.PaymentStatus"/> of type <see cref="RCSPaymentStatusCodeType"/>.
		/// </summary>
		public RCSPaymentStatusCodeType PaymentStatus
		{ 
			get { return ApiRequest.PaymentStatus; }
			set { ApiRequest.PaymentStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.AdjustmentAmount"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType AdjustmentAmount
		{ 
			get { return ApiRequest.AdjustmentAmount; }
			set { ApiRequest.AdjustmentAmount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ShippingAddress"/> of type <see cref="AddressType"/>.
		/// </summary>
		public AddressType ShippingAddress
		{ 
			get { return ApiRequest.ShippingAddress; }
			set { ApiRequest.ShippingAddress = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.BuyerID"/> of type <see cref="string"/>.
		/// </summary>
		public string BuyerID
		{ 
			get { return ApiRequest.BuyerID; }
			set { ApiRequest.BuyerID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ShippingInsuranceCost"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType ShippingInsuranceCost
		{ 
			get { return ApiRequest.ShippingInsuranceCost; }
			set { ApiRequest.ShippingInsuranceCost = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.SalesTax"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType SalesTax
		{ 
			get { return ApiRequest.SalesTax; }
			set { ApiRequest.SalesTax = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ShippingCost"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType ShippingCost
		{ 
			get { return ApiRequest.ShippingCost; }
			set { ApiRequest.ShippingCost = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.EncryptedID"/> of type <see cref="string"/>.
		/// </summary>
		public string EncryptedID
		{ 
			get { return ApiRequest.EncryptedID; }
			set { ApiRequest.EncryptedID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.ExternalTransaction"/> of type <see cref="ExternalTransactionType"/>.
		/// </summary>
		public ExternalTransactionType ExternalTransaction
		{ 
			get { return ApiRequest.ExternalTransaction; }
			set { ApiRequest.ExternalTransaction = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.MultipleSellerPaymentID"/> of type <see cref="string"/>.
		/// </summary>
		public string MultipleSellerPaymentID
		{ 
			get { return ApiRequest.MultipleSellerPaymentID; }
			set { ApiRequest.MultipleSellerPaymentID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseCheckoutStatusRequestType.CODCost"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType CODCost
		{ 
			get { return ApiRequest.CODCost; }
			set { ApiRequest.CODCost = value; }
		}
		
		

		#endregion

		
	}
}
