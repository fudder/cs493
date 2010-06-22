using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace SimpleStore.Core
{
    public class Site : Entity
    {
        [DomainSignature]
        public virtual int SiteId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Tagline { get; set; }

        public Site() { } // NH Requirement

        public Site(int siteId)
        {
            Check.Require(siteId >= 0,"siteId must be valid"); 
            SiteId = siteId;
        }
    }
}
