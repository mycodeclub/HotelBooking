
using HotelBookingApp.EF;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace HotelManagement.Service
{
    public class BookingService(AppDbContext context) : IBookingService
    {
        private readonly AppDbContext _context = context;

        public async Task<List<RoomsAvilibilityVM>> GetAvailability(DateTime checkIn, DateTime checkOut)
        {
            var roomsAvilibility = new List<RoomsAvilibilityVM>() { };
            try
            {
                var rooms = await _context.Rooms.ToListAsync();
                var bookings = await _context.Bookings.Where(b => (b.ExpectedCheckIn.Date <= checkIn.Date || b.ActualCheckIn.Date <= checkIn.Date) && (b.ExpectedCheckOut.Date>= checkOut.Date || b.ActualCheckOut.Date >= checkOut.Date)).ToListAsync();
                DateTime forDate = checkIn;
                while (forDate <= checkOut)
                {
                    var ThisDaybooking = bookings.Where(b => forDate.Date >= b.ExpectedCheckIn.Date || forDate.Date >= b.ActualCheckIn.Date && (forDate.Date <= b.ActualCheckOut.Date || forDate.Date <= b.ExpectedCheckOut.Date)).ToList();
                    var json = JsonSerializer.Serialize(rooms);
                    var roomsAvilibilityForThisDay = new RoomsAvilibilityVM()
                    {
                        BookingDate = forDate,
                        Rooms = JsonSerializer.Deserialize<List<Room>>(json)
                    };
                    ThisDaybooking.Where(b => b.ActualCheckIn == forDate);
                    roomsAvilibilityForThisDay.Rooms.ForEach(r =>
                    {
                        if (ThisDaybooking.Any(b => b.RoomId == r.RoomNumber))
                            r.IsAvailable = false;
                    });
                    roomsAvilibility.Add(roomsAvilibilityForThisDay);
                    forDate = forDate.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                var data = ex.Message;
            }
            return roomsAvilibility;
        }
    }

}

