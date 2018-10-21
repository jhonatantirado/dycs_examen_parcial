using System.Collections.Generic;
namespace EnterprisePatterns.Api.DepotOrders.Domain.Repository
{
    public interface IDepotOrderEquipmentRepository
    {
            List<DepotOrderEquipment> GetList(
            int page = 0,
            int pageSize = 5);

        void Create(DepotOrderEquipment depotOrderEquipment);
    }
}
