using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = CrystalHill.TheVault)
            {
                // Model testing code here.

                Console.WriteLine("Starting");
                var sport = new Data.Sport { Name = "football" };
                var league1 = new Data.League { Sport = sport, LeagueName = "Canada league", Link = "https://google.com", UpdTime = DateTime.Now };
                var league2 = new Data.League { LeagueName = "Australia league", Link = "https://bing.com", UpdTime = DateTime.Now };
                sport.Leagues.Add(league2);

                context.Leagues.Add(league1);
                context.Sports.Add(sport);
                context.SaveChanges();
                Console.WriteLine("Saved.");
                foreach (var s in context.Sports)
                {
                    Console.WriteLine(s.Name);
                    foreach (var l in s.Leagues)
                    {
                        Console.WriteLine($"\t{l.LeagueName}");
                    }
                }
                Console.ReadLine();
            }

        }

    }

}
