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
	/// Summary description for GetAttributesCSForm.
	/// </summary>
	public class FrmGetAttributesCS : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.Button BtnGetAttributesCS;
		private System.Windows.Forms.Label LblAttributeData;
		private System.Windows.Forms.TextBox TxtAttributeData;
		private System.Windows.Forms.Label LblAttVersion;
		private System.Windows.Forms.TextBox TxtAttVersion;
		private System.Windows.Forms.Label LblAttSets;
		private System.Windows.Forms.TextBox TxtAttSets;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetAttributesCS()
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
			this.BtnGetAttributesCS = new System.Windows.Forms.Button();
			this.GrpResult = new System.Windows.Forms.GroupBox();
			this.TxtAttributeData = new System.Windows.Forms.TextBox();
			this.LblAttributeData = new System.Windows.Forms.Label();
			this.LblAttVersion = new System.Windows.Forms.Label();
			this.TxtAttVersion = new System.Windows.Forms.TextBox();
			this.TxtAttSets = new System.Windows.Forms.TextBox();
			this.LblAttSets = new System.Windows.Forms.Label();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnGetAttributesCS
			// 
			this.BtnGetAttributesCS.Location = new System.Drawing.Point(200, 72);
			this.BtnGetAttributesCS.Name = "BtnGetAttributesCS";
			this.BtnGetAttributesCS.Size = new System.Drawing.Size(128, 23);
			this.BtnGetAttributesCS.TabIndex = 9;
			this.BtnGetAttributesCS.Text = "GetAttributesCS";
			this.BtnGetAttributesCS.Click += new System.EventHandler(this.BtnGetAttributesCS_Click);
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.Add(this.TxtAttributeData);
			this.GrpResult.Controls.Add(this.LblAttributeData);
			this.GrpResult.Location = new System.Drawing.Point(8, 104);
			this.GrpResult.Name = "GrpResult";
			this.GrpResult.Size = new System.Drawing.Size(504, 256);
			this.GrpResult.TabIndex = 10;
			this.GrpResult.TabStop = false;
			this.GrpResult.Text = "Result";
			// 
			// TxtAttributeData
			// 
			this.TxtAttributeData.Location = new System.Drawing.Point(24, 56);
			this.TxtAttributeData.Multiline = true;
			this.TxtAttributeData.Name = "TxtAttributeData";
			this.TxtAttributeData.ReadOnly = true;
			this.TxtAttributeData.Size = new System.Drawing.Size(456, 192);
			this.TxtAttributeData.TabIndex = 74;
			this.TxtAttributeData.Text = "";
			// 
			// LblAttributeData
			// 
			this.LblAttributeData.Location = new System.Drawing.Point(16, 24);
			this.LblAttributeData.Name = "LblAttributeData";
			this.LblAttributeData.Size = new System.Drawing.Size(475, 23);
			this.LblAttributeData.TabIndex = 12;
			this.LblAttributeData.Text = "Attribute CS Data:";
			// 
			// LblAttVersion
			// 
			this.LblAttVersion.Location = new System.Drawing.Point(80, 16);
			this.LblAttVersion.Name = "LblAttVersion";
			this.LblAttVersion.Size = new System.Drawing.Size(128, 23);
			this.LblAttVersion.TabIndex = 13;
			this.LblAttVersion.Text = "Attributes Version:";
			// 
			// TxtAttVersion
			// 
			this.TxtAttVersion.Location = new System.Drawing.Point(208, 16);
			this.TxtAttVersion.Name = "TxtAttVersion";
			this.TxtAttVersion.TabIndex = 14;
			this.TxtAttVersion.Text = "";
			// 
			// TxtAttSets
			// 
			this.TxtAttSets.Location = new System.Drawing.Point(208, 40);
			this.TxtAttSets.Name = "TxtAttSets";
			this.TxtAttSets.Size = new System.Drawing.Size(240, 20);
			this.TxtAttSets.TabIndex = 16;
			this.TxtAttSets.Text = "";
			// 
			// LblAttSets
			// 
			this.LblAttSets.Location = new System.Drawing.Point(16, 40);
			this.LblAttSets.Name = "LblAttSets";
			this.LblAttSets.Size = new System.Drawing.Size(192, 23);
			this.LblAttSets.TabIndex = 15;
			this.LblAttSets.Text = "Attributes Sets (separate by comma):";
			// 
			// FrmGetAttributesCS
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 365);
			this.Controls.Add(this.TxtAttSets);
			this.Controls.Add(this.LblAttSets);
			this.Controls.Add(this.TxtAttVersion);
			this.Controls.Add(this.LblAttVersion);
			this.Controls.Add(this.GrpResult);
			this.Controls.Add(this.BtnGetAttributesCS);
			this.Name = "FrmGetAttributesCS";
			this.Text = "GetAttributesCS";
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnGetAttributesCS_Click(object sender, System.EventArgs e)
		{
			try
			{
				TxtAttributeData.Text = "";

				GetAttributesCSCall apicall = new GetAttributesCSCall(Context);
				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);


				if (TxtAttVersion.Text.Length > 0)
					apicall.AttributeVersion = TxtAttVersion.Text;

				if (TxtAttSets.Text.Length > 0)
				{
					apicall.AttributeSetIDList = new Int32Collection();
					string[] atts = TxtAttSets.Text.Split(',');
					foreach (string att in atts)
						apicall.AttributeSetIDList.Add(Convert.ToInt32(att));
				}

				string attdata = apicall.GetAttributesCS();
		
				TxtAttributeData.Text = attdata.Replace("\n", "\r\n");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

	
	}
}
