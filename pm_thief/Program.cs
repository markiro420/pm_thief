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
            var html = await Core.Downloader.GetHTML("https://www.parimatch.com");
            var sportHierarchy = Core.Parser.GetSportHierarchy(html); // пока просто string 

            //foreach(var sport in sportHierarchy.Keys)
            //{
            //    foreach (var league in data[sport])
            //    {
            //        var sport_page = await Core.Downloader.GetHTML("https://www.parimatch.com" + league.link);
            //        Core.Parser.getMatchesFromDoc(sport_page);
            //    }
            //}
        }
    }
}
