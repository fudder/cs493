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
using System.Xml;
using System.Xml.XPath;
using System.Collections.Specialized;
using System.Xml.Xsl;
using System.IO;

using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.SDK.Attribute;
using eBay.Service.Call;
using Samples.Helper.Cache;

namespace Attributes
{
	/// <summary>
	/// Summary description for CategoryList.
	/// </summary>
	public partial class CategoryList : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
			}
			else
			{
				return;
			}
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

		public void addCategories()
		{
			CategoryTypeCollection cats = (CategoryTypeCollection)Session[Global.CATEGORIES];
			string name;
			SortedList catSL = new SortedList();

			foreach (CategoryType cat in cats) 
			{
				if( !cat.LeafCategory )
					continue;
				catSL.Add(int.Parse(cat.CategoryID), cat); 
			}
			for ( int i = 0; i < catSL.Count; i++ )  
			{
				CategoryType cat = (CategoryType) catSL.GetByIndex(i);
				name = cat.CategoryName;
				int csId=int.MinValue;
				bool hasCharacterstic=false;

				if(cat.CharacteristicsSets!=null
					&&cat.CharacteristicsSets.Count>0)
				{
					csId = cat.CharacteristicsSets[0].AttributeSetID;
					hasCharacterstic=true;
				}

				string csID=hasCharacterstic?("-" + csId):string.Empty;
				if (name != null && name.Length > 1) 
				{

					Response.Write("<option value=\"" + cat.CategoryID + "\"" + ">" + 
						cat.CategoryName + " (" + cat.CategoryID + csID + ")</option>");
				}
				else 
				{
					Response.Write("<option value=\"" + cat.CategoryID + "\"" + ">" + 
						cat.CharacteristicsSets[0].Name + "[" + cat.CategoryID + csID + "]</option>");
				}
			}
		}

		protected void btSubmit_Click(object sender, System.EventArgs e)
		{
			NameValueCollection request = Request.Form;
			string cat1 = request[CAT_ID];
			string cat2 = request[CAT_ID2];
			if (cat1 == null || cat1.Length == 0) 
			{
				pageError.Text = "Please select first category.";
				return;
			}
			if (cat1.Equals(cat2)) 
			{
				cat2 = "";
			}

			try
			{
				getCategoryFeaturse(cat1);
				Response.Redirect("AttributeInfo.aspx?catId=" + cat1 + "&catId2=" + cat2 + "&" + Global.ACTION + "=attributes");
			}
			/*
			catch(System.Threading.ThreadAbortException)
			{
				//calling Response.Redirect() method will cause this exception, just ignore it.
			}*/
			catch (System.Exception err)
			{
				this.pageError.Text=err.Message;
			}	
		}

		//recursively find out the payment metheds for a given category
		private BuyerPaymentMethodCodeTypeCollection getPaymentMethods(string catId, Hashtable catsTable, Hashtable cfsTable)
		{
			if(cfsTable.ContainsKey(catId))
			{
				CategoryFeatureType cf = (CategoryFeatureType)cfsTable[catId];
				if (cf.PaymentMethod != null)
				{
					return cf.PaymentMethod;
				}
			}

			CategoryType cat = (CategoryType)catsTable[catId];
			//if we reach top level, return null
			if (cat.CategoryLevel == 1)
			{
				return null;
			}

			//check parent category
			return getPaymentMethods(cat.CategoryParentID[0], catsTable, cfsTable);
			
		}

		//recursively find out the listing duration reference type for a given category
		private ListingDurationReferenceTypeCollection getListingTypes(string catId, Hashtable catsTable, Hashtable cfsTable)
		{
			if (cfsTable.ContainsKey(catId))
			{
				CategoryFeatureType cf = cfsTable[catId] as CategoryFeatureType;
				if (cf.ListingDuration != null) 
				{
					return cf.ListingDuration;
				}
			}

			CategoryType cat = catsTable[catId] as CategoryType;
			//if we reach top level, return null
			if (cat.CategoryLevel == 1)
			{
				return null;
			}

			//check parent category
			return getListingTypes(cat.CategoryParentID[0], catsTable, cfsTable);
		}


		//find out category features and cache them in session
		private void getCategoryFeaturse(string catid)
		{
			ApiContext context = (ApiContext)Session[Global.APISESSION];
			
			Hashtable catsTable = Global.GetAllCategoriesTable(context);

			//get all category features for a given site
			Global.syncAllCategoriesFeatures(context);
			Hashtable cfsTable = Global.siteCategoriesFeaturesTable[context.Site] as Hashtable;
			SiteDefaultsType siteDefaults = Global.siteFeatureDefaultTable[context.Site] as SiteDefaultsType;
			FeatureDefinitionsType featureDefinition = Global.siteFeatureDefinitionsTable[context.Site] as FeatureDefinitionsType;


			CategoryFeatureType cf = cfsTable[catid] as CategoryFeatureType;
			//get item SpecificsEnabled feature
			//workaround, if no CategoryFeature found, just use site defaults
			ItemSpecificsEnabledCodeType itemSpecificEnabled = (cf == null)?siteDefaults.ItemSpecificsEnabled:cf.ItemSpecificsEnabled;
			Session[Global.CATEGORY_FEATURES_ITEM_SPECIFIC_ENABLED] = itemSpecificEnabled;
			
			//get returnPolicyEnabled feature
            //workaround, just siteDefaults now
            //bool retPolicyEnabled = (cf == null)?siteDefaults.ReturnPolicyEnabled:cf.ReturnPolicyEnabled;
            bool retPolicyEnabled = siteDefaults.ReturnPolicyEnabled;
			Session[Global.CATEGORY_FEATURES_RETURN_POLICY_ENABLED] = retPolicyEnabled;

			//listing types, recursively search
			ListingDurationReferenceTypeCollection listingTypes = getListingTypes(catid, catsTable, cfsTable);
			if (listingTypes == null || listingTypes.Count == 0)//get site defaults
			{
				listingTypes = siteDefaults.ListingDuration;
			}
			//listing duration definitions
			ListingDurationDefinitionsType listingDurations=featureDefinition.ListingDurations;
			//get a mapping from listing type to duration
			Session[Global.LISTING_TYPE_DURATION_MAPPING] = constructListingTypeDurationMapping(listingTypes,listingDurations);

			//payment methods
			BuyerPaymentMethodCodeTypeCollection paymentMethods = getPaymentMethods(catid, catsTable, cfsTable);
			if (paymentMethods == null || paymentMethods.Count == 0)//get site defautls
			{
				paymentMethods = siteDefaults.PaymentMethod;
			}
			Session[Global.CATEGORY_FEATURES_PAYMENT_METHOD] = paymentMethods;
		}

		
		/// <summary>
		/// construct a mapping from listing type to listing duration
		/// </summary>
		/// <param name="listingTypes"></param>
		/// <param name="listingDurations"></param>
		/// <returns>Hashtable</returns>
		private Hashtable constructListingTypeDurationMapping(ListingDurationReferenceTypeCollection listingTypes,ListingDurationDefinitionsType listingDurations)
		{
			Hashtable listingTypeDurationMap = new Hashtable();
			eBay.Service.Core.Soap.StringCollection listingDuration = null;

			foreach (ListingDurationReferenceType listingType in listingTypes)
			{
				string key =listingType.type.ToString();
				//iterate listingDuration collection to find specific listingDuration whose durationSetID equals listingType id
				foreach (ListingDurationDefinitionType definition in listingDurations.ListingDuration)
				{
					if(definition.durationSetID.Equals(listingType.Value))
					{
						listingDuration=definition.Duration;
					}
				}

				listingTypeDurationMap.Add(key,listingDuration);
			}

			return listingTypeDurationMap;
		}
	
		private const string CATEGORY = "Category";
		private const string CATEGORY2 = "Category2";
		
		public const string CAT_ID = "catId";
		public const string CAT_ID2 = "catId2";
		public const string ASPX_CATEGORY_LIST = "CategoryList.aspx";
	}
}
