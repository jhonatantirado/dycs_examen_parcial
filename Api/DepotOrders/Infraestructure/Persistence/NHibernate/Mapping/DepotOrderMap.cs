using EnterprisePatterns.Api.Common.Application.Enum;
using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.DepotOrders.Infrastructure.Persistence.NHibernate.Mapping
{
    public class DepotOrderMap : ClassMap<DepotOrder>
    {
        public DepotOrderMap()
        {
            Id(x => x.Id).Column("depot_order_id");
            Map(x => x.DocumentNumber).Column("document_number");
            Map(x => x.RequestDate).Column("request_date");
            Map(x => x.PortId).Column("port_id");
            References(x => x.Customer, "customer_id");
            Map(x => x.OceanCarrierId).Column("ocean_carrier_id");
            Component(x => x.Price, m =>
            {
                m.Map(x => x.Amount, "total_amount");
                m.Map(x => x.Currency, "currency_id").CustomType<Currency>();
            });
        }
    }
}
