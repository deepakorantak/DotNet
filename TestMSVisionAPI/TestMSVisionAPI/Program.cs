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

            string ocrImageFile = "D:\\Deepa\\OCR.JPG";
            string ocrImageLang = "unk";
            string visionAPISubKey = "cd708778b49f4d3e8849f9cae530a928";
            string resultText = VisionAPIFunctions.Dowork(ocrImageFile, ocrImageLang, visionAPISubKey);
            Console.WriteLine(resultText); 
            Console.ReadLine();
        }

      
    }
}
