using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAFTriggerUtility
{
    public class DBTable
    {
        public string TableName { get; set; }
        public string HistoryTableName { get; set; }
        public List<string> ColumnList { get; set; }
        public List<string> HistoryColumnList { get; set; }
        public Dictionary<EnumTriggerType,TriggerTemplate> ListTriggerType { get; set; }
        public DBTable()
        {
            //the  defuault values to be configured
            HistoryColumnList = new List<string>() ;
            ColumnList = new List<string>() ;
            ListTriggerType = new Dictionary<EnumTriggerType,TriggerTemplate> ();
        }
    }

    public static class GetDBTableDetails
    {
        
        public static List<DBTable> Create()
        {
            List<DBTable> listOfTable = new List<DBTable>();

            listOfTable = File.ReadAllLines("D:\\Deepa\\Training\\GitHub\\DotNet\\DAFTriggerUtility\\TableList.csv")
                              .Skip(1)
                              .Select(a => ExtractTableDetails(a))
                              .ToList();

            return listOfTable;


        }

        private static  DBTable  ExtractTableDetails(string a)
        {
           
                var row = a.Split(',');
                var tabDetails = new DBTable();
                tabDetails.TableName = row[0];
                tabDetails.HistoryTableName = row[1];
                tabDetails.ColumnList = row[14].Split('|').ToList();
                tabDetails.HistoryColumnList.Add("`history_id`");
                tabDetails.HistoryColumnList.Add("`operation`");
                tabDetails.HistoryColumnList.AddRange(tabDetails.ColumnList);


                if (row[2] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.RowBeforeInsert, TriggerTemplateCreate.Create(EnumTriggerType.RowBeforeInsert));
                }

                if (row[3] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.RowAfterInsert, TriggerTemplateCreate.Create(EnumTriggerType.RowAfterInsert));
                }

                if (row[4] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.RowBeforeUpdate, TriggerTemplateCreate.Create(EnumTriggerType.RowBeforeUpdate));
                }

                if (row[5] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.RowAfterUpdate, TriggerTemplateCreate.Create(EnumTriggerType.RowAfterUpdate));
                }

                if (row[6] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.RowBeforeDelete, TriggerTemplateCreate.Create(EnumTriggerType.RowBeforeDelete));
                }
                if (row[7] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.RowAfterDelete, TriggerTemplateCreate.Create(EnumTriggerType.RowAfterDelete));
                }

                if (row[8] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.StatementBeforeInsert, TriggerTemplateCreate.Create(EnumTriggerType.StatementBeforeInsert));
                }

                if (row[9] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.StatementAfterInsert, TriggerTemplateCreate.Create(EnumTriggerType.StatementAfterInsert));
                }

                if (row[10] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.StatementBeforeUpdate, TriggerTemplateCreate.Create(EnumTriggerType.StatementBeforeUpdate));
                }

                if (row[11] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.StatementAfterUpdate, TriggerTemplateCreate.Create(EnumTriggerType.StatementAfterUpdate));
                }

                if (row[12] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.StatementBeforeDelete, TriggerTemplateCreate.Create(EnumTriggerType.StatementBeforeDelete));
                }
                if (row[13] == "Y")
                {
                    tabDetails.ListTriggerType.Add(EnumTriggerType.StatementAfterDelete, TriggerTemplateCreate.Create(EnumTriggerType.StatementAfterDelete));
                }

                return tabDetails;

           
        }
    }
}
