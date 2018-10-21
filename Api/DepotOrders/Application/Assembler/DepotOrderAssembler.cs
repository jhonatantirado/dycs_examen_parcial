using AutoMapper;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;

namespace EnterprisePatterns.Api.DepotOrders.Application.Assembler
{
    public class DepotOrderAssembler
    {
        private readonly IMapper _mapper;

        public DepotOrderAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DepotOrder FromDepotOrderDtoToDepotOrder(DepotOrderDto depotOrderDto)
        {
            return _mapper.Map<DepotOrderDto, DepotOrder>(depotOrderDto);
        }
    }
}
