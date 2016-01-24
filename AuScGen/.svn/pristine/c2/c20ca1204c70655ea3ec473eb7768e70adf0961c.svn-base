using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuScGen.FunctionalTest;
using UIAccess;
using Framework;
using System.Drawing;

namespace TestApp
{
    class Program : TestBase
    {
        static void Main(string[] args)
        {
            ExtractPages(Directory.GetCurrentDirectory() + @"\TestPDF\Test3.pdf", Directory.GetCurrentDirectory() + @"\TestPDF\Page58.pdf", 58, 58);

            foreach (string value in PDFRead())
            {
                Console.WriteLine(value);
            }

            foreach (Image image in GetImagesFromPdf())
            {
                image.Save("Image_" + Guid.NewGuid() + ".bmp");
            }
                        
            Console.Read();
        }
        
        public static List<string> PDFRead()
        {
            ContainerAccess container = new ContainerAccess();
            AuScGen.PDFOperation.PDFReader pdfReader = container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            string pdfContent = pdfReader.ExtractTextFromPdf(Directory.GetCurrentDirectory() + @"\TestPDF\Test3.pdf");
            List<string> values = pdfContent.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();

            return values;
        }

        public static List<Image> GetImagesFromPdf()
        {
            ContainerAccess container = new ContainerAccess();
            AuScGen.PDFOperation.PDFReader pdfReader = container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            List<Image> images = pdfReader.GetImages(Directory.GetCurrentDirectory() + @"\TestPDF\Test3.pdf");
            return images;
        }

        public static void ExtractPages(string sourcePath, string targetPath, int startPageNumber, int endPageNumber)
        {
            ContainerAccess container = new ContainerAccess();
            AuScGen.PDFOperation.PDFReader pdfReader = container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            pdfReader.ExtractPages(sourcePath, targetPath, startPageNumber, endPageNumber);
        }
        

    }

    
}
