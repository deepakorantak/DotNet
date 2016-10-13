using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System.IO;
using System.Activities.Presentation.Metadata;

namespace MSVisionAPI
{
    public class VisionAPIFunctions : IRegisterMetadata
    {

        public static async Task<OcrResults> UploadAndRecognizeImage(string imageFilePath, string language,string SubscriptionKey)
        {

            Console.WriteLine( $"Image File : {imageFilePath}");
            Console.WriteLine($"Langauage : {language}");
            VisionServiceClient VisionServiceClient = new VisionServiceClient(SubscriptionKey);
            Console.WriteLine("VisionServiceClient is created");

            using (Stream imageFileStream = File.OpenRead(imageFilePath))
            {
               
                Console.WriteLine("Calling VisionServiceClient.RecognizeTextAsync()...");
                OcrResults ocrResult = await VisionServiceClient.RecognizeTextAsync(imageFileStream, language);
                LogOcrResults(ocrResult);
                return ocrResult;
            }

             
        }

        public static string Dowork(string ocrImageFile,string ocrImageLang,string visionAPISubKey)
        {

            //string ocrImageFile = "D:\\Deepa\\OCR.JPG";
            //string ocrImageLang = "unk";
            //string visionAPISubKey = "cd708778b49f4d3e8849f9cae530a928";
            Task<OcrResults> res = UploadAndRecognizeImage(ocrImageFile, ocrImageLang, visionAPISubKey);
            return LogOcrResults(res.Result);
        }

        protected static string LogOcrResults(OcrResults results)
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

            return stringBuilder.ToString();
        }

        public void Register()
        {

        }
        

    }
}
