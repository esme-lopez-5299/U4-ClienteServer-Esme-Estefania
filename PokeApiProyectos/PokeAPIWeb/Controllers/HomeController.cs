using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokeAPIWeb.Models;
using PokeAPIWeb.Models.ViewModels;

namespace PokeAPIWeb.Controllers
{
    public class HomeController : Controller
    {
        public IHttpClientFactory Factory { get; set; }
        HttpClient cliente;
        public HomeController(IHttpClientFactory clientFactory)
        {
            Factory = clientFactory;

        }
        public async Task<IActionResult> Index()
        {
            IndexViewModel vm = new IndexViewModel();
            try
            {
                cliente = Factory.CreateClient("Pokemones");

                var habilidades = await cliente.GetAsync("ability?limit=327");
                var tipos = await cliente.GetAsync("type");


                if (habilidades.IsSuccessStatusCode && tipos.IsSuccessStatusCode)
                {
                    var jsonHabilidades = await habilidades.Content.ReadAsStringAsync();
                    var jsonTipos= await tipos.Content.ReadAsStringAsync();

                    vm.Habilidades = JsonConvert.DeserializeObject<abilityInfo>(jsonHabilidades);
                    vm.Tipos = JsonConvert.DeserializeObject<TypesInfo>(jsonTipos);

                }
                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string texto, string habilidad, string tipo)
        {
            IndexViewModel vm = new IndexViewModel();
            List<PokemonInfo> pokemones = new List<PokemonInfo>();
            try
            {
                cliente = Factory.CreateClient("Pokemones");
                //Buscadores
               
                var habilidades = await cliente.GetAsync("ability?limit=327");
                var tipos = await cliente.GetAsync("type");

                if (habilidades.IsSuccessStatusCode && tipos.IsSuccessStatusCode)
                {
                   

                    var jsonHabilidades = await habilidades.Content.ReadAsStringAsync();
                    var jsonTipos = await tipos.Content.ReadAsStringAsync();

                    vm.Habilidades = JsonConvert.DeserializeObject<abilityInfo>(jsonHabilidades);
                    vm.Tipos = JsonConvert.DeserializeObject<TypesInfo>(jsonTipos);
                }

                //Resultados
                //Buscar por Nombre
                if (!String.IsNullOrEmpty(texto))
                {
                    var result = await cliente.GetAsync($"pokemon/{texto}");

                    if(result.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var json = await result.Content.ReadAsStringAsync();
                        PokemonInfo p = JsonConvert.DeserializeObject<PokemonInfo>(json);
                        pokemones.Add(p);
                        
                    }
                    else
                    {
                        vm.Pokemones = pokemones;
                    }
                   
                }
                //Busca los de la habilidad
                if (habilidad != "--Abilities--")
                {
                    var resultHabilidad = await cliente.GetAsync($"ability/{habilidad}");
                    var jsonHabilidad = await resultHabilidad.Content.ReadAsStringAsync();
                    HabilidadCompletaInfo habilidadObtenida = JsonConvert.DeserializeObject<HabilidadCompletaInfo>(jsonHabilidad);                     

                    foreach (var p in habilidadObtenida.pokemon)
                    {
                        var poke = await cliente.GetAsync($"pokemon/{p.pokemon.name}");
                        var jsonPoke = await poke.Content.ReadAsStringAsync();
                        PokemonInfo poke2 = JsonConvert.DeserializeObject<PokemonInfo>(jsonPoke);
                        pokemones.Add(poke2);
                    }
                }
                //Buscar por tipos
                if (tipo != "--Types--")
                {
                    var resultTipo = await cliente.GetAsync($"type/{tipo}");
                    var jsonTipo = await resultTipo.Content.ReadAsStringAsync();
                    TipoCompletoInfo tipoObtenido = JsonConvert.DeserializeObject<TipoCompletoInfo>(jsonTipo);

                    foreach (var p in tipoObtenido.pokemon)
                    {
                        var poke = await cliente.GetAsync($"pokemon/{p.pokemon.name}");
                        var jsonPoke = await poke.Content.ReadAsStringAsync();
                        PokemonInfo poke2 = JsonConvert.DeserializeObject<PokemonInfo>(jsonPoke);
                        pokemones.Add(poke2);
                    }
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            vm.Pokemones = BuscadorHelper.EliminarDuplicados(pokemones);
            return View(vm);
        }

        public async Task<IActionResult> VerPokemon(int id)
        {
            if (id != 0)
            {
                cliente = Factory.CreateClient("Pokemones");

                PokemonInfo p = new PokemonInfo();

                var result = await cliente.GetAsync($"pokemon/{id}");
                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<PokemonInfo>(json);
                }
                return View(p);
            }
            else
                return RedirectToAction("Index");
            
        }
    }
}
