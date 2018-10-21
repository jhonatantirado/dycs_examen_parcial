using EnterprisePatterns.Api.Common.Application.Enum;
using System;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.DepotOrders.Application.Dto
{
    public class DepotOrderDto
    {
        public string DocumentNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string PortISOCode { get; set; }
        public string CustomerIdentificationNumber { get; set; }
        public string OceanCarrierSCACCode { get; set; }
        public decimal TotalAmount { get; set; }
        public Currency CurrencyISOCode { get; set; }
        public List<DepotOrderEquipmentDto> Equipments { get; set; }
    }
}
