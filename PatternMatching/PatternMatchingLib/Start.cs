using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Activities;
using System.ComponentModel;

namespace PatternMatchingLib
{
    public  class Start:CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> sourceDataTable { get; set; }
        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> accountMappingDataTable { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<DataTable> transactionMappingDataTable { get; set; }

        [Category("Output")]        
        public OutArgument<List<Transaction>> mappedTransactionList { get; set; }


        static List<Transaction> sourceTrans;
        static List<Pattern> patternConfig;

        protected override void Execute(CodeActivityContext context)
        {
            var sourceDT = sourceDataTable.Get(context);
            var accountMappingDT = accountMappingDataTable.Get(context);
            var transactionMappingDT = transactionMappingDataTable.Get(context);
            mappedTransactionList.Set(context, Process(sourceDT, accountMappingDT, transactionMappingDT));
           
        }

        public static List<Transaction> Process(string sourcePath,string accountMappingPath,string transactionmMappingPath)
        {
            sourceTrans = ProcessTransactionList.GetTransactions(sourcePath, accountMappingPath);
            patternConfig = ProcessPatternList.GetPatterns(transactionmMappingPath);

            return GetFinalTransactions();

        }

        public static List<Transaction> Process(DataTable sourceTransactions, DataTable accountMapping,DataTable transactionMapping)
        {

            sourceTrans = ProcessTransactionList.GetTransactions(sourceTransactions, accountMapping);
            patternConfig = ProcessPatternList.GetPatterns(transactionMapping);

            return GetFinalTransactions();
        }

        private static List<Transaction> GetFinalTransactions()
        {
            var matchedList = patternConfig.Where(p => p.isAdditionPattern == "NA")
                                                  .SelectMany(p => { return MatchingBasicPattern(p); })
                                                  .ToList();

            var notmatchedList = sourceTrans.Except(matchedList, new TransactionComparer()).ToList();
            sourceTrans = notmatchedList.Union(matchedList).ToList();

            matchedList = patternConfig.Where(p => p.isAdditionPattern == "Add")
                                      .SelectMany(p => { return MatchingAdditionPattern(p); })
                                      .ToList();

            notmatchedList = sourceTrans.Except(matchedList, new TransactionComparer()).ToList();
            sourceTrans = notmatchedList.Union(matchedList).ToList();

            matchedList = patternConfig.Where(p => p.isAdditionPattern == "AFR")
                          .SelectMany(p => { return MatchingAFRPattern(p); })
                          .ToList();

            notmatchedList = sourceTrans.Except(matchedList, new TransactionComparer()).ToList();
            sourceTrans = notmatchedList.Union(matchedList).ToList();

            using (var file = File.CreateText("D:\\Deepa\\Projects\\VGZ\\Robot\\output\\maptransactions.csv"))
            {

                file.WriteLine("id|load_date|iban|companycode|statement_numbe|entry_date|value_date|glaccount|amount|codadesc|remarks|additional");
                sourceTrans.ForEach(t => file.WriteLine(string.Join("|", new[] {t.id,t.load_date,t.iban,t.companyCode,t.statementNumber,t.entryDate,
                                                                                 t.valueDate,t.glAccountNumber,t.amount,t.codaDescription,t.transactionDescription,t.additionaInfo })));

            }

            Console.WriteLine("Process completed");
            return sourceTrans;
        }

        private static IEnumerable<Transaction> MatchingBasicPattern(Pattern p)
        {
            var regex = new Regex(p.mainPattern);
            return sourceTrans.Where(s => regex.IsMatch(s.transactionDescription.ToLower()))
                               .Select(s => new Transaction
                               {
                                   id = s.id,
                                   load_date = s.load_date,
                                   iban = s.iban,
                                   statementNumber = s.statementNumber,
                                   entryDate = s.entryDate,
                                   valueDate = s.valueDate,
                                   transactionDescription = s.transactionDescription,
                                   amount = s.amount,
                                   additionaInfo = s.additionaInfo,
                                   glAccountNumber = p.glAccountNumber,
                                   companyCode = s.companyCode,
                                   codaDescription = GetCODADescription(p.codaDescription, s.transactionDescription)

                               }
                                );
        }
 
        private static IEnumerable<Transaction> MatchingAdditionPattern(Pattern p)
        {
            var regexMain = new Regex(p.mainPattern);
            var regexAdd = new Regex(p.additionPattern);
            return sourceTrans.Where(s => regexMain.IsMatch(s.transactionDescription.ToLower()) &&
                                          regexAdd.IsMatch(s.additionaInfo.ToLower()) &&
                                          s.glAccountNumber == "NA"
                                    )
                              .Select(s => new Transaction
                              {
                                  id = s.id,
                                  load_date = s.load_date,
                                  iban = s.iban,
                                  statementNumber = s.statementNumber,
                                  entryDate = s.entryDate,
                                  valueDate = s.valueDate,
                                  transactionDescription = s.transactionDescription,
                                  amount = s.amount,
                                  additionaInfo = s.additionaInfo,
                                  glAccountNumber = p.glAccountNumber,
                                  companyCode = s.companyCode,
                                  codaDescription = GetCODADescription(p.codaDescription, s.transactionDescription)
                              }
                                    );
        }

        private static IEnumerable<Transaction> MatchingAFRPattern(Pattern p)
        {
            var regexMain = new Regex(p.mainPattern);

            return sourceTrans.Where(s => regexMain.IsMatch(s.transactionDescription.ToLower()))
                              .Select(s => new Transaction
                              {
                                  id = s.id,
                                  load_date = s.load_date,
                                  iban = s.iban,
                                  statementNumber = s.statementNumber,
                                  entryDate = s.entryDate,
                                  valueDate = s.valueDate,
                                  transactionDescription = s.transactionDescription,
                                  amount = s.amount,
                                  additionaInfo = s.additionaInfo,
                                  glAccountNumber = GetAccount(s.transactionDescription, " " + s.companyCode),
                                  companyCode = s.companyCode,
                                  codaDescription = GetCODADescription(p.codaDescription, s.transactionDescription)
                              }
                                    );
        }

        private static string GetAccount(string inputString, string matchingCode)
        {

            var startindex = inputString.IndexOf(matchingCode, 0) + matchingCode.Count();
            var endindex = inputString.IndexOf(" ", startindex + 2);
            var numberChars = ((endindex - startindex) < 0) ? inputString.Length - startindex : endindex - startindex;
            var res = inputString.Substring(startindex, numberChars).Trim().Replace(":", "");

            return res;
        }

        private static string GetCODADescription(string config, string omschrijving)
        {

            if (config.Contains("OMSCHRIJVING"))
            {
                var s = config.Split('|');
                var numChars = Int32.Parse(s[1].Replace("]",""));
                var length = ( numChars > omschrijving.Length) ? omschrijving.Length : numChars ;
                var res = omschrijving.Substring(0,length);
                return res;
            };

            if (config.Contains("[MM YYYY]"))
            {
                return config.Replace("[MM YYYY]", DateTime.Now.Month.ToString() + " " + DateTime.Now.Year.ToString());
            };

            return config;
        }


    }
}
