using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace PatternMatching
{
    public class AccountMapping
    {
        public string iban { get; set; }
        public string companyCode { get; set; }       

    }

    public static class ProcessAccountMapping
    {
        private static List<AccountMapping> listofAccountMapping;

        public static List<AccountMapping> GetAccountMappings(DataTable sourceDataTable)
        {
            listofAccountMapping = new List<AccountMapping>();
            return listofAccountMapping = sourceDataTable.AsEnumerable().Select(dr => { return GetAccountMappings(dr); }).ToList();

        }

        private static AccountMapping GetAccountMappings(DataRow dr)
        {
            return new AccountMapping
            {
                iban = dr["Rekening"].ToString(),
                companyCode = dr["bedrijf"].ToString()
            };
        }

        public static List<AccountMapping> GetAccountMappings(String filePath)
        {
            listofAccountMapping = new List<AccountMapping>();
            return listofAccountMapping = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(s =>
                            {
                                var str = s.Split(',');
                                return new AccountMapping
                                {
                                    iban = str[0],
                                    companyCode = str[1]
                                };
                            }
                       ).ToList();

        }

    }


}
