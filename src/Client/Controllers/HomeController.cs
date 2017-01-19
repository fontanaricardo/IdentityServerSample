using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CallApi()
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");
            var client = new HttpClient 
            {
                BaseAddress = new Uri(_apiSettings.Value.BaseAddress)
            };
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync("/claims");
            ViewBag.Json = JArray.Parse(response).ToString();

            return View();
        }
    }
}
