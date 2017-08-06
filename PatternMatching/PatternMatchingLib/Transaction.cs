using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatchingLib
{
    public class Transaction
    {
        public string id { get; set; }
        public string loadDate{ get; set; }
        public string iban { get; set; }
        public string companyCode { get; set; }
        public string statementNumber { get; set; }
        public string entryDate { get; set; }
        public string valueDate { get; set; }
        public string transactionDescription { get; set; }
        public string amount { get; set; }
        public string glAccountNumber { get; set; }
        public string additionaInfo { get; set; }
        public string codaDescription { get; set; }
    }

    public class TransactionComparer : IEqualityComparer<Transaction>
    {
        public bool Equals(Transaction x, Transaction y)
        {
            return x.id.Equals(y.id);
        }

        public int GetHashCode(Transaction obj)
        {
            return obj.id.GetHashCode();

        }
    }
    public static class ProcessTransactionList
    {
   
        public static List<Transaction> GetTransactions(DataTable sourceDataTable,DataTable accountMapping)
        {
           
            List<AccountMapping> listofAccountMappings = ProcessAccountMapping.GetAccountMappings(accountMapping);
            return  sourceDataTable.AsEnumerable().Select(dr => { return GetTransaction(dr, listofAccountMappings); }).ToList();          
            
        }

        private static Transaction GetTransaction(DataRow dr,List<AccountMapping> listofAccountMappings)
        {
            return new Transaction
            {
                id = dr["ID"].ToString(),
                loadDate = dr["LAADDATUM"].ToString(),
                iban = dr["IBAN"].ToString(),
                companyCode = listofAccountMappings.Where(s => s.iban == dr["IBAN"].ToString()).Select(s => s.companyCode).First(),
                statementNumber = dr["STATEMENT_NUMBER"].ToString(),
                entryDate = dr["ENTRY_DATE"].ToString(),
                valueDate = dr["VALUE_DATE"].ToString(),
                transactionDescription = dr["OMSCHRIJVING"].ToString(),
                amount = dr["AMOUNT"].ToString(),
                additionaInfo = dr["NAAM_TEGENPARTIJ"].ToString(),
                glAccountNumber = "NA",
                codaDescription = ""

            };
        }

        public static List<Transaction> GetTransactions(string sourceFilePath,string accountMappingPath )
        {

            List<AccountMapping> listofAccountMappings = ProcessAccountMapping.GetAccountMappings(accountMappingPath);            
            return  File.ReadAllLines(sourceFilePath)
                .Skip(1)
                .Select(s =>
                            {
                                var str = s.Split(',');
                                return new Transaction
                                {
                                    id = str[0],
                                    loadDate = str[1],
                                    iban = str[2],
                                    companyCode = listofAccountMappings.Where(a => a.iban == str[2]).Select(a => a.companyCode).First(),
                                    statementNumber = str[3],
                                    entryDate = str[4],
                                    valueDate = str[5],
                                    transactionDescription = str[6],
                                    amount = str[7],
                                    additionaInfo = str[8],
                                    glAccountNumber = "NA",
                                    codaDescription = ""
                                    
                                };
                            }
                       ).ToList();

        }
    }

}
