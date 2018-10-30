using System;
using DepotSystem.Api.Common.Application.Enum;
namespace DepotSystem.Api.Common.Application{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(LogLevel mask)
            : base(mask)
        { }
 
        protected override void WriteMessage(string msg)
        {
            Console.WriteLine("Writing to console: " + msg);
        }
    }

}
