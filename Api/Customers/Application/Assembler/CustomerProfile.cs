using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(
                    dest => dest.Name,
                    x => x.MapFrom(src => src.Name)
                );
            CreateMap<SignUpDto, Customer>()
                .ForMember(
                    dest => dest.Name,
                    x => x.MapFrom(src => src.OrganizationName)
                );
            CreateMap<DepotOrderDto, Customer>()
                .ForMember(
                    dest => dest.IdentificationNumber,
                    x => x.MapFrom(src => src.CustomerIdentificationNumber)
                );
        }
    }
}
