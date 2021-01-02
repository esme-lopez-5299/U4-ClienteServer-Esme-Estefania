﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeAPIWeb.Models
{
    public class HabilidadCompleta
    {
        public class Language
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class EffectEntry
        {
            public string effect { get; set; }
            public Language language { get; set; }
            public string short_effect { get; set; }
        }

        public class Language2
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class VersionGroup
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class FlavorTextEntry
        {
            public string flavor_text { get; set; }
            public Language2 language { get; set; }
            public VersionGroup version_group { get; set; }
        }

        public class Generation
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Language3
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Name
        {
            public Language3 language { get; set; }
            public string name { get; set; }
        }

        public class Poke
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Pokemon1
        {
            public bool is_hidden { get; set; }
            public Poke pokemon { get; set; }
            public int slot { get; set; }
        }

        public class Root
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
}
