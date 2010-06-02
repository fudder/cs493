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
using System.Collections.Specialized;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Configuration;

using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.SDK.Attribute;
using eBay.Service.SDK.Util;
using eBay.Service.Call;

namespace Attributes
{
	/// <summary>
	/// Summary description for AttributeInfo.
	/// </summary>
	public partial class AttributeInfo : System.Web.UI.Page
	{
		private const string HOME = "home";
		private const string ADD_ITEM = "addItem";
		private const string CUSTOME_ITEM_SPECIFICS_NAME="itemSpecificName_";
		private const string CUSTOME_ITEM_SPECIFICS_VALUE="itemSpecificValue_";
		private const string EBAY_CUSTOM_ITEM_SPECIFICS_NAME="eBayItemSpecificName_";
		private const string EBAY_CUSTOM_ITEM_SPECIFICS_VALUE="eBayItemSpecificValue_";
		private const string EBAY_CUSTOM_ITEM_SPECIFICS_NAME_CACHE="eBayItemSpecificNameCache_";
		private bool hasAttributes;
		private bool hasCustomItemSpecific;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			NameValueCollection request;
			if( Request.HttpMethod == "POST") 
				request = Request.Form;
			else 
                request = Request.QueryString;

			string action = request[Global.ACTION];
			if( action == ADD_ITEM )
			{
				NameValueListTypeCollection nvCol=getAllCustomItemSpecificsNameValue(request);
				if (nvCol!=null)
				{
					Session[Global.CUSTOME_ITEM_SPECIFIC]=nvCol;
				}
				AddItemNVC(request);
			}
			else if( action == HOME ) 
			{
				Response.Redirect(Global.StartPage);
			}
			else 
			{
				DisplayAttributes(request, null);
				//this category has no attributes and custom item specific
				//just redirect to AddItem page.
				if(hasItemSpecificOrAttributes()==false)
				{
					Response.Redirect("AddItem.aspx?hasItemSpecificOrAttributes=false");
				}
			}

			
		}

		private void AddHtmlHeaders()
		{
			System.Text.StringBuilder str=new System.Text.StringBuilder();

			str.Append("<html>");
			str.Append("<head>");
			str.Append("<title>Attribute Info</title>");
			str.Append("</head>");
			str.Append("<body>");
			str.Append("<script language=\"javascript\">");
			str.Append("function onClick(id)");
			str.Append("{");
			str.Append("document.all('action').value = id;");
			str.Append("document.forms['APIForm'].submit();");
			str.Append("}\n");
			str.Append("</script>");
			//CustomSpecific JS added by peter
			str.Append("<script language=\"javascript\" src=\"CustomSpecific.js\"></script>");

			str.Append("<form name=\"APIForm\" id=\"APIForm\" method=\"get\" action=\"AttributeInfo.aspx\">");
			str.Append("<table align=\"center\" border=\"0\"><tr><td><img src=\"images/ebay.gif\"></td></tr><tr><td>");

			Response.Write(str.ToString());
		}

		private void AddCustomItemSpecificsHtml()
		{
			System.Text.StringBuilder str=new System.Text.StringBuilder();
			str.Append("</td></tr>");
			
			ItemSpecificsEnabledCodeType itemSpecificsEnabledCodeType = 
				(ItemSpecificsEnabledCodeType)Session[Global.CATEGORY_FEATURES_ITEM_SPECIFIC_ENABLED];

			hasCustomItemSpecific=false;//initial to false
			if(itemSpecificsEnabledCodeType==ItemSpecificsEnabledCodeType.Enabled)
			{
				genCustomSpecificHtml(ref str);
				hasCustomItemSpecific=true;//indicates the category has custom item specific enabled
			}

			Response.Write(str.ToString());
		}

		private void AddHtmlTails()
		{
			System.Text.StringBuilder str=new System.Text.StringBuilder();

			str.Append("<tr><td align=\"center\">");
			str.Append("<input type=\"button\" name=\"btSubmit0\" value=\"&nbsp;Home&nbsp;\" id=\"btSubmit0\"");
			str.Append("onclick=\"javascript:onClick('home')\"" + "/>");
			str.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
			str.Append("<input type=\"button\" name=\"btSubmit1\" value=\"Continue\" id=\"btSubmit1\"");
			str.Append("onclick=\"javascript:onClick('addItem')\"" + "/>");
			str.Append("</td></tr></table>");
			str.Append("<input type=\"hidden\" name=\"action\" value=\"display\"/>");			
			str.Append("</form></body></html>");

			Response.Write(str.ToString());
		}

