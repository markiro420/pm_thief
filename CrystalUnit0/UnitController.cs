using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalUnit0
{
    public class UnitController : CrystalGeneric.UnitControllerBase
    {
        private UnitController() { }

        static readonly Lazy<UnitController>  instance = new Lazy<UnitController>(() => new UnitController());

        public static UnitController Controller { get => instance.Value; }

        int refCount = 0;

        protected override void Refresh()
        {
            refCount++;
            Console.WriteLine(refCount.ToString());
        }
    }
}
