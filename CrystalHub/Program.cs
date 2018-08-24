using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrystalHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var cller1 = CrystalUnit0.UnitController.Controller;
            //var cller2 = new CrystalUnit0.UnitController(); // now singleton
            cller1.UpdSpan = TimeSpan.FromMilliseconds(100);
            //Task.Run((Action)cller.Run);
            cller1.RunAsync();
            //cller2.RunAsync();
            Console.WriteLine("OmegaLul1");
            Thread.Sleep(3000);
            Console.WriteLine("OmegaLul2");
            cller1.Break();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
