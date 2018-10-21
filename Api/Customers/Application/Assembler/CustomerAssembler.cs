using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class CustomerAssembler
    {
        private readonly IMapper _mapper;

        public CustomerAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Customer FromSignUpDtoToCustomer(SignUpDto signUpDto)
        {
            return _mapper.Map<SignUpDto,Customer> (signUpDto);
        }

        public Customer FromDepotOrderDtoToCustomer(DepotOrderDto depotOrderDto)
        {
            return _mapper.Map<DepotOrderDto, Customer>(depotOrderDto);
        }

        public List<CustomerDto> toDtoList(List<Customer> customerList)
        {
            return _mapper.Map<List<Customer>, List<CustomerDto>>(customerList);
        }
    }
}