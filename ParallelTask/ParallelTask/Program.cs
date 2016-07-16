using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTask
{
    class Program
    {
        static string[] apps = { "Excel", "Notepad", "Calc" };

        static void Main(string[] args)
        {
            AsyncProcessing();
            Console.WriteLine($"Asyn Processing done in Main function thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static void AsyncProcessing()
        {           
            Action<string> _app = PerformTask;
            Parallel.ForEach(apps, _app);             
        }

        static void PerformTask(object _app)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = _app.ToString();
            myProcess.Start();
            Console.WriteLine($"Application - {_app.ToString()} opened on thread - {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
            Thread.Sleep(10000);
            myProcess.CloseMainWindow();
            Console.WriteLine($"Application - {_app.ToString()} closed on thread - {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
            
        }
    }
}
