using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class FileLogger : Ilogger
    {
              
        private string _filename;

        public FileLogger(string ifilename)
        {
            _filename = ifilename;
        }
               
        public bool logEvent(string logDetails, string logType, string loggedBy)
        {
            
            System.IO.StreamWriter file = new System.IO.StreamWriter("D:\\Deepa\\Training\\GitHub\\DotNet\\InterfaceExample\\"+ _filename,true);
            file.WriteLine($"Date : {DateTime.Now}\t Serverity:{logType}\t Logged By:{loggedBy}\t Log:{logDetails}");

            file.Close();

            return true;
        }
    }
}
