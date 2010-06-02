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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Call;
using eBay.Service.Util;


namespace SoapLibraryDemo
{
	/// <summary>
	/// Summary description for FormGetSellerList.
	/// </summary>
	public class FrmGetSearchResults : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.ColumnHeader ClmItemId;
		private System.Windows.Forms.ColumnHeader ClmTitle;
		private System.Windows.Forms.ColumnHeader ClmPrice;
		private System.Windows.Forms.ColumnHeader ClmBids;
		private System.Windows.Forms.Button BtnGetSearchResults;
		private System.Windows.Forms.TextBox TxtQuery;
		private System.Windows.Forms.CheckBox ChkSearchDescription;
		private System.Windows.Forms.Label LblQuery;
		private System.Windows.Forms.TextBox TxtPriceFrom;
		private System.Windows.Forms.TextBox TxtPriceTo;
		private System.Windows.Forms.Label LblPriceRange;
		private System.Windows.Forms.Label LblPriceSep;
		private System.Windows.Forms.Label LblCategory;
		private System.Windows.Forms.TextBox TxtCategory;
		private System.Windows.Forms.CheckBox ChkPayPal;
		private System.Windows.Forms.ComboBox CboSort;
		private System.Windows.Forms.Label LblSort;
		private System.Windows.Forms.ListView LstSearchResults;
		private System.Windows.Forms.Label LblSearchResults;
		private System.Windows.Forms.ColumnHeader ClmTimeLeft;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetSearchResults()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.GrpResult = new System.Windows.Forms.GroupBox();
			this.LblSearchResults = new System.Windows.Forms.Label();
			this.LstSearchResults = new System.Windows.Forms.ListView();
			this.ClmItemId = new System.Windows.Forms.ColumnHeader();
			this.ClmTitle = new System.Windows.Forms.ColumnHeader();
			this.ClmPrice = new System.Windows.Forms.ColumnHeader();
			this.ClmBids = new System.Windows.Forms.ColumnHeader();
			this.ClmTimeLeft = new System.Windows.Forms.ColumnHeader();
			this.BtnGetSearchResults = new System.Windows.Forms.Button();
			this.TxtQuery = new System.Windows.Forms.TextBox();
			this.ChkSearchDescription = new System.Windows.Forms.CheckBox();
			this.LblQuery = new System.Windows.Forms.Label();
			this.TxtPriceFrom = new System.Windows.Forms.TextBox();
			this.TxtPriceTo = new System.Windows.Forms.TextBox();
			this.LblPriceRange = new System.Windows.Forms.Label();
			this.LblPriceSep = new System.Windows.Forms.Label();
			this.LblCategory = new System.Windows.Forms.Label();
			this.TxtCategory = new System.Windows.Forms.TextBox();
			this.ChkPayPal = new System.Windows.Forms.CheckBox();
			this.CboSort = new System.Windows.Forms.ComboBox();
			this.LblSort = new System.Windows.Forms.Label();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.LblSearchResults,
																					this.LstSearchResults});
			this.GrpResult.Location = new System.Drawing.Point(8, 200);
			this.GrpResult.Name = "GrpResult";
			this.GrpResult.Size = new System.Drawing.Size(456, 296);
			this.GrpResult.TabIndex = 24;
			this.GrpResult.TabStop = false;
			this.GrpResult.Text = "Results";
			// 
			// LblSearchResults
			// 
			this.LblSearchResults.Location = new System.Drawing.Point(16, 24);
			this.LblSearchResults.Name = "LblSearchResults";
			this.LblSearchResults.Size = new System.Drawing.Size(112, 23);
			this.LblSearchResults.TabIndex = 15;
			this.LblSearchResults.Text = "Items Found:";
			// 
			// LstSearchResults
			// 
			this.LstSearchResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.LstSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.ClmItemId,
																							   this.ClmTitle,
																							   this.ClmPrice,
																							   this.ClmBids,
																							   this.ClmTimeLeft});
			this.LstSearchResults.GridLines = true;
			this.LstSearchResults.Location = new System.Drawing.Point(8, 48);
			this.LstSearchResults.Name = "LstSearchResults";
			this.LstSearchResults.Size = new System.Drawing.Size(440, 232);
			this.LstSearchResults.TabIndex = 4;
			this.LstSearchResults.View = System.Windows.Forms.View.Details;
			// 
			// ClmItemId
			// 
			this.ClmItemId.Text = "ItemId";
			this.ClmItemId.Width = 80;
			// 
			// ClmTitle
			// 
			this.ClmTitle.Text = "Title";
			this.ClmTitle.Width = 173;
			// 
			// ClmPrice
			// 
			this.ClmPrice.Text = "Price";
			// 
			// ClmBids
			// 
			this.ClmBids.Text = "Bids";
			this.ClmBids.Width = 39;
			// 
			// ClmTimeLeft
			// 
			this.ClmTimeLeft.Text = "TimeLeft";
			// 
			// BtnGetSearchResults
			// 
			this.BtnGetSearchResults.Location = new System.Drawing.Point(176, 168);
			this.BtnGetSearchResults.Name = "BtnGetSearchResults";
			this.BtnGetSearchResults.Size = new System.Drawing.Size(128, 23);
			this.BtnGetSearchResults.TabIndex = 23;
			this.BtnGetSearchResults.Text = "GetSearchResults";
			this.BtnGetSearchResults.Click += new System.EventHandler(this.BtnGetSearchResults_Click);
			// 
			// TxtQuery
			// 
			this.TxtQuery.Location = new System.Drawing.Point(96, 16);
			this.TxtQuery.Name = "TxtQuery";
			this.TxtQuery.Size = new System.Drawing.Size(240, 20);
			this.TxtQuery.TabIndex = 70;
			this.TxtQuery.Text = "";
			// 
			// ChkSearchDescription
			// 
			this.ChkSearchDescription.Location = new System.Drawing.Point(96, 40);
			this.ChkSearchDescription.Name = "ChkSearchDescription";
			this.ChkSearchDescription.Size = new System.Drawing.Size(152, 24);
			this.ChkSearchDescription.TabIndex = 71;
			this.ChkSearchDescription.Text = "Search In Description";
			// 
			// LblQuery
			// 
			this.LblQuery.Location = new System.Drawing.Point(16, 16);
			this.LblQuery.Name = "LblQuery";
			this.LblQuery.Size = new System.Drawing.Size(80, 16);
			this.LblQuery.TabIndex = 72;
			this.LblQuery.Text = "Search Term:";
			// 
			// TxtPriceFrom
			// 
			this.TxtPriceFrom.Location = new System.Drawing.Point(96, 64);
			this.TxtPriceFrom.Name = "TxtPriceFrom";
			this.TxtPriceFrom.TabIndex = 73;
			this.TxtPriceFrom.Text = "";
			// 
			// TxtPriceTo
			// 
			this.TxtPriceTo.Location = new System.Drawing.Point(216, 64);
			this.TxtPriceTo.Name = "TxtPriceTo";
			this.TxtPriceTo.TabIndex = 74;
			this.TxtPriceTo.Text = "";
			// 
			// LblPriceRange
			// 
			this.LblPriceRange.Location = new System.Drawing.Point(16, 64);
			this.LblPriceRange.Name = "LblPriceRange";
			this.LblPriceRange.Size = new System.Drawing.Size(80, 23);
			this.LblPriceRange.TabIndex = 75;
			this.LblPriceRange.Text = "Price Range:";
			// 
			// LblPriceSep
			// 
			this.LblPriceSep.Location = new System.Drawing.Point(200, 64);
			this.LblPriceSep.Name = "LblPriceSep";
			this.LblPriceSep.Size = new System.Drawing.Size(8, 23);
			this.LblPriceSep.TabIndex = 76;
			this.LblPriceSep.Text = "-";
			// 
			// LblCategory
			// 
			this.LblCategory.Location = new System.Drawing.Point(16, 88);
			this.LblCategory.Name = "LblCategory";
			this.LblCategory.Size = new System.Drawing.Size(80, 23);
			this.LblCategory.TabIndex = 78;
			this.LblCategory.Text = "Category:";
			// 
			// TxtCategory
			// 
			this.TxtCategory.Location = new System.Drawing.Point(96, 88);
			this.TxtCategory.Name = "TxtCategory";
			this.TxtCategory.TabIndex = 77;
			this.TxtCategory.Text = "";
			// 
			// ChkPayPal
			// 
			this.ChkPayPal.Location = new System.Drawing.Point(96, 112);
			this.ChkPayPal.Name = "ChkPayPal";
			this.ChkPayPal.Size = new System.Drawing.Size(120, 24);
			this.ChkPayPal.TabIndex = 79;
			this.ChkPayPal.Text = "Pay Pal Accepted";
			// 
			// CboSort
			// 
			this.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSort.Location = new System.Drawing.Point(96, 136);
			this.CboSort.Name = "CboSort";
			this.CboSort.Size = new System.Drawing.Size(136, 21);
			this.CboSort.TabIndex = 81;
			// 
			// LblSort
			// 
			this.LblSort.Location = new System.Drawing.Point(32, 136);
			this.LblSort.Name = "LblSort";
			this.LblSort.Size = new System.Drawing.Size(64, 18);
			this.LblSort.TabIndex = 80;
			this.LblSort.Text = "Sort:";
			// 
			// FrmGetSearchResults
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 501);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.CboSort,
																		  this.LblSort,
																		  this.ChkPayPal,
																		  this.LblCategory,
																		  this.TxtCategory,
																		  this.LblPriceSep,
																		  this.LblPriceRange,
																		  this.TxtPriceTo,
																		  this.TxtPriceFrom,
																		  this.LblQuery,
																		  this.ChkSearchDescription,
																		  this.TxtQuery,
																		  this.GrpResult,
																		  this.BtnGetSearchResults});
			this.Name = "FrmGetSearchResults";
			this.Text = "GetSearchResults";
			this.Load += new System.EventHandler(this.FrmGetSearchResults_Load);
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	

		private void FrmGetSearchResults_Load(object sender, System.EventArgs e)
		{
			string[] enums = Enum.GetNames(typeof(SearchSortOrderCodeType));
			foreach (string item in enums)
			{
				if (item != "CustomCode")
					CboSort.Items.Add(item);
			}

			CboSort.SelectedIndex = 0;

		}

		private void BtnGetSearchResults_Click(object sender, System.EventArgs e)
		{

			try 
			{
				LstSearchResults.Items.Clear();
				
				GetSearchResultsCall apicall = new GetSearchResultsCall(Context);
			
				if (ChkSearchDescription.Checked || ChkPayPal.Checked)
					apicall.SearchFlagsList = new SearchFlagsCodeTypeCollection();

				if (ChkSearchDescription.Checked)
					apicall.SearchFlagsList.Add(SearchFlagsCodeType.SearchInDescription);
			
				if (this.ChkPayPal.Checked)
					apicall.SearchFlagsList.Add(SearchFlagsCodeType.PayPalBuyerPaymentOption);

				if (TxtPriceFrom.Text.Length > 0 && TxtPriceTo.Text.Length > 0)
				{
					apicall.PriceRangeFilter = new PriceRangeFilterType();
					apicall.PriceRangeFilter.MinPrice = new AmountType();
					apicall.PriceRangeFilter.MaxPrice = new AmountType();
					apicall.PriceRangeFilter.MinPrice.Value = Convert.ToDouble(TxtPriceFrom.Text);
					apicall.PriceRangeFilter.MaxPrice.Value = Convert.ToDouble(TxtPriceTo.Text);
				}

				if (TxtCategory.Text.Length > 0)
					apicall.CategoryID = TxtCategory.Text;
				
				apicall.Order = (SearchSortOrderCodeType)Enum.Parse(typeof(SearchSortOrderCodeType), CboSort.SelectedItem.ToString());

				SearchResultItemTypeCollection fnditems = apicall.GetSearchResults(TxtQuery.Text);

				foreach (SearchResultItemType fnditem in fnditems)
				{
					string[] listparams = new string[5];
					listparams[0] = fnditem.Item.ItemID;
					listparams[1] = fnditem.Item.Title;
					listparams[2] = fnditem.Item.SellingStatus.CurrentPrice.Value.ToString();
					listparams[3] = fnditem.Item.SellingStatus.BidCount.ToString();
					listparams[4] = DateTime.Now.ToString();

					ListViewItem vi = new ListViewItem(listparams);
					LstSearchResults.Items.Add(vi);

				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

	
	}
}
