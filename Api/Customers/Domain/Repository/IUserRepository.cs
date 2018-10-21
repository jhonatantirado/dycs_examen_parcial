using System.Collections.Generic;
namespace EnterprisePatterns.Api.Users.Domain.Repository
{
    public interface IUserRepository
    {
            List<User> GetList(
            int page = 0,
            int pageSize = 5);

        void Create(User user);
    }
}
