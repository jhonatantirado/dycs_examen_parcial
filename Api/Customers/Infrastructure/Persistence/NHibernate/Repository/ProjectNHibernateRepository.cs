using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using System.Collections.Generic;
using System;
using System.Linq;
using EnterprisePatterns.Api.Projects.Domain.Repository;

namespace EnterprisePatterns.Api.Projects.Infrastructure.Persistence.NHibernate.Repository
{
    class ProjectNHibernateRepository : BaseNHibernateRepository<Project>, IProjectRepository
    {
        public ProjectNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<Project> GetList(
            int page = 0,
            int pageSize = 5)
        {
            List<Project> projects = new List<Project>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                projects = _unitOfWork.GetSession().Query<Project>()
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return projects;
        }
    }
}
