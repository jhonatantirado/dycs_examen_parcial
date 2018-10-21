using EnterprisePatterns.Api.Common.Application.Enum;
using System;

namespace EnterprisePatterns.Api.Customers.Application.Dto
{
    public class SignUpDto
    {
        public string OrganizationName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProjectName { get; set; }
        public decimal Budget { get; set; }
        public Currency CurrencyCode { get; set; }

    }
}
