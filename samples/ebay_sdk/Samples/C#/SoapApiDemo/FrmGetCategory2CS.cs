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
	/// Summary description for GetCategory2CSForm.
	/// </summary>
	public class FrmGetCategory2CS : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.Label LblCategories;
		private System.Windows.Forms.ListView LstCategories;
		private System.Windows.Forms.ColumnHeader ClmCatId;
		private System.Windows.Forms.Button BtnGetCategory2CS;
		private System.Windows.Forms.Label LblCategory;
		private System.Windows.Forms.TextBox TxtCategory;
		private System.Windows.Forms.ColumnHeader ClmCharName;
		private System.Windows.Forms.ColumnHeader ClmCharId;
		private System.Windows.Forms.ColumnHeader ClmCatEnabled;
		private System.Windows.Forms.Label lblNumCats;
		private System.Windows.Forms.Label lblShowNumCats;
		private System.Windows.Forms.ColumnHeader ClmHasFinder;
		private System.Windows.Forms.ColumnHeader ClmProdSrchPg;
		private System.Windows.Forms.ColumnHeader ClmProdSrchPgAvlSpec;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetCategory2CS()
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
			this.BtnGetCategory2CS = new System.Windows.Forms.Button();
			this.GrpResult = new System.Windows.Forms.GroupBox();
			this.lblShowNumCats = new System.Windows.Forms.Label();
			this.lblNumCats = new System.Windows.Forms.Label();
			this.LblCategories = new System.Windows.Forms.Label();
			this.LstCategories = new System.Windows.Forms.ListView();
			this.ClmCatId = new System.Windows.Forms.ColumnHeader();
			this.ClmCharName = new System.Windows.Forms.ColumnHeader();
			this.ClmCharId = new System.Windows.Forms.ColumnHeader();
			this.ClmCatEnabled = new System.Windows.Forms.ColumnHeader();
			this.LblCategory = new System.Windows.Forms.Label();
			this.TxtCategory = new System.Windows.Forms.TextBox();
			this.ClmHasFinder = new System.Windows.Forms.ColumnHeader();
			this.ClmProdSrchPg = new System.Windows.Forms.ColumnHeader();
			this.ClmProdSrchPgAvlSpec = new System.Windows.Forms.ColumnHeader();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnGetCategory2CS
			// 
			this.BtnGetCategory2CS.Location = new System.Drawing.Point(200, 48);
			this.BtnGetCategory2CS.Name = "BtnGetCategory2CS";
			this.BtnGetCategory2CS.TabIndex = 9;
			this.BtnGetCategory2CS.Text = "GetCategory2CS";
			this.BtnGetCategory2CS.Click += new System.EventHandler(this.BtnGetCategory2CS_Click);
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.lblShowNumCats,
																																	this.lblNumCats,
																																	this.LblCategories,
																																	this.LstCategories});
			this.GrpResult.Location = new System.Drawing.Point(8, 80);
			this.GrpResult.Name = "GrpResult";
			this.GrpResult.Size = new System.Drawing.Size(640, 240);
			this.GrpResult.TabIndex = 10;
			this.GrpResult.TabStop = false;
			this.GrpResult.Text = "Result";
			// 
			// lblShowNumCats
			// 
			this.lblShowNumCats.Location = new System.Drawing.Point(208, 16);
			this.lblShowNumCats.Name = "lblShowNumCats";
			this.lblShowNumCats.TabIndex = 15;
			// 
			// lblNumCats
			// 
			this.lblNumCats.Location = new System.Drawing.Point(160, 16);
			this.lblNumCats.Name = "lblNumCats";
			this.lblNumCats.TabIndex = 14;
			this.lblNumCats.Text = "# Cats:";
			// 
			// LblCategories
			// 
			this.LblCategories.Location = new System.Drawing.Point(16, 16);
			this.LblCategories.Name = "LblCategories";
			this.LblCategories.TabIndex = 12;
			this.LblCategories.Text = "Category CS:";
			// 
			// LstCategories
			// 
			this.LstCategories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																							this.ClmCatId,
																																							this.ClmCharName,
																																							this.ClmCharId,
																																							this.ClmCatEnabled,
																																							this.ClmHasFinder,
																																							this.ClmProdSrchPg,
																																							this.ClmProdSrchPgAvlSpec});
			this.LstCategories.GridLines = true;
			this.LstCategories.Location = new System.Drawing.Point(16, 48);
			this.LstCategories.Name = "LstCategories";
			this.LstCategories.Size = new System.Drawing.Size(584, 160);
			this.LstCategories.TabIndex = 13;
			this.LstCategories.View = System.Windows.Forms.View.Details;
			// 
			// ClmCatId
			// 
			this.ClmCatId.Text = "Category Id";
			this.ClmCatId.Width = 69;
			// 
			// ClmCharName
			// 
			this.ClmCharName.Text = "Characteristic Name";
			this.ClmCharName.Width = 120;
			// 
			// ClmCharId
			// 
			this.ClmCharId.Text = "Characteristic Id";
			this.ClmCharId.Width = 94;
			// 
			// ClmCatEnabled
			// 
			this.ClmCatEnabled.Text = "Catalog Enabled";
			this.ClmCatEnabled.Width = 94;
			// 
			// LblCategory
			// 
			this.LblCategory.Location = new System.Drawing.Point(112, 16);
			this.LblCategory.Name = "LblCategory";
			this.LblCategory.TabIndex = 13;
			this.LblCategory.Text = "Category Id:";
			// 
			// TxtCategory
			// 
			this.TxtCategory.Location = new System.Drawing.Point(208, 16);
			this.TxtCategory.Name = "TxtCategory";
			this.TxtCategory.TabIndex = 14;
			this.TxtCategory.Text = "";
			// 
			// ClmHasFinder
			// 
			this.ClmHasFinder.Text = "Has Prod Finder";
			// 
			// ClmProdSrchPg
			// 
			this.ClmProdSrchPg.Text = "Prod Srch Pg Avl";
			// 
			// ClmProdSrchPgAvlSpec
			// 
			this.ClmProdSrchPgAvlSpec.Text = "Prod SrchPg Aval Spc";
			// 
			// FrmGetCategory2CS
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 350);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  							this.TxtCategory,
																		  							this.LblCategory,
																		  							this.GrpResult,
																		  							this.BtnGetCategory2CS});
			this.Name = "FrmGetCategory2CS";
			this.Text = "GetCategory2CSForm";
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnGetCategory2CS_Click(object sender, System.EventArgs e)
		{
			try
			{
				LstCategories.Items.Clear();
				
				GetCategory2CSCall apicall = new GetCategory2CSCall(Context);
				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
				if (TxtCategory.Text.Length > 0)
					apicall.CategoryID = TxtCategory.Text;
				CategoryTypeCollection	cats = apicall.GetCategory2CS();
				int numCats = cats.Count;
				lblShowNumCats.Text = numCats.ToString();
				int catCount = 0;
				foreach (CategoryType category in cats)
				{
					bool hasProdFinder = category.ProductFinderIDs.Count > 0;
					if(category.CatalogEnabled || hasProdFinder
						|| category.ProductSearchPageAvailable
						|| category.ProductSearchPageAvailableSpecified) 
					{
						string[] listparams = new string[8];
						listparams[0] = category.CategoryID;
						listparams[1] = category.CharacteristicsSets[0].Name;
						listparams[2] = category.CharacteristicsSets[0].AttributeSetID.ToString();
						listparams[3] = category.CatalogEnabled.ToString();
						listparams[4] = hasProdFinder.ToString();
						listparams[5] = category.ProductSearchPageAvailable.ToString();
						listparams[6] = category.ProductSearchPageAvailableSpecified.ToString();
						ListViewItem vi = new ListViewItem(listparams);
						this.LstCategories.Items.Add(vi);
						catCount++;
					}
				}
				lblShowNumCats.Text = catCount.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

	}
}
