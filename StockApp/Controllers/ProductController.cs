using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using StockApp.Models;
using StockApp.Models.Entites.Concrete;
using StockApp.Models.Entites.DTOs;


namespace StockApp.Controllers
{
    public class ProductController : Controller
    {
        MyDbContext _context;
        public ProductController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Products.ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product != null)
            {
                throw new Exception("Ürün Eklenirken Bir Hata Oluştu");
            }
            List<SelectListItem> list =
                (from category in _context.Categories.ToList()
                 select new SelectListItem
                 {
                     Text = category.CategoryName,
                     Value = category.CategoryName

                 }).ToList();

            ViewBag.list = list;
            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (result != null)
            {
                _context.Products.Remove(result);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            throw new Exception("Ürün silinirken bir hata oluştu");

            var result = _context.Products;
                       
            return View(result.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product) 
        {
            if (product != null) 
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            throw new Exception("Ürün Eklenirken Bir Hata Oluştu");

        }

        public IActionResult Delete(int id)
        {
            var result = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if(result != null) 
            {
                _context.Products.Remove(result);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            throw new Exception("Ürün silinirken bir hata oluştu");

            
        }
    }
}
