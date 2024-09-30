
using HotelBookingApp.EF;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Buffers.Text;
using System.Collections.Generic;

namespace HotelManagement.Service
{
    public class BookingService(AppDbContext context) : IBookingService
    {
        private readonly AppDbContext _context = context;

        public async Task<List<RoomsAvilibilityVM>> GetAvailability(DateTime checkIn, DateTime checkOut)
        {

            var availableRooms = new List<RoomsAvilibilityVM>() { };
            DateTime forDate = checkIn;

            var halls = await _context.Halls.ToListAsync();
            var rooms = await _context.Rooms.ToListAsync();
            var bookings = await _context.Bookings.Where(b => b.CheckIn >= checkIn && b.CheckOut <= checkOut).ToListAsync();

            var commonHalls = new List<Hall>();
            var commonRooms = new List<Room>();

            foreach (var booking in bookings)
            {
                var bookingHalls = halls.Where(h => booking.HallIds.Contains(h.HallNumber)).ToList();
                var bookingRooms = rooms.Where(r => booking.RoomIds.Contains(r.RoomNumber)).ToList();
                commonHalls.AddRange(bookingHalls);
                commonRooms.AddRange(bookingRooms);

            }
            availableRooms.Add(new RoomsAvilibilityVM() { BookingDate = booking.CheckIn,  });


            // Optionally, to find only unique common halls and rooms:
            commonHalls = commonHalls.Distinct().ToList();
            commonRooms = commonRooms.Distinct().ToList();



            while (forDate <= checkOut)
            {
                availableRooms.Add(new RoomsAvilibilityVM()
                {
                    BookingDate = forDate,
                    AvailableHalls = halls,
                    AvailableRooms = rooms
                });

                forDate = forDate.AddDays(1);
            }


            return availableRooms;

        }


    }
}
