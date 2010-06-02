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
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
#endregion

namespace AllTestsSuite
{

	public class TestData 
	{

		public static ItemType NewItem = null;
		public static ItemType NewFixedPriceItem = null;
		public static ItemType NewItem2 = null;//it is new, this item contains more information than NewItem.
		public static ItemType EndedItem = null;
		public static ItemType EndedFixedPriceItem = null;
		public static ItemType EndedItem2 = null; //it is new, it is used for ending NewItem2.
		public static ItemType WatchedItem = null;
		public static ItemType ChineseAuctionItem = null;// it is new, it is used for Dutch Action
		public static ItemType AdFormatItem = null;// it is new, it is used for Dutch Action

		public static CategoryTypeCollection Categories = null;
		public static CategoryTypeCollection Category2CS = null;
		public static CategoryType Category2CS2 = null;//It is new.
		public static ItemTypeCollection CategoryListings = null;

		public static StoreType Store = null;

		public static StoreCustomPageTypeCollection StoreCustomPages = null;

		public static GetStoreOptionsResponseType StoreOptionsResponse = null;

		public static StorePreferencesType StorePreferences = null;

		public static GetUserPreferencesResponseType UserPreferencesResponse = null;

		public static TaxJurisdictionTypeCollection TaxTable = null;

		public static GetNotificationPreferencesResponseType NotificationPreferencesResponse = null;

		public static MemberMessageExchangeTypeCollection MemberMessages = null;

		public static TransactionTypeCollection SellerTransactions = null;

		public static PictureManagerDetailsType PictureManagerDetails = null;

		public static PromotionRuleType ItemPromotionRule = null;

		public static ProductSearchPageTypeCollection ProductSearchPages = null;
		public static ProductSearchPageTypeCollection ProductSearchPages2 = null;// It is new

		public static StringCollection itemIds=null;//cache ids which return from AddItems call 

		public static ProductSearchResultTypeCollection ProductSearchResults = null;
		public static ProductSearchResultTypeCollection ProductSearchResults2 = null;// it is new
		public static string AudioChallengeURL = null;
		public static string ChallengeToken = null;
		public static string ImageChallengeURL = null;
		public static long CartID = 0;

		public static string ApiUserID="apitest11";
        public static string BuyerToken = "AgAAAA**AQAAAA**aAAAAA**jROnSw**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnY+gD5iFoA+dj6x9nY+seQ**fk8AAA**AAMAAA**6/RGdkgr40CAWarfUQj9uRpgafnpvfehqNotojy3aNlw21Vurb9QQv/drjFA6QyR2+D/dWqWnVuwqQ4g21FoUwGaZqf6t4+t8qYvLsbYcKyqVL4bqhKGGdeuzsfj8pumOOZ79dO1bzB2WbmjfixaF2XrDIiIWkeGU5MUGak9RNn++pYzhevgncs5pyTcPeMUC8pq1YVGbcIbXFtgs9V4trmxYmdbmHgsdcWTRzSPwR4B1uVd4ozKhgLXhi/RYWoASzrkSUJJzmXC7Zp4ZZEwj8Li+vMNk70zFnk6zHwnlCLOJNRBZY5us8JSuF8IrJ221qSqp1DZTM9aFF+K6FWzcJx0GhhtnVduCzZefcQiOZADrzODhHvbDHsYWX7JQ8HD/JAB8mp8ss88d39dMkg+e/RcJkRhuSisD+cMj/juusZNvr3FM/v16rL6eeil7YKUlbFa/b9eFCV9undDnjxwwz33ZoLc+KkJwhoMjyvI+tnqT9M33EFvCBMvYn1BE63wC7x00siopEnXVXtHNva+BPLXvX99WmbJ8fwxbn6J0r++iThKZ7DqzAq8NWPJsLC+7D7D/zhCr7zUTJ7Ehecl14sy3fcgyoxtiIHH5JGeJo+2e0OKC9z2aJNpHBPBy8ap5lW/l6HT6db3i/wtzL2FROI2tZNLZ7IYbSMpr30mbWMFgJJwdoKRjhLYwlIYTdXxj9qS85R3Mgm0rlu7Z7/b9CCluGjA7IKOIPpWXVZ9wl9psh8Noe6qkkUmQxQh0i0M";

		#region static fields & properties for selling manager

		private static long folder_id1 = long.MinValue;
		public static long Folder_id1
		{
			get
			{
				return folder_id1;
			}
			set
			{
				folder_id1=value;
			}
		}

		private static long folder_id2 = long.MinValue;
		public static long Folder_id2
		{
			get
			{
				return folder_id2;
			}
			set
			{
				folder_id2=value;
			}
		}

		private static long saleTemplateId = long.MinValue;
		public static long SaleTemplateId
		{
			get
			{
				return saleTemplateId;
			}
			set
			{
				saleTemplateId=value;
			}
		}

		private static long productId = long.MinValue;
		public static long ProductId
		{
			get
			{
				return productId;
			}
			set
			{
				productId=value;
			}
		}

		private static string itemId = string.Empty;
		public static string ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				itemId=value;
			}
		}

		private static string soldItemId = string.Empty;
		public static string SoldItemId
		{
			get
			{
				return soldItemId;
			}
			set
			{
				soldItemId=value;
			}
		}

		#endregion
	}
}
