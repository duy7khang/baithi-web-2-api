using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBook187MVC.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBook187MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:7225") };
        }

        public async Task<IActionResult> Index()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            HttpResponseMessage response = await _client.GetAsync("/api/Books/get-allbooks");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }

            return View(books);
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
