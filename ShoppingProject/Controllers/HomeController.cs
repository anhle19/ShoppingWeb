using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ShoppingProject.Data;
using ShoppingProject.Models;
using System.Diagnostics;
using System.Linq;

namespace ShoppingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> products =  this._context.Products.ToList<Product>();
            return View(products);
            //return View();
        }

        //open products with id
        public IActionResult Shop(int id)
        {
            var products = this._context.Products.Where(p => p.CategoryId == id).ToList();
            return View(products);
        }

        //open product-detail with id
        public IActionResult ProductDetail(int id)
        {
            var product = this._context.Products.FirstOrDefault(p => p.Id == id);
            ViewBag.Product=product;
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