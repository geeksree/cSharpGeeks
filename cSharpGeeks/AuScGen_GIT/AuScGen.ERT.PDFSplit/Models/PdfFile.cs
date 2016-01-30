using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.ERT.PDFSplit.Models
{
    public class PdfFile
    {
        public PdfFile(string source, string target)
        {
            SourcePath = source;
            TargetPath = target;
        }

        public string SourcePath { get; set; }

        public string TargetPath { get; set; }
    }
}
