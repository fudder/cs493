﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using eBaySvc = eBay.Service;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;
using Samples.Helper;

namespace SimpleStore.Services.eBay
{
    public class eBayManager
    {
        private ApiContext ctx = null;

        public ApiContext GetContext()
        {
            if (ctx != null)
                return ctx;

            string token = "AgAAAA**AQAAAA**aAAAAA**A84dTA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4CoAJODogydj6x9nY+seQ**YVEBAA**AAMAAA**4exHm5ivwB1E6NRebim1SUGq3TDnVzkmkaiCFVKj3gWjwEq+ZlRX7FNP6OVew3mqPgpwrl9Qcu43XBBvlq+zNZ01Gkw4aNb9/108/lLYUXZDSR+bWjrPXntUOQ72pDjb9vWy7v8yvx9Q5PxxsTHp/2K4B8muarV2yyqykbTLiLOjVgTlzIi/+hc6vKzqt9BIo/FVYcg7VEAEMTo7bVI+qDg3HZncpzpMJyjteY/3Mvwn5FsHtNmUsaeqzFVFi/aMbCr83q+4T174pn0l2qmpiQ7BKf3WasPQBcWTtgadJW03XmEXrO2Zx01wD4BShYgFV940vK6UnQMDD1p0E9Q34kMYIHAKx9afro2PxHN9sFkIf/v9LHtQqTy7cXdfCIHUyApJaB3h5Dz3T/HcL5lebCs7ijk9KdGoLNJF8FFUfKFlHQ3qpmMHmbzNx8uRaBye6h4wwowJMBmVhd6l2y0uRHIER0dgHa4g5blKAVigUkW7ZvIJpq/4Ym82cGokemC1yxTCgxnmx12rwg+s1Td6ts+9fd63gIQZTUKPx0oXryA2uTVCDWjvIFGeuV/ea+bAfpAq3mGH3GPcEoSEqo/30NgNPlDcvptPdDSzbHLYx7Qx6SBtHxM9Y2pdIdVkxuemxp8gjvQk3v7HaduHAmspggkARNRaOTpE6fMLv0s9GV5kust616jWFLXX6NYa1gU1aPWOSapZSjqyL4aY7f58AWtb6TR5CB0IvfkSNE1t1XZ/Q4oI830f5UW/XogIcqJ9";
            string dev = "5c3b682d-dfb9-4446-80de-c2f989f1b632";
            string app = "Cardogra-a816-494e-ad4c-878f8d7a4c53";
            string cert = "47bc1aff-9740-4857-868b-3a994bdc9886";

            ctx = AppSettingHelper.GetApiContext();
            ctx.ApiLogManager = new ApiLogManager();
            LoggingProperties logProps = AppSettingHelper.GetLoggingProperties();
            ctx.ApiLogManager.ApiLoggerList.Add(new eBaySvc.Util.FileLogger("Log.txt", true, true, true));
            ctx.ApiLogManager.EnableLogging = true;
            ctx.ApiLogManager.MessageLoggingFilter = GetExceptionFilter(logProps);
            ctx.Site = eBaySvc.Core.Soap.SiteCodeType.US;

            ctx.ApiCredential = new ApiCredential(token);
            ctx.ApiCredential.ApiAccount = new ApiAccount(dev, app, cert);

            ctx.SoapApiServerUrl = "https://api.sandbox.ebay.com/wsapi";
            ctx.SignInUrl = "https://signin.sandbox.ebay.com/ws/eBayISAPI.dll?SignIn";
            ctx.EPSServerUrl = "https://api.sandbox.ebay.com/ws/api.dll";
            ctx.Version = "661";
            ctx.Timeout = 60000;

            return ctx;
        }

