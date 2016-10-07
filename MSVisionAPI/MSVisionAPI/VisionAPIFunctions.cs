using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System.IO;

namespace MSVisionAPI
{
    public class VisionAPIFunctions
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
                return ocrResult;
            }

             
        }


    

        
     

    }
}
