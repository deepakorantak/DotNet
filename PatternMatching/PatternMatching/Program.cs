﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace PatternMatching
{
    public class Program
    {
       static List<Transaction> sourceTrans;
       static List<Pattern> patternConfig;
        static void Main(string[] args)
        {
            sourceTrans = ProcessTransactionList.GetTransactions("D:\\Deepa\\Projects\\VGZ\\Robot\\output\\optransactions.csv");
            patternConfig = ProcessPatternList.GetPatterns("D:\\Deepa\\Projects\\VGZ\\Robot\\input\\transactionMapping.csv");

            Process();

            //Console.WriteLine("Completed");
         


        }

        static void Process()
        {


            var matchedList = patternConfig.Where(p => p.isAdditionPattern == "NA")
                                                  .SelectMany(p => { return MatchingBasicPattern(p); })
                                                  .ToList();

            var notmatchedList = sourceTrans.Except(matchedList,new TransactionComparer()).ToList();
            sourceTrans =  notmatchedList.Union(matchedList).ToList();

            matchedList = patternConfig.Where(p => p.isAdditionPattern == "Add")
                                      .SelectMany(p => { return MatchingAdditionPattern(p); })
                                      .ToList();

            notmatchedList = sourceTrans.Except(matchedList, new TransactionComparer()).ToList();
            sourceTrans = notmatchedList.Union(matchedList).ToList();

            using (var file = File.CreateText("D:\\Deepa\\Projects\\VGZ\\Robot\\output\\maptransactions.csv"))
            {

                file.WriteLine("id|load_date|iban|statement_numbe|entry_date|value_date|glaccount|amount|remarks|additional");
                sourceTrans.ForEach(t =>  file.WriteLine(string.Join("|", new[] {t.id,t.laaddatum,t.iban,t.statementNumber,t.entryDate,
                                                                                 t.valueDate,t.glAccountNumber,t.amount,t.omschrijving,t.naamTegenpartij })));
              
            }

            Console.WriteLine("Process completed");
        }

        private static IEnumerable<Transaction> MatchingBasicPattern(Pattern p)
        {
            var regex = new Regex(p.mainPattern);
            return  sourceTrans.Where(s => regex.IsMatch(s.omschrijving.ToLower()))
                               .Select(s => new Transaction
                                            {
                                                id = s.id,
                                                laaddatum = s.laaddatum,
                                                iban = s.iban,
                                                statementNumber = s.statementNumber,
                                                entryDate = s.entryDate,
                                                valueDate = s.valueDate,
                                                omschrijving = s.omschrijving,
                                                amount = s.amount,
                                                naamTegenpartij = s.naamTegenpartij,
                                                glAccountNumber = p.glAccountNumber
                                            }
                                );

        }


        private static IEnumerable<Transaction> MatchingAdditionPattern(Pattern p)
        {
            var regexMain = new Regex(p.mainPattern);
            var regexAdd = new Regex(p.additionPattern);
            return sourceTrans.Where(s => regexMain.IsMatch(s.omschrijving.ToLower()) &&
                                          regexAdd.IsMatch(s.naamTegenpartij.ToLower()) &&
                                          s.glAccountNumber == "NA"
                                    )
                              .Select(s => new Transaction
                                                {
                                                    id = s.id,
                                                    laaddatum = s.laaddatum,
                                                    iban = s.iban,
                                                    statementNumber = s.statementNumber,
                                                    entryDate = s.entryDate,
                                                    valueDate = s.valueDate,
                                                    omschrijving = s.omschrijving,
                                                    amount = s.amount,
                                                    naamTegenpartij = s.naamTegenpartij,
                                                    glAccountNumber = p.glAccountNumber
                                                }
                                    );
        }
    }
}