using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill.Data
{
    public class Sport
    {
        public Sport()
        {
            Leagues = new HashSet<League>();
        }

        public Guid SportId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
        public DateTime UpdTime { get; set; }
    }

}
