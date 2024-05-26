using Microsoft.AspNetCore.Mvc;
using StockApp.Models;
using StockApp.Models.Entites.DTOs;

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
           var customerResult =  _context.Customers.ToList();

            foreach (var customer in customerResult) 
            {
                customerDtos.Add
                    (
                    new CustomerDto
                    {
                        CustomerName = customer.CustomerName,
                        CustomerSurname = customer.CustomerSurname
                    }
                    );
            }

            return View(customerDtos);
        }
    }
}
