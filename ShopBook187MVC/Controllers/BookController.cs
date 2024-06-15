using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ShopBook187MVC.Models;

namespace ShopBook187MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BookController> _logger;

        public BookController(IHttpClientFactory httpClientFactory, ILogger<BookController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            try
            {
                var client = _httpClientFactory.CreateClient("API");
                var httpResponseMess = await client.GetAsync("Books");
                httpResponseMess.EnsureSuccessStatusCode();
                books.AddRange(await httpResponseMess.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving books from API.");
                ViewBag.Error = "An error occurred while retrieving books from the API.";
            }
            return View(books);
        }
    }
}
