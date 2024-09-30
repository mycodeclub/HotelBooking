using HotelManagement.ViewModels;

namespace HotelManagement.Service
{
    public interface IBookingService
    {
        public Task<List<RoomsAvilibilityVM>> GetAvailability(DateTime checkIn, DateTime checkOut);
    }
}
