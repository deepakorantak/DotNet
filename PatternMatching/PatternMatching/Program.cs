using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using PatternMatchingLib;

namespace PatternMatching
{
    public class Program
    {
        static void Main(string[] args)
        {

                          
            Start.Process(@"D:\Deepa\Projects\VGZ\Robot\output\optransactions.csv", @"D:\Deepa\Projects\VGZ\Robot\input\accountsInScope.csv", @"D:\Deepa\Projects\VGZ\Robot\input\transactionMapping.csv");

            Console.WriteLine("Completed");
        }

       
    }
}
