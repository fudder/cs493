#region Copyright
//	Copyright (c) 2007 eBay, Inc.
//
//	This program is licensed under the terms of the eBay Common Development and 
//	Distribution License (CDDL) Version 1.0 (the "License") and any subsequent 
//	version thereof released by eBay.  The then-current version of the License 
//	can be found at https://www.codebase.ebay.com/Licenses.html and in the 
//	eBaySDKLicense file that is under the eBay SDK install directory.
#endregion

#region Namespaces
using System;
using System.Runtime.InteropServices;
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class ApiAccount 
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ApiAccount()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Developer">The <see cref="Developer"/> credential.</param>
		/// <param name="Application">The <see cref="Application"/> credential.</param>
		/// <param name="Certificate">The <see cref="Certificate"/> credential.</param>
		public ApiAccount(string Developer, string Application, string Certificate)
		{
			mDeveloper = Developer;
			mApplication = Application;
			mCertificate = Certificate;

		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Application credentials to use.
		/// </summary>
		public string Application
		{ 
			get { return mApplication; }
			set { mApplication = value; }
		}

		/// <summary>
		/// Gets or sets the Certificate credentials to use.
		/// </summary>
		public string Certificate
		{ 
			get { return mCertificate; }
			set { mCertificate = value; }
		}

		/// <summary>
		/// Gets or sets the Developer credentials to use.
		/// </summary>
		public string Developer
		{ 
			get { return mDeveloper; }
			set { mDeveloper = value; }
		}
		#endregion

		#region Private Fields
		private string mApplication = "";
		private string mCertificate = "";
		private string mDeveloper = "";
		#endregion

	}
}
