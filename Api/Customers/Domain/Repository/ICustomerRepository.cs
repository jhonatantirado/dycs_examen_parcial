using EnterprisePatterns.Api.Common.Domain.Specification;
using System.Collections.Generic;
namespace EnterprisePatterns.Api.Customers.Domain.Repository
{
    public interface ICustomerRepository
    {
            List<Customer> GetList(
            Specification<Customer> specification,
            int page = 0,
            int pageSize = 5);

        void Create(Customer customer);

        Customer GetByIdentificationNumber(string identificationNumber);
    }
}
