using BootstrapLesson.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapLesson.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Create() => View(new Product { InStock = true });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product); 

            product.Id = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1;
            _products.Add(product);

            TempData["Success"] = $"Товар «{product.Name}» добавлен";
            return RedirectToAction(nameof(Index));
        }

        private static readonly List<Product> _products =
            [
                new() { Id = 1, Name = "Механическая клавиатура", Category = "Периферия", Price = 7490m, InStock = true },
        new() { Id = 2, Name = "Игровая мышь", Category = "Периферия", Price = 3290m, InStock = true },
        new() { Id = 3, Name = "Монитор 27\"", Category = "Мониторы", Price = 24990m, InStock = false },
        new() { Id = 4, Name = "Веб-камера", Category = "Периферия", Price = 4590m, InStock = true },
        new() { Id = 5, Name = "Наушники", Category = "Аудио", Price = 8990m, InStock = false },
        new() { Id = 6, Name = "USB-хаб", Category = "Аксессуары", Price = 1490m, InStock = true }
            ];

        public IActionResult Index() => View(_products);
    }
}
