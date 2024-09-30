using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rent",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Halls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rent",
                table: "Halls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HallIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvanceAmt = table.Column<int>(type: "int", nullable: false),
                    RemainingAmt = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "HallNumber",
                keyValue: "H1",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 25000 });

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "HallNumber",
                keyValue: "H2",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 25000 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "101",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "102",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "103",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "104",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "105",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "106",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "107",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "108",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "109",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomNumber",
                keyValue: "110",
                columns: new[] { "BookingId", "Rent" },
                values: new object[] { null, 1800 });

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookingId",
                table: "Room",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_BookingId",
                table: "Halls",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingId",
                table: "Guests",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Bookings_BookingId",
                table: "Halls",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Bookings_BookingId",
                table: "Room",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Bookings_BookingId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Bookings_BookingId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Room_BookingId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Halls_BookingId",
                table: "Halls");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Halls");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Guests");
        }
    }
}
