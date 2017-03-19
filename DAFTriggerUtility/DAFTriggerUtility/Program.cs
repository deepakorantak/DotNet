using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAFTriggerUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get list of tables for which trigger are to be generated
            var ListOfTables = DBTableDetailList.Create();

            var trigOutPutPath = ConfigurationManager.AppSettings["TriggerOutPutPath"];

            foreach (var tab in ListOfTables)
            {
                var finalTriggersyntax = "";
                //for each table create syntax for triggers applicable
                foreach (var trig in tab.ListTriggerType.Values)
                {
                    // Create trigger syntax
                    var triCreate = trig.TriggerCreateSyntax.Replace("{table}", tab.TableName) ;
                  
                    // Trigger body to contain any condition and/or history table insert
                    var tricondition =  trig.TriggerBodyCondition  ;

                    if (trig.InsertHistorytable == "Yes")
                    {
                        var trihistory = BuildHistTableClause(tab, trig);
                        tricondition = tricondition + trihistory;
                    }

                    //Create the trigger body 
                    var tribody = trig.TriggerBodySyntax.Replace("{body}", tricondition);

                    //Create the complete trigger syntax
                    finalTriggersyntax += triCreate + tribody;

                    //Finally replace placeholders for new line and tab in the trigger syntax
                    finalTriggersyntax = finalTriggersyntax.Replace("{t}", "\t");
                    finalTriggersyntax = finalTriggersyntax.Replace("{n}", "\n");                   
                    //Console.WriteLine(finalTriggersyntax);
                }

                File.WriteAllText(trigOutPutPath + "trg_" + tab.TableName + ".sql", finalTriggersyntax);

            }
        }

        private static string BuildHistTableClause(DBTable tab, TriggerTemplate trig)
        {
            // Generally column list in history is replica of main table + few additions
            // Concatinate the columns list with "," sperator
            var hist_column_list = tab.ColumnList.Aggregate((a, c) => string.Join(",\n\t\t", a, c));

            // Create value list with "," sperator. Depending upon the trigger type  
            // The main table values are accessed via OLD or NEW qualifier
            var value_column_list = trig.HistoryTablequalifier + "." + tab.ColumnList.Aggregate((a, c) => string.Join(",\n\t\t", a, trig.HistoryTablequalifier + "." + c));

            //Replace the history table insert for actual history table, column list and value list
            var trihistory = trig.HistoryTableInsert.Replace("{hist_table}", tab.HistoryTableName);
            trihistory = trihistory.Replace("{column_list}", hist_column_list);
            trihistory = trihistory.Replace("{value_list}", value_column_list);

            //Append the history insert to trigger condition
           
            return trihistory;
        }
    }
}
