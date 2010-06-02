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
	/// Summary description for FormEnvironment.
	/// </summary>
	public class FormEnvironment : System.Windows.Forms.Form
	{
		FormMain formMain;
		private System.Windows.Forms.TextBox txtApiServer;
		private System.Windows.Forms.Label label_apisvr;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnContinue;
		private System.Windows.Forms.Button btnCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormEnvironment()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.txtApiServer = new System.Windows.Forms.TextBox();
			this.label_apisvr = new System.Windows.Forms.Label();
			this.btnContinue = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtApiServer
			// 
			this.txtApiServer.Location = new System.Drawing.Point(100, 28);
			this.txtApiServer.Name = "txtApiServer";
			this.txtApiServer.Size = new System.Drawing.Size(232, 20);
			this.txtApiServer.TabIndex = 6;
			this.txtApiServer.Text = "";
			// 
			// label_apisvr
			// 
			this.label_apisvr.Location = new System.Drawing.Point(12, 24);
			this.label_apisvr.Name = "label_apisvr";
			this.label_apisvr.Size = new System.Drawing.Size(88, 23);
			this.label_apisvr.TabIndex = 4;
			this.label_apisvr.Text = "API Server URL:";
			this.label_apisvr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnContinue
			// 
			this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnContinue.Location = new System.Drawing.Point(64, 96);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(108, 23);
			this.btnContinue.TabIndex = 7;
			this.btnContinue.Text = "Continue";
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(220, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtApiServer);
			this.groupBox3.Controls.Add(this.label_apisvr);
			this.groupBox3.Location = new System.Drawing.Point(16, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(356, 64);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			// 
			// FormEnvironment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 142);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnContinue);
			this.Name = "FormEnvironment";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Environment";
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CustomInit()
		{
			this.Load += new System.EventHandler(this.FormEnvironment_Load);
			this.Text = "Set eBay API Server Address";
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void FormEnvironment_Load(object sender, System.EventArgs e)
		{
			this.formMain = (FormMain)this.Owner;

			ApiContext apiContext = formMain.ApiContext;
			this.txtApiServer.Text = apiContext.SoapApiServerUrl;
		}

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			try{
				ApiContext apiContext = this.formMain.ApiContext;
				apiContext.SoapApiServerUrl = this.txtApiServer.Text;

				if(!ValidateInput()) return;

				this.DialogResult = DialogResult.OK;

				FormMain owner = this.formMain;
				this.Hide();
				this.Dispose();
				Form form = new FormUserAcnt();
				form.ShowDialog(owner);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Operation failed!\n"+ex.Message, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool ValidateInput()
		{

			if (txtApiServer.Text==string.Empty)
			{
				MessageBox.Show("Please set the api server address");
				txtApiServer.Focus();
				return false;
			}

			return true;
		}
	}
}
