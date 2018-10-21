using Common.Application;
using EnterprisePatterns.Api.DepotOrders.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepotSystem.Api.DepotOrders.Application.Validations
{
    public class DepotOrderDtoValidator
    {
        public Notification Validate(DepotOrderDto depotOrderDto)
        {
            Notification notification = new Notification();
            if (depotOrderDto == null)
            {
                notification.addError("Missing data");
                return notification;
            }
            if (string.IsNullOrEmpty(depotOrderDto.DocumentNumber))
            {
                notification.addError("DocumentNumber is missing");
            }
            if (string.IsNullOrEmpty(depotOrderDto.CustomerIdentificationNumber))
            {
                notification.addError("CustomerIdentificationNumber is missing");
            }
            if (string.IsNullOrEmpty(depotOrderDto.OceanCarrierSCACCode))
            {
                notification.addError("OceanCarrierSCACCode is missing");
            }
            if (string.IsNullOrEmpty(depotOrderDto.PortISOCode))
            {
                notification.addError("PortISOCode is missing");
            }
            if (string.IsNullOrEmpty(depotOrderDto.RequestDate.ToString()))
            {
                notification.addError("RequestDate is missing");
            }
            if (depotOrderDto.TotalAmount<0)
            {
                notification.addError("TotalAmount can't be negative");
            }
            if (string.IsNullOrEmpty(depotOrderDto.CurrencyISOCode.ToString()))
            {
                notification.addError("CurrencyISOCode is missing");
            }

            return notification;
        }
    }
}
