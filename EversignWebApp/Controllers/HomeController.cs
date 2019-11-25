using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EversignWebApp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace EversignWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string ACCESS_KEY = "0fd094ff9f73fc76a16ece4fba8212e4";
        private const string BUSINESS_ID = "106694";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string baseUrl = $"https://api.eversign.com/api/document?access_key={ACCESS_KEY}&business_id={BUSINESS_ID}";

            var person = new
            {
                Name = "John Doe",
                Occupation = "gardener"
            };

            var json = JsonConvert.SerializeObject(person);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(baseUrl, requestContent);

            string result = response.Content.ReadAsStringAsync().Result;
            {
                Console.WriteLine(result);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
