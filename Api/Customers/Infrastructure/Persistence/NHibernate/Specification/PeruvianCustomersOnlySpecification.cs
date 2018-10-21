using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EnterprisePatterns.Api.Common.Domain.Specification;

namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Specification
{
    public sealed class PeruvianCustomersOnlySpecification : Specification<Customer>
    {
        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => customer.Name.Contains("PERU");
        }
    }
}
