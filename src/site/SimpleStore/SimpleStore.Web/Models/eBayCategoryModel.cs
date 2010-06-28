using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using eBay.Service.Core.Soap;

namespace SimpleStore.Web.Models
{
    public class eBayCategoryModel
    {
        public List<CategoryType> BreadCrumb = new List<CategoryType>();
        public List<CategoryType> Categories = new List<CategoryType>();
    }
}