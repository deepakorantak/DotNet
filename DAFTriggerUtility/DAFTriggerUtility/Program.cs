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
                    trig.TriggerCreateSyntax = trig.TriggerCreateSyntax.Replace("{table}", item.TableName) ;
                    //Console.WriteLine(trig.TriggerCreateSyntax);

                    var tribody =   "\n" + trig.TriggerBodyCondition + "\n" ;


                    if (trig.IsHistorytable == "Yes")
                    {
                        var hist_column_list = item.HistoryColumnList.Aggregate((a,c) => string.Join(",\n",a,c));
                        //Console.WriteLine(hist_column_list);

                        var column_list = "OLD." +  item.ColumnList.Aggregate((a, c) => string.Join(",\n",a, "OLD." + c));
                      //  Console.WriteLine(column_list);

                        trig.HistoryTableInsert =  trig.HistoryTableInsert.Replace("{hist_table}", item.HistoryTableName);
                        trig.HistoryTableInsert =  trig.HistoryTableInsert.Replace("{column_list}", hist_column_list);
                        trig.HistoryTableInsert =  trig.HistoryTableInsert.Replace("{value_list}", column_list);

                        //Console.WriteLine(trig.HistoryTableInsert);
                        tribody = tribody + "\n" + trig.HistoryTableInsert + "\n";


                    }

                    trig.TriggerBodySyntax = trig.TriggerBodySyntax.Replace("{body}", tribody);

                    var finalTriggersyntax = trig.TriggerCreateSyntax + "\n\n" +  trig.TriggerBodySyntax;
                    Console.WriteLine(finalTriggersyntax);

                }

            }
        }
    }
}
