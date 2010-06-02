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
using System.Net;
using System.Runtime.InteropServices;
using eBay.Service.Core.Soap;
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class ApiContext
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ApiContext()
		{
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Updates the last call time that an API call occured.
		/// </summary>
		/// <param name="eBayTime">The <see cref="AbstractResponseType.Timestamp"/>.</param>
		public void CallUpdate(DateTime eBayTime)
		{
			lock( this )
			{
				mTotalCalls++;
				if (eBayTime > DateTime.MinValue)
				{
					mLastCallTime = eBayTime;
				}
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Log Manager of type <see cref="ApiLogManager"/>.
		/// </summary>
		public ApiLogManager ApiLogManager
		{ 
			get { return mLogger; }
			set { mLogger = value; }
		}
		
		/// <summary>
		/// Gets or sets the credentials to use for making API calls of type <see cref="ApiCredential"/>.
		/// </summary>
		public ApiCredential ApiCredential
		{ 
			get { return mApiCredential; }
			set { mApiCredential = value; }
		}

		/// <summary>
		/// Gets or sets the url to use for uploading pictures to eBay Picture Service of type <see cref="string"/>.
		/// </summary>
		public string EPSServerUrl
		{ 
			get { return mEPSServerUrl; }
			set { mEPSServerUrl = value; }
		}

		/// <summary>
		/// Gets or sets the language in which API errors will be returned of type <see cref="ErrorLanguageCodeType"/>.
		/// </summary>
		public ErrorLanguageCodeType ErrorLanguage
		{ 
			get { return mErrorLanguage; }
			set { mErrorLanguage = value; }
		}
		
		/// <summary>
		/// Gets the time the last API Call was made of type <see cref="DateTime"/>
		/// </summary>
		public DateTime LastCallTime
		{ 
			get { return mLastCallTime; }
		}

		/// <summary>
		/// Gets or sets the retry parameters of type <see cref="CallRetry"/>.
		/// </summary>
		public CallRetry CallRetry
		{ 
			get { return mCallRetry; }
			set { mCallRetry = value; }
		}

		/// <summary>
		/// Gets or sets the return url name to use when using the Authentication &amp; Authorization feature of type <see cref="string"/>.
		/// </summary>
		public string RuName
		{ 
			get { return mRuName; }
			set { mRuName = value; }
		}	

		/// <summary>
		/// Gets or sets the url to direct to when using the Authentication &amp; Authorization feature of type <see cref="string"/>.
		/// </summary>
		public string SignInUrl
		{ 
			get { return mSignInUrl; }
			set { mSignInUrl = value; }
		}

		/// <summary>
		/// Gets or sets the site to use when making API Calls of type <see cref="SiteCodeType"/>.
		/// </summary>
		public SiteCodeType Site
		{ 
			get { return mSite; }
			set { mSite = value; }
		}

		/// <summary>
		/// Gets or sets the the number of milliseconds to wait before the API call times out of type <see cref="int"/>.
		/// </summary>
		public int Timeout
		{ 
			get { return mTimeout; }
			set { mTimeout = value; }
		}

		/// <summary>
		/// Gets the the number of API calls made of type <see cref="int"/>.
		/// </summary>
		public int TotalCalls
		{ 
			get { return mTotalCalls; }
		}
		/// <summary>
		/// Gets or sets the url to use when making Soap API calls of type <see cref="string"/>.
		/// </summary>
		public string SoapApiServerUrl
		{ 
			get { return mSoapApiServerUrl; }
			set { mSoapApiServerUrl = value; }
		}

		/// <summary>
		/// Gets or sets the url to use when making XML API calls of type <see cref="string"/>.
		/// </summary>
		public string XmlApiServerUrl
		{ 
			get { return mXmlApiServerUrl; }
			set { mXmlApiServerUrl = value; }
		}

		/// <summary>
		/// Gets or sets the Compatability version to use when making API calls of type <see cref="string"/>.
		/// </summary>
		public string Version
		{ 
			get { return mVersion; }
			set { mVersion= value; }
		}

		/// <summary>
		/// If set to <b>true</b>, enables collection of data about total call latency, network latency, and server-side latency.
		/// </summary>
		public bool EnableMetrics
		{ 
			get { return mEnableMetrics; }
			set { mEnableMetrics= value; }
		}
		/// <summary>
		/// Holds a reference to a master table of call metrics for various call names.  There is normally one such table across an entire application
		/// (including multiple thread instances).
		/// </summary>
		public CallMetricsTable CallMetricsTable
		{ 
			get { return mCallMetricsTable; }
			set { mCallMetricsTable= value; }
		}

        /// <summary>
        /// Set this if you accesss eBay API server behind a proxy server
        /// </summary>
        public IWebProxy WebProxy
        {
            get { return mWebProxy; }
            set { mWebProxy = value; }
        }

		/// <summary>
		/// holds the rulename to use when fetching token.
		/// </summary>
		public string RuleName
		{
			get { return ruleName; }
			set { ruleName = value; }
		}
		#endregion

		#region Private Fields
		private ApiCredential mApiCredential = new ApiCredential();
		private ErrorLanguageCodeType mErrorLanguage = ErrorLanguageCodeType.CustomCode;
		private string mEPSServerUrl;
		private DateTime mLastCallTime;
		private ApiLogManager mLogger = null;
		private CallRetry mCallRetry = null;
		private string mRuName = "";
		private string mSignInUrl;
		private SiteCodeType mSite = SiteCodeType.CustomCode;
		private int mTimeout = 60000;
		private int mTotalCalls = 0;
		private string mVersion= "661";
		private string mSoapApiServerUrl;
		private string mXmlApiServerUrl;
		private bool mEnableMetrics;
		private CallMetricsTable mCallMetricsTable;
        private IWebProxy mWebProxy = null;
		private string ruleName;
		#endregion

	}
}
