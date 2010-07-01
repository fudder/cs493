using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate;
using FluentNHibernate.Mapping;
using SimpleStore.Core;

namespace SimpleStore.Data.NHibernateMaps
{
    public class SiteMap : ClassMap<Site>
    {
        public SiteMap()
        {
            Id(x => x.SiteId);
            Map(x => x.Name);
            Map(x => x.Tagline);
            Map(x => x.Created);
        }
    }
}
