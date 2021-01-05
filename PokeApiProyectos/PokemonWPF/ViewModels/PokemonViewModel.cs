using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using PokemonWPF.Helpers;
using PokemonWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static PokemonWPF.Models.ability;

namespace PokemonWPF.ViewModels
{
    public enum Modal { Ver, VerDetalle }
    public class PokemonViewModel : INotifyPropertyChanged
    {

        public class Busqueda
        {
            public string habilidadBuscada { get; set; }
            public string tipoBuscado { get; set; }
            public string nombreBuscado { get; set; }
        }

        public Busqueda BusquedaObj { get; set; } = new Busqueda();
        public List<PokemonInfo> Pokemones { get; set; }
        public abilityInfo Habilidades { get; set; }        
        public TypesInfo Tipos { get; set; }
        public string Mensaje { get; set; } = "Selecciona tu búsqueda para iniciar";

        public PokemonInfo PokemonParameter { get; set; } = new PokemonInfo();
        public Modal ModalVisible { get; set; } = Modal.Ver;

        public ICommand HacerBusquedaCommand { get; set; }
        public ICommand VerDetalleCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        public ICommand ResetCommand { get; set; }

        HttpClient client = new HttpClient() { BaseAddress = new Uri("https://pokeapi.co/api/v2/") };

        public event PropertyChangedEventHandler PropertyChanged;
        void Lanzar(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }     
        
        async void GetCombos()
        {
            var result = await client.GetAsync("ability?limit=327");
            var tipos = await client.GetAsync("type");

            if (result.IsSuccessStatusCode&&tipos.IsSuccessStatusCode)
            {
                var jsonHabilidades = await result.Content.ReadAsStringAsync();
                var jsonTipos = await tipos.Content.ReadAsStringAsync();

                Habilidades = JsonConvert.DeserializeObject<abilityInfo>(jsonHabilidades);
                Tipos = JsonConvert.DeserializeObject<TypesInfo>(jsonTipos);
                Lanzar();
            }
        }

        public PokemonViewModel()
        {
            GetCombos();
            HacerBusquedaCommand = new RelayCommand<Busqueda>(HacerBusqueda);
            VerDetalleCommand = new RelayCommand<string>(VerDetalle);
            CancelarCommand = new RelayCommand(Cancelar);
            ResetCommand = new RelayCommand(Reset);
        }

        public void Reset()
        {
            BusquedaObj.habilidadBuscada = null;
            BusquedaObj.nombreBuscado = null;
            BusquedaObj.tipoBuscado = null;
            Pokemones.Clear();
            Lanzar();
        }



        public void Cancelar()
        {
            ModalVisible = Modal.Ver;
            Lanzar();
        }

        public void VerDetalle(string pokemonParametro)
        {
            ModalVisible = Modal.VerDetalle;           
            PokemonParameter = Pokemones.First(x => x.name == pokemonParametro);
            Lanzar();
        }

        private async void HacerBusqueda(Busqueda parametrosBusqueda)
        {
            Mensaje = "Realizando búsqueda";
            Lanzar(nameof(Mensaje));
            
            List<PokemonInfo> pokemonesTemp = new List<PokemonInfo>();
            try
            {
                
                if (!String.IsNullOrEmpty(parametrosBusqueda.nombreBuscado))
                {
                    var result = await client.GetAsync($"pokemon/{parametrosBusqueda.nombreBuscado.ToLower()}");

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = await result.Content.ReadAsStringAsync();
                        PokemonInfo p = JsonConvert.DeserializeObject<PokemonInfo>(json);
                        pokemonesTemp.Add(p);

                    }
                    else
                    {
                        Pokemones = pokemonesTemp;
                    }
                }
                //Busca los de la habilidad
                if (parametrosBusqueda.habilidadBuscada!= "--Abilities--"&& parametrosBusqueda.habilidadBuscada !=null)
                {
                    var resultHabilidad = await client.GetAsync($"ability/{parametrosBusqueda.habilidadBuscada}");
                    var jsonHabilidad = await resultHabilidad.Content.ReadAsStringAsync();
                    HabilidadCompletaInfo habilidadObtenida = JsonConvert.DeserializeObject<HabilidadCompletaInfo>(jsonHabilidad);

                    foreach (var p in habilidadObtenida.pokemon)
                    {
                        var poke = await client.GetAsync($"pokemon/{p.pokemon.name}");
                        var jsonPoke = await poke.Content.ReadAsStringAsync();
                        PokemonInfo poke2 = JsonConvert.DeserializeObject<PokemonInfo>(jsonPoke);
                        pokemonesTemp.Add(poke2);
                    }
                }
                //Buscar por tipos
                if (parametrosBusqueda.tipoBuscado != "--Types--" && parametrosBusqueda.tipoBuscado !=null)
                {
                    var resultTipo = await client.GetAsync($"type/{parametrosBusqueda.tipoBuscado }");
                    var jsonTipo = await resultTipo.Content.ReadAsStringAsync();
                    TipoCompletoInfo tipoObtenido = JsonConvert.DeserializeObject<TipoCompletoInfo>(jsonTipo);

                    foreach (var p in tipoObtenido.pokemon)
                    {
                        var poke = await client.GetAsync($"pokemon/{p.pokemon.name}");
                        var jsonPoke = await poke.Content.ReadAsStringAsync();
                        PokemonInfo poke2 = JsonConvert.DeserializeObject<PokemonInfo>(jsonPoke);
                        pokemonesTemp.Add(poke2);
                    }
                }

            }
            catch (Exception e)
            {
                Mensaje = e.ToString();
                Lanzar(nameof(Mensaje));
            }            
            Pokemones = BuscadorHelper.FiltrarLista(pokemonesTemp, parametrosBusqueda.nombreBuscado, parametrosBusqueda.habilidadBuscada, parametrosBusqueda.tipoBuscado).ToList();
            Mensaje = $"Se han encontrado {Pokemones.Count()} resultados que coinciden con su búsqueda";
            Lanzar(nameof(Mensaje));
            Lanzar(nameof(Pokemones));
        }
    }

    }

