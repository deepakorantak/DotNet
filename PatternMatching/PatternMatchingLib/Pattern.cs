using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace PatternMatchingLib
{
    public class Pattern
    {
        public String mainPattern { get; set; }
        public String isAdditionPattern { get; set; }
        public String additionPattern { get; set; }
        public String glAccountNumber { get; set; }
        public String codaDescription { get; set; }
    }

    public static class ProcessPatternList
    {
        private static List<Pattern> listofPatterns { get; set; }
        public static List<Pattern> GetPatterns(DataTable confiDataTable)
        {
            listofPatterns = new List<Pattern>();
            return listofPatterns = confiDataTable.AsEnumerable().Select(dr => { return GetPattern(dr); }).ToList();

        }

        private static Pattern GetPattern(DataRow dr)
        {
            return new Pattern
            {
                mainPattern = dr["MAINPATTERN"].ToString(),
                isAdditionPattern = dr["ISADDITIONPATTERN"].ToString(),
                additionPattern = dr["ADDITIONPATTERN"].ToString(),
                glAccountNumber = dr["GLACCOUNTNUMBER"].ToString(),
                codaDescription = dr["CODADESCRIPTION"].ToString()
            };
        }

        public static List<Pattern> GetPatterns(String filePath)
        {
            listofPatterns = new List<Pattern>();
            return listofPatterns = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(s =>
                                {
                                    var str = s.Split(',');
                                    return new Pattern
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
