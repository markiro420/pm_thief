using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalUnit0
{
    class Program
    {
        static readonly Stopwatch sw = new Stopwatch();
        static void Main(string[] args)
        {
            DownloaderTest();
            Console.ReadLine();
        }

        private static async void DownloaderTest()
        {
            sw.Start();
            var html = await CrystalGeneric.Downloader.GetHTML("https://www.parimatch.com");
            Console.WriteLine($"Page load time: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            var sportHierarchy = Parser.GetSportHierarchy(html);
            Console.WriteLine($"Total parsing time: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            string data = CrystalGeneric.SerializationSupervisor.Serialize(sportHierarchy);
            Console.WriteLine($"From c# serialization  time: {sw.ElapsedMilliseconds}ms");

            //string guid = Core.FileSupervisor.WriteFile(data);
            //Console.WriteLine(guid);

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
