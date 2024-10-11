﻿using HotelBookingApp.EF;
using HotelManagement.Models;
using HotelManagement.Service;
using HotelManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting.Internal;

namespace HotelManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBookingService _booking;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public BookingController(AppDbContext context, IBookingService booking, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _booking = booking;
            _hostingEnvironment = hostingEnvironment;

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
                    await SaveGuestDocs(booking.Guests);
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

        private async Task SaveGuestDocs(List<Guest>? guests)
        {
            foreach (var guest in guests)
            {
                if (guest.GovIdFile != null && guest.GovIdFile.Length > 0)
                {
                    // Define the folder to save the image
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "GuestDocs");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);  // Generate a unique name for the file
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + guest.Id + "_" + guest.GovnId + " " + guest.GovIdFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the file to the target directory
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await guest.GovIdFile.CopyToAsync(fileStream);
                    }

                    // Optionally save the file path to the database
                    guest.GovIdFilePath = "/GuestDocs/" + uniqueFileName;
                    await _context.SaveChangesAsync();
                }
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
