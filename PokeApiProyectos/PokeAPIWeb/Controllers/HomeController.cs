using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokeAPIWeb.Models;

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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string texto, string habilidad, string poder)
        {
            List<Pokemon> lista = new List<Pokemon>();
            try
            {
                cliente = Factory.CreateClient("pokemon");

                var result = await cliente.GetAsync("/texto");

                if(result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Pokemon>>(json);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}
