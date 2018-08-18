using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmThief
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
            var doc = await Core.Downloader.GetHtmlDoc("https://www.parimatch.com");

            var html = doc.DocumentNode.OuterHtml;
            var result = Core.Parser.GetSportHierarchy(html);
            Console.WriteLine(result);

            //var data = Core.Parser.GetSportLinksHierarchy(doc);
            //foreach(var sport in data.Keys)
            //{
            //    foreach (var league in data[sport])
            //    {
            //        var sport_page = await Core.Downloader.GetHtmlDoc("https://www.parimatch.com" + league.link);
            //        Core.Parser.getMatchesFromDoc(sport_page);
            //    }
            //}
        }
    }
}
