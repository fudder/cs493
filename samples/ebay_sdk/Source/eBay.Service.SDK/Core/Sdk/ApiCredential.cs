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
	public class ApiCredential
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ApiCredential()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eBayToken">The token to use when making API calls.</param>
		public ApiCredential(string eBayToken)
		{
			meBayToken = eBayToken;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="expirationDate"></param>
		public void TokenHardExpirationWarning(DateTime expirationDate)
		{
			if( this.OnTokenHardExpirationWarning != null )
				this.OnTokenHardExpirationWarning(this,  new TokenHardExpirationEventArgs(expirationDate));

		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the program credentials (Application, Developer, and Certificate) to use of type <see cref="ApiAccount"/>.
		/// </summary>
		public ApiAccount ApiAccount
		{ 
			get { return mApiAccount; }
			set { mApiAccount = value; }
		}

		/// <summary>
		/// Gets or sets the user credentials (eBay user id, password) to use of type <see cref="eBayAccount"/>.
		/// </summary>
		public eBayAccount eBayAccount
		{ 
			get { return meBayAccount; }
			set { meBayAccount = value; }
		}

		/// <summary>
		/// Gets or sets the users token of type <see cref="string"/>.
		/// </summary>
		public string eBayToken
		{ 
			get { return meBayToken; }
			set { meBayToken = value; }
		}
		#endregion

		#region Events
		/// <summary>
		/// 
		/// </summary>
		public event TokenHardExpirationWarningEventHandler OnTokenHardExpirationWarning;
		#endregion

		#region Private Fields
		private ApiAccount mApiAccount =  new ApiAccount();
		private eBayAccount meBayAccount =  new eBayAccount();
		private string meBayToken = "";
		#endregion

	}

	#region TokenHardExpirationEventArgs
	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public class TokenHardExpirationEventArgs : EventArgs 
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ExpirationDate">The time the token expires of type <see cref="DateTime"/>.</param>
		public TokenHardExpirationEventArgs(DateTime ExpirationDate)
		{
			mExpirationDate = ExpirationDate;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the time the token will expire.
		/// </summary>
		public DateTime ExpirationDate
		{
			get { return mExpirationDate; }
		}
		#endregion

		#region Private Fields
		private DateTime mExpirationDate;
		#endregion
	}
	#endregion

	#region Delegates
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">An <see cref="TokenHardExpirationEventArgs"/> containing the event data.</param>
	[ComVisible(false)]
	public delegate void TokenHardExpirationWarningEventHandler(object sender, TokenHardExpirationEventArgs e);
	#endregion

}
