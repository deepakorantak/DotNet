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
        public OutArgument<DataTable> mappedTransactionDataTable { get; set; }


        [Category("Output")]
        public OutArgument<List<Transaction>> mappedTransactionList { get; set; }
       
        [Category("Output")]
        [RequiredArgument]
        public OutArgument<DataTable> mappedMacroDataTable { get; set; }

        List<Transaction> sourceTrans { get; set; }
        List<TransctionMapping> patternConfig { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            var sourceDT = sourceDataTable.Get(context);
            var accountMappingDT = accountMappingDataTable.Get(context);
            var transactionMappingDT = transactionMappingDataTable.Get(context);
            var resultTRans = Process(sourceDT, accountMappingDT, transactionMappingDT);
            mappedTransactionList.Set(context, resultTRans);
            mappedTransactionDataTable.Set(context, TransformToDataTable(resultTRans));
            mappedMacroDataTable.Set(context,TransformToMacroDataTable(resultTRans));

        }

        public List<Transaction> Process(string sourceTransactiosPath,string accountMappingPath,string transactionmMappingPath)
        {
            sourceTrans = ProcessTransactionList.GetTransactions(sourceTransactiosPath, accountMappingPath);
            patternConfig = ProcessTransactionMappingList.GetTransactionMapping(transactionmMappingPath);
            return  GetFinalTransactions();         

        }

        public List<Transaction> Process(DataTable sourceTransactions, DataTable accountMapping,DataTable transactionMapping)
        {

            sourceTrans = ProcessTransactionList.GetTransactions(sourceTransactions, accountMapping);
            patternConfig = ProcessTransactionMappingList.GetPatterns(transactionMapping);

           return  GetFinalTransactions();           
        }

        private  List<Transaction> GetFinalTransactions()
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

            Console.WriteLine("Process completed");
            return sourceTrans;
        }

        private  IEnumerable<Transaction> MatchingBasicPattern(TransctionMapping p)
        {
            var regex = new Regex(p.mainPattern);
            return sourceTrans.Where(s => regex.IsMatch(s.transactionDescription.ToLower()))
                               .Select(s => new Transaction
                               {
                                   id = s.id,
                                   loadDate = s.loadDate,
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
 
        private  IEnumerable<Transaction> MatchingAdditionPattern(TransctionMapping p)
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
                                  loadDate = s.loadDate,
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

        private  IEnumerable<Transaction> MatchingAFRPattern(TransctionMapping p)
        {
            var regexMain = new Regex(p.mainPattern);

            return sourceTrans.Where(s => regexMain.IsMatch(s.transactionDescription.ToLower()))
                              .Select(s => new Transaction
                              {
                                  id = s.id,
                                  loadDate = s.loadDate,
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

        private  string GetAccount(string inputString, string matchingCode)
        {

            var startindex = inputString.IndexOf(matchingCode, 0) + matchingCode.Count();
            var endindex = inputString.IndexOf(" ", startindex + 2);
            var numberChars = ((endindex - startindex) < 0) ? inputString.Length - startindex : endindex - startindex;
            var res = inputString.Substring(startindex, numberChars).Trim().Replace(":", "");

            return res;
        }

        private  string GetCODADescription(string config, string omschrijving)
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

        public  DataTable TransformToDataTable(List<Transaction> listTran)
        {

            DataTable tempTable = new DataTable();
            tempTable.Columns.Add("id", typeof(string));
            tempTable.Columns.Add("loadDate", typeof(string));
            tempTable.Columns.Add("iban", typeof(string));
            tempTable.Columns.Add("companyCode", typeof(string));
            tempTable.Columns.Add("fixedGLAccountNumber", typeof(string));
            tempTable.Columns.Add("documentCode", typeof(string));
            tempTable.Columns.Add("statementNumber", typeof(string));
            tempTable.Columns.Add("entryDate", typeof(string));
            tempTable.Columns.Add("valueDate", typeof(string));
            tempTable.Columns.Add("transactionDescription", typeof(string));
            tempTable.Columns.Add("amount", typeof(string));
            tempTable.Columns.Add("glAccountNumber", typeof(string));
            tempTable.Columns.Add("additionaInfo", typeof(string));
            tempTable.Columns.Add("codaDescription", typeof(string));
            listTran.ForEach(s =>
                                    {
                                        var dr = tempTable.NewRow();
                                        dr["id"] = s.id; 
                                        dr["loadDate"] = s.loadDate; 
                                        dr["iban"] = s.iban; 
                                        dr["companyCode"] = s.companyCode;
                                        dr["fixedGLAccountNumber"] = s.fixedGLAccountNumber;
                                        dr["documentCode"] = s.documentCode;
                                        dr["statementNumber"] = s.statementNumber;
                                        dr["entryDate"] = s.entryDate; 
                                        dr["valueDate"] = s.valueDate; 
                                        dr["transactionDescription"] = s.transactionDescription;
                                        dr["amount"] = s.amount; ;
                                        dr["glAccountNumber"] = s.glAccountNumber ;
                                        dr["additionaInfo"] = s.additionaInfo ;
                                        dr["codaDescription"] = s.codaDescription ;
                                        tempTable.Rows.Add(dr);
                                        tempTable.AcceptChanges();
                                    }
                                );

            return tempTable;
        }

        public DataTable TransformToMacroDataTable(List<Transaction> listTran)
        {

            DataTable tempTable = new DataTable();
            tempTable.Columns.Add("iban", typeof(string));
            tempTable.Columns.Add("colJpnr", typeof(string));
            tempTable.Columns.Add("colDocnr", typeof(string));
            tempTable.Columns.Add("colBedrijf", typeof(string));
            tempTable.Columns.Add("colDocdd", typeof(string));
            tempTable.Columns.Add("colJaar", typeof(string));
            tempTable.Columns.Add("colPeriode", typeof(string));
            tempTable.Columns.Add("colAutoriserendGebruiker", typeof(string));
            tempTable.Columns.Add("colIntercomp", typeof(string));
            tempTable.Columns.Add("colRekeningcode", typeof(string));
            tempTable.Columns.Add("colBedreg", typeof(string));
            tempTable.Columns.Add("colOmschrijving", typeof(string));
            listTran.ForEach(s =>
            {
                var dr = tempTable.NewRow();
                dr["iban"] = s.iban;
                dr["colJpnr"] = "1";
                dr["colDocnr"] = s.entryDate.Substring(s.entryDate.LastIndexOf("/")+1,4) + s.statementNumber + "0";
                dr["colBedrijf"] = s.companyCode;
                dr["colDocdd"] = s.entryDate;
                dr["colJaar"] = s.valueDate.Substring(s.valueDate.LastIndexOf("/") + 1,4);
                dr["colPeriode"] = s.valueDate.Substring(s.valueDate.IndexOf("/")+1,s.valueDate.LastIndexOf("/")-s.valueDate.IndexOf("/")-1);
                dr["colAutoriserendGebruiker"] = "";
                dr["colIntercomp"] = "";
                dr["colRekeningcode"] = s.glAccountNumber;
                var amt = Decimal.Parse(s.amount, System.Globalization.NumberStyles.AllowParentheses |
                                                 System.Globalization.NumberStyles.AllowLeadingWhite |
                                                 System.Globalization.NumberStyles.AllowTrailingWhite |
                                                 System.Globalization.NumberStyles.AllowThousands |
                                                 System.Globalization.NumberStyles.AllowDecimalPoint |
                                                 System.Globalization.NumberStyles.AllowLeadingSign );
                dr["colBedreg"] = amt *-1 ;
                dr["colOmschrijving"] = s.codaDescription;
                tempTable.Rows.Add(dr);
                tempTable.AcceptChanges();
            }
                                );

            return tempTable;
        }

    }
}
