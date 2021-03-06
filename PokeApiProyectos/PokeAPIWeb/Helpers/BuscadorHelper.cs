﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using PokeAPIWeb.Models;

namespace PokeAPIWeb
{
    public class BuscadorHelper: IEqualityComparer<PokemonInfo>
    {
        //public static IEnumerable<PokemonInfo> EliminarDuplicados(IEnumerable<PokemonInfo> lista)
        //{
        //    IEnumerable<PokemonInfo> resultados =lista.Distinct(new BuscadorHelper());
        //    return resultados;
        //}

        public bool Equals(PokemonInfo x, PokemonInfo y)
        {
            return x.id == y.id;
        }

        public int GetHashCode([DisallowNull] PokemonInfo obj)
        {
            return obj.id.GetHashCode();
        }
        public static IEnumerable<PokemonInfo> FiltrarLista(IEnumerable<PokemonInfo> lista, string nombre, string habilidad, string tipo)
        {
            List<PokemonInfo> pokemones = new List<PokemonInfo>();
            
            //Escribiste nombre?
            if(nombre!=null)
            {
                //Si hay nombre, escribiste habilidad?
                if ( habilidad != "--Abilities--")
                {
                    //Si hay habilidad, escribiste un tipo?
                    if(tipo!= "--Types--")
                    {
                        //Si hay tipo (Filtra por nombre, habilidad y tipo)
                        foreach (var pokemon in lista)
                        {
                            foreach (var Habilidad in pokemon.abilities)
                            {
                                foreach (var tipos in pokemon.types)
                                {
                                    if (Habilidad.ability.name == habilidad && pokemon.name.Contains(nombre) && tipos.type.name==tipo)
                                        pokemones.Add(pokemon);
                                }
                            } 
                        }
                        return pokemones.Distinct(new BuscadorHelper());
                    }
                    else //No hay tipo, filtra por nombre y habilidad
                    {
                        foreach (var pokemon in lista)
                        {
                            foreach (var Habilidad in pokemon.abilities)
                            {
                                if (Habilidad.ability.name == habilidad && pokemon.name.Contains(nombre))
                                    pokemones.Add(pokemon);
                            }
                        }
                        return pokemones.Distinct(new BuscadorHelper());
                    }
                    
                }
                //No hay habilidad, Hay un tipo?
                else if (tipo != "--Types--")
                {
                    //Si hay un tipo, se filtra por tipo y nombre
                    foreach (var pokemon in lista)
                    {
                        foreach (var tipos in pokemon.types)
                        {
                            if (tipos.type.name == tipo && pokemon.name.Contains(nombre))
                                pokemones.Add(pokemon);
                        }
                    }
                    return pokemones.Distinct(new BuscadorHelper());
                }

                //No hay ni habilidad ni tipo, solo nombre
                return lista;
            }
            else //No escribi nombre
            {
                //Hay habilidad?
                if (habilidad != "--Abilities--")
                {
                    //Si hay habilidad, escribiste un tipo?
                    if (tipo != "--Types--")
                    {
                        //Si hay tipo (Filtra por habilidad y tipo)
                        foreach (var pokemon in lista)
                        {
                            foreach (var Habilidad in pokemon.abilities)
                            {
                                foreach (var tipos in pokemon.types)
                                {
                                    if (Habilidad.ability.name == habilidad && tipos.type.name == tipo)
                                        pokemones.Add(pokemon);
                                }
                            }
                        }
                        return pokemones.Distinct(new BuscadorHelper());
                    }
                    else //No hay tipo filtra solo por habilidad
                    {
                        return lista;
                    }
                }
                //No hay habilidad, solo hay tipo
                else 
                {
                    return lista;
                }
            }
        }
    }
}
