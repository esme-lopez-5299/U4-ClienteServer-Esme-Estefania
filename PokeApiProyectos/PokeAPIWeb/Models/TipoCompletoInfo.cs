using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PokeAPIWeb.Models.TipoCompleto;

namespace PokeAPIWeb.Models
{
    public class TipoCompletoInfo
    {
        public DamageRelations damage_relations { get; set; }
        public List<GameIndice> game_indices { get; set; }
        public Generation2 generation { get; set; }
        public int id { get; set; }
        public MoveDamageClass move_damage_class { get; set; }
        public List<Move> moves { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<Poke> pokemon { get; set; }
    }
}
