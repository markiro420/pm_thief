using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill
{
    public static class CrystalHill
    {
        public static CrystalVault TheVault { get { return new CrystalVault(); } }
        static CrystalHill()
        {
            Database.SetInitializer(new CyrstalInitializer());
        }

    }

}
