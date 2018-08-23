using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalHill.Data
{
    public class League
    {
        public Guid LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string Link { get; set; }
        public Sport Sport { get; set; }
        public DateTime UpdTime { get; set; }
    }

}
