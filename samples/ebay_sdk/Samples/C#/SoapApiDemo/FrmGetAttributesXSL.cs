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
	public class FrmGetAttributesXSL : System.Windows.Forms.Form
	{
		public ApiContext Context;
		private System.Windows.Forms.GroupBox GrpResult;
		private System.Windows.Forms.Label LblAttributeData;
		private System.Windows.Forms.TextBox TxtAttributeData;
		private System.Windows.Forms.Button BtnGetAttributesXSL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmGetAttributesXSL()
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
			this.BtnGetAttributesXSL = new System.Windows.Forms.Button();
			this.GrpResult = new System.Windows.Forms.GroupBox();
			this.TxtAttributeData = new System.Windows.Forms.TextBox();
			this.LblAttributeData = new System.Windows.Forms.Label();
			this.GrpResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnGetAttributesXSL
			// 
			this.BtnGetAttributesXSL.Location = new System.Drawing.Point(200, 8);
			this.BtnGetAttributesXSL.Name = "BtnGetAttributesXSL";
			this.BtnGetAttributesXSL.Size = new System.Drawing.Size(128, 23);
			this.BtnGetAttributesXSL.TabIndex = 9;
			this.BtnGetAttributesXSL.Text = "GetAttributesXSL";
			this.BtnGetAttributesXSL.Click += new System.EventHandler(this.BtnGetAttributesXSL_Click);
			// 
			// GrpResult
			// 
			this.GrpResult.Controls.Add(this.TxtAttributeData);
			this.GrpResult.Controls.Add(this.LblAttributeData);
			this.GrpResult.Location = new System.Drawing.Point(8, 40);
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
			this.LblAttributeData.Text = "Attribute XSL:";
			// 
			// FrmGetAttributesXSL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 301);
			this.Controls.Add(this.GrpResult);
			this.Controls.Add(this.BtnGetAttributesXSL);
			this.Name = "FrmGetAttributesXSL";
			this.Text = "GetAttributesXSL";
			this.GrpResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void BtnGetAttributesXSL_Click(object sender, System.EventArgs e)
		{
			try
			{
				GetAttributesXSLCall apicall = new GetAttributesXSLCall(Context);
				apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);

				XSLFileTypeCollection attfiles = apicall.GetAttributesXSL();
				GetAttributesXSLCall.DecodeFileContent(attfiles[0]);
				TxtAttributeData.Text = attfiles[0].FileContent.Replace("\n", "\r\n");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		
		}

	
	}
}
