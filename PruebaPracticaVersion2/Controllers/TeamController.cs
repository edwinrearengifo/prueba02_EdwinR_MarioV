using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaPracticaVersion2.Models.Teams;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaPracticaVersion2.Controllers
{
    public class TeamController : Controller
    {
        public ActionResult Informacion()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetTeam(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://v3.football.api-sports.io");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "d38dc1e7c3fa3047a6a2a1344889f53a");

                    string apiEndpoint = $"/teams?id={id}";

                    HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject teamInfo = JObject.Parse(data);

                        // Configurar las variables ViewBag con los datos del equipo y el estadio
                        ViewBag.TeamName = teamInfo["response"][0]["team"]["name"].ToString();
                        ViewBag.TeamCode = teamInfo["response"][0]["team"]["code"].ToString();
                        ViewBag.TeamCountry = teamInfo["response"][0]["team"]["country"].ToString();
                        ViewBag.TeamFounded = teamInfo["response"][0]["team"]["founded"].ToString();

                        ViewBag.VenueName = teamInfo["response"][0]["venue"]["name"].ToString();
                        ViewBag.VenueAddress = teamInfo["response"][0]["venue"]["address"].ToString();
                        ViewBag.VenueCity = teamInfo["response"][0]["venue"]["city"].ToString();
                        ViewBag.VenueCapacity = teamInfo["response"][0]["venue"]["capacity"].ToString();

                        string logoUrl = teamInfo["response"][0]["team"]["logo"].ToString();

                        ViewBag.TeamData = data;
                        ViewBag.LogoUrl = logoUrl;
                    }
                    else
                    {
                        return Content($"Error: {response.StatusCode}", "text/plain");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}", "text/plain");
            }

            return View("Informacion");
        }

        // Consulta2 -- con problemas
        public ActionResult Estadisticas()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetTeamInfo(int liga, string estacion, int equipo, string fecha)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://v3.football.api-sports.io");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "d38dc1e7c3fa3047a6a2a1344889f53a");

                    string apiEndpoint = $"/teams/statistics?season={estacion}&team={equipo}&league={liga}&date={fecha}";

                    

                    HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject teamInfo = JObject.Parse(data);

                        // Configurar las variables ViewBag con los datos del equipo y el estadio
                        ViewBag.LeagueName = teamInfo["response"]["league"]["name"].ToString();
                        ViewBag.LeagueCountry = teamInfo["response"]["league"]["country"].ToString();
                        ViewBag.LeagueSeason = teamInfo["response"]["league"]["season"].ToString();
                        //ViewBag.TeamFounded = teamInfo["response"][0]["team"]["founded"].ToString();

                        ViewBag.TeamName = teamInfo["response"]["team"]["name"].ToString();
                        
                        ViewBag.PlayedTotal = teamInfo["response"]["fixtures"]["played"]["total"].ToString();
                        ViewBag.WinsTotal = teamInfo["response"]["fixtures"]["wins"]["total"].ToString();
                        ViewBag.DrawTotal = teamInfo["response"]["fixtures"]["draws"]["total"].ToString();
                        ViewBag.LosesTotal = teamInfo["response"]["fixtures"]["loses"]["total"].ToString();


                        string logoUrl = teamInfo["response"]["league"]["logo"].ToString();

                        ViewBag.TeamData = data;
                        ViewBag.LogoUrl = logoUrl;
                    }
                    else
                    {
                        return Content($"Error: {response.StatusCode}", "text/plain");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}", "text/plain");
            }
            return View("Estadisticas");
        }

        ///

    }
}
