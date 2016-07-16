using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskProcessing();
            Console.WriteLine($"Task processing completed on thread : {Thread.CurrentThread.ManagedThreadId}" );
        }

        static void TaskProcessing()
        {
            String[] urls =
            {
                "https://msdn.microsoft.com/en-us/default.aspx",
               // "https://www.UiPath.com",
                "https://www.nseindia.com/"
            };

            foreach (var url in urls)
            {
                DownloadSite(url);
            }
            
        }

        static void DownloadSite(string url)
        {
            WebClient _cl = new WebClient();
            _cl.DownloadStringCompleted += DisplayMsg;
            try
            {
                _cl.DownloadStringAsync(new Uri(url),url);

            }
            catch (ArgumentNullException)
            {

                throw;
            }
            catch (WebException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }


        }

        static void DisplayMsg(object sender,DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine("Inside DisplayMsg");
            var res = e.Result;
            string task = e.UserState as string;
            Console.WriteLine($"Task {task} run on thread : {Thread.CurrentThread.ManagedThreadId} returned bytes : {res}");
        }
    }
}
