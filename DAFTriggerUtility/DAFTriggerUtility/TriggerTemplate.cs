using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAFTriggerUtility
{
    public class TriggerTemplate
    {
        public string TriggerCreateSyntax { get; set; }
        public EnumTriggerType TriggerType { get; set; }      
        public string TriggerBodySyntax { get; set; }
        public string TriggerBodyCondition { get; set; }
        public string HistoryTableInsert { get; set; }
        public string InsertHistorytable { get; set; }

        public TriggerTemplate(EnumTriggerType iTriggerType)
        {
           TriggerType = iTriggerType;
        }

    }

    public static class TriggerTemplateCreate
    {
        public static TriggerTemplate Create(EnumTriggerType iTriggerType )
        {

            TriggerTemplate trigTemplate = new TriggerTemplate(iTriggerType);

            string configOption = GetTriggerConfiguration(iTriggerType);

            var doc = XDocument.Load("D:\\Deepa\\Training\\GitHub\\DotNet\\DAFTriggerUtility\\MySqlTrigger.xml");

            var listOfConfiguration = doc.Descendants(configOption);

            trigTemplate.TriggerCreateSyntax = (string)listOfConfiguration.Descendants("TriggerCreateSyntax")
                                                                          .First()
                                                                          .Attribute("syntax");


            trigTemplate.TriggerBodySyntax = (string)listOfConfiguration.Descendants("TriggerBodySyntax")
                                                                         .First()
                                                                         .Attribute("syntax");


            trigTemplate.TriggerBodyCondition = (string)listOfConfiguration.Descendants("TriggerBodyCondition")
                                                                         .First()
                                                                         .Attribute("syntax");

            trigTemplate.InsertHistorytable = (string)listOfConfiguration.Descendants("Historytable")
                                                             .First()
                                                             .Attribute("flag")
                                                             ;

            trigTemplate.HistoryTableInsert = (string)listOfConfiguration.Descendants("Historytable")
                                                 .First()
                                                 .Attribute("syntax")
                                                 ;
            return trigTemplate;

        }

        private static string GetTriggerConfiguration(EnumTriggerType iTriggerType)
        {
            string configOption;
            switch (iTriggerType)
            {
                case EnumTriggerType.RowBeforeInsert:
                    configOption = "RowBeforeInsert";
                    break;
                case EnumTriggerType.RowAfterInsert:
                    configOption = "RowAfterInsert";
                    break;
                case EnumTriggerType.RowBeforeUpdate:
                    configOption = "RowBeforeUpdate";
                    break;
                case EnumTriggerType.RowAfterUpdate:
                    configOption = "RowAfterUpdate";
                    break;
                case EnumTriggerType.RowBeforeDelete:
                    configOption = "RowBeforeDelete";
                    break;
                case EnumTriggerType.RowAfterDelete:
                    configOption = "RowAfterDelete";
                    break;
                case EnumTriggerType.StatementBeforeInsert:
                    configOption = "StatementBeforeInsert";
                    break;
                case EnumTriggerType.StatementAfterInsert:
                    configOption = "StatementAfterInsert";
                    break;
                case EnumTriggerType.StatementBeforeUpdate:
                    configOption = "StatementBeforeUpdate";
                    break;
                case EnumTriggerType.StatementAfterUpdate:
                    configOption = "StatementAfterUpdate";
                    break;
                case EnumTriggerType.StatementBeforeDelete:
                    configOption = "StatementBeforeDelete";
                    break;
                case EnumTriggerType.StatementAfterDelete:
                    configOption = "StatementAfterDelete";
                    break;
                default:
                    configOption = "Invalid";
                    break;
            }

            return configOption;
        }


    }

}
