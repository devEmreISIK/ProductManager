using Microsoft.AspNetCore.Mvc;
using ProductManager.Models.DTOs.Categories;
using ProductManager.Service.Abstracts;

namespace ProductManager.View.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View("Index", categories);
        }


        [HttpPost]
        public IActionResult Add(CategoryAddRequestDto categoryAddRequestDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(categoryAddRequestDto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category); // Eğer Update.cshtml kullanıyorsan
        }


        [HttpPost]
        public IActionResult Update(CategoryUpdateRequestDto categoryUpdateRequestDto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(categoryUpdateRequestDto);
            }
            return RedirectToAction("Index");
        }
    }
}
