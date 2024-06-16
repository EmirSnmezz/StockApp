using Microsoft.AspNetCore.Mvc;
using StockApp.Models;
using StockApp.Models.Entites.Concrete;

namespace StockApp.Controllers
{
    public class BrandController : Controller
    {
        MyDbContext _context;
        public BrandController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Brands.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Brand brand)
        {
            if (brand == null)
            {
                throw new Exception("Data gelmedi");
            }

            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _context.Brands.Find(id);
            if(result != null)
            {
                _context.Brands.Remove(result);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            throw new Exception("İşlem Sırasında Hata!");
        }
    }
}
