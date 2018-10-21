# Examen Parcial DYCS

Construir endpoint(s) donde se aplique lo siguiente:

- Null Object Pattern
- Special Case Pattern
- Specification Pattern (OK): /v1/customers?peruvianOnly=true
- Send messages to rabbitmq (OK): KipubitRabbitMQ.SendMessage(message) envía a net-core-job-background en Pivotal
- Process messages from rabbitmq
- Domain Model Pattern (OK): DepotOrder.ValidateDepotOrder()
- Money Pattern (OK)
- Value Object Pattern (OK): Money es un Value Object
- Data Transfer Object Pattern (OK)
- Assembler Pattern (OK)
- Notification Pattern (OK)
- Unit of Work Pattern (OK)
- Repository Pattern (OK)
- Database Migrations (OK)
- Deployment to Pivotal Cloud Foundry (OK): https://dycs-examen-parcial-funny-serval.cfapps.io/

Sus ejemplos propuestos deben ser originales: (OK)

POST https://dycs-examen-parcial-funny-serval.cfapps.io/v1/depotorders

```
{
	"DocumentNumber": "HLCU2018102103",
	"RequestDate": "2018-10-21",
	"PortISOCode": "PECLL",
	"CustomerIdentificationNumber": "20101010101",
	"OceanCarrierSCACCode": "HLCU",
	"TotalAmount": 1000.00,
	"CurrencyISOCode": "USD",
	"Equipments":[
		{
		"EquipmentNumber": "CAXU0000004"
		},
		{
		"EquipmentNumber": "ROXU0000004"
		}
	]
}
```

GET https://dycs-examen-parcial-funny-serval.cfapps.io/v1/customers?peruvianOnly=true&page=0&size=5
```
[
    {
        "id": 21,
        "name": "Gloria del Peru",
        "identificationNumber": "20202020203"
    },
    {
        "id": 31,
        "name": "Aceros del Peru",
        "identificationNumber": "20202020204"
    },
    {
        "id": 41,
        "name": "Policia Nacional del Peru",
        "identificationNumber": "20202020205"
    },
    {
        "id": 51,
        "name": "Bomberos Voluntarios del Peru",
        "identificationNumber": "20202020206"
    },
    {
        "id": 71,
        "name": "Microsoft Peru",
        "identificationNumber": "20202020208"
    }
]
```