using Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.ERT.PDFSplit
{
    class Program
    {
        
        private static ContainerAccess Container 
        { 
            get
            {
                ContainerAccess container = new ContainerAccess();
                return container;
            }
        }

        private static AuScGen.PDFOperation.PDFReader PDFReadPlugin
        {
            get
            {
                return Container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            }
        }

        //private static StreamWriter indexFile;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Starting extraction .....");
            Utils.FileSystemUtil fileUtil = new Utils.FileSystemUtil();

            List<Models.PdfFile> files = fileUtil.GetAllFiles;
            //ExtractPages(files.LastOrDefault().SourcePath, files.LastOrDefault().TargetPath + "Page58.pdf", 58, 58);

            foreach(Models.PdfFile file in files)
            {
                int numberOfPages = PDFReadPlugin.GetNumberOfPages(file.SourcePath);

                for (int i = 1; i <= numberOfPages; i++ )
                {
                    string pagePath = string.Format(@"{0}\Page{1}",file.TargetPath,i);
                    Utils.FileSystemUtil.CreateDirectory(pagePath);
                    string targetpdf = string.Format(@"{0}\Page{1}.pdf", pagePath, i);
                    ExtractPages(file.SourcePath, targetpdf, i, i);
                    ExtractText(targetpdf);
                    ExtractXml(targetpdf);                    
                    if(Utils.FileSystemUtil.DeleteSplitAfterExtraction)
                    {
                        DeleteFile(targetpdf);
                    }
                }

                EndOfExtraction(file.TargetPath);
                
                LogIndexFile(Path.GetDirectoryName(file.SourcePath), string.Format("Extracted [{0}/{1}] files: pdf name {2}"
                                                                                , files.IndexOf(file) + 1, files.Count()
                                                                                , Path.GetFileName(file.SourcePath)));
                
            }

            //foreach (string value in PDFRead())
            //{
            //    Console.WriteLine(value);
            //}

            //foreach (Image image in GetImagesFromPdf())
            //{
            //    image.Save("Image_" + Guid.NewGuid() + ".bmp");
            //}

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Extraction complete.....");            
            Console.Read();
            //indexFile.Close();
        }

        private static List<string> PDFRead(string path)
        {
            //ContainerAccess container = new ContainerAccess();
            //AuScGen.PDFOperation.PDFReader pdfReader = container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            string pdfContent = PDFReadPlugin.ExtractTextFromPdf(path);
            List<string> values = pdfContent.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();

            return values;
        }

        private static List<Image> GetImagesFromPdf()
        {
            //ContainerAccess container = new ContainerAccess();
            //AuScGen.PDFOperation.PDFReader pdfReader = container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            List<Image> images = PDFReadPlugin.GetImages(Directory.GetCurrentDirectory() + @"\TestPDF\Test3.pdf");
            return images;
        }

        private static void ExtractPages(string sourcePath, string targetPath, int startPageNumber, int endPageNumber)
        {
            //ContainerAccess container = new ContainerAccess();
            //AuScGen.PDFOperation.PDFReader pdfReader = container.GetPlugin<AuScGen.PDFOperation.PDFReader>();
            PDFReadPlugin.ExtractPages(sourcePath, targetPath, startPageNumber, endPageNumber);          
           
        }         

        private static void ExtractText(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            StreamWriter textfile = File.CreateText(string.Format(@"{0}\{1}.txt",directory,filename));
            List<string> textList = PDFRead(path);
            foreach(string text in textList)
            {
                textfile.WriteLine(text);
            }
            textfile.Close();
        }

        private static void ExtractXml(string targetPdf)
        {
            string directory = Path.GetDirectoryName(targetPdf);
            string filename = Path.GetFileNameWithoutExtension(targetPdf);
            string xmlFileName = string.Format(@"{0}\{1}.xml", directory, filename);
            PDFReadPlugin.ExtractXml(targetPdf,Utils.FileSystemUtil.MergePlainTextInTable);
        }

        private static void EndOfExtraction(string path)
        {
            //string directory = Path.GetDirectoryName(path);
            StreamWriter textfile = File.CreateText(string.Format(@"{0}\completed.txt", path));
        }

        private static void LogIndexFile(string path, string text)
        {
            StreamWriter indexFile;
            if (!File.Exists(string.Format(@"{0}\Index.log", path)))
            {
                 indexFile = File.CreateText(string.Format(@"{0}\Index.log",path));
            }
            else
            {
                indexFile = File.AppendText(string.Format(@"{0}\Index.log",path));
            }
            indexFile.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            indexFile.Close();
        }
        
        private static void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}