		private NameValueListTypeCollection getAllCustomItemSpecificsNameValue(NameValueCollection request)
		{
			NameValueListTypeCollection att=new NameValueListTypeCollection();
			NameValueListType nvList;

			foreach (string key in request.AllKeys)
			{
				int index;
				index = key.IndexOf(EBAY_CUSTOM_ITEM_SPECIFICS_NAME);
				if(index>=0&&request[key]!=string.Empty)
				{
					string suffix=key.Substring(index+EBAY_CUSTOM_ITEM_SPECIFICS_NAME.Length);
					nvList=new NameValueListType();
					nvList.Name=request[EBAY_CUSTOM_ITEM_SPECIFICS_NAME_CACHE+suffix];
					eBay.Service.Core.Soap.StringCollection strCol=new eBay.Service.Core.Soap.StringCollection();
					strCol.Add(request[key]);
					nvList.Value=strCol;
					att.Add(nvList);
					continue;
				}

				index=key.IndexOf(CUSTOME_ITEM_SPECIFICS_VALUE);
				if(index>=0&&request[key]!=string.Empty)
				{
					string suffix=key.Substring(index+CUSTOME_ITEM_SPECIFICS_VALUE.Length);
					nvList=new NameValueListType();
					nvList.Name=request[CUSTOME_ITEM_SPECIFICS_NAME+suffix];
					eBay.Service.Core.Soap.StringCollection strCol=new eBay.Service.Core.Soap.StringCollection();
					strCol.Add(request[key]);
					nvList.Value=strCol;
					att.Add(nvList);
					continue;
				}

			}

			return att;
		}
	
		

		private void AddItemNVC(NameValueCollection request)
		{
			AttributesMaster attrMaster = (AttributesMaster)Session[Global.ATTRIBUTES_MASTER];

			IAttributeSetCollection sets = attrMaster.NameValuesToAttributeSets(AttributesHelper.ConvertFromNameValues(request));
			IErrorSetCollection errList = attrMaster.Validate(sets);

			if (errList.Count == 0) 
			{
				Session[Global.ITEM_ATTR_SETS] = sets;
				Response.Redirect("AddItem.aspx");
			}
			else 
			{
				DisplayAttributes(request, errList);
			}
		}

		private void DisplayAttributes(NameValueCollection request, IErrorSetCollection errList)
		{
		    AttributesMaster attrMaster = (AttributesMaster)Session[Global.ATTRIBUTES_MASTER];
			
			AddHtmlHeaders();

			string tableText=string.Empty;

			// For the first time we have only categoryId and categoryId2 but we don't 
			// have any attributes request data so we have to use RenderHtmlForCategories to generate the html text.
			string strCatId = request[CategoryList.CAT_ID];
			if( strCatId != null && strCatId.Length != 0 )
			{
				Int32Collection ids = new Int32Collection();
				int catId = Int32.Parse(strCatId);
				ids.Add(catId);

				Session["CategoryId"] = catId;
				Session["Category2Id"] = 0;

				strCatId = request[CategoryList.CAT_ID2];
				if( strCatId != null && strCatId.Length != 0 )
				{
					catId = Int32.Parse(strCatId);
					ids.Add(catId);

					Session["Category2Id"] = catId;
 				}
				IAttributeSetCollection itemSpecAttrSets = attrMaster.GetItemSpecificAttributeSetsForCategories(ids);
				IAttributeSetCollection siteWideAttrSets = attrMaster.GetSiteWideAttributeSetsForCategories(ids);
				Session[Global.ITEM_SITE_WIDE_ATTR_SETS] = siteWideAttrSets;
				IAttributeSetCollection joinedAttrSets = attrMaster.JoinItemSpecificAndSiteWideAttributeSets(itemSpecAttrSets, siteWideAttrSets);
				Session[Global.JOINED_ATTR_SETS] = joinedAttrSets;
				if(joinedAttrSets!=null)
				{
					tableText = attrMaster.RenderHtml(joinedAttrSets, errList);
				}
			}
			else
			{
				tableText = attrMaster.RenderHtmlForPostback(AttributesHelper.ConvertFromNameValues(request), errList);
			}

			IAttributeSetCollection attrSets = Session[Global.JOINED_ATTR_SETS] as IAttributeSetCollection;
			if (attrSets != null && attrSets.Count > 0)
			{
				hasAttributes = true;
			}
			else
			{
				hasAttributes = false;
			}

			Response.Write(tableText);

			AddCustomItemSpecificsHtml();

			AddHtmlTails();
		}

		/// <summary>
		/// check whether the category has attributes or custom item specific
		/// </summary>
		/// <returns></returns>
		private bool hasItemSpecificOrAttributes()
		{
			return hasAttributes || hasCustomItemSpecific ;
		}

