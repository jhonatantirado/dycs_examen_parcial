using EnterprisePatterns.Api.Common.Application.Enum;
using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Projects.Infrastructure.Persistence.NHibernate.Mapping
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id).Column("project_id");
            Map(x => x.ProjectName).Column("project_name");
            Component(x => x.Budget, m =>
            {
                m.Map(x => x.Amount, "budget");
                m.Map(x => x.Currency, "currency_id").CustomType<Currency>();
            });

            References(x => x.Customer, "customer_id");
        }
    }
}
