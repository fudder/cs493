using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate;
using FluentNHibernate.Mapping;
using SimpleStore.Core;

namespace SimpleStore.Data.NHibernateMaps
{
    public class SellerMap : ClassMap<Seller>
    {
        public SellerMap()
        {
            Id(x => x.SellerId);
            Map(x => x.Email);
            Map(x => x.EbayUser);
            Map(x => x.Created);
        }
    }
}
