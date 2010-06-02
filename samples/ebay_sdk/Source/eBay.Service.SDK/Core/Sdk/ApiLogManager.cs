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
using System.Xml;
using System.IO;
using System.Collections;
using eBay.Service.Util;
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// 
	/// </summary>
	public class ApiLogManager
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ApiLogManager()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ApiLogManager(ApiLoggerCollection ApiLoggerList)
		{
			mApiLoggerList.AddRange(ApiLoggerList);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Message"></param>
		public void RecordMessage(string Message)
		{
			this.RecordMessage(Message, MessageType.Information, MessageSeverity.Informational);
		}
		
		/// <summary>
		/// Log a message to all loggers enabled for this type of message.
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Type"></param>
		/// <param name="Severity"></param>
		public void RecordMessage(string Message, MessageType Type, MessageSeverity Severity)
		{	if (!mEnableLogging)
				return;

			switch (Type)
			{
				case MessageType.Exception:
					foreach (ApiLogger logger in mApiLoggerList)
					{
						if (logger.LogExceptions)
							logger.RecordMessage(Message, Severity);
					}

					break;
				case MessageType.Information:
					foreach (ApiLogger logger in mApiLoggerList)
					{
						if (logger.LogInformations)
							logger.RecordMessage(Message, Severity);
					}

					break;

				case MessageType.ApiMessage:
					foreach (ApiLogger logger in mApiLoggerList)
					{
						if (logger.LogApiMessages)
							logger.RecordMessage(Message, Severity);
					}
				
					break;

			}
		}

		/// <summary>
		/// Used only for exception-based payload logging; variation of RecordMessage which takes an exception parameter.
		/// Calls RecordMessage if no exception is supplied, or if this is not an ApiMessage (i.e. payload message), or if
		/// no MessageLoggingFilter property is configured on the log manager.  Otherwise, the exception logic is applied: the 
		/// method will continue calling RecordMessage only if the exception matches the configured MessageLoggingFilter property.
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Type"></param>
		/// <param name="Severity"></param>
		/// <param name="Ex"></param>
		public void RecordPayloadOnException(string Message, MessageType Type, MessageSeverity Severity, Exception Ex)
		{
			if (Type != MessageType.ApiMessage || mMessageLoggingFilter == null || mMessageLoggingFilter.Matches(Ex))
				RecordMessage(Message, Type, Severity);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets list of loggers to use when logging of type <see cref="ApiLoggerCollection"/>.
		/// </summary>
		public ApiLoggerCollection ApiLoggerList
		{ 
			get { return mApiLoggerList; }
			set { mApiLoggerList = value; }
		}
		
		/// <summary>
		/// Gets or sets a value that turns logging off if set to <b>false</b>
		/// </summary>
		public bool EnableLogging
		{ 
			get { return mEnableLogging; }
			set { mEnableLogging = value; }
		}

		/// <summary>
		/// Gets or sets a global message logging filter.  If this is set, all loggers will perform message logging 
		/// </summary>
		public ExceptionFilter MessageLoggingFilter
		{
			get { return mMessageLoggingFilter; }
			set { mMessageLoggingFilter = value; }
		}

		/// <summary>
		/// Get only - returns <b>true</b> if any logger is enabling message logging.
		/// </summary>
		public bool LogApiMessages
		{ 
			get { 
				foreach (ApiLogger logger in mApiLoggerList)
				{
					if (logger.LogApiMessages)
						return true;
				}
				return false; 
			
			}
		}

		/// <summary>
		/// Get only - returns <b>true</b> if any logger is enabling logging of exception message strings.
		/// </summary>
		public bool LogExceptions
		{ 
			get 
			{ 
				foreach (ApiLogger logger in mApiLoggerList)
				{
					if (logger.LogExceptions)
						return true;
				}
				return false; 
			
			}		
		}

		/// <summary>
		/// Get only - returns <b>true</b> if any logger is enabling information logging.
		/// </summary>
		public bool LogInformation
		{ 
			get 
			{ 
				foreach (ApiLogger logger in mApiLoggerList)
				{
					if (logger.LogInformations)
						return true;
				}
				return false; 
			
			}		
		}
		#endregion

		#region Private Fields
		private ApiLoggerCollection mApiLoggerList = new ApiLoggerCollection();
		private bool mEnableLogging = true;
		private ExceptionFilter mMessageLoggingFilter = null;
		#endregion

	}
}
