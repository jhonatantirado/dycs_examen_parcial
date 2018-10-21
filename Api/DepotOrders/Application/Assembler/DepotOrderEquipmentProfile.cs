using AutoMapper;
using EnterprisePatterns.Api.Common.Domain.ValueObject;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;

namespace EnterprisePatterns.Api.DepotOrders.Application.Assembler
{
    public class DepotOrderEquipmentProfile: Profile
    {
        public DepotOrderEquipmentProfile()
        {
            CreateMap<DepotOrderEquipmentDto, DepotOrderEquipment>()
            .ForMember(
                dest => dest.EquipmentNumber,
                x => x.MapFrom(src => src.EquipmentNumber)
            );
        }

    }
}
