using System;
using Common.Application;
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

        private bool HasIdentity()
        {
            return !String.IsNullOrEmpty(this.DocumentNumber);
        }

        public virtual void ValidateDepotOrder(Notification notification)
        {
            if (!this.HasIdentity())
            {
                notification.addError("DocumentNumber is missing");
                return;
            }
            ValidatePrice(notification);
        }

        private void ValidatePrice(Notification notification)
        {
            if (Price == null)
            {
                notification.addError("Price is missing");
                return;
            }

            if (String.IsNullOrEmpty(Price.Currency.ToString()))
            {
                notification.addError("Currency is missing");
            }
            if (Price.Amount <= 0)
            {
                notification.addError("The amount must be greater than zero");
            }
        }

    }
}
