using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill
{
    class CrystalHill
    {

        public CrystalHill()
        {
            Database.SetInitializer(new CyrstalInitializer());
        }
    }
}
