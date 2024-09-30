using HotelBookingApp.EF;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    public class GuestController : Controller
    {
        private readonly AppDbContext _context;

        public GuestController(AppDbContext context) {
            _context = context;

        }
        public  async Task<IActionResult> Index()
        {
            var data = await _context.Guests.ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public IActionResult Create(Guest guest)
        {

            return View();
        }
    }
}
