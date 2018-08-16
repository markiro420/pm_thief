using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm_thief
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloaderTest();
            Console.ReadLine();
        }

        private static async void DownloaderTest()
        {
            var doc = await Downloader.GetHtmlDoc("http://ru.elderscrolls.wikia.com/wiki/%D0%9A%D0%BE%D0%BD%D1%81%D0%BE%D0%BB%D1%8C%D0%BD%D1%8B%D0%B5_%D0%BA%D0%BE%D0%BC%D0%B0%D0%BD%D0%B4%D1%8B_(Oblivion)");
            var node = doc.DocumentNode;
            Console.WriteLine(node.InnerHtml); 
        }
    }
}
