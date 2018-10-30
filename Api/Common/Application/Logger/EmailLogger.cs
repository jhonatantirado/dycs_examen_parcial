using System;
using DepotSystem.Api.Common.Application.Enum;
namespace DepotSystem.Api.Common.Application{
    public class EmailLogger : Logger
    {
        public EmailLogger(LogLevel mask)
            : base(mask)
        { }
 
        protected override void WriteMessage(string msg)
        {
            // Placeholder for mail send logic, usually the email configurations are saved in config file.
            Console.WriteLine("Sending via email: " + msg);
        }
    }

}