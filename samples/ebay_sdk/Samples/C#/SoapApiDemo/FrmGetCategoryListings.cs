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
	public class FrmGetCategoryListings : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.ColumnHeader ClmItemId;
		private System.Windows.Forms.ColumnHeader ClmTitle;
		private System.Windows.Forms.ColumnHeader ClmPrice;
		private System.Windows.Forms.ColumnHeader ClmBids;
		private System.Windows.Forms.Label LblCategory;
		private System.Windows.Forms.TextBox TxtCategory;
		private System.Windows.Forms.ComboBox CboSort;
		private System.Windows.Forms.Label LblSort;
		private System.Windows.Forms.ListView LstSearchResults;
		private System.Windows.Forms.Label LblSearchResults;
		private System.Windows.Forms.ColumnHeader ClmTimeLeft;
		private System.Windows.Forms.Button BtnGetCategoryListings;
		private System.Windows.Forms.Label LblRegion;
		private System.Windows.Forms.TextBox TxtRegion;
		private System.Windows.Forms.ComboBox CboSiteFilter;
		private System.Windows.Forms.Label LblSiteFilter;
		private System.Windows.Forms.ComboBox CboItemFilter;
		private System.Windows.Forms.Label LblItemFilter;
		private System.Windows.Forms.ComboBox CboSearchType;
		private System.Windows.Forms.Label LblSearchType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetCategoryListings()
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
			this.BtnGetCategoryListings = new System.Windows.Forms.Button();
			this.LblCategory = new System.Windows.Forms.Label();
			this.TxtCategory = new System.Windows.Forms.TextBox();
			this.CboSort = new System.Windows.Forms.ComboBox();
			this.LblSort = new System.Windows.Forms.Label();
			this.LblRegion = new System.Windows.Forms.Label();
			this.TxtRegion = new System.Windows.Forms.TextBox();
			this.CboSiteFilter = new System.Windows.Forms.ComboBox();
			this.LblSiteFilter = new System.Windows.Forms.Label();
			this.CboItemFilter = new System.Windows.Forms.ComboBox();
			this.LblItemFilter = new System.Windows.Forms.Label();
			this.CboSearchType = new System.Windows.Forms.ComboBox();
			this.LblSearchType = new System.Windows.Forms.Label();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.Add(this.LblSearchResults);
			this.GrpResult.Controls.Add(this.LstSearchResults);
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
			this.LstSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
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
			// BtnGetCategoryListings
			// 
			this.BtnGetCategoryListings.Location = new System.Drawing.Point(176, 136);
			this.BtnGetCategoryListings.Name = "BtnGetCategoryListings";
			this.BtnGetCategoryListings.Size = new System.Drawing.Size(128, 23);
			this.BtnGetCategoryListings.TabIndex = 23;
			this.BtnGetCategoryListings.Text = "GetCategoryListings";
			this.BtnGetCategoryListings.Click += new System.EventHandler(this.BtnGetCategoryListings_Click);
			// 
			// LblCategory
			// 
			this.LblCategory.Location = new System.Drawing.Point(16, 8);
			this.LblCategory.Name = "LblCategory";
			this.LblCategory.Size = new System.Drawing.Size(80, 23);
			this.LblCategory.TabIndex = 78;
			this.LblCategory.Text = "Category:";
			// 
			// TxtCategory
			// 
			this.TxtCategory.Location = new System.Drawing.Point(96, 8);
			this.TxtCategory.Name = "TxtCategory";
			this.TxtCategory.TabIndex = 77;
			this.TxtCategory.Text = "";
			// 
			// CboSort
			// 
			this.CboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSort.Location = new System.Drawing.Point(96, 104);
			this.CboSort.Name = "CboSort";
			this.CboSort.Size = new System.Drawing.Size(136, 21);
			this.CboSort.TabIndex = 81;
			// 
			// LblSort
			// 
			this.LblSort.Location = new System.Drawing.Point(16, 104);
			this.LblSort.Name = "LblSort";
			this.LblSort.Size = new System.Drawing.Size(80, 18);
			this.LblSort.TabIndex = 80;
			this.LblSort.Text = "Sort:";
			// 
			// LblRegion
			// 
			this.LblRegion.Location = new System.Drawing.Point(16, 32);
			this.LblRegion.Name = "LblRegion";
			this.LblRegion.Size = new System.Drawing.Size(80, 23);
			this.LblRegion.TabIndex = 83;
			this.LblRegion.Text = "Region Id:";
			// 
			// TxtRegion
			// 
			this.TxtRegion.Location = new System.Drawing.Point(96, 32);
			this.TxtRegion.Name = "TxtRegion";
			this.TxtRegion.TabIndex = 82;
			this.TxtRegion.Text = "";
			// 
			// CboSiteFilter
			// 
			this.CboSiteFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSiteFilter.Location = new System.Drawing.Point(272, 32);
			this.CboSiteFilter.Name = "CboSiteFilter";
			this.CboSiteFilter.Size = new System.Drawing.Size(136, 21);
			this.CboSiteFilter.TabIndex = 85;
			// 
			// LblSiteFilter
			// 
			this.LblSiteFilter.Location = new System.Drawing.Point(208, 32);
			this.LblSiteFilter.Name = "LblSiteFilter";
			this.LblSiteFilter.Size = new System.Drawing.Size(64, 18);
			this.LblSiteFilter.TabIndex = 84;
			this.LblSiteFilter.Text = "Site Filter:";
			// 
			// CboItemFilter
			// 
			this.CboItemFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboItemFilter.Location = new System.Drawing.Point(96, 56);
			this.CboItemFilter.Name = "CboItemFilter";
			this.CboItemFilter.Size = new System.Drawing.Size(136, 21);
			this.CboItemFilter.TabIndex = 87;
			// 
			// LblItemFilter
			// 
			this.LblItemFilter.Location = new System.Drawing.Point(16, 56);
			this.LblItemFilter.Name = "LblItemFilter";
			this.LblItemFilter.Size = new System.Drawing.Size(80, 18);
			this.LblItemFilter.TabIndex = 86;
			this.LblItemFilter.Text = "Item Filter:";
			// 
			// CboSearchType
			// 
			this.CboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CboSearchType.Location = new System.Drawing.Point(96, 80);
			this.CboSearchType.Name = "CboSearchType";
			this.CboSearchType.Size = new System.Drawing.Size(136, 21);
			this.CboSearchType.TabIndex = 89;
			// 
			// LblSearchType
			// 
			this.LblSearchType.Location = new System.Drawing.Point(16, 80);
			this.LblSearchType.Name = "LblSearchType";
			this.LblSearchType.Size = new System.Drawing.Size(80, 18);
			this.LblSearchType.TabIndex = 88;
			this.LblSearchType.Text = "Search Type:";
			// 
			// FrmGetCategoryListings
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 501);
			this.Controls.Add(this.CboSearchType);
			this.Controls.Add(this.LblSearchType);
			this.Controls.Add(this.CboItemFilter);
			this.Controls.Add(this.LblItemFilter);
			this.Controls.Add(this.CboSiteFilter);
			this.Controls.Add(this.LblSiteFilter);
			this.Controls.Add(this.LblRegion);
			this.Controls.Add(this.TxtRegion);
			this.Controls.Add(this.CboSort);
			this.Controls.Add(this.LblSort);
			this.Controls.Add(this.LblCategory);
			this.Controls.Add(this.TxtCategory);
			this.Controls.Add(this.GrpResult);
			this.Controls.Add(this.BtnGetCategoryListings);
			this.Name = "FrmGetCategoryListings";
			this.Text = "GetCategoryListings";
			this.Load += new System.EventHandler(this.FrmGetCategoryListings_Load);
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

	

		private void FrmGetCategoryListings_Load(object sender, System.EventArgs e)
		{
			CboSiteFilter.Items.Add("NoFilter");
			CboItemFilter.Items.Add("NoFilter");
			CboSearchType.Items.Add("NoFilter");
			CboSort.Items.Add("DefaultSort");

			string[] enums = Enum.GetNames(typeof(SiteIDFilterCodeType));
			foreach (string item in enums)
			{
				if (item != "CustomCode")
					CboSiteFilter.Items.Add(item);
			}

			enums = Enum.GetNames(typeof(ItemTypeFilterCodeType));
			foreach (string item in enums)
			{
				if (item != "CustomCode")
					CboItemFilter.Items.Add(item);
			}

			enums = Enum.GetNames(typeof(CategoryListingsOrderCodeType));
			foreach (string item in enums)
			{
				if (item != "CustomCode")
					CboSort.Items.Add(item);
			}


			enums = Enum.GetNames(typeof(CategoryListingsSearchCodeType));
			foreach (string item in enums)
			{
				if (item != "CustomCode")
					CboSearchType.Items.Add(item);
			}

			CboItemFilter.SelectedIndex = 0;
			CboSearchType.SelectedIndex = 0;
			CboSiteFilter.SelectedIndex = 0;
			CboSort.SelectedIndex = 0;

		}

		private void BtnGetCategoryListings_Click(object sender, System.EventArgs e)
		{
			try
			{
				LstSearchResults.Items.Clear();
				GetCategoryListingsCall apicall = new GetCategoryListingsCall(Context);


				if (TxtRegion.Text.Length > 0 || CboSiteFilter.SelectedIndex > 0)
				{
					apicall.SearchLocation = new SearchLocationType();
					apicall.SearchLocation.RegionID = TxtRegion.Text;
					if (CboSiteFilter.SelectedIndex > 0)
					{
						apicall.SearchLocation.SiteLocation = new SiteLocationType();
						apicall.SearchLocation.SiteLocation.SiteID =	(SiteIDFilterCodeType)Enum.Parse(typeof(SiteIDFilterCodeType), CboSiteFilter.SelectedItem.ToString());
					}
				}
				if (CboItemFilter.SelectedIndex > 0)
				{
					apicall.ItemTypeFilter = (ItemTypeFilterCodeType)Enum.Parse(typeof(ItemTypeFilterCodeType), CboItemFilter.SelectedItem.ToString());
				}
				if (CboSearchType.SelectedIndex > 0)
				{
					apicall.SearchType = (CategoryListingsSearchCodeType)Enum.Parse(typeof(CategoryListingsSearchCodeType), CboSearchType.SelectedItem.ToString());
				}

				if (CboSort.SelectedIndex > 0)
				{
					apicall.OrderBy = (CategoryListingsOrderCodeType)Enum.Parse(typeof(CategoryListingsOrderCodeType), CboSort.SelectedItem.ToString());
				}
			
				ItemTypeCollection fnditems = apicall.GetCategoryListings(TxtCategory.Text);
	

				foreach (ItemType fnditem in fnditems)
				{
					string[] listparams = new string[5];
					listparams[0] = fnditem.ItemID;
					listparams[1] = fnditem.Title;
					listparams[2] = fnditem.SellingStatus.CurrentPrice.Value.ToString();
					listparams[3] = fnditem.SellingStatus.BidCount.ToString();
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
