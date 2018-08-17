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
            var doc = await Downloader.GetHtmlDoc("https://www.parimatch.com");
            //var node = doc.DocumentNode;
            //Console.WriteLine(node.InnerHtml); 
            var data = Parser.GetSportLinksHierarchy(doc);
            foreach(var sport in data.Keys)
            {
                foreach (var league in data[sport])
                {
                    var sport_page = await Downloader.GetHtmlDoc("https://www.parimatch.com" + league.link);
                    Parser.getMatchesFromDoc(sport_page);
                }
            }
        }
    }
}
