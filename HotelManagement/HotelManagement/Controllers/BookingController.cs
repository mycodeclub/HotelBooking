using HotelBookingApp.EF;
using HotelManagement.Service;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<ActionResult> Index()
        {
            var bookings = await _context.Bookings.Include(b => b.Room).Include(b => b.Guests).ToListAsync();
            return View(bookings);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public async Task<IActionResult> Create(int id)
        {
            var booking = await _context.Bookings.Include(b => b.Guests).Include(b => b.Room).Where(b => b.UniqueId == id).FirstOrDefaultAsync();
            booking ??= new Models.Booking()
            {
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(2),
                Guests = [new Models.Guest() { }]
            };

            ViewData["GorvnIdType"] = new SelectList(_context.GorvnIdTypes, "Id", "IdType");
            ViewData["RoomId"] = new SelectList(_context.Rooms.Select(r => new { r.RoomNumber, DisplayText = r.RoomNumber + " - Rent: $" + r.Rent.ToString("F2") }), "RoomNumber", /*  Value field */ "DisplayText" /*Display field*/ );
            return View(booking);
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Bookings.AddAsync(booking);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            ViewData["GorvnIdType"] = new SelectList(_context.GorvnIdTypes, "Id", "IdType");
            ViewData["RoomId"] = new SelectList(_context.Rooms.Select(r => new { r.RoomNumber, DisplayText = r.RoomNumber + " - Rent: $" + r.Rent.ToString("F2") }), "RoomNumber", /*  Value field */ "DisplayText" /*Display field*/ );
            return View(booking);
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
