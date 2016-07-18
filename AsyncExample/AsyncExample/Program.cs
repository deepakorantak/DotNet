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
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            TaskProcessing();
            Console.WriteLine($"Task processing completed on thread : {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }

        static void TaskProcessing()
        {
            WebClient _cl = new WebClient();
              _cl.DownloadStringCompleted += DisplayMsg;

   
            String[] urls =
            {
                "http://msdn.microsoft.com/en-us/default.aspx",
                "http://www.Microsoft.com",
                "https://www.UiPath.com"

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


        }

        static void DisplayMsg(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                Console.WriteLine("Inside DisplayMsg");
                var res = e.Result;
                string task = e.UserState as string;
                Console.WriteLine($"Task {task} run on thread : {Thread.CurrentThread.ManagedThreadId} returned bytes : {res.Length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
