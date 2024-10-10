using HotelBookingApp.EF;
using HotelManagement.Service;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBookingService _booking;

        public BookingController(AppDbContext context, IBookingService booking)
        {
            _context = context;
            _booking = booking;
        }


        // GET: BookingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public async Task<IActionResult> Create(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            booking ??= new Models.Booking()
            {
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(2),
                Rooms = await _context.Rooms.ToListAsync(),
            };
            // ViewData["RoomTypeId"] = new SelectList(  _context.Rooms , "RoomNumber", "RoomNumber");
            ViewData["RoomId"] = new SelectList(_context.Rooms.Select(r => new { r.RoomNumber, DisplayText = r.RoomNumber + " - Rent: $" + r.Rent.ToString("F2") }), "RoomNumber", /*  Value field */ "DisplayText" /*Display field*/ );
            return View(booking);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
