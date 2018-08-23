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

        public virtual DbSet<Data.League> Leagues { get; set; }
        public virtual DbSet<Data.Sport> Sports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new Configs.LeagueConfig());
            modelBuilder.Configurations.Add(new Configs.SportConfig());
        }

    }

}