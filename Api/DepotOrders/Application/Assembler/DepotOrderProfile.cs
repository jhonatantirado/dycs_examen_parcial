using AutoMapper;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;

namespace EnterprisePatterns.Api.DepotOrders.Application.Assembler
{
    public class DepotOrderProfile: Profile
    {
        public DepotOrderProfile()
        {
            CreateMap<DepotOrderDto, DepotOrder>()
            .ForMember(
                dest => dest.DocumentNumber,
                x => x.MapFrom(src => src.DocumentNumber)
            )
            .ForMember(
                dest => dest.RequestDate,
                x => x.MapFrom(src => src.RequestDate)
            )
            .ForMember(
                    dest => dest.Price,
                    opts => opts.MapFrom(
                        src => new Money(src.TotalAmount, src.CurrencyISOCode)
                    )
                )
            ;
        }

    }
}
