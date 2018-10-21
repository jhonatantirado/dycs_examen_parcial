using Common.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DepotSystem.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public void throwErrors(Notification notification)
        {
            if (notification.hasErrors()) {
                throw new ArgumentException(notification.errorMessage());
            }
        }
    }
}
