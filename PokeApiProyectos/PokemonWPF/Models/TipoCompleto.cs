using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonWPF.Models
{
    public class TipoCompleto
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class DoubleDamageFrom
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class HalfDamageTo
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class NoDamageFrom
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class NoDamageTo
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class DamageRelations
        {
            public List<DoubleDamageFrom> double_damage_from { get; set; }
            public List<object> double_damage_to { get; set; }
            public List<object> half_damage_from { get; set; }
            public List<HalfDamageTo> half_damage_to { get; set; }
            public List<NoDamageFrom> no_damage_from { get; set; }
            public List<NoDamageTo> no_damage_to { get; set; }
        }

        public class Generation
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class GameIndice
        {
            public int game_index { get; set; }
            public Generation generation { get; set; }
        }

        public class Generation2
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class MoveDamageClass
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Move
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Language
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Name
        {
            public Language language { get; set; }
            public string name { get; set; }
        }

        public class Pokemon2
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Poke
        {
            public Pokemon2 pokemon { get; set; }
            public int slot { get; set; }
        }

        public class Root
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
}
