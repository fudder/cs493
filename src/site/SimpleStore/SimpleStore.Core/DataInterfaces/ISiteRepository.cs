using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpArch.Core.PersistenceSupport;

namespace SimpleStore.Core.DataInterfaces
{
    public interface ISiteRepository : IRepository<Site>
    {
        List<Site> FindAllMatching(string filter);
    }
}
