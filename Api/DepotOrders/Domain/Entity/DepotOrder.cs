using System;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers;

namespace EnterprisePatterns.Api.DepotOrders
{
    public class DepotOrder
    {
        public virtual long Id { get; set; }
        public virtual string DocumentNumber { get; set; }
        public virtual DateTime RequestDate { get; set; }
        public virtual long PortId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual long OceanCarrierId { get; set; }
        public virtual Money Price { get; set; }

        public DepotOrder()
        {
        }

    }
}
