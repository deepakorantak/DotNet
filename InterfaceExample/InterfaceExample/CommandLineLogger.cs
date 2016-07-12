using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class CommandLineLogger : Ilogger
    {
        public bool logEvent(string logDetails, string logType, string loggedBy)
        {
            Console.WriteLine($"Date : {DateTime.Now}\t Serverity:{logType}\t Logged By:{loggedBy}\t Log:{logDetails}");
            return true;
        }
    }
}
