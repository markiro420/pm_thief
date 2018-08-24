using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalUnit0
{
    using CrystalHill;
    using System.IO;
    using System.Reflection;

    class Program
    {
        static readonly Stopwatch sw = new Stopwatch();
        static void Main(string[] args)
        {
            using (var context = CrystalHill.TheVault)
            {
                foreach (var s in context.Sports)
                {
                    Console.WriteLine(s.Name);
                    foreach (var l in s.Leagues)
                    {
                        Console.WriteLine($"\t{l.LeagueName}");
                    }
                }
            }

            //Assembly thisAssembly = Assembly.GetExecutingAssembly();
            //Console.WriteLine("Name: " + thisAssembly.GetName().Name);
            //Console.WriteLine("Location: " + thisAssembly.Location);
            //string codebase = thisAssembly.CodeBase;
            //UriBuilder uri = new UriBuilder(codebase);
            //string path = Uri.UnescapeDataString(uri.Path);
            //string dirctory = Path.GetDirectoryName(path);
            //Console.WriteLine(dirctory);

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
