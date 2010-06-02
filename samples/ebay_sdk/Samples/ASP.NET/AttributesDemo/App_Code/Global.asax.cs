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
using System.Web;
using System.Web.SessionState;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection;

using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.SDK.Attribute;
using Samples.Helper.Cache;
using eBay.Service.Util;
using eBay.Service.Call;

namespace Attributes 
{
	/// <summary>
	/// 
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		const string KEY_API_URL = "ApiServerUrl";
		const string KEY_LOGFILE = "LogFile";
		const string KEY_USER_NAME = "UserName";
		const string KEY_PASSWORD = "Password";
		const string KEY_DEVELOPER = "Developer";
		const string KEY_APPLICATIOIN = "Application";
		const string KEY_CERTIFICATE = "Certificate";
		const string KEY_APITOKEN = "ApiToken";

		const int TABLE_SIZE = 30000;

		public const string KEY_VIEWITEM_URL = "ViewItemUrl";
		public const string ACTION = "action";

		// Keys in Session
		public const string ATTRIBUTES_MASTER = "AttributesMaster";
		public const string CATEGORIES = "Categories";
		public const string SITE = "Site";
		public const string CATID = "CategoryID";
		public const string APISESSION = "ApiContext";
		public const string ITEM_ATTR_SETS = "ItemAttributeSets";
		public const string JOINED_ATTR_SETS = "JoinedAttributeSets";
		public const string ITEM_SITE_WIDE_ATTR_SETS = "ItemSiteWideAttributeSets";
		public const string RETURN_POLICY_ATTR_SET = "ReturnPolicyAttributeSet";
		public const string CUSTOME_ITEM_SPECIFIC="CUSTOME_ITEM_SPECIFIC";
		public const string CATEGORY_FEATURES="CATEGORY_FEATURES";
		public const string EBAY_DETAILS="EBAY_DETAILS";
		public const string LISTING_TYPE_DURATION_MAPPING="LISTING_TYPE_DURATION_MAPPING";
		public const string CATEGORY_FEATURES_RETURN_POLICY_ENABLED="CATEGORY_FEATURES_RETURN_POLICY_ENABLED";
		public const string CATEGORY_FEATURES_ITEM_SPECIFIC_ENABLED="CATEGORY_FEATURES_ITEM_SPECIFIC_ENABLED";
		public const string CATEGORY_FEATURES_LIST_DURATIONS="CATEGORY_FEATURES_LIST_DURATIONS";
		public const string CATEGORY_FEATURES_PAYMENT_METHOD="CATEGORY_FEATURES_LIST_PAYMENT_METHOD";

		public static string HomeDir;
		public static string StartPage = "SelectSite.aspx";
		public static ApiLogManager LogManager = null;

		//two level map, site -> category id -> cateory
		public static Hashtable siteCategoriesTable = new Hashtable();
		//site -> eBayDetails
		private static Hashtable eBayDetailsTable = new Hashtable();

		public static Hashtable siteCategoriesFeaturesTable = new Hashtable();
		public static Hashtable siteFeatureDefaultTable = new Hashtable();
		public static Hashtable siteFeatureDefinitionsTable = new Hashtable();

		
		#region constructor

		public Global()
		{
		}	

		#endregion

		#region page events
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			Global.HomeDir = this.Context.Request.PhysicalApplicationPath;

