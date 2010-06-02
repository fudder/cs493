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
using System.Collections;
using System.Runtime.InteropServices;
using eBay.Service.Core.Soap;

#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class CallRetry
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public CallRetry() 
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Determines if a retry should be invoked based on an exception that occured.
		/// </summary>
		/// <param name="ex">The <see cref="System.Exception"/> to test for retry.</param>
		/// <returns>Returns <b>true</b> if retry should be invoked, else <b>false</b></returns>
		public bool ShouldRetry(Exception ex)
		{
			return mFilter.Matches(ex);
		}
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public int DelayTime
		{
			get { return mDelayTime; }
			set { mDelayTime = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public int MaximumRetries
		{
			get { return mMaximumRetries; }
			set { 
				if (value < 0)
					throw new SdkException("Maximum retries is invalid", new ArgumentException());
				mMaximumRetries = value; }
		}

		/// <summary>
		/// Gets or sets the error codes that retry should occur for of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection TriggerErrorCodes
		{
			get { return mFilter.TriggerErrorCodes; }
			set { mFilter.TriggerErrorCodes = value ; }
		}

		/// <summary>
		/// Gets or sets the error codes that retry should occur for of type <see cref="StringCollection"/>.
		/// </summary>
		public Int32Collection TriggerHttpStatusCodes
		{
			get { return mFilter.TriggerHttpStatusCodes; }
			set { mFilter.TriggerHttpStatusCodes = value ; }
		}

		/// <summary>
		/// Gets or sets the exception types that retry should occur for of type <see cref="TypeCollection"/>.
		/// </summary>
		public TypeCollection TriggerExceptions
		{
			get { return mFilter.TriggerExceptions; }
			set { mFilter.TriggerExceptions = value ; }
		}
		#endregion

		#region Private Fields
		private int mDelayTime = 5000;
		private int mMaximumRetries = 0;
		private ExceptionFilter mFilter = new ExceptionFilter();
		#endregion

	}
}
