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

            var act = new Start();
                          
            var resList = act.Process(@"D:\Deepa\Projects\VGZ\Robot\output\optransactions.csv", @"D:\Deepa\Projects\VGZ\Robot\input\accountsInScope.csv", @"D:\Deepa\Projects\VGZ\Robot\input\transactionMapping.csv");

            var resDT = act.TransformToDataTable(resList);

            //using (var file = File.CreateText("d:\\deepa\\projects\\vgz\\robot\\output\\maptransactions.csv"))
            //{

            //    file.WriteLine("id|load_date|iban|companycode|statement_numbe|entry_date|value_date|glaccount|amount|codadesc|remarks|additional");
            //    foreach (var item in resDT)
            //    {

            //    }

            //    resDT.foreach(t => file.writeline(string.join("|", new[] {t.id,t.load_date,t.iban,t.companycode,t.statementnumber,t.entrydate,
            //                                                                     t.valuedate,t.glaccountnumber,t.amount,t.codadescription,t.transactiondescription,t.additionainfo })));

            //}

            Console.WriteLine($"Completed with DT rows - {resDT.Rows.Count} ");
        }

       
    }
}
