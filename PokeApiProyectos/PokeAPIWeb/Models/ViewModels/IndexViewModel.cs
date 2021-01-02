using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPIWeb.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<PokemonInfo> Pokemones { get; set; }

        public abilityInfo Habilidades { get; set; }
        public TypesInfo Tipos { get; set; }

        public string habilidadBuscada { get; set; }
        public string tipoBuscado { get; set; }
        public string nombreBuscado { get; set; }


    }
}
