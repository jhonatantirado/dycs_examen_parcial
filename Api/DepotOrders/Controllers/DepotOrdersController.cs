using Microsoft.AspNetCore.Mvc;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using EnterprisePatterns.Api.DepotOrders.Application.Assembler;
using EnterprisePatterns.Api.DepotOrders.Domain.Repository;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;
using DepotSystem.Api.Common.Application.Enum;
using DepotSystem.Api.DepotOrders.Application.Validations;
using DepotSystem.API.Application.Response;
using DepotSystem.API.Controllers;
using DepotSystem.Api.Common.Application;

namespace EnterprisePatterns.Api.DepotOrders.Controllers
{
    [Route("v1/depotorders")]
    [ApiController]
    public class DepotOrdersController: BaseController{
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IDepotOrderRepository _depotOrderRepository;
        private readonly IDepotOrderEquipmentRepository _depotOrderEquipmentRepository;

        private readonly CustomerAssembler _customerAssembler;
        private readonly DepotOrderAssembler _depotOrderAssembler;
        private readonly DepotOrderEquipmentAssembler _depotOrderEquipmentAssembler;

        private readonly DepotOrderDtoValidator _depotOrderDtoValidator;
        private readonly ApiResponseHandler _apiResponseHandler;
        private Logger logger, logger1, logger2;

        public DepotOrdersController(IUnitOfWork unitOfWork, 
            ICustomerRepository customerRepository,
            IDepotOrderRepository depotOrderRepository,
            IDepotOrderEquipmentRepository depotOrderEquipmentRepository,
            CustomerAssembler customerAssembler,
            DepotOrderAssembler depotOrderAssembler,
            DepotOrderEquipmentAssembler depotOrderEquipmentAssembler,
            DepotOrderDtoValidator depotOrderDtoValidator,
            ApiResponseHandler apiResponseHandler)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _depotOrderRepository = depotOrderRepository;
            _depotOrderEquipmentRepository = depotOrderEquipmentRepository;
            _customerAssembler = customerAssembler;
            _depotOrderAssembler = depotOrderAssembler;
            _depotOrderEquipmentAssembler = depotOrderEquipmentAssembler;
            _depotOrderDtoValidator = depotOrderDtoValidator;
            _apiResponseHandler = apiResponseHandler;

            // Build the chain of responsibility
            logger = new ConsoleLogger(LogLevel.All);
            logger1 = logger.SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError));
            logger2 = logger1.SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));
        }

        [HttpPost]
        public IActionResult CreateDepotOrder([FromBody] DepotOrderDto depotOrderDto)
        {
            bool uowStatus = false;
            try
            {
                var notification = _depotOrderDtoValidator.Validate(depotOrderDto);
                throwErrors(notification);

                uowStatus = _unitOfWork.BeginTransaction();
                var customer = _customerAssembler.FromDepotOrderDtoToCustomer(depotOrderDto);
                // Handled by ConsoleLogger since the console has a loglevel of all
                logger.Message("Verifying customer exists", LogLevel.Debug);
                Customer searchCustomer = _customerRepository.GetByIdentificationNumber(depotOrderDto.CustomerIdentificationNumber);
                logger.Message("Customer retrieved.", LogLevel.Info);

                if (searchCustomer.Equals(null))
                {
                    // Handled by ConsoleLogger and FileLogger since filelogger implements Warning & Error
                    logger.Message("Customer doesn't exist", LogLevel.Warning);
                    logger.Message("Preventing NULL exception", LogLevel.Error);
                    // Handled by ConsoleLogger and EmailLogger as it implements functional error
                    logger.Message("Business exception", LogLevel.FunctionalError);
                    return StatusCode(StatusCodes.Status400BadRequest, _apiResponseHandler.AppErrorResponse("Customer doesn't exist"));
                }

                DepotOrder depotOrder = _depotOrderAssembler.FromDepotOrderDtoToDepotOrder(depotOrderDto);
                Port _port = (Port)Enum.Parse(typeof(Port), depotOrderDto.PortISOCode);
                depotOrder.PortId = (long)_port;

                depotOrder.Customer = searchCustomer;
                OceanCarrier _oceanCarrier = (OceanCarrier)Enum.Parse(typeof(OceanCarrier), depotOrderDto.OceanCarrierSCACCode);
                depotOrder.OceanCarrierId = (long)_oceanCarrier;
                depotOrder.ValidateDepotOrder(notification);
                throwErrors(notification);
                _depotOrderRepository.Create(depotOrder);

                List<DepotOrderEquipment> depotOrderEquipments = _depotOrderEquipmentAssembler.ToEntityList(depotOrderDto.Equipments);
                depotOrderEquipments.ForEach(x => x.DepotOrder = depotOrder);
                depotOrderEquipments.ForEach(x => _depotOrderEquipmentRepository.Create(x));
                _unitOfWork.Commit(uowStatus);

                var message = "DepotOrder created!";
                // Handled by ConsoleLogger and EmailLogger
                logger.Message(message, LogLevel.FunctionalMessage);
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status201Created, new ApiStringResponseDto(message));
            }
            catch (ArgumentException ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                logger.Message(ex.StackTrace, LogLevel.Error);
                KipubitRabbitMQ.SendMessage(ex.StackTrace);
                return BadRequest(_apiResponseHandler.AppErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                logger.Message(ex.StackTrace, LogLevel.Error);
                var message = "Internal Server Error";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponseHandler.AppErrorResponse(message));

            }
        }

    }
}