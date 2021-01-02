using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using PokeAPIWeb.Models;

namespace PokeAPIWeb
{
    public class BuscadorHelper: IEqualityComparer<PokemonInfo>
    {
        public static IEnumerable<PokemonInfo> EliminarDuplicados(IEnumerable<PokemonInfo> lista)
        {
            IEnumerable<PokemonInfo> resultados =lista.Distinct(new BuscadorHelper());
            return resultados;
        }

        public bool Equals(PokemonInfo x, PokemonInfo y)
        {
            return x.id == y.id;
        }

        public IEnumerable<PokemonInfo> FiltrarLista()
        {
            List<PokemonInfo> lista = new List<PokemonInfo>();
            return lista;
        }

        public int GetHashCode([DisallowNull] PokemonInfo obj)
        {
            return obj.id.GetHashCode();
        }
    }
}
