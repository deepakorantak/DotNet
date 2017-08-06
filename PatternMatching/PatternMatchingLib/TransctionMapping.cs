using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace PatternMatchingLib
{
    public class TransctionMapping
    {
        public String mainPattern { get; set; }
        public String isAdditionPattern { get; set; }
        public String additionPattern { get; set; }
        public String glAccountNumber { get; set; }
        public String codaDescription { get; set; }
    }

    public static class ProcessTransactionMappingList
    {
        private static List<TransctionMapping> listofPatterns { get; set; }
        public static List<TransctionMapping> GetPatterns(DataTable confiDataTable)
        {
            listofPatterns = new List<TransctionMapping>();
            return listofPatterns = confiDataTable.AsEnumerable().Select(dr => { return GetTransactionMapping(dr); }).ToList();

        }

        private static TransctionMapping GetTransactionMapping(DataRow dr)
        {
            return new TransctionMapping
            {
                mainPattern = dr["MAINPATTERN"].ToString(),
                isAdditionPattern = dr["ISADDITIONPATTERN"].ToString(),
                additionPattern = dr["ADDITIONPATTERN"].ToString(),
                glAccountNumber = dr["GLACCOUNTNUMBER"].ToString(),
                codaDescription = dr["CODADESCRIPTION"].ToString()
            };
        }

        public static List<TransctionMapping> GetTransactionMapping(String filePath)
        {
            listofPatterns = new List<TransctionMapping>();
            return listofPatterns = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(s =>
                                {
                                    var str = s.Split(',');
                                    return new TransctionMapping
                                    {
                                        mainPattern = str[0],
                                        isAdditionPattern = str[1],
                                        additionPattern = str[2],
                                        glAccountNumber = str[3],
                                        codaDescription = str[4]
                                    };
                                }
                       ).ToList();

        }

    }
}
