using Microsoft.AspNetCore.Mvc;
using MVCfrontend28_3.Models;
using System.Text;
using System.Text.Json;

namespace MVCfrontend28_3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: /Product
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync("api/Product");

            if (!response.IsSuccessStatusCode)
                return View(new List<Product>());

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<Product>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(data ?? new List<Product>());
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var client = _httpClientFactory.CreateClient("ApiClient");

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Product", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to create product");
                return View(product);
            }

            return RedirectToAction("Index");
        }

        // GET: /Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync($"api/Product/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();

            var product = JsonSerializer.Deserialize<Product>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var client = _httpClientFactory.CreateClient("ApiClient");

            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("api/Product", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to update product");
                return View(product);
            }

            return RedirectToAction("Index");
        }

        // POST: /Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.DeleteAsync($"api/Product/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to delete product";
            }

            return RedirectToAction("Index");
        }
    }
}