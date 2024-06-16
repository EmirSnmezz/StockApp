    using Microsoft.AspNetCore.Mvc;
using StockApp.Models;
using StockApp.Models.Entites.Concrete;

namespace StockApp.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext _context;
        public CategoryController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Categories.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View("Add");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (result == null)
            {
                throw new Exception("İd gelmedi kanka kategoriyi bulamadım");
            }
            _context.Categories.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _context.Categories.Find(id);

            if (result == null)
            {
                throw new Exception("Kategori Bulunamadı");
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
