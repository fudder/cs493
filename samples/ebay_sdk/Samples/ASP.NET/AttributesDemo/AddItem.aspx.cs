#region Copyright
//	Copyright (c) 2007 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.SDK.Attribute;
using eBay.Service.Call;
using eBay.Service.Util;

namespace Attributes
{
	/// <summary>
	/// Summary description for AddItem.
	/// </summary>
	public partial class AddItem : System.Web.UI.Page
	{


		//a flag used to mark whether the category is Return Policy Enabled
		private static readonly  string RETURN_POLICY_ENABLE="ReturnPolicyEnable";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			SiteCodeType siteId = (SiteCodeType)Session[Global.SITE];
			this.Currency.Text = Global.GetCurrencyType(siteId).ToString();
			if(!Page.IsPostBack)
			{
				ltlReturnPolicyEnalbed.Text=string.Empty;
				PopulateAllFields();
			}
		}


		protected void Page_PreRender(object sender,System.EventArgs e)
		{
			if(Page.IsPostBack)
			{
				ListItem tmpItem=ddlListingType.Items.FindByText(ddlListingType.SelectedItem.Text);
				tmpItem.Selected=true;
			}
			ltlReturnPolicyEnalbed.Visible=false;
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void BtnAddItem_Click(object sender, System.EventArgs e)
		{
			try 
			{
				AttributesMaster attrMaster = (AttributesMaster)Session[Global.ATTRIBUTES_MASTER];

				//
				ApiContext asn = (ApiContext)Session[Global.APISESSION];
				AddItemCall api = new AddItemCall(asn);

				// Create the item
				ItemType item = new ItemType();

				item.Site = (SiteCodeType)Session[Global.SITE];
				item.Country = CountryCodeType.US;

				item.ListingType = (ListingTypeCodeType)Enum.Parse(typeof(ListingTypeCodeType),this.ddlListingType.SelectedValue.ToString());
				if(item.ListingType.Equals(ListingTypeCodeType.LeadGeneration))
				{
					item.ListingSubtype2=ListingSubtypeCodeType.ClassifiedAd;
				}
				item.Title = this.ItemTitle.Text;
				item.Description = this.Description.Text;
				item.Currency = Global.GetCurrencyType(item.Site);

				if(this.StartPrice.Text!=string.Empty)
				{
					item.StartPrice = new AmountType();
					item.StartPrice.currencyID = item.Currency;
					item.StartPrice.Value = Convert.ToDouble(this.StartPrice.Text);
				}

				if(this.BuyItNowPrice.Text!=string.Empty)
				{
					item.BuyItNowPrice = new AmountType();
					item.BuyItNowPrice.currencyID = item.Currency;
					item.BuyItNowPrice.Value = Convert.ToDouble(this.BuyItNowPrice.Text);
				}

				item.Quantity = Int32.Parse(this.Quantity.Text);

				item.Location = this.ItemLocation.Text;
				item.ListingDuration = this.ItemDuration.SelectedItem.Value;

				ListingEnhancementsCodeTypeCollection enhancements = new ListingEnhancementsCodeTypeCollection();
				enhancements.Add(ListingEnhancementsCodeType.BoldTitle);
				item.ListingEnhancement = enhancements;

				// Set Attributes property.
				int catID = (int)Session["CategoryId"];
				item.PrimaryCategory = new CategoryType();
				item.PrimaryCategory.CategoryID = catID.ToString();

				catID = (int)Session["Category2Id"];
				if( catID != 0 )
				{
					item.SecondaryCategory = new CategoryType();
					item.SecondaryCategory.CategoryID = catID.ToString();
				}

				IAttributeSetCollection itemAttributes=null;
				if(Session[Global.ITEM_ATTR_SETS]!=null)
				{
					itemAttributes = (IAttributeSetCollection)Session[Global.ITEM_ATTR_SETS];
					item.AttributeSetArray = attrMaster.ConvertAttributeSetArray(itemAttributes);
				}
				if (Session[Global.CUSTOME_ITEM_SPECIFIC]!=null)
				{
					item.ItemSpecifics=(NameValueListTypeCollection)Session[Global.CUSTOME_ITEM_SPECIFIC];
				}

				// Motor
				if( this.MotorSubtitle.Text.Length > 0 )
				{
					MotorAttributeHelper mh = new MotorAttributeHelper(item.AttributeSetArray[0]);
					mh.Subtitle = this.MotorSubtitle.Text;
					if( this.MotorDepositAmount.Text.Length > 0 )
						mh.DepositAmount = Decimal.Parse(this.MotorDepositAmount.Text);
				}
				
				if(ddlShippingServiceDetails.SelectedItem.Value != "None") 
				{
					//add shipping information
					item.ShippingDetails=getShippingDetails(ddlShippingServiceDetails.SelectedItem.Value);
				}
				//add handling time
				item.DispatchTimeMax=1;
				//add return policy
				if(ltlReturnPolicyEnalbed.Text!=string.Empty&&ltlReturnPolicyEnalbed.Text==RETURN_POLICY_ENABLE)
				{
					item.ReturnPolicy=getReturnPolicy();
				}

			    //get shipping locations
				item.ShipToLocations=getShppingLocations();
				//set payments
				setPaymentMethods(item);

				FeeTypeCollection fees = api.AddItem(item);

				viewItemInfo(item);
			}
			catch(Exception ex) 
			{
				this.StatusText.Text = ex.Message;
				this.StatusText.Visible = true;
			}
		}

		
		//display appropriate listingDuration based on listingType
		protected void ddlListingType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			populateListingDurationFields();
		}


