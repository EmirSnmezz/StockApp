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
            var result = (from product in _context.Products
                          join category in _context.Categories
                          on product.CategoryId equals category.CategoryId
                          select new ProductDTO
                          {
                              ProductId = product.ProductId,
                              CategoryName = category.CategoryName,
                              Brand = product.Brand,
                              Price = product.Price,
                              ProductName = product.ProductName,
                              Stock = product.Stock,
                          }).ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> values = (from category in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = category.CategoryName,
                                               Value = category.CategoryId.ToString()
                                           }).ToList();
            ViewBag.Values = values;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product == null)
            {
                throw new Exception("Ürün Eklenirken Bir Hata Oluştu");
            }

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
        }

    }
}
