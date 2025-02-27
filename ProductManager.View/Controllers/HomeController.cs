using Microsoft.AspNetCore.Mvc;
using ProductManager.Models.DTOs.Products;
using ProductManager.Service.Abstracts;
using ProductManager.View.Models;
using System.Diagnostics;

namespace ProductManager.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(int? categoryId, int? min, int? max, int? stockMin, int? stockMax)
        {
            var products = _productService.GetAllProducts().AsQueryable();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }
            if (min.HasValue)
            {
                products = products.Where(p => p.Price >= min.Value);
            }
            if (max.HasValue)
            {
                products = products.Where(p => p.Price <= max.Value);
            }
            if (stockMin.HasValue)
            {
                products = products.Where(p => p.Stock >= stockMin.Value);
            }
            if (stockMax.HasValue)
            {
                products = products.Where(p => p.Stock <= stockMax.Value);
            }

            var categories = _categoryService.GetAllCategories();
            ViewBag.Categories = categories;

            return View(products.ToList());
        }

        [HttpPost]
        public IActionResult Add(ProductAddRequestDto productAddRequestDto)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(productAddRequestDto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return NotFound();
            }

            ViewBag.Categories = _categoryService.GetAllCategories(); 

            return View(product);
        }


        [HttpPost]
        public IActionResult Update(ProductUpdateRequestDto productUpdateRequestDto)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(productUpdateRequestDto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Category()
        {
            return RedirectToAction("Index", "Category");
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
