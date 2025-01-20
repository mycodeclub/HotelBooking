using HotelManagement.EF;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelManagement.Controllers
{
    public class HomeController(ILogger<HomeController> logger, AppDbContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly AppDbContext _context = context;
    

   
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult BookNow()
        {
            return View();
        }
    }
}
