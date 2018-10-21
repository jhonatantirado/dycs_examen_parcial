using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Users.Infrastructure.Persistence.NHibernate.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Column("user_id");
            Map(x => x.Username).Column("username");
            Map(x => x.Password).Column("password");
            Map(x => x.RoleId).Column("role_id");
            References(x => x.Customer, "customer_id");
        }
    }
}
