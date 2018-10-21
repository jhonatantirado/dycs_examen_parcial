using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).Column("customer_id");
            Map(x => x.Name).Column("name");
            Map(x => x.IdentificationNumber).Column("identification_number");
        }
    }
}
