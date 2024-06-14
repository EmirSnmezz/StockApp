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
                           join brand in _context.Brands
                           on product.BrandId equals brand.BrandId
                          select new ProductDTO
                          {
                              ProductId = product.ProductId,
                              ProductName = product.ProductName,
                              CategoryName = category.CategoryName,
                              Brand = brand.BrandName,
                              Stock = product.Stock,
                              Price = product.Price

                          }).ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> Categories = (from category in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = category.CategoryName,
                                               Value = category.CategoryId.ToString()
                                           }).ToList();
            ViewBag.Categories = Categories;

            List<SelectListItem> Brands = (from brand in _context.Brands.ToList()
                                           select new SelectListItem
                                           {
                                               Text = brand.BrandName,
                                               Value = brand.BrandId.ToString()
                                           }).ToList();
            ViewBag.Brands = Brands;
                                           
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _context.Products.FirstOrDefault(x => x.ProductId == id);
            
           List<SelectListItem> categoryValues =(from category in _context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text=category.CategoryName,
                                                     Value= category.CategoryId.ToString()
                                                 }).ToList() ;

            ViewBag.values = categoryValues;
            if (result == null)
            {
                throw new Exception("İd lerle ilgili bir problem var durumu incele");
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
