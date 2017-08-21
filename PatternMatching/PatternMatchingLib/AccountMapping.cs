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
        public string fixedGLAccountNumber { get; set; }
        public string documentCode { get; set; }

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
                companyCode = dr["bedrijf"].ToString(),
                fixedGLAccountNumber = dr["glaccount"].ToString(),
                documentCode = dr["documentcode"].ToString()
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
                                    companyCode = str[1],
                                    fixedGLAccountNumber = str[2],
                                    documentCode = str[3]
                                };
                            }
                       ).ToList();

        }

    }


}
