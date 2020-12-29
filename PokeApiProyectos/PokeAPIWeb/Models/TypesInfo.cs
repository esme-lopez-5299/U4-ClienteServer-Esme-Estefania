using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PokeAPIWeb.Models.Types;

namespace PokeAPIWeb.Models
{
    public class TypesInfo
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