		//display dynamic information
		private void PopulateAllFields()
		{
			populateReturnPolicyFields();
			populateShippingServiceFields();
			populateListingTypeFields();
			populateListingDurationFields();
			populatePaymentMethodFields();
		}

		//display return policy
		private void populateReturnPolicyFields()
		{
			GeteBayDetailsResponseType ebayDetails=getEbayDetails();
			bool enableReturnPolicyForCategory=false;

			if (ebayDetails==null)
			{
				return;
			}

			enableReturnPolicyForCategory = System.Convert.ToBoolean(Session[Global.CATEGORY_FEATURES_RETURN_POLICY_ENABLED].ToString());

			if(enableReturnPolicyForCategory)
			{
				ltlReturnPolicyEnalbed.Text=RETURN_POLICY_ENABLE;
				pnlReturnPolicy.Visible=true;
				
				if (ebayDetails.ReturnPolicyDetails!=null)
				{
					RefundDetailsTypeCollection refundCol = ebayDetails.ReturnPolicyDetails.Refund;
					ReturnsWithinDetailsTypeCollection returnsWithinCol = ebayDetails.ReturnPolicyDetails.ReturnsWithin;
					ReturnsAcceptedDetailsTypeCollection returnsAcceptedCol = ebayDetails.ReturnPolicyDetails.ReturnsAccepted;
					ShippingCostPaidByDetailsTypeCollection costPaidByCol = ebayDetails.ReturnPolicyDetails.ShippingCostPaidBy;

					//bind refund
					if (refundCol==null||refundCol.Count<=0)
					{
						ddlRefund.Visible=false;
						ltlRefund.Visible=false;
					}
					else
					{
						ddlRefund.Visible=true;
						ltlRefund.Visible=true;
						ddlRefund.Items.Clear();
						foreach(RefundDetailsType refund in refundCol)
						{
							ListItem item=new ListItem();
							item.Text=refund.Description;
							item.Value=refund.RefundOption;
							ddlRefund.Items.Add(item);
						}
					}
					

					//bind returnWithIn
					if (returnsWithinCol==null||returnsWithinCol.Count<=0)
					{
						ddlReturnWithin.Visible=false;
						ltlReturnWithin.Visible=false;
					}
					else
					{
						ddlReturnWithin.Visible=true;
						ltlReturnWithin.Visible=true;
						ddlReturnWithin.Items.Clear();
						foreach(ReturnsWithinDetailsType refund in returnsWithinCol)
						{
							ListItem item=new ListItem();
							item.Text=refund.Description;
							item.Value=refund.ReturnsWithinOption;
							ddlReturnWithin.Items.Add(item);
						}
					}

					//bind returnAccepted
					if (returnsAcceptedCol==null||returnsAcceptedCol.Count<=0)
					{
						ddlReturnAccepted.Visible=false;
						ltlReturnAccepted.Visible=false;
					}
					else
					{
						ddlReturnAccepted.Visible=true;
						ltlReturnAccepted.Visible=true;
						ddlReturnAccepted.Items.Clear();
						foreach(ReturnsAcceptedDetailsType refund in returnsAcceptedCol)
						{
							ListItem item=new ListItem();
							item.Text=refund.Description;
							item.Value=refund.ReturnsAcceptedOption;
							ddlReturnAccepted.Items.Add(item);
						}
					}				

					//bind costPaidBy
					if (returnsAcceptedCol==null||returnsAcceptedCol.Count<=0)
					{
						ddlShippingCostPaidBy.Visible=false;
						ltlShippingPaidBy.Visible=false;
					}
					else
					{
						ddlShippingCostPaidBy.Visible=true;
						ltlShippingPaidBy.Visible=true;
						ddlShippingCostPaidBy.Items.Clear();
						foreach(ShippingCostPaidByDetailsType refund in costPaidByCol)
						{
							ListItem item=new ListItem();
							item.Text=refund.Description;
							item.Value=refund.ShippingCostPaidByOption;
							ddlShippingCostPaidBy.Items.Add(item);
						}		
					}
				}
			}
			else
			{
				pnlReturnPolicy.Visible=false;
			}

		}


