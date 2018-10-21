using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using System.Collections.Generic;
using System;
using System.Linq;
using EnterprisePatterns.Api.DepotOrders.Domain.Repository;

namespace EnterprisePatterns.Api.DepotOrders.Infrastructure.Persistence.NHibernate.Repository
{
    class DepotOrderEquipmentNHibernateRepository : BaseNHibernateRepository<DepotOrderEquipment>, IDepotOrderEquipmentRepository
    {
        public DepotOrderEquipmentNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<DepotOrderEquipment> GetList(
            int page = 0,
            int pageSize = 5)
        {
            List<DepotOrderEquipment> depotOrderEquipments = new List<DepotOrderEquipment>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                depotOrderEquipments = _unitOfWork.GetSession().Query<DepotOrderEquipment>()
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return depotOrderEquipments;
        }
    }
}
