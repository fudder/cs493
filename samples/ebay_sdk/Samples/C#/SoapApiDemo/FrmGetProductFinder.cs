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
	/// Summary description for GetProductFinderForm.
	/// </summary>
	public class FrmGetProductFinder : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.Button BtnGetProductFinder;
		private System.Windows.Forms.Label LblFinderVersion;
		private System.Windows.Forms.TextBox TxtFinderVersion;
		private System.Windows.Forms.TextBox TxtFinderSets;
		private System.Windows.Forms.Label LblFinderSets;
		private System.Windows.Forms.TextBox TxtFinderData;
		private System.Windows.Forms.Label LblFinderData;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetProductFinder()
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
			this.BtnGetProductFinder = new System.Windows.Forms.Button();
			this.GrpResult = new System.Windows.Forms.GroupBox();
			this.TxtFinderData = new System.Windows.Forms.TextBox();
			this.LblFinderData = new System.Windows.Forms.Label();
			this.LblFinderVersion = new System.Windows.Forms.Label();
			this.TxtFinderVersion = new System.Windows.Forms.TextBox();
			this.TxtFinderSets = new System.Windows.Forms.TextBox();
			this.LblFinderSets = new System.Windows.Forms.Label();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnGetProductFinder
			// 
			this.BtnGetProductFinder.Location = new System.Drawing.Point(200, 72);
			this.BtnGetProductFinder.Name = "BtnGetProductFinder";
			this.BtnGetProductFinder.Size = new System.Drawing.Size(128, 23);
			this.BtnGetProductFinder.TabIndex = 9;
			this.BtnGetProductFinder.Text = "GetProductFinder";
			this.BtnGetProductFinder.Click += new System.EventHandler(this.BtnGetProductFinder_Click);
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.Add(this.TxtFinderData);
			this.GrpResult.Controls.Add(this.LblFinderData);
			this.GrpResult.Location = new System.Drawing.Point(8, 104);
			this.GrpResult.Name = "GrpResult";
			this.GrpResult.Size = new System.Drawing.Size(504, 256);
			this.GrpResult.TabIndex = 10;
			this.GrpResult.TabStop = false;
			this.GrpResult.Text = "Result";
			// 
			// TxtFinderData
			// 
			this.TxtFinderData.Location = new System.Drawing.Point(24, 56);
			this.TxtFinderData.Multiline = true;
			this.TxtFinderData.Name = "TxtFinderData";
			this.TxtFinderData.ReadOnly = true;
			this.TxtFinderData.Size = new System.Drawing.Size(456, 192);
			this.TxtFinderData.TabIndex = 74;
			this.TxtFinderData.Text = "";
			// 
			// LblFinderData
			// 
			this.LblFinderData.Location = new System.Drawing.Point(16, 24);
			this.LblFinderData.Name = "LblFinderData";
			this.LblFinderData.Size = new System.Drawing.Size(475, 23);
			this.LblFinderData.TabIndex = 12;
			this.LblFinderData.Text = "Product Finder Data:";
			// 
			// LblFinderVersion
			// 
			this.LblFinderVersion.Location = new System.Drawing.Point(80, 16);
			this.LblFinderVersion.Name = "LblFinderVersion";
			this.LblFinderVersion.Size = new System.Drawing.Size(128, 23);
			this.LblFinderVersion.TabIndex = 13;
			this.LblFinderVersion.Text = "Finder Version:";
			// 
			// TxtFinderVersion
			// 
			this.TxtFinderVersion.Location = new System.Drawing.Point(208, 16);
			this.TxtFinderVersion.Name = "TxtFinderVersion";
			this.TxtFinderVersion.TabIndex = 14;
			this.TxtFinderVersion.Text = "";
			// 
			// TxtFinderSets
			// 
			this.TxtFinderSets.Location = new System.Drawing.Point(208, 40);
			this.TxtFinderSets.Name = "TxtFinderSets";
			this.TxtFinderSets.Size = new System.Drawing.Size(240, 20);
			this.TxtFinderSets.TabIndex = 16;
			this.TxtFinderSets.Text = "";
			// 
			// LblFinderSets
			// 
			this.LblFinderSets.Location = new System.Drawing.Point(16, 40);
			this.LblFinderSets.Name = "LblFinderSets";
			this.LblFinderSets.Size = new System.Drawing.Size(192, 23);
			this.LblFinderSets.TabIndex = 15;
			this.LblFinderSets.Text = "Finder Id\'s (separate by comma):";
			// 
			// FrmGetProductFinder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 365);
			this.Controls.Add(this.TxtFinderSets);
			this.Controls.Add(this.LblFinderSets);
			this.Controls.Add(this.TxtFinderVersion);
			this.Controls.Add(this.LblFinderVersion);
			this.Controls.Add(this.GrpResult);
			this.Controls.Add(this.BtnGetProductFinder);
			this.Name = "FrmGetProductFinder";
			this.Text = "GetProductFinder";
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnGetProductFinder_Click(object sender, System.EventArgs e)
		{
			try
			{
				TxtFinderData.Text = "";

				GetProductFinderCall apicall = new GetProductFinderCall(Context);
				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);

				if (TxtFinderVersion.Text != String.Empty)
					apicall.AttributeVersion = TxtFinderVersion.Text;

				if (TxtFinderSets.Text != String.Empty)
				{
					apicall.ProductFinderIDList = new Int32Collection();
					string[] atts = TxtFinderSets.Text.Split(',');
					foreach (string att in atts)
						apicall.ProductFinderIDList.Add(Convert.ToInt32(att));
				}

				string finderdata = apicall.GetProductFinder();
		
				if (finderdata != null)
					TxtFinderData.Text = finderdata.Replace("\n", "\r\n");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	
	}
}
