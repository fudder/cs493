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
using System.Data;
using System.Configuration;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.SDK;
using eBay.Service.Util;
using Samples.Helper;

namespace SimpleSetup
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnContinue;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ApiContext apiContext;

		public ApiContext ApiContext
		{
			get {return this.apiContext;}
			set {this.apiContext = value;}
		}

		private void CustomInit()
		{

			this.apiContext = AppSettingHelper.GetApiContext();
			if (this.apiContext.Site == SiteCodeType.CustomCode) 
			{
				this.apiContext.Site = SiteCodeType.US;
			}

			string logFile = System.Configuration.ConfigurationManager.AppSettings.Get(AppSettingHelper.LOG_FILE_NAME);
			if (logFile != null) 
			{
				ApiLogManager apiLogManager = new ApiLogManager();
				apiLogManager.ApiLoggerList.Add(new eBay.Service.Util.FileLogger(logFile, true, true, true));
				apiLogManager.EnableLogging = true;
				this.apiContext.ApiLogManager = apiLogManager;
			}
		}

		public FormMain()
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
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}

			Samples.Helper.AppSettingHelper.SaveAppSettings("app.config");
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(140, 268);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(80, 32);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(308, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Exit";
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(28, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 248);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 40);
            this.label1.TabIndex = 5;
            this.label1.Text = "This application walks you through a simple 3-step setup to use eBay APIs.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(88, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(272, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "3. Verify setup - Call API GeteBayOfficialTime";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(88, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "2. Set eBay User Credentials(eBay Token)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(88, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "1. Set eBay API Server Address";
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(532, 313);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Name = "FormMain";
            this.Text = "Simple Setup Application";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			Form form = new FormEnvironment();
			form.ShowDialog(this);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Dispose();
		}
	}
}
