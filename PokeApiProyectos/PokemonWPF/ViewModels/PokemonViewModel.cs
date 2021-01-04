using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
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
    public class PokemonViewModel : INotifyPropertyChanged
    {

        public class Busqueda
        {
            public string habilidadBuscada { get; set; }
            public string tipoBuscado { get; set; }
            public string nombreBuscado { get; set; }
        }

        public Busqueda BusquedaObj { get; set; } = new Busqueda();
        public ObservableCollection<PokemonInfo> Pokemones { get; set; }
        public abilityInfo Habilidades { get; set; }        
        public TypesInfo Tipos { get; set; }
        public string Mensaje { get; set; }
        

       
        public ICommand HacerBusquedaCommand { get; set; }

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
        }

        private async void HacerBusqueda(Busqueda parametrosBusqueda)
        {

            try
            {
                ObservableCollection<PokemonInfo> pokemonesTemp = new ObservableCollection<PokemonInfo>();
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
                if (parametrosBusqueda.habilidadBuscada.ToString() != "--Abilities--")
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
                if (parametrosBusqueda.tipoBuscado != "--Types--")
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
          
        }
    }

    }

