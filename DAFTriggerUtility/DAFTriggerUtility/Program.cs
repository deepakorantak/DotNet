using System;
using System.Collections.Generic;
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

            var test = GetDBTableDetails.Create();

            foreach (var item in test)
            {
                foreach (var trig in item.ListTriggerType.Values)
                {
                    var triCreate = trig.TriggerCreateSyntax.Replace("{table}", item.TableName) + "\n" ;
                    //Console.WriteLine(trig.TriggerCreateSyntax);

                    var tricondition = "\n\t"+ trig.TriggerBodyCondition + "\n" ;


                    if (trig.InsertHistorytable == "Yes")
                    {
                        var hist_column_list = item.HistoryColumnList.Aggregate((a,c) => string.Join(",\n\t",a,c));
                        //Console.WriteLine(hist_column_list);

                        var column_list = "NULL,\n\t'update',\n\tOLD." +  item.ColumnList.Aggregate((a, c) => string.Join(",\n\t",a, "OLD." + c));
                      //  Console.WriteLine(column_list);

                        var trihistory = trig.HistoryTableInsert.Replace("{hist_table}", item.HistoryTableName);
                        trihistory = trihistory.Replace("{column_list}", hist_column_list);
                        trihistory = trihistory.Replace("{value_list}", column_list);

                        //Console.WriteLine(trig.HistoryTableInsert);
                        tricondition = tricondition + "\n" + trihistory + "\n";
                    }

                    var tribody= trig.TriggerBodySyntax.Replace("{body}", tricondition);

                    var finalTriggersyntax = triCreate + "\n\n" + tribody;
                    Console.WriteLine(finalTriggersyntax);

                }

            }
        }
    }
}