		//display shipping service
		private void populateShippingServiceFields()
		{
			GeteBayDetailsResponseType ebayDetails=getEbayDetails();
			if (ebayDetails!=null)
			{
				ShippingServiceDetailsTypeCollection shippingDetailCol = ebayDetails.ShippingServiceDetails;
				
				//for eBayMotors site, we add a 'None' Shipping Service
				SiteCodeType site = (SiteCodeType)Session[Global.SITE];
				if (site == SiteCodeType.eBayMotors) 
				{

					ListItem item = new ListItem();
					item.Text = "None";
					item.Value = "None";
					this.ddlShippingServiceDetails.Items.Add(item);

				}

				if(shippingDetailCol!=null)
				{
					//bind shipping details
					foreach(ShippingServiceDetailsType shippingDetail in shippingDetailCol)
					{
						if(shippingDetail.ServiceType.Contains(ShippingTypeCodeType.Flat))
						{
							ListItem item=new ListItem();
							item.Text=shippingDetail.Description;
							item.Value=shippingDetail.ShippingService.ToString();
							if(shippingDetail.ShippingServiceID<5000)
							{
								ddlShippingServiceDetails.Items.Add(item);
							}
						}
					}
				}

				//bind locations
				ShippingLocationDetailsTypeCollection locationCol = ebayDetails.ShippingLocationDetails;
				if(locationCol!=null)
				{
					cblLocation.Items.Clear();
					foreach (ShippingLocationDetailsType location in locationCol)
					{
						ListItem item=new ListItem();
						item.Text=location.Description;
						item.Value=location.ShippingLocation;
						cblLocation.Items.Add(item);
					}
				}
			}
		}

		//display listing type
		private void populateListingTypeFields()
		{
			Hashtable listingTypeDuration=getListingTypeDuration();
			IDictionaryEnumerator myEnumerator = listingTypeDuration.GetEnumerator();

			ddlListingType.Items.Clear();
			while (myEnumerator.MoveNext())
			{
				ListItem item=new ListItem();
				item.Text=myEnumerator.Key.ToString();
				item.Value=myEnumerator.Key.ToString();
				ddlListingType.Items.Add(item);
			}
		}


		//display listing duration
		private void populateListingDurationFields()
		{
			Hashtable listingTypeDuration=getListingTypeDuration();
			string key = ddlListingType.SelectedItem.Value;
			StringCollection listingDuration = (StringCollection)listingTypeDuration[key];

			ItemDuration.Items.Clear();
			foreach(string duration in listingDuration)
			{
				ListItem item=new ListItem();
				item.Text=duration;
				item.Value=duration;
				ItemDuration.Items.Add(item);
			}
		}


		//display payment methods
		private void populatePaymentMethodFields()
		{
			BuyerPaymentMethodCodeTypeCollection paymentMethods=getPaymentMethods();
			cblPaymentMethod.Items.Clear();
			foreach (BuyerPaymentMethodCodeType payment in paymentMethods)
			{
				ListItem item=new ListItem();
				item.Text=payment.ToString();
				item.Value=payment.ToString();
				cblPaymentMethod.Items.Add(item);
			}
		}

		//get ebay detais from session
		private GeteBayDetailsResponseType getEbayDetails()
		{
			if(Session[Global.EBAY_DETAILS]!=null)
			{
				return (GeteBayDetailsResponseType)Session[Global.EBAY_DETAILS];
			}
			else
			{
				return null;
			}
		}

		//get features from session
		private BuyerPaymentMethodCodeTypeCollection getPaymentMethods()
		{
			if(Session[Global.CATEGORY_FEATURES_PAYMENT_METHOD]!=null)
			{
				return (BuyerPaymentMethodCodeTypeCollection)Session[Global.CATEGORY_FEATURES_PAYMENT_METHOD];
			}
			else
			{
				return null;
			}
		}

