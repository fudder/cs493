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

using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.SDK.Attribute;
using eBay.Service.Call;
using Samples.Helper.Cache;

namespace Attributes
{
	/// <summary>
	/// Summary description for SelectSite.
	/// </summary>
	public partial class SelectSite : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if( !this.IsPostBack )
			{
				initVersion();
				initializeSiteList();
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

		#region private methods
		
		/// <summary>
		/// initialize site list
		/// </summary>
		private void initializeSiteList()
		{
			this.ddlEbaySite.Items.Clear();
			string[] sites = Enum.GetNames(typeof(SiteCodeType));
			foreach (string site in sites)
			{
				//exclude CustomCode value and Taiwan site
				if (site != "CustomCode" && site!="Taiwan")
				{
					this.ddlEbaySite.Items.Add(site);
				}
			}
			this.ddlEbaySite.SelectedIndex = 0;
		}

		private void initVersion()
		{
			ApiContext context = (ApiContext)Session[Global.APISESSION];
			this.VersionLabel.Text = "v" + context.Version;
		}

		#endregion


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Continue_Click(object sender, System.EventArgs e)
		{
			SiteCodeType site = (SiteCodeType)Enum.Parse(typeof(SiteCodeType), this.ddlEbaySite.SelectedItem.Value, true);
			Session[Global.SITE] = site;
			string catID = this.TextBox1.Text;
			if (catID.Trim().Equals(string.Empty))
			{
				catID = null;
			}
			Session[Global.CATID] = catID;
			ApiContext context = (ApiContext)Session[Global.APISESSION];
			context.Site = site;
			Session[Global.CATEGORIES] = downloadCategories(context,catID);
			GeteBayDetailsResponseType geteBayDetailsResponseType = Global.GetEbayDetails(context);
			//for eBayMotors site, we use ShippingService on Site US
			if (site == SiteCodeType.eBayMotors) 
			{
				//set site to US
				context.Site = SiteCodeType.US;
				//get ShippingServices on Site US
				GeteBayDetailsResponseType geteBayDetailsResponseTypeUS = Global.GetEbayDetails(context);
				//set ShippingServiceDetails
				geteBayDetailsResponseType.ShippingServiceDetails = geteBayDetailsResponseTypeUS.ShippingServiceDetails;
				//reset site
				context.Site = site;
			}
			Session[Global.EBAY_DETAILS] = geteBayDetailsResponseType;
			Server.Transfer("CategoryList.aspx");
		}


	  /**
	   * Get categories using GetCategory2CS and GetCategories calls,
	   * although some categories have no characteristics sets, they may still have custom
	   * item specifics, so we merge the categories accordingly.
	   */
	   private CategoryTypeCollection downloadCategories(ApiContext context, string catID)
	   {
			AttributesMaster amst = initailAttributesMaster(context);
		    //Get all categories that are mapped to characteristics sets
			CategoryTypeCollection cats = ((CategoryCSDownloader)amst.CategoryCSProvider).GetCategoriesCS(catID);
			Hashtable csCatsTable = new Hashtable();
			foreach(CategoryType cat in cats) 
			{
				if (csCatsTable.ContainsKey(cat.CategoryID)) continue;
				csCatsTable.Add(cat.CategoryID, cat);
			}

		    //get all categories
		    Hashtable allCatsTable = Global.GetAllCategoriesTable(context);

		   if (catID != null) //one category case, catId specified
		   {
			   if (allCatsTable.ContainsKey(catID))
			   {
				   CategoryType cat = allCatsTable[catID] as CategoryType;
				   CategoryType csCat = csCatsTable[cat.CategoryID] as CategoryType;
				   if (csCat != null)
				   {
					   //copy category name and leaf category fields, since these
					   //fields are not set when using GetCategory2CS call.
					   csCat.CategoryName = cat.CategoryName;
					   csCat.LeafCategory = cat.LeafCategory;
				   }
				   else
				   {
					   //some category has no characteristic sets,
					   //but it may has custom item specifics
					   csCat = cat;
				   }
				   CategoryTypeCollection catCol = new CategoryTypeCollection();
				   catCol.Add(csCat);
				   return catCol;
			   }
			   else
			   {
				   //no category found
				   return new CategoryTypeCollection();
			   }

		   }
		   else //all categories case, catId not specified
		   {
			   foreach(CategoryType cat in allCatsTable.Values)
			   {
				   CategoryType csCat = csCatsTable[cat.CategoryID] as CategoryType;
				   if (csCat != null)
				   {
					   //copy category name and leaf category fields, since these
					   //fields are not set when using GetCategoryCS call.
					   csCat.CategoryName = cat.CategoryName;
					   csCat.LeafCategory = cat.LeafCategory;
				   }
				   else
				   {
					   //some category has no characteristics sets,
					   //but it may has custom item specifics
					   csCatsTable.Add(cat.CategoryID, cat);
				   }
			   }

			   CategoryTypeCollection catCol = new CategoryTypeCollection();
			   foreach(CategoryType cat in csCatsTable.Values)
			   {
				   catCol.Add(cat);
			   }

			   return catCol;

		   }

		}

		/// <summary>
		/// get an AttributeMaster instance object and set default value to that object
		/// </summary>
		/// <returns></returns>
		private AttributesMaster initailAttributesMaster(ApiContext context)
		{
			AttributesMaster amst = new AttributesMaster();
			// Set common site for all calls.
			context.Site = (SiteCodeType)Session[Global.SITE];
			//asn.ApiCallCommon.SiteId = (SiteCodeType)Session[Global.SITE]; 
			
			AttributesXmlDownloader axd = new AttributesXmlDownloader(context);
			amst.XmlProvider = axd;

			AttributesXslDownloader asd = new AttributesXslDownloader(context);
			amst.XslProvider = asd;

			CategoryCSDownloader ctd = new CategoryCSDownloader(context);
			amst.CategoryCSProvider = ctd;

			Session[Global.ATTRIBUTES_MASTER] = amst;
			return amst; 
		}
	}
}
