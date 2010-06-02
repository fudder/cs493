#region Copyright
//	Copyright (c) 2008, 2009 eBay, Inc.
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
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using eBay.Service.Util;
#endregion

namespace eBay.Service.Call
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class SetNotificationPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetNotificationPreferencesCall()
		{
			ApiRequest = new SetNotificationPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetNotificationPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetNotificationPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Manages a user's notification and alert preferences.
		/// </summary>
		/// 
		/// <param name="ApplicationDeliveryPreferences">
		/// Specifies application-based event preferences that have been enabled,
		/// including the URL to which notifications should be delivered and whether
		/// notifications should be enabled or disabled (although the
		/// UserDeliveryPreferenceArray input property specifies specific
		/// notification subscriptions).
		/// </param>
		///
		/// <param name="UserDeliveryPreferenceList">
		/// Array of NotificationEventEnableTypes. Each NotificationEventEnableType
		/// contains an EventSetting and an EventType.
		/// </param>
		///
		/// <param name="UserData">
		/// Specifies user data for notification settings such as mobile phone number.
		/// </param>
		///
		/// <param name="EventPropertyList">
		/// Characteristics or details of an event such as type, name and value.
		/// Currently can only be set for wireless applications.
		/// </param>
		///
		/// <param name="DeliveryURLName">
		/// For Platform Notifications, specify the name of the delivery notification URL
		/// that you want to associate with the user token specified for
		/// the SetNotificationPreferences call.
		/// If, with different SetNotificationPreferences calls, you
		/// associate multiple URL names with a single user
		/// token, each subsequent URL name overwrites
		/// the previous name associated with the user token.
		/// </param>
		///
		public void SetNotificationPreferences(ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences, NotificationEnableTypeCollection UserDeliveryPreferenceList, NotificationUserDataType UserData, NotificationEventPropertyTypeCollection EventPropertyList, string DeliveryURLName)
		{
			this.ApplicationDeliveryPreferences = ApplicationDeliveryPreferences;
			this.UserDeliveryPreferenceList = UserDeliveryPreferenceList;
			this.UserData = UserData;
			this.EventPropertyList = EventPropertyList;
			this.DeliveryURLName = DeliveryURLName;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetNotificationPreferences(NotificationEnableTypeCollection UserDeliveryPreferenceList)
		{
			this.UserDeliveryPreferenceList = UserDeliveryPreferenceList;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetNotificationPreferences(ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences)
		{
			this.ApplicationDeliveryPreferences = ApplicationDeliveryPreferences;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetNotificationPreferences(ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences, NotificationEnableTypeCollection UserDeliveryPreferenceList)
		{
			this.ApplicationDeliveryPreferences = ApplicationDeliveryPreferences;
			this.UserDeliveryPreferenceList = UserDeliveryPreferenceList;

			Execute();
			
		}

		#endregion




		#region Properties
		/// <summary>
		/// The base interface object.
		/// </summary>
		/// <remarks>This property is reserved for users who have difficulty querying multiple interfaces.</remarks>
		public ApiCall ApiCallBase
		{
			get { return this; }
		}

		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType"/> for this API call.
		/// </summary>
		public SetNotificationPreferencesRequestType ApiRequest
		{ 
			get { return (SetNotificationPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetNotificationPreferencesResponseType"/> for this API call.
		/// </summary>
		public SetNotificationPreferencesResponseType ApiResponse
		{ 
			get { return (SetNotificationPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.ApplicationDeliveryPreferences"/> of type <see cref="ApplicationDeliveryPreferencesType"/>.
		/// </summary>
		public ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences
		{ 
			get { return ApiRequest.ApplicationDeliveryPreferences; }
			set { ApiRequest.ApplicationDeliveryPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.UserDeliveryPreferenceArray"/> of type <see cref="NotificationEnableTypeCollection"/>.
		/// </summary>
		public NotificationEnableTypeCollection UserDeliveryPreferenceList
		{ 
			get { return ApiRequest.UserDeliveryPreferenceArray; }
			set { ApiRequest.UserDeliveryPreferenceArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.UserData"/> of type <see cref="NotificationUserDataType"/>.
		/// </summary>
		public NotificationUserDataType UserData
		{ 
			get { return ApiRequest.UserData; }
			set { ApiRequest.UserData = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.EventProperty"/> of type <see cref="NotificationEventPropertyTypeCollection"/>.
		/// </summary>
		public NotificationEventPropertyTypeCollection EventPropertyList
		{ 
			get { return ApiRequest.EventProperty; }
			set { ApiRequest.EventProperty = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.DeliveryURLName"/> of type <see cref="string"/>.
		/// </summary>
		public string DeliveryURLName
		{ 
			get { return ApiRequest.DeliveryURLName; }
			set { ApiRequest.DeliveryURLName = value; }
		}
		
		

		#endregion

		
	}
}
