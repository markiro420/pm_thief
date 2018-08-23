namespace CrystalHill
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CrystalVault : DbContext
    {
        public CrystalVault() : base("name=CrystalVault")
        {
        }

    }

}