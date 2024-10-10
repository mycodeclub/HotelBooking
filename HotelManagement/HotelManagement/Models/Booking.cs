﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Booking
    {
        [Key]
        public int UniqueId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string? RoomId { get; set; } = string.Empty;
        [ForeignKey("RoomId")]
        public Room? Room { get; set; }

        public List<Guest>? Guests { get; set; }

        public int AdvanceAmt { get; set; }
        public int RemainingAmt { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        [NotMapped]
        public int NumberOfGuests { get { return Guests == null ? 0 : Guests.Count; } }
        [NotMapped]
        public List<Room>? Rooms { get; set; }

    }
}
