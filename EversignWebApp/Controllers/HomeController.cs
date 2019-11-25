using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EversignWebApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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

            var requestBody = new
            {
                sandbox = 1,
                is_draft = 0,
                embedded = 0,
                title = "Sample Document",
                message = "This is my general document message.",
                reminders = 1,
                require_all_signers = 1,
                redirect = "https://myredirect.com/completed",
                redirect_decline = "https://myredirect.com/declined",
                embedded_signing_enabled = 1,
                flexible_signing = 0,
                use_hidden_tags = 0,
                files = new List<dynamic> {
                    new {
                        name = "My Document File",
                        file_url = "https://file-examples.com/wp-content/uploads/2017/10/file-example_PDF_1MB.pdf",
                        file_id = "",
                        file_base64 = ""
                    }
                },
                signers = new List<dynamic> {
                    new {
                        id = 1,
                        name = "Gab McSign",
                        email = "miguelp@pageuppeople.com"
                    }
                },
                recipients = new List<dynamic> {
                    new {
                        name = "Gab McSign",
                        email = "miguelp@pageuppeople.com",
                    }
                },
                fields = new List<dynamic>()
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(baseUrl, requestContent);

            EversignDocument document = JsonConvert.DeserializeObject<EversignDocument>(response.Content.ReadAsStringAsync().Result);

            return View(new HomeViewModel { 
                EmbeddedSigningUrl = document.signers.First().embedded_signing_url
            });
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
