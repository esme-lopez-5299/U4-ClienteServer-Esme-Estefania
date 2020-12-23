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

                var result = await cliente.GetAsync("ability/?limit=20&offset=20");

                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    vm.Habilidades = JsonConvert.DeserializeObject<ability>(json);
                }
                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string texto, string habilidad, string poder)
        {
            IndexViewModel vm = new IndexViewModel();
            List<PokemonInfo> pokemones = new List<PokemonInfo>();
            try
            {
                cliente = Factory.CreateClient("Pokemones");

                var result = await cliente.GetAsync("pokemon/1");
                var result2 = await cliente.GetAsync("ability/?limit=20&offset=20");

                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    PokemonInfo p= JsonConvert.DeserializeObject<PokemonInfo>(json);
                    pokemones.Add(p);

                    var habilidades = await result2.Content.ReadAsStringAsync();

                    vm.Habilidades = JsonConvert.DeserializeObject<ability>(habilidades);
                    vm.Pokemones = pokemones;
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

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
