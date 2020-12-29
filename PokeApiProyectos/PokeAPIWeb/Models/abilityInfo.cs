using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PokeAPIWeb.Models.ability;

namespace PokeAPIWeb.Models
{
    public class abilityInfo
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
