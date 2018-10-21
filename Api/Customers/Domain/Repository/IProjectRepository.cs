using System.Collections.Generic;
namespace EnterprisePatterns.Api.Projects.Domain.Repository
{
    public interface IProjectRepository
    {
            List<Project> GetList(
            int page = 0,
            int pageSize = 5);

        void Create(Project project);
    }
}
