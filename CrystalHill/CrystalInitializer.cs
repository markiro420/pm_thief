using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill
{
    // MigrateDatabaseToLatestVersion | DropCreateDatabaseIfModelChanges
    class CyrstalInitializer : DropCreateDatabaseIfModelChanges<CrystalVault>
    {
        protected override void Seed(CrystalVault context)
        {
            base.Seed(context);
            //context.Bookies.Add(new Bookie { })
        }
    }
}
