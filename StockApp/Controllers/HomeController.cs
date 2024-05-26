using Microsoft.AspNetCore.Mvc;
using StockApp.Models;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext _dbContext;
        public HomeController(MyDbContext context) 
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {   
            return View();
        }
    }
}
