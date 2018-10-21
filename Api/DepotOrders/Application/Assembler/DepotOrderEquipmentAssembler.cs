using AutoMapper;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.DepotOrders.Application.Assembler
{
    public class DepotOrderEquipmentAssembler
    {
        private readonly IMapper _mapper;

        public DepotOrderEquipmentAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DepotOrderEquipment FromDepotOrderEquipmentDtoToDepotOrderEquipment(DepotOrderEquipmentDto depotOrderEquipmentDto)
        {
            return _mapper.Map<DepotOrderEquipmentDto, DepotOrderEquipment>(depotOrderEquipmentDto);
        }

        public List<DepotOrderEquipment> ToEntityList(List<DepotOrderEquipmentDto> depotOrderEquipmentDtoList)
        {
            return _mapper.Map<List<DepotOrderEquipmentDto>, List<DepotOrderEquipment>>(depotOrderEquipmentDtoList);
        }
    }
}
