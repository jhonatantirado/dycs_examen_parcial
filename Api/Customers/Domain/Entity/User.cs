using EnterprisePatterns.Api.Customers;
namespace EnterprisePatterns.Api.Users
{
    public class User
    {
        public virtual long Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual long RoleId { get; set; }
        public virtual Customer Customer { get; set; }

        public User()
        {
        }
    }
}
