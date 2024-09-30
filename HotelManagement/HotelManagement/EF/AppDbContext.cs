using HotelManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.EF
{
    //    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
              new Room() { RoomNumber = "101", Rent = 1800 },
              new Room() { RoomNumber = "102", Rent = 1800 },
              new Room() { RoomNumber = "103", Rent = 1800 },
              new Room() { RoomNumber = "104", Rent = 1800 },
              new Room() { RoomNumber = "105", Rent = 1800 },
              new Room() { RoomNumber = "106", Rent = 1800 },
              new Room() { RoomNumber = "107", Rent = 1800 },
              new Room() { RoomNumber = "108", Rent = 1800 },
              new Room() { RoomNumber = "109", Rent = 1800 },
              new Room() { RoomNumber = "110", Rent = 1800 }
               );

            modelBuilder.Entity<Hall>().HasData(
                new Hall() { HallNumber = "H1", Rent = 25000 },
                new Hall() { HallNumber = "H2", Rent = 25000 }

                );
            modelBuilder.Entity<GorvnIdType>().HasData(
               new GorvnIdType() { IdType = "Pan", Id = 1 },
               new GorvnIdType() { IdType = "Aadhar", Id = 2 },
               new GorvnIdType() { IdType = "Voter", Id = 3 },
               new GorvnIdType() { IdType = "Other", Id = 4 }

               );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }









        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<GorvnIdType> GorvnIdTypes { get; set; }

    }
}
