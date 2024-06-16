using Microsoft.AspNetCore.Mvc;
using StockApp.Models;
using StockApp.Models.Entites.DTOs;
using StockApp.Models.Entites.Concrete;

namespace StockApp.Controllers
{
    public class CustomerController : Controller
    {
        MyDbContext _context;
        public CustomerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            var customerResult = _context.Customers.ToList();

            foreach (var customer in customerResult)
            {
                customerDtos.Add
                    (
                    new CustomerDto
                    {
                        CustomerId = customer.CustomerId,
                        CustomerName = customer.CustomerName,
                        CustomerSurname = customer.CustomerSurname
                    }
                    );
            }

            return View(customerDtos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View("Add");
            }

            var result = _context.Customers.ToList();

            if (result.FirstOrDefault(x => x.CustomerId == customer.CustomerId) != null)
            {
                throw new Exception("Ürün zaten mevcut");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _context.Customers.First(x => x.CustomerId == id);

            if (result == null)
            {
                throw new Exception("Belirtilen Müşteri Bulunamadı Lütfen Sistem Yöneticisiyle İletişime Geçiniz !");
            }

            _context.Customers.Remove(result);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
