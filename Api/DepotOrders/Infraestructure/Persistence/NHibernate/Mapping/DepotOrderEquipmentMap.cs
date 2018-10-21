using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.DepotOrders.Infrastructure.Persistence.NHibernate.Mapping
{
    public class DepotOrderEquipmentMap : ClassMap<DepotOrderEquipment>
    {
        public DepotOrderEquipmentMap()
        {
            Id(x => x.Id).Column("depot_order_equipment_id");
            Map(x => x.EquipmentNumber).Column("equipment_number");
            References((System.Linq.Expressions.Expression<System.Func<DepotOrderEquipment, DepotOrder>>)(x => x.DepotOrder), "depot_order_id");
        }
    }
}
