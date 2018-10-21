using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers;
namespace EnterprisePatterns.Api.Projects
{
    public class Project
    {
        public virtual long Id { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual Money Budget { get; set; }
        public virtual Customer Customer { get; set; }

        public Project()
        {
        }
    }
}
