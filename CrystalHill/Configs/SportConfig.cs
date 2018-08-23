using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill.Configs
{
    class SportConfig : EntityTypeConfiguration<Data.Sport>
    {
        public SportConfig()
        {
            HasKey(p => p.SportId);
            Property(p => p.SportId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(p => p.Leagues).WithRequired(p => p.Sport);
        }

    }

}