		private void genCustomSpecificHtml(ref System.Text.StringBuilder str)
		{
			str.Append("<tr><td>");
			//CustomItemSpecificGroup div
			str.Append("<span>");
			str.Append("<div id=\"CustomItemSpecificGroup\">");
			genItemSpecificHtml(ref str);
			str.Append("</div>");
			str.Append("</span>");
			//NewCustomItemSpecific div
			str.Append("<span>");
			str.Append("<div id=\"NewCustomItemSpecific\">");
			str.Append("</div>");
			str.Append("</span>");
			//SuggestedSectionLyr div
			str.Append("<span>");
			str.Append("<div id=\"tray\" style=\"visibility: visible;\">");
			str.Append("<div id=\"Addmore\">");
			str.Append("<b>Add more Specifics</b>");
			str.Append("</div>");
			str.Append("<div id=\"msg\" style=\"display: none; visibility: hidden;\"> If you want to add another item specific, please remove one of the existing specifics and add a new one. </div>");
			str.Append("<div id=\"SuggestedSectionLyr\" style=\"padding-top: 10px; visibility: visible;\">");
			str.Append("</div>");
			str.Append("</div>");
			str.Append("</span>");
			//AddCustomLnk tip
			str.Append("<span>");
			str.Append("<div>");
			str.Append("<span id=\"AddCustomLnk\" onclick=\"addNewSpecific();\">");
			str.Append("<a href=\"javascript:void(0);\">");
			str.Append("<img src=\"http://pics.qa.ebaystatic.com/aw/pics/buttons/btnOptionAdd.gif\" hspace=\"1\" border=\"0\" align=\"absmiddle\" />");
			str.Append("</a>");
			str.Append("<a href=\"javascript:void(0);\"><b>Add a custom detail</b></a>");
			str.Append("</span>");
			str.Append("</div>");
			str.Append("</span>");
			str.Append("</td></tr>");
		}
		
        private void genItemSpecificHtml(ref System.Text.StringBuilder str)
		{
			NameRecommendationTypeCollection col=getCategorySpecific();
			if(col==null) return;
			int suffix=0;

			foreach (NameRecommendationType nrt in col)
			{
				str.Append(string.Format("<span id=\"SpecificLayer_{0}\" style=\"margin-top: 8px\">",suffix));
				str.Append("<div>");
				str.Append(string.Format("<div id=\"TagName_{0}\" style=\"margin-top: 10px\">",suffix));
				str.Append("<b>");str.Append(nrt.Name);str.Append("</b>");
				str.Append("</div>");
				str.Append("<div>");
                str.Append(string.Format("<input type=\"text\" id=\"eBayItemSpecificName_{0}\" name=\"eBayItemSpecificName_{0}\" style=\"width:100px;height:21px;font-size:10pt;\">", suffix));
				str.Append("<span style=\"width:18px;border:0px solid red;\">");
				str.Append(string.Format("<select id=\"eBayItemSpecificValue_{0}\" name=\"eBayItemSpecificValue_{0}\" style=\"margin-left:-100px;width:118px; background-color:#FFEEEE;\" onchange=\"optionSelect(this.name,this.value);\">",suffix));
				str.Append("<option value=\" \">Enter Your Own</option>");

				//generate value
				foreach (ValueRecommendationType vrt in nrt.ValueRecommendation)
				{
					str.Append(string.Format("<option value=\"{0}\">",vrt.Value));
					str.Append(vrt.Value);
					str.Append("</option>");
				}

				str.Append("</select>");
				str.Append("</span>");
				str.Append(string.Format("<a href=\"javascript:void(0);\" onclick=\"remove(this.id);return false;\" id=\"Remove_{0}\" class=\"navigation\">",suffix));
				str.Append("remove");
				str.Append("</a>");
				str.Append("</div>");
				str.Append(string.Format("<input type=\"hidden\" id=\"{2}{0}\" name=\"{2}{0}\" value=\"{1}\"></input>",suffix,nrt.Name,EBAY_CUSTOM_ITEM_SPECIFICS_NAME_CACHE));
				str.Append("</div>");
				str.Append("</span>");

				suffix++;
			}
		}

		private NameRecommendationTypeCollection getCategorySpecific()
		{
			ApiContext asn = (ApiContext)Session[Global.APISESSION];
			GetCategorySpecificsCall api = new GetCategorySpecificsCall(asn);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {DetailLevelCodeType.ReturnAll};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			eBay.Service.Core.Soap.StringCollection strCol=new eBay.Service.Core.Soap.StringCollection();
			strCol.Add(Session["CategoryId"].ToString());
			api.CategoryIDList=strCol;
			api.Execute();
		
			NameRecommendationTypeCollection nameRecommendationTypes=null;
			if ((api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning)
					&&	api.ApiResponse.Recommendations!=null
					&&	api.ApiResponse.Recommendations.Count>0)
			{
				nameRecommendationTypes = api.ApiResponse.Recommendations[0].NameRecommendation;
			}

			return nameRecommendationTypes;
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
	}
}
