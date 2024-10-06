using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class newmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Rooms_RoomNumber",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Bookings_BookingId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Halls_BookingId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Guests_RoomNumber",
                table: "Guests");

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "HallNumber",
                keyValue: "H1");

            migrationBuilder.DeleteData(
                table: "Halls",
                keyColumn: "HallNumber",
                keyValue: "H2");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "HallIds",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "BookingId", "Rent" },
                values: new object[,]
                {
                    { "H1", null, 22000 },
                    { "H2", null, 22000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "H1");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "H2");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Halls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Guests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HallIds",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "HallNumber", "BookingId", "Rent" },
                values: new object[,]
                {
                    { "H1", null, 25000 },
                    { "H2", null, 25000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Halls_BookingId",
                table: "Halls",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomNumber",
                table: "Guests",
                column: "RoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Rooms_RoomNumber",
                table: "Guests",
                column: "RoomNumber",
                principalTable: "Rooms",
                principalColumn: "RoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Bookings_BookingId",
                table: "Halls",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
