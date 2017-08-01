using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    public class Transaction
    {
        public string id { get; set; }
        public string laaddatum{ get; set; }
        public string iban { get; set; }
        public string statementNumber { get; set; }
        public string entryDate { get; set; }
        public string valueDate { get; set; }
        public string omschrijving { get; set; }
        public string amount { get; set; }
        public string glAccountNumber { get; set; }
        public string naamTegenpartij { get; set; }
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
        private static List<Transaction> listofTransactions { get; set; }
        public static List<Transaction> GetTransactions(DataTable sourceDataTable)
        {
            listofTransactions = new List<Transaction>();
            return  listofTransactions = sourceDataTable.AsEnumerable().Select(dr => { return GetTransaction(dr); }).ToList();          
            
        }

        private static Transaction GetTransaction(DataRow dr)
        {
            return new Transaction
            {
                id = dr["ID"].ToString(),
                laaddatum = dr["LAADDATUM"].ToString(),
                iban = dr["IBAN"].ToString(),
                statementNumber = dr["STATEMENT_NUMBER"].ToString(),
                entryDate = dr["ENTRY_DATE"].ToString(),
                valueDate = dr["VALUE_DATE"].ToString(),
                omschrijving = dr["OMSCHRIJVING"].ToString(),
                amount = dr["AMOUNT"].ToString(),
                naamTegenpartij = dr["NAAM_TEGENPARTIJ"].ToString()
            };
        }

        public static List<Transaction> GetTransactions(String filePath)
        {
            listofTransactions = new List<Transaction>();
            return listofTransactions = File.ReadAllLines(filePath)
                .Skip(1)
                .Select(s =>
                            {
                                var str = s.Split(',');
                                return new Transaction
                                {
                                    id = str[0],
                                    laaddatum = str[1],
                                    iban = str[2],
                                    statementNumber = str[3],
                                    entryDate = str[4],
                                    valueDate = str[5],
                                    omschrijving = str[6],
                                    amount = str[7],
                                    naamTegenpartij = str[8],
                                    glAccountNumber = "NA"

                                };
                            }
                       ).ToList();

        }
    }

}
