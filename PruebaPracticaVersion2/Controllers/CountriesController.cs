using Newtonsoft.Json;
using PruebaPracticaVersion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaPracticaVersion2.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        private readonly string Baseurl = "https://api-football-v1.p.rapidapi.com";

        // GET: Countries

        public async Task<ActionResult> Paises()
        {
            List<Countries1> CountryInfo = new List<Countries1>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://v3.football.api-sports.io");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "d38dc1e7c3fa3047a6a2a1344889f53a");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "v3.football.api-sports.io");

                string apiEndpoint = $"/teams/countries/";

                HttpResponseMessage Res = await client.GetAsync(apiEndpoint);
                if (Res.IsSuccessStatusCode)
                {
                    var CnResponse = Res.Content.ReadAsStringAsync().Result;
                    //EmpInfo = JsonConvert.DeserializeObject<List<Countries>>(EmpResponse);
                    var countryResponse = JsonConvert.DeserializeObject<Countries1Response>(CnResponse);
                    CountryInfo = countryResponse.Response;
                }
                return View(CountryInfo);
            }

        }

    }
}