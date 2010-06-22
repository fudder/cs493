using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Criterion;
using SharpArch.Data.NHibernate;
using SimpleStore.Core;
using SimpleStore.Core.DataInterfaces;

namespace SimpleStore.Data
{
    public class SiteRepository : Repository<Site>, ISiteRepository
    {
        public List<Site> FindAllMatching(string filter)
        {
            ICriteria criteria =
                Session.CreateCriteria(typeof(Site))
                .Add(
                    Expression.Or(
                        Expression.InsensitiveLike("Name", filter, MatchMode.Anywhere),
                        Expression.InsensitiveLike("Tagline", filter, MatchMode.Anywhere)
                    )
                 )
                .AddOrder(
                    new NHibernate.Criterion.Order("Name", true)
                );

            return criteria.List<Site>() as List<Site>;
        }
    }
}

