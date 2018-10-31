using Common.Application;
using DepotSystem.Api.Common.Application;
using DepotSystem.Api.Common.Application.Enum;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DepotSystem.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public Logger logger, logger1, logger2;

        public BaseController()
        {
            // Build the chain of responsibility
            logger = new ConsoleLogger(LogLevel.All);
            logger1 = logger.SetNext(new EmailLogger(LogLevel.FunctionalMessage | LogLevel.FunctionalError));
            logger2 = logger1.SetNext(new FileLogger(LogLevel.Warning | LogLevel.Error));
        }

        public void throwErrors(Notification notification)
        {
            if (notification.hasErrors()) {
                throw new ArgumentException(notification.errorMessage());
            }
        }
    }
}
