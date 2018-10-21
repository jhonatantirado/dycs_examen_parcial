using Microsoft.AspNetCore.Mvc;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using EnterprisePatterns.Api.Users;
using EnterprisePatterns.Api.Projects;
using EnterprisePatterns.Api.Users.Domain.Repository;
using EnterprisePatterns.Api.Projects.Domain.Repository;
using Common.Application;
using EnterprisePatterns.Api.Common.Application.Enum;
using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Specification;

namespace EnterprisePatterns.Api.Controllers
{
    [Route("v1/customers")]
    [ApiController]
    public class CustomersController: ControllerBase{
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly CustomerAssembler _customerAssembler;
        private readonly UserAssembler _userAssembler;
        private readonly ProjectAssembler _projectAssembler;


        public CustomersController(IUnitOfWork unitOfWork, 
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            CustomerAssembler customerAssembler,
            UserAssembler userAssembler,
            ProjectAssembler projectAssembler)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _customerAssembler = customerAssembler;
            _userAssembler = userAssembler;
            _projectAssembler = projectAssembler;
        }

        [HttpGet]
        public IActionResult Customers([FromQuery] int page = 0, [FromQuery] int size = 5, [FromQuery] bool peruvianOnly = false)
        {
            bool uowStatus = false;
            try
            {
                Specification<Customer> specification = GetCustomerSpecification(peruvianOnly);
                uowStatus = _unitOfWork.BeginTransaction();
                List<Customer> customers = _customerRepository.GetList(specification, page, size);
                _unitOfWork.Commit(uowStatus);
                List<CustomerDto> customersDto = _customerAssembler.toDtoList(customers);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            } catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }

        }

        [Route("signup")]
        [HttpPost]
        public IActionResult Create([FromBody] SignUpDto signUpDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Customer customer = _customerAssembler.FromSignUpDtoToCustomer(signUpDto);
                notification = customer.validateForSave();

                if(notification.hasErrors())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, notification.ToString());
                }

                _customerRepository.Create(customer);

                User user = _userAssembler.FromSignUpDtoToUser(signUpDto);
                user.RoleId = (long) Role.Owner;
                user.Customer = customer;
                _userRepository.Create(user);

                Project project = _projectAssembler.FromSignUpDtoToProject(signUpDto);
                project.Customer = customer;

                _projectRepository.Create(project);

                _unitOfWork.Commit(uowStatus);

                var message = "Customer, user and project created!";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status201Created, new ApiStringResponseDto(message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(message));

            }
        }

        private Specification<Customer> GetCustomerSpecification(bool peruvianOnly)
        {
            Specification<Customer> specification = Specification<Customer>.All;

            if (peruvianOnly)
                specification = specification.And(new PeruvianCustomersOnlySpecification());

            return specification;
        }

    }
}