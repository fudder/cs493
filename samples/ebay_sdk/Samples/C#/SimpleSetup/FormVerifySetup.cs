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
using eBay.Service.Call;

namespace SimpleSetup
{
	/// <summary>
	/// Summary description for FormVerifySetup.
	/// </summary>
	public class FormVerifySetup : System.Windows.Forms.Form
	{
		FormMain formMain;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txteBayOfficialTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Label lbInfo;
		private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormVerifySetup()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			CustomInit();
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

		private void CustomInit()
		{
			this.Load += new System.EventHandler(this.FormVerifySetup_Load);
			this.Text = "Verify Setup";
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txteBayOfficialTime = new System.Windows.Forms.TextBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.lbInfo = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(96, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "eBay Official Time:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txteBayOfficialTime
			// 
			this.txteBayOfficialTime.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.txteBayOfficialTime.Enabled = false;
			this.txteBayOfficialTime.Location = new System.Drawing.Point(240, 172);
			this.txteBayOfficialTime.Name = "txteBayOfficialTime";
			this.txteBayOfficialTime.Size = new System.Drawing.Size(128, 20);
			this.txteBayOfficialTime.TabIndex = 1;
			this.txteBayOfficialTime.Text = "";
			this.txteBayOfficialTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnExecute
			// 
			this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExecute.Location = new System.Drawing.Point(104, 268);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(160, 28);
			this.btnExecute.TabIndex = 1;
			this.btnExecute.Text = "GeteBayOfficialTime";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// lbInfo
			// 
			this.lbInfo.Location = new System.Drawing.Point(20, 28);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Size = new System.Drawing.Size(452, 36);
			this.lbInfo.TabIndex = 3;
			this.lbInfo.Text = "Test your setup by calling eBay API GeteBayOfficialTime.";
			this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtStatus,
																					this.label3,
																					this.txteBayOfficialTime,
																					this.lbInfo,
																					this.label1});
			this.groupBox1.Location = new System.Drawing.Point(24, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(488, 224);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// txtStatus
			// 
			this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
			this.txtStatus.Enabled = false;
			this.txtStatus.Location = new System.Drawing.Point(240, 108);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.Size = new System.Drawing.Size(128, 20);
			this.txtStatus.TabIndex = 5;
			this.txtStatus.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(136, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 28);
			this.label3.TabIndex = 4;
			this.label3.Text = "Call Status:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(328, 268);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(84, 28);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// FormVerifySetup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(532, 313);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnClose,
																		  this.groupBox1,
																		  this.btnExecute});
			this.Name = "FormVerifySetup";
			this.Text = "FormVerifySetup";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExecute_Click(object sender, System.EventArgs e)
		{
			this.lbInfo.Text = "Making call to eBay. Please wait...";

			this.txtStatus.Text = "";
			this.txteBayOfficialTime.Text = "";

			eBay.Service.Call.GeteBayOfficialTimeCall api = null;
			try 
			{
				api = new GeteBayOfficialTimeCall(this.formMain.ApiContext);
				api.GeteBayOfficialTime();
				this.txtStatus.Text = api.AbstractResponse.Ack.ToString();
				this.txteBayOfficialTime.Text = api.AbstractResponse.Timestamp.ToString();
				this.lbInfo.Text = "Congratulation ! You have completed the setup and are ready to use eBay APIs.";
			}
			catch(Exception ex) 
			{
				this.txtStatus.Text = "Failure";				
				MessageBox.Show("Operation failed!\n"+ex.Message, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void FormVerifySetup_Load(object sender, System.EventArgs e)
		{
			this.formMain = (FormMain)this.Owner;
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
