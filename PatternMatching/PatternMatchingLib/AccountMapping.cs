using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace PatternMatchingLib
{
    public class AccountMapping
    {
        public string iban { get; set; }
        public string companyCode { get; set; }       

    }

    public static class ProcessAccountMapping
    {
      
        public static List<AccountMapping> GetAccountMappings(DataTable sourceDataTable)
        {
           
            return sourceDataTable.AsEnumerable().Select(dr => { return GetAccountMappings(dr); }).ToList();

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
           
            return  File.ReadAllLines(filePath)
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
