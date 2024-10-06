
using HotelBookingApp.EF;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement.Service
{
    public class BookingService(AppDbContext context) : IBookingService
    {
        private readonly AppDbContext _context = context;

        public async Task<List<RoomsAvilibilityVM>> GetAvailability(DateTime checkIn, DateTime checkOut)
        {

            var roomsAvilibility = new List<RoomsAvilibilityVM>() { };
            var rooms = await _context.Rooms.ToListAsync();
            var bookings = await _context.Bookings.Where(b => b.CheckIn >= checkIn && b.CheckOut <= checkOut).ToListAsync();
            DateTime forDate = checkIn;

            while (forDate >= checkOut)
            {
                var forThisDaybooking = bookings.Where(b => b.CheckIn == forDate).ToList();
                //roomsAvilibility.Add(new RoomsAvilibilityVM()
                //{
                //    BookingDate = forDate,
                //    Rooms = rooms.ForEach(r =>
                //    {
                //        var data = forThisDaybooking.Where(bookedRoom => bookedRoom.RoomIds.Contains(r.RoomNumber)).ToList();
                //    })

                //});

                forDate = forDate.AddDays(1);
            }
            return roomsAvilibility;
        }
   
    }
}
