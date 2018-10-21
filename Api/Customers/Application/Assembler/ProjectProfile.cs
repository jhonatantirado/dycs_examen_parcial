using AutoMapper;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Projects;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<SignUpDto, Project>()
            .ForMember(
                dest => dest.ProjectName,
                x => x.MapFrom(src => src.ProjectName)
            )
            .ForMember(
                    dest => dest.Budget,
                    opts => opts.MapFrom(
                        src => new Money(src.Budget, src.CurrencyCode)
                    )
                )
            ;
        }

    }
}
