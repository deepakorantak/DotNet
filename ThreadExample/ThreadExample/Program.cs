using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
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
            int i = 0;
            bool running = true;

            List<Thread > threadCollection  = new List<Thread>();

            foreach (var _app in apps)
            {
                Console.WriteLine($"Iteration : {++i} on thread {Thread.CurrentThread.ManagedThreadId}");
                Thread thread = new Thread(PerformTask);
                thread.Start(_app);
                threadCollection.Add(thread);                     
             }

            if (threadCollection.Count == 0)
                running = false;

            
            while (running)
            {
                for (int idx = 0; idx < threadCollection.Count; idx ++)
                {
                  
                    if (threadCollection[idx].ThreadState != System.Threading.ThreadState.Stopped)
                        goto check_1;
                    else
                        if (idx == threadCollection.Count-1)
                        running = false;
                }

            check_1: continue;
            }
        }

        static void PerformTask(object _app)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = _app.ToString();
            myProcess.Start();
            Console.WriteLine($"Application - {_app.ToString()} opened on thread - {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
            Thread.Sleep(7000);
            myProcess.CloseMainWindow();
            Console.WriteLine($"Application - {_app.ToString()} closed on thread - {Thread.CurrentThread.ManagedThreadId} at {DateTime.Now}");
            Thread.CurrentThread.Abort(); 
        }
    }
}
