using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSVisionAPI;
using Microsoft.ProjectOxford.Vision.Contract;

namespace TestMSVisionAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            Dowork();
            Console.ReadLine();
        }

        public static async Task Dowork()
        {

            string ocrImageFile = "D:\\Deepa\\OCR.JPG";
            string ocrImageLang = "unk";
            string visionAPISubKey = "cd708778b49f4d3e8849f9cae530a928";
            OcrResults res =  await VisionAPIFunctions.UploadAndRecognizeImage(ocrImageFile, ocrImageLang, visionAPISubKey);
            LogOcrResults(res);
        }


        protected static void LogOcrResults(OcrResults results)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (results != null && results.Regions != null)
            {
                stringBuilder.Append("Text: ");
                stringBuilder.AppendLine();
                foreach (var item in results.Regions)
                {
                    foreach (var line in item.Lines)
                    {
                        foreach (var word in line.Words)
                        {
                            stringBuilder.Append(word.Text);
                            stringBuilder.Append(" ");
                        }

                        stringBuilder.AppendLine();
                    }

                    stringBuilder.AppendLine();
                }
            }

            Console.WriteLine(stringBuilder.ToString());
        }


    }
}