		//get listingTypeDuration mapping from session
		private Hashtable getListingTypeDuration()
		{
			if(Session[Global.LISTING_TYPE_DURATION_MAPPING]!=null)
			{
				return (Hashtable)Session[Global.LISTING_TYPE_DURATION_MAPPING];
			}
			else
			{
				return null;
			}
		}

		private ShippingDetailsType getShippingDetails(String shippingService)
		{
			// Shipping details.
			SiteCodeType site = (SiteCodeType)Session[Global.SITE];
			ShippingDetailsType sd = new ShippingDetailsType();
			SalesTaxType salesTax = new SalesTaxType();
			salesTax.SalesTaxPercent=0.0825f;
			salesTax.SalesTaxState="CA";
			sd.ApplyShippingDiscount=true;
			AmountType at =new AmountType();
			at.Value=0.1;
			at.currencyID=Global.GetCurrencyType(site);
			sd.InsuranceFee=at;
			sd.InsuranceOption=InsuranceOptionCodeType.Optional;
			sd.PaymentInstructions="eBay DotNet SDK test instruction.";

			// Set calculated shipping.
			sd.ShippingType=ShippingTypeCodeType.Flat;
			//
			ShippingServiceOptionsType st1 = new ShippingServiceOptionsType();
			st1.ShippingService=shippingService;
			at = new AmountType();
			at.Value=0.1;
			at.currencyID=Global.GetCurrencyType(site);
			st1.ShippingServiceAdditionalCost=at;
			at = new AmountType();
			at.Value=0.1;
			at.currencyID=Global.GetCurrencyType(site);
			st1.ShippingServiceCost=at;
			st1.ShippingServicePriority=1;
			at = new AmountType();
			at.Value=0.1;
			at.currencyID=Global.GetCurrencyType(site);
			st1.ShippingInsuranceCost=at;

			sd.ShippingServiceOptions=new ShippingServiceOptionsTypeCollection(new ShippingServiceOptionsType[]{st1});

			return sd;
		}


		//get shipping locations
		private StringCollection getShppingLocations()
		{
			StringCollection strCol=new StringCollection();

			foreach (ListItem item in cblLocation.Items)
			{
				if (item.Selected)
				{
					strCol.Add(item.Value);
				}
			}

			return strCol;
		}

		//set PaymentMethods
		private void setPaymentMethods(ItemType item)
		{
			BuyerPaymentMethodCodeTypeCollection paymentCol=new BuyerPaymentMethodCodeTypeCollection();
			foreach(ListItem li in cblPaymentMethod.Items)
			{
				if (li.Selected)
				{
					BuyerPaymentMethodCodeType paymentCodeType = (BuyerPaymentMethodCodeType)Enum.Parse(typeof(BuyerPaymentMethodCodeType),li.Value,false);
					paymentCol.Add(paymentCodeType);
					if (paymentCodeType==BuyerPaymentMethodCodeType.PayPal && txtPaypalAccount.Text!=string.Empty)
					{
						item.PayPalEmailAddress=txtPaypalAccount.Text;
					}
				}
			}

			item.PaymentMethods=paymentCol;
		}

		private void viewItemInfo(ItemType item)
		{
			System.Threading.Thread.Sleep(3000);
			string format = ConfigurationManager.AppSettings[Global.KEY_VIEWITEM_URL];
			string url = String.Format(format, item.ItemID);
			Response.Redirect(url);
			Response.End();
		}

		/// <summary>
		/// get a policy for us site only.
		/// </summary>
		/// <returns></returns>
		public  ReturnPolicyType getReturnPolicy()
		{
			ReturnPolicyType policy=new ReturnPolicyType();
			if (  ddlRefund.Visible==true
				&&ddlRefund.SelectedItem!=null)
			{
				policy.Refund=ddlRefund.SelectedItem.Value;
			}
			if (  ddlReturnWithin.Visible==true
				&&ddlReturnWithin.SelectedItem!=null)
			{
				policy.ReturnsWithinOption=ddlReturnWithin.SelectedItem.Value;
			}
			if (  ddlReturnAccepted.Visible==true
				&&ddlReturnAccepted.SelectedItem!=null)
			{
				policy.ReturnsAcceptedOption=ddlReturnAccepted.SelectedItem.Value;
			}
			if (  ddlShippingCostPaidBy.Visible==true
				&&ddlShippingCostPaidBy.SelectedItem!=null)
			{
				policy.ShippingCostPaidByOption=ddlShippingCostPaidBy.SelectedItem.Value;
			}
			policy.Description=txtReturnPolicyDescription.Text;

			return policy;
		}
	}

	
}