			// Initialize log.
			string logPath = ConfigurationManager.AppSettings[Global.KEY_LOGFILE];
			if( logPath.Length > 0 )
			{
				LogManager = new ApiLogManager();
				
				LogManager.EnableLogging = true;

				LogManager.ApiLoggerList = new ApiLoggerCollection();
				ApiLogger log = new FileLogger(logPath, true, true, true);
				LogManager.ApiLoggerList.Add(log);
			}
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			if( LogManager != null )
			{
				//LogManager.Close();
				LogManager = null;
			}
		}

		protected void Session_Start(Object sender, EventArgs e)
		{
			Session[Global.APISESSION] = GetApiSession();
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{
		}

		#endregion

		public static CurrencyCodeType GetCurrencyType(SiteCodeType siteId)
		{
			CurrencyCodeType curr = CurrencyCodeType.USD;
			switch( siteId )
			{
				case SiteCodeType.US:
				case SiteCodeType.eBayMotors:
					curr = CurrencyCodeType.USD;
					break;
				case SiteCodeType.UK:
					curr = CurrencyCodeType.GBP;
					break;
				case SiteCodeType.Canada:
					curr = CurrencyCodeType.CAD;
					break;
				case SiteCodeType.Australia:
					curr = CurrencyCodeType.AUD;
					break;
				case SiteCodeType.Taiwan:
					curr = CurrencyCodeType.TWD;
					break;
				case SiteCodeType.Switzerland:
					curr = CurrencyCodeType.CHF;
					break;
				case SiteCodeType.Poland:
					curr = CurrencyCodeType.PLN;
					break;
				case SiteCodeType.India:
					curr = CurrencyCodeType.INR;
					break;
				case SiteCodeType.France:
				case SiteCodeType.Germany:
				case SiteCodeType.Italy:
				case SiteCodeType.Netherlands:
				case SiteCodeType.Belgium_Dutch:
				case SiteCodeType.Belgium_French:
				case SiteCodeType.Austria:
					curr = CurrencyCodeType.EUR;
					break;
				default:
					curr = CurrencyCodeType.USD;
					break;
			}

			return curr;
		}	

		public static CategoryType FindCategory(CategoryTypeCollection cats, string catId)
		{
			foreach(CategoryType cat in cats)
			{
				if (cat.CategoryID == catId) 
					return cat;
			}
			return null;
		}

		public static void syncAllCategoriesFeatures(ApiContext context)
		{
			if (!siteCategoriesFeaturesTable.ContainsKey(context.Site))
			{
				FeaturesDownloader downloader = new FeaturesDownloader(context);
				GetCategoryFeaturesResponseType resp = downloader.GetCategoryFeatures();
				CategoryFeatureTypeCollection cfCol = resp.Category;
				Hashtable cfsTable = new Hashtable(TABLE_SIZE);
				foreach(CategoryFeatureType cf in cfCol)
				{
					cfsTable.Add(cf.CategoryID, cf);
				}
				siteCategoriesFeaturesTable.Add(context.Site, cfsTable);
				siteFeatureDefaultTable.Add(context.Site, resp.SiteDefaults);
				siteFeatureDefinitionsTable.Add(context.Site, resp.FeatureDefinitions);
			}
		}

		//get all categories table
		public static Hashtable GetAllCategoriesTable(ApiContext apiContext) 
		{
			if (!siteCategoriesTable.ContainsKey(apiContext.Site))
			{
				Hashtable catsTable = new Hashtable(TABLE_SIZE);
				CategoriesDownloader downloader = new CategoriesDownloader(apiContext);
				CategoryTypeCollection catsCol = downloader.GetAllCategories();

				foreach(CategoryType cat in catsCol)
				{
					catsTable.Add(cat.CategoryID, cat);
				}
				siteCategoriesTable.Add(apiContext.Site, catsTable);
				return catsTable;
			}
			else
			{
				return siteCategoriesTable[apiContext.Site] as Hashtable;
			}
		}

		//get eBay details response
		public static GeteBayDetailsResponseType GetEbayDetails(ApiContext apiContext)
		{
			if (!eBayDetailsTable.ContainsKey(apiContext.Site))
			{
                DetailsDownloader downloader = new DetailsDownloader(apiContext);
                GeteBayDetailsResponseType response = downloader.GeteBayDetails();
                
				eBayDetailsTable.Add(apiContext.Site, response);
				return response;
			} 
			else
			{
				return eBayDetailsTable[apiContext.Site] as GeteBayDetailsResponseType;
			}
		}


		ApiContext GetApiSession()
		{
			ApiContext session = new ApiContext();

            session.SoapApiServerUrl = ConfigurationManager.AppSettings[KEY_API_URL];

			// Initialize log.
			if( LogManager != null )
			{
				session.ApiLogManager = LogManager;
			}

			ApiCredential ac = new ApiCredential();
			session.ApiCredential = ac;

            string tokenStr = ConfigurationManager.AppSettings[KEY_APITOKEN];
			bool useToken = tokenStr.Length > 0;
			if( useToken )
			{
				ac.eBayToken = tokenStr;
			}

			return session;
		}
	}
}

