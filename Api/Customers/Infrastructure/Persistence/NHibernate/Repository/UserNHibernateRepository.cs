using EnterprisePatterns.Api.Common.Infrastructure.Persistence.NHibernate;
using EnterprisePatterns.Api.Users.Domain.Repository;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EnterprisePatterns.Api.Users.Infrastructure.Persistence.NHibernate.Repository
{
    class UserNHibernateRepository : BaseNHibernateRepository<User>, IUserRepository
    {
        public UserNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public List<User> GetList(
            int page = 0,
            int pageSize = 5)
        {
            List<User> users = new List<User>();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                users = _unitOfWork.GetSession().Query<User>()
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
                _unitOfWork.Commit(uowStatus);
            } catch(Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                throw ex;
            }
            return users;
        }
    }
}
