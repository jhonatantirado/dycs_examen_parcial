using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Users;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class UserAssembler
    {
        private readonly IMapper _mapper;

        public UserAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User FromSignUpDtoToUser(SignUpDto signUpDto)
        {
            return _mapper.Map<SignUpDto, User>(signUpDto);
        }
    }
}
