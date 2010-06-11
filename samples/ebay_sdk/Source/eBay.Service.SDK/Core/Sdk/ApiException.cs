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
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.XPath;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// Wraps errors which can be either client-side (e.g. validation) errors, SOAP faults, API errors, or nested
      /// HttpExceptions.
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[Serializable()]
	public class ApiException: SdkException, ISerializable
	{

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ApiException(): base()
		{
		}

		/// <summary>
		/// Construct an ApiException described by the specified message.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public ApiException(string message): base(message)
		{
		}

		/// <summary>
		/// Construct an ApiException wrapping the given exception, and described by the specified message.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="inner">The exception that is the cause of the current exception.</param>
		public ApiException(string message, Exception inner): base(message, inner)
		{
		}

		/// <summary>
		/// Construct an ApiException from the specified API error set (ErrorTypeCollection).
		/// </summary>
		/// <param name="errors">The errors for this exception of type <see cref="ErrorTypeCollection"/>.</param>
		public ApiException(ErrorTypeCollection errors)
		{
			mErrors = errors;
		}

		/// <summary>
		/// Deserialize an ApiException from serialized state information.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		protected ApiException(SerializationInfo info, StreamingContext context):base(info, context)
		{
			mErrors = (ErrorTypeCollection) info.GetValue("mErrors", typeof(ErrorTypeCollection));

		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Serialize an ApiException.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("mErrors", mErrors, typeof(ErrorTypeCollection));
			base.GetObjectData(info, context);
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Parses a failed xml request into an ApiException.
		/// </summary>
		/// <param name="nav">The XPath navigator for the XML response.</param>
		/// <returns>The <see cref="ApiException"/>.</returns>
		static public ApiException FromXmlErrors(XPathNavigator nav)
		{
			ApiException ex = new ApiException();

			XPathNodeIterator i = nav.Select("/eBay/Errors/Error");

			while (i.MoveNext())
			{
				ErrorType err = new ErrorType();

				err.ErrorCode = XmlUtility.GetString(i.Current, "Code");
				err.LongMessage = XmlUtility.GetString(i.Current, "LongMessage");
				err.ShortMessage =XmlUtility.GetString(i.Current, "ShortMessage");

				if (XmlUtility.GetString(i.Current, "Severity") == "Warning")
					err.SeverityCode = SeverityCodeType.Warning;
				else
					err.SeverityCode = SeverityCodeType.Error;


				ex.Errors.Add(err);
			}
			return ex;
		}
		/// <summary>
		/// Parses a soap fault into an ApiException.
		/// </summary>
		/// <param name="soapex">The <see cref="SoapException"/>.</param>
		/// <returns>The <see cref="ApiException"/>.</returns>
		static public ApiException FromSoapException(SoapException soapex)
		{
			ErrorType errorType = new ErrorType();
			XmlNode details = soapex.Detail;

			XPathExpression expr;
			XPathNavigator nav = details.CreateNavigator();
			System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(details.OwnerDocument.NameTable);
			//nsmgr.AddNamespace("pfx", "urn:ebay:apis:eBLBaseComponents");

			expr = nav.Compile("/FaultDetail");
			expr.SetContext(nsmgr);

			XmlNode faultdet = XmlUtility.GetChildNode(nav, expr);

			if (faultdet != null)
			{
				nav = faultdet.CreateNavigator();
				errorType.ShortMessage  = soapex.Message.Trim();

				expr = nav.Compile("Severity");
				expr.SetContext(nsmgr);

				if (XmlUtility.GetString(nav, expr).Trim() == "Warning")
					errorType.SeverityCode = SeverityCodeType.Warning;
				else 
					errorType.SeverityCode = SeverityCodeType.Error;

				expr = nav.Compile("DetailedMessage");
				expr.SetContext(nsmgr);
				errorType.LongMessage = XmlUtility.GetString(nav, expr).Trim();

				expr = nav.Compile("ErrorCode");
				expr.SetContext(nsmgr);
				errorType.ErrorCode = XmlUtility.GetString(nav, expr).Trim();
			} 
			else
			{
				errorType.SeverityCode = SeverityCodeType.Error;
				errorType.ShortMessage  = soapex.Code.Name.Trim();
				errorType.LongMessage = soapex.Message.Trim();
				errorType.ErrorCode = "0";

			}
			
			ErrorTypeCollection etc = new ErrorTypeCollection();
			etc.Add(errorType);
		
			return new ApiException(etc);

		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets the list of errors associated with this exception of type <see cref="ErrorTypeCollection"/>.
		/// </summary>
		public ErrorTypeCollection Errors
		{ 
			get { return mErrors; }
		}

		/// <summary>
		/// Gets the formatted message of this exception of type <see cref="string"/>.
		/// </summary>
		public override string Message
		{ 
			get 
			{
				string message = "";

				if (mErrors.Count > 0) 
				{

					IEnumerator eenum = mErrors.GetEnumerator();

					while (eenum.MoveNext())
					{
						ErrorType err = (ErrorType)eenum.Current;
						
						if (mErrors.IndexOf(err) > 0)
							message += "\r\n";

						if( err.LongMessage != null && err.LongMessage.Length > 0 )
						{
							message += String.Format("{0}", err.LongMessage);

						} 
						else if (err.ShortMessage != null && err.ShortMessage.Length > 0)
						{
							message += String.Format("{0}", err.ShortMessage);
						} 
						else 
						{
							message += String.Format("{0}\r\n", err.ErrorCode);

						}
					}
				} 
				else 
				{
					message = base.Message;
				}

				return message.Trim();
			}
		}

		/// <summary>
		/// Gets the number of errors associated with this exception with <see cref="SeverityCodeType.Error"/>.
		/// </summary>
		public int SeverityErrorCount
		{ 
			get 
			{
				return (this.InnerException != null) ? 1 : CountErrors(SeverityCodeType.Error); 
			}
		}

		/// <summary>
		/// Returns true if the specified error code is one of the error codes belonging to this exception instance.
		/// </summary>
		public bool containsErrorCode(string errorcode)
		{
            if (errorcode == null || errorcode == string.Empty)
            {
                return false;
            }
            
            IEnumerator itenum = Errors.GetEnumerator();
			while (itenum.MoveNext())
			{
				ErrorType errorType = (ErrorType)itenum.Current;
                if (errorcode.Equals(errorType.ErrorCode))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Gets the number of errors associated with this exception with <see cref="SeverityCodeType.Warning"/>.
		/// </summary>
		public int SeverityWarningCount
		{ 
			get 
			{
				return CountErrors(SeverityCodeType.Warning); 
			}
		}

		private int CountErrors(SeverityCodeType type)
		{
			IEnumerator eenum = mErrors.GetEnumerator();

			int count = 0;
			while (eenum.MoveNext())
			{
				if (((ErrorType)eenum.Current).SeverityCode == type)
					count ++;
			}

			return count;
		}
		#endregion

		#region Private Fields
		private ErrorTypeCollection mErrors = new ErrorTypeCollection();
		#endregion

	}
}