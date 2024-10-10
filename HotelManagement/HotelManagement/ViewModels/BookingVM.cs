using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HotelManagement.Models;

namespace HotelManagement.ViewModels
{
    public class BookingVM
    {
        public int Id { get; set; }
        public Room? Room { get; set; }
        public int AdvanceAmt { get; set; }
        public int RemainingAmt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
