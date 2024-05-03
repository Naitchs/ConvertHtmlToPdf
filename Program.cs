using System;
using PuppeteerSharp;
using System.Threading.Tasks;

namespace WebsiteToPdf
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the URL to convert to PDF:");
            string url = Console.ReadLine();

            await ConvertHtmlToPdf(url);

            Console.WriteLine("Conversion complete.");
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        static async Task ConvertHtmlToPdf(string url)
        {
            await new BrowserFetcher().DownloadAsync();

            using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(url);

                string pdfPath = $"output.pdf";
                await page.PdfAsync(pdfPath);
                Console.WriteLine($"PDF saved to: {pdfPath}");
            }
        }
    }
}
