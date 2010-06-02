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
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using Samples.Helper;

namespace SimpleSetup
{
	/// <summary>
	/// Summary description for FormUserAcnt.
	/// </summary>
	public class FormUserAcnt : System.Windows.Forms.Form
	{
		FormMain formMain;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtToken;
		private System.Windows.Forms.Button btnContinue;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormUserAcnt()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			CustomInit();
			SetFormStartPosition();
		}

		private void SetFormStartPosition()
		{
			this.StartPosition = FormStartPosition.CenterParent;
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtToken = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.btnContinue = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Token:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtToken
			// 
			this.txtToken.Location = new System.Drawing.Point(122, 30);
			this.txtToken.Multiline = true;
			this.txtToken.Name = "txtToken";
			this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtToken.Size = new System.Drawing.Size(200, 252);
			this.txtToken.TabIndex = 2;
			this.txtToken.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 28);
			this.label3.TabIndex = 4;
			this.label3.Text = "Don\'t have a token ? ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(18, 84);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(150, 24);
			this.linkLabel1.TabIndex = 5;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Signup and get one at eBay: http://developer.eBay.com.";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// btnContinue
			// 
			this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnContinue.Location = new System.Drawing.Point(366, 204);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(132, 28);
			this.btnContinue.TabIndex = 4;
			this.btnContinue.Text = "Continue";
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(368, 254);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(130, 28);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(10, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(320, 292);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.linkLabel1);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(342, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(180, 128);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			// 
			// FormUserAcnt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 313);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnContinue);
			this.Controls.Add(this.txtToken);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "FormUserAcnt";
			this.Text = "FormUserAcnt";
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CustomInit()
		{
			this.Load += new System.EventHandler(this.FormUserAcnt_Load);
			this.Text = "Set eBay User Credential";
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			string url = "http://developer.ebay.com";
			System.Diagnostics.Process.Start(url);		
		}

		private void FormUserAcnt_Load(object sender, System.EventArgs e)
		{
			this.formMain = (FormMain)this.Owner;
			this.txtToken.Text = this.formMain.ApiContext.ApiCredential.eBayToken;
		}


		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			try 
			{
				string token = this.txtToken.Text;

				if(!ValiateInput()) return;

				ApiContext apiContext = this.formMain.ApiContext;
				apiContext.ApiCredential.eBayToken = token;

				this.DialogResult = DialogResult.OK;
				FormMain owner = this.formMain;

				this.Hide();
				this.Dispose();

				Form form = new FormVerifySetup();
				DialogResult result = form.ShowDialog(owner);
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Operation failed!\n"+ex.Message, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool ValiateInput()
		{
			if (txtToken.Text==string.Empty)
			{
				MessageBox.Show("Please set the Token");
				txtToken.Focus();
				return false;
			}

			return true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Dispose();
		}
	}
}
