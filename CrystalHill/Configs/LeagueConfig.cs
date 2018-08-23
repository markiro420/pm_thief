using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill.Configs
{
    class LeagueConfig : EntityTypeConfiguration<Data.League>
    {
        public LeagueConfig()
        {
            HasKey(p => p.LeagueId);
            Property(p => p.LeagueId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }

}
