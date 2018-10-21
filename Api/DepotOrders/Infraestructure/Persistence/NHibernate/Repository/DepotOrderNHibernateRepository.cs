using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using System.Collections.Generic;
using System;
using System.Linq;
using EnterprisePatterns.Api.DepotOrders.Domain.Repository;

namespace EnterprisePatterns.Api.DepotOrders.Infrastructure.Persistence.NHibernate.Repository
{
    class DepotOrderNHibernateRepository : BaseNHibernateRepository<DepotOrder>, IDepotOrderRepository
    {
        public DepotOrderNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<DepotOrder> GetList(
            int page = 0,
            int pageSize = 5)
        {
            List<DepotOrder> depotOrders = new List<DepotOrder>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                depotOrders = _unitOfWork.GetSession().Query<DepotOrder>()
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return depotOrders;
        }
    }
}
