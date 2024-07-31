using DynamicGoogleMaps.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DynamicGoogleMaps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /Home/Contact
        public IActionResult Contact()
        {
            // Ýlk yüklenmede boþ bir model ile formu render eder
            return View(new MapViewModel());
        }

        // POST: /Home/Contact
        [HttpPost]
        public IActionResult Contact(MapViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Formdan gelen adres ile model oluþturulur
                return View(model); // Ayný sayfayý model ile birlikte döndürür
            }

            // Hatalý durumda formu tekrar gösterir
            return View(new MapViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
