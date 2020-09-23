using System;
using System.Diagnostics;

namespace WkhtmlForNetCore.Core
{
    public class HtmlToPdfHelper
    {
        public const string UrlType = "-url";
        
        public const string FileType = "-file";
        
        public const string StringType = "-string";
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pythonExecutableFile">executable python filename (wkhtml plugin)</param>
        /// <param name="htmlSrc">html source</param>
        /// <param name="pdfFileName"></param>
        /// <param name="folder2SavePdfFile"></param>
        /// <param name="srcType"></param>
        /// <returns></returns>
        public static void Run(string pythonExecutableFile, string htmlSrc, string pdfFileName, string folder2SavePdfFile, string srcType = UrlType)
        {
            try
            {
                var start = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"{pythonExecutableFile} {srcType} {htmlSrc} {pdfFileName}.pdf {folder2SavePdfFile} ",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using var process = Process.Start(start);
                if (process == null)
                {
                    throw new Exception("Process not running");
                }

                using var reader = process.StandardOutput;
                process.StandardError.ReadToEnd();
                reader.ReadToEnd();
            }
            catch
            {
                throw new Exception("Process not completed");
            }
            
        }
    }
}