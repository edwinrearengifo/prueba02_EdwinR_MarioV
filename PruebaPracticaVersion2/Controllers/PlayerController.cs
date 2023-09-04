using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaPracticaVersion2.Controllers
{
    public class PlayerController : Controller
    {
        public ActionResult InformacionJugador()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetPlayer(int id, string estacion)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://v3.football.api-sports.io");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "d38dc1e7c3fa3047a6a2a1344889f53a");

                    string apiEndpoint = $"/players?id={id}&season={estacion}";


                    HttpResponseMessage response = await client.GetAsync(apiEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject teamInfo = JObject.Parse(data);

                        // Configurar las variables ViewBag con los datos del equipo y el estadio
                        ViewBag.PlayerName = teamInfo["response"][0]["player"]["name"].ToString();
                        ViewBag.PlayerLastName = teamInfo["response"][0]["player"]["lastname"].ToString();
                        ViewBag.PlayerAge = teamInfo["response"][0]["player"]["age"].ToString();
                        ViewBag.PlayerNationality = teamInfo["response"][0]["player"]["nationality"].ToString();
                        ViewBag.PlayerHeight = teamInfo["response"][0]["player"]["height"].ToString();


                        ViewBag.teamName = teamInfo["response"][0]["statistics"][0]["team"]["name"].ToString();
                        
                        ViewBag.LeagueName = teamInfo["response"][0]["statistics"][0]["league"]["name"].ToString();
                        ViewBag.LeagueCountry = teamInfo["response"][0]["statistics"][0]["league"]["country"].ToString();

                        ViewBag.GamesAppearences = teamInfo["response"][0]["statistics"][0]["games"]["appearences"].ToString();
                        ViewBag.GamesPosition = teamInfo["response"][0]["statistics"][0]["games"]["position"].ToString();

                        ViewBag.GoalsTotal = teamInfo["response"][0]["statistics"][0]["goals"]["total"].ToString();
                        ViewBag.GoalsAssists = teamInfo["response"][0]["statistics"][0]["goals"]["assists"].ToString();


                        string logoUrl = teamInfo["response"][0]["player"]["photo"].ToString();

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

            return View("InformacionJugador");
        }
    }
}