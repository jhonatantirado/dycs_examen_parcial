using System;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers;

namespace EnterprisePatterns.Api.DepotOrders
{
    public class DepotOrderEquipment
    {
        public virtual long Id { get; set; }
        public virtual string EquipmentNumber { get; set; }
        public virtual DepotOrder DepotOrder { get; set; }

        public DepotOrderEquipment()
        {
        }

    }
}
