using System.Collections.Generic;
namespace EnterprisePatterns.Api.DepotOrders.Domain.Repository
{
    public interface IDepotOrderRepository
    {
            List<DepotOrder> GetList(
            int page = 0,
            int pageSize = 5);

        void Create(DepotOrder depotOrder);
    }
}
