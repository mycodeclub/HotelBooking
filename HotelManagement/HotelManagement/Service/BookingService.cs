
using HotelBookingApp.EF;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            var booking = await _context.Bookings.Where(b => b.CheckIn >= checkIn && b.CheckOut <= checkOut).ToListAsync();

            foreach (var b in booking)
            {
                halls.Where( h => b.HallIds.Contains(h.HallNumber)).
            }



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