        public List<ItemType> GetSales()
        {
            GetMyeBaySellingCall apicall = new GetMyeBaySellingCall(GetContext());

            PaginationType pageInfo = new PaginationType();
            pageInfo.EntriesPerPage = 100;

            apicall.ActiveList = new ItemListCustomizationType();
            apicall.ActiveList.Sort = ItemSortTypeCodeType.EndTime;
            apicall.ScheduledList = new ItemListCustomizationType();
            apicall.ScheduledList.Sort = ItemSortTypeCodeType.EndTime;
            apicall.UnsoldList = new ItemListCustomizationType();
            apicall.UnsoldList.Sort = ItemSortTypeCodeType.EndTime;
            apicall.SoldList = new ItemListCustomizationType();
            apicall.SoldList.Sort = ItemSortTypeCodeType.EndTime;

            if (pageInfo != null)
            {
                apicall.ActiveList.Pagination = pageInfo;
                apicall.UnsoldList.Pagination = pageInfo;
                apicall.ScheduledList.Pagination = pageInfo;
                apicall.SoldList.Pagination = pageInfo;
            }

            apicall.GetMyeBaySelling();

            List<ItemType> Items = new List<ItemType>();

            if (apicall.ActiveListReturn != null &&
                    apicall.ActiveListReturn.ItemArray != null &&
                    apicall.ActiveListReturn.ItemArray.Count > 0)
            {
                foreach (ItemType actitem in apicall.ActiveListReturn.ItemArray)
                {
                    Items.Add(actitem);
                }
            }

            foreach (ItemType actitem in Items)
                actitem.TimeLeft = FormatTimeLeft(actitem.TimeLeft);

            return Items;
        }

        public List<eBaySvc.Core.Soap.CategoryType> GetCategories(int parentId, int level)
        {
            GetCategoriesCall apicall = new GetCategoriesCall(GetContext());

            // Enable HTTP compression to reduce the download size.
            apicall.EnableCompression = true;

            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
            apicall.ViewAllNodes = true;
            apicall.LevelLimit = level;
            apicall.CategoryParent = new StringCollection();

            if (parentId > 0)
                apicall.CategoryParent.Add(parentId.ToString());

            CategoryTypeCollection cats = apicall.GetCategories();

            List<CategoryType> Items = new List<CategoryType>();

            foreach (CategoryType category in cats)
			{
                Items.Add(category);
            }

            if (Items[0].CategoryID == parentId.ToString())
                Items.RemoveAt(0);

            return Items;
        }

        public List<eBaySvc.Core.Soap.CategoryType> GetCategoryBreadCrumb(int categoryId)
        {
            GetCategoriesCall apicall = new GetCategoriesCall(GetContext());

            // Enable HTTP compression to reduce the download size.
            apicall.EnableCompression = true;

            int level = 1;
            int parentId = 0;

            apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
            apicall.ViewAllNodes = true;
            apicall.LevelLimit = level;
            apicall.CategoryParent = new StringCollection();
            apicall.CategoryParent.Add(categoryId.ToString());

            List<CategoryType> Items = new List<CategoryType>();

            while (parentId == 0 && level < 10) // arbitrary bailout at 10
            {
                CategoryTypeCollection cats = apicall.GetCategories();
                if (cats.Count == 1)
                {
                    // Add current cat
                    Items.Add(cats[0]);
                    // Find any parents
                    parentId = Convert.ToInt32(cats[0].CategoryParentID[0]);
                }
                else
                {
                    level++;
                    apicall.LevelLimit = level;
                }
            }

            while (level > 0 && parentId != categoryId)
            {
                apicall.LevelLimit = level;
                apicall.CategoryParent = new StringCollection();
                apicall.CategoryParent.Add(parentId.ToString());

                CategoryTypeCollection cats = apicall.GetCategories();

                if (cats.Count > 0)
                {
                    Items.Add(cats[0]);
                    if (cats[0].CategoryParentID.Count > 0)
                    {
                        if (parentId == Convert.ToInt32(cats[0].CategoryParentID[0]))
                            break;
                        else
                            parentId = Convert.ToInt32(cats[0].CategoryParentID[0]);
                    }
                    else
                        break;
                }

                level--;
            }

            Items.Reverse();
            
            return Items;
        }

        private ExceptionFilter GetExceptionFilter(LoggingProperties logProps)
        {
            if (logProps.LogPayloadErrorCodes == null && logProps.LogPayloadExceptions == null && logProps.LogPayloadHttpStatusCodes == null)
                return null;
            else
                return new ExceptionFilter(logProps.LogPayloadErrorCodes, logProps.LogPayloadExceptions, logProps.LogPayloadHttpStatusCodes);

        }

        private string FormatTimeLeft(string timeLeft)
        {
            timeLeft = timeLeft.Replace("P", "");
            timeLeft = timeLeft.Replace("T", "");
            timeLeft = timeLeft.Replace("D", " days, ");
            timeLeft = timeLeft.Replace("H", " hours, ");
            timeLeft = timeLeft.Replace("M", " minutes, ");
            timeLeft = timeLeft.Replace("S", " seconds");
            return timeLeft;
        }
    }
}
