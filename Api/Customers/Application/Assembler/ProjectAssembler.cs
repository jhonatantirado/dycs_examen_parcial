using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Projects;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class ProjectAssembler
    {
        private readonly IMapper _mapper;

        public ProjectAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Project FromSignUpDtoToProject(SignUpDto signUpDto)
        {
            return _mapper.Map<SignUpDto, Project>(signUpDto);
        }
    }
}
