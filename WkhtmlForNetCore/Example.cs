using WkhtmlForNetCore.Core;

namespace WkhtmlForNetCore
{
    public class Example
    {
        public static void Pdf()
        {
            // By url
            HtmlToPdfHelper.Run("C:\\WkhtmlForNetCore\\index.py", "https://google.com", "google", "pdfFolder");
            
            // By file
            HtmlToPdfHelper.Run("C:\\WkhtmlForNetCore\\index.py", "../pdfContent.html", "pdfContent", "pdfFolder");
            
            // By string
            HtmlToPdfHelper.Run("C:\\WkhtmlForNetCore\\index.py", "<h1>test testov</h1>", "content", "pdfFolder");
        }
    }
}