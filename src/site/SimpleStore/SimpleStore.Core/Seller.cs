using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace SimpleStore.Core
{
    public class Seller : Entity
    {
        [DomainSignature]
        public virtual int SellerId { get; protected set; }
        public virtual string Email { get; set; }
        public virtual string EbayUser { get; set; }
        public virtual DateTime Created { get; set; }

        public Seller() { } // NH Requirement

        public Seller(int sellerId)
        {
            Check.Require(sellerId >= 0, "sellerId must be valid");
            SellerId = sellerId;
        }
    }
}
