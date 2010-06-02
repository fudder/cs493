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
	/// Summary description for GetProductSearchPageForm.
	/// </summary>
	public class FrmGetProductSearchPage : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.Button BtnGetProductSearchPage;
		private System.Windows.Forms.Label LblSearchPageVersion;
		private System.Windows.Forms.TextBox TxtSearchPageVersion;
		private System.Windows.Forms.TextBox TxtSearchPageSets;
		private System.Windows.Forms.Label LblSearchPageSets;
		private System.Windows.Forms.Label LblSearchPageData;
		private System.Windows.Forms.ListView LstProductData;
		private System.Windows.Forms.ColumnHeader ClmAttributeID;
		private System.Windows.Forms.ColumnHeader ClmDisplay;
		private System.Windows.Forms.ColumnHeader ClmName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetProductSearchPage()
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
			this.BtnGetProductSearchPage = new System.Windows.Forms.Button();
			this.GrpResult = new System.Windows.Forms.GroupBox();
			this.LstProductData = new System.Windows.Forms.ListView();
			this.ClmAttributeID = new System.Windows.Forms.ColumnHeader();
			this.ClmDisplay = new System.Windows.Forms.ColumnHeader();
			this.ClmName = new System.Windows.Forms.ColumnHeader();
			this.LblSearchPageData = new System.Windows.Forms.Label();
			this.LblSearchPageVersion = new System.Windows.Forms.Label();
			this.TxtSearchPageVersion = new System.Windows.Forms.TextBox();
			this.TxtSearchPageSets = new System.Windows.Forms.TextBox();
			this.LblSearchPageSets = new System.Windows.Forms.Label();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnGetProductSearchPage
			// 
			this.BtnGetProductSearchPage.Location = new System.Drawing.Point(200, 72);
			this.BtnGetProductSearchPage.Name = "BtnGetProductSearchPage";
			this.BtnGetProductSearchPage.Size = new System.Drawing.Size(152, 23);
			this.BtnGetProductSearchPage.TabIndex = 9;
			this.BtnGetProductSearchPage.Text = "GetProductSearchPage";
			this.BtnGetProductSearchPage.Click += new System.EventHandler(this.BtnGetProductSearchPage_Click);
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.LstProductData,
																					this.LblSearchPageData});
			this.GrpResult.Location = new System.Drawing.Point(8, 104);
			this.GrpResult.Name = "GrpResult";
			this.GrpResult.Size = new System.Drawing.Size(504, 256);
			this.GrpResult.TabIndex = 10;
			this.GrpResult.TabStop = false;
			this.GrpResult.Text = "Result";
			// 
			// LstProductData
			// 
			this.LstProductData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.ClmAttributeID,
																							 this.ClmDisplay,
																							 this.ClmName});
			this.LstProductData.GridLines = true;
			this.LstProductData.Location = new System.Drawing.Point(16, 56);
			this.LstProductData.Name = "LstProductData";
			this.LstProductData.Size = new System.Drawing.Size(480, 192);
			this.LstProductData.TabIndex = 77;
			this.LstProductData.View = System.Windows.Forms.View.Details;
			// 
			// ClmAttributeID
			// 
			this.ClmAttributeID.Text = "AttributeID";
			this.ClmAttributeID.Width = 129;
			// 
			// ClmDisplay
			// 
			this.ClmDisplay.Text = "Display Sequence";
			this.ClmDisplay.Width = 61;
			// 
			// ClmName
			// 
			this.ClmName.Text = "Name";
			this.ClmName.Width = 63;
			// 
			// LblSearchPageData
			// 
			this.LblSearchPageData.Location = new System.Drawing.Point(16, 24);
			this.LblSearchPageData.Name = "LblSearchPageData";
			this.LblSearchPageData.Size = new System.Drawing.Size(475, 23);
			this.LblSearchPageData.TabIndex = 12;
			this.LblSearchPageData.Text = "Product SearchPage Data:";
			// 
			// LblSearchPageVersion
			// 
			this.LblSearchPageVersion.Location = new System.Drawing.Point(112, 16);
			this.LblSearchPageVersion.Name = "LblSearchPageVersion";
			this.LblSearchPageVersion.Size = new System.Drawing.Size(128, 23);
			this.LblSearchPageVersion.TabIndex = 13;
			this.LblSearchPageVersion.Text = "Attributes Version:";
			// 
			// TxtSearchPageVersion
			// 
			this.TxtSearchPageVersion.Location = new System.Drawing.Point(240, 16);
			this.TxtSearchPageVersion.Name = "TxtSearchPageVersion";
			this.TxtSearchPageVersion.TabIndex = 14;
			this.TxtSearchPageVersion.Text = "";
			// 
			// TxtSearchPageSets
			// 
			this.TxtSearchPageSets.Location = new System.Drawing.Point(240, 40);
			this.TxtSearchPageSets.Name = "TxtSearchPageSets";
			this.TxtSearchPageSets.Size = new System.Drawing.Size(240, 20);
			this.TxtSearchPageSets.TabIndex = 16;
			this.TxtSearchPageSets.Text = "";
			// 
			// LblSearchPageSets
			// 
			this.LblSearchPageSets.Location = new System.Drawing.Point(32, 40);
			this.LblSearchPageSets.Name = "LblSearchPageSets";
			this.LblSearchPageSets.Size = new System.Drawing.Size(208, 23);
			this.LblSearchPageSets.TabIndex = 15;
			this.LblSearchPageSets.Text = "Characteristic Id\'s (separate by comma):";
			// 
			// FrmGetProductSearchPage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.TxtSearchPageSets,
																		  this.LblSearchPageSets,
																		  this.TxtSearchPageVersion,
																		  this.LblSearchPageVersion,
																		  this.GrpResult,
																		  this.BtnGetProductSearchPage});
			this.Name = "FrmGetProductSearchPage";
			this.Text = "GetProductSearchPage";
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnGetProductSearchPage_Click(object sender, System.EventArgs e)
		{
			try
			{
				LstProductData.Items.Clear();

				GetProductSearchPageCall apicall = new GetProductSearchPageCall(Context);
				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
				if (TxtSearchPageVersion.Text != String.Empty)
					apicall.AttributeVersion = TxtSearchPageVersion.Text;

				if (TxtSearchPageSets.Text != String.Empty)
				{
					apicall.AttributeSetIDList = new Int32Collection();

					string[] atts = TxtSearchPageSets.Text.Split(',');
					foreach (string att in atts)
					{
						apicall.AttributeSetIDList.Add(Convert.ToInt32(att));
					}
				}

				ProductSearchPageTypeCollection spages = apicall.GetProductSearchPage();
		

				foreach (ProductSearchPageType page in spages)
				{
					
					foreach (CharacteristicType val in page.SearchCharacteristicsSet.Characteristics)
					{
						string[] listparams = new string[3];

						listparams[0] = val.AttributeID.ToString();
						listparams[1] = val.DisplaySequence;
						listparams[2] = val.Label.Name;

						ListViewItem vi = new ListViewItem(listparams);
						LstProductData.Items.Add(vi);
					}
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	
	}
}
