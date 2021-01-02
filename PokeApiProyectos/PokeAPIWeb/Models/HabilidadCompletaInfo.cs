using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PokeAPIWeb.Models.HabilidadCompleta;
using Pokemon = PokeAPIWeb.Models.HabilidadCompleta.Pokemon1;

namespace PokeAPIWeb.Models
{
    public class HabilidadCompletaInfo
    {
        public List<object> effect_changes { get; set; }
        public List<EffectEntry> effect_entries { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public Generation generation { get; set; }
        public int id { get; set; }
        public bool is_main_series { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<Pokemon1> pokemon { get; set; }
    }
}
