using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class reDesignname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Room_RoomsRoomNumber",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.RenameColumn(
                name: "RoomsRoomNumber",
                table: "Guests",
                newName: "RoomNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_RoomsRoomNumber",
                table: "Guests",
                newName: "IX_Guests_RoomNumber");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_Rooms_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "BookingId", "Rent" },
                values: new object[,]
                {
                    { "101", null, 1800 },
                    { "102", null, 1800 },
                    { "103", null, 1800 },
                    { "104", null, 1800 },
                    { "105", null, 1800 },
                    { "106", null, 1800 },
                    { "107", null, 1800 },
                    { "108", null, 1800 },
                    { "109", null, 1800 },
                    { "110", null, 1800 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Rooms_RoomNumber",
                table: "Guests",
                column: "RoomNumber",
                principalTable: "Rooms",
                principalColumn: "RoomNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Rooms_RoomNumber",
                table: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "Guests",
                newName: "RoomsRoomNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_RoomNumber",
                table: "Guests",
                newName: "IX_Guests_RoomsRoomNumber");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    Rent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomNumber);
                    table.ForeignKey(
                        name: "FK_Room_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomNumber", "BookingId", "Rent" },
                values: new object[,]
                {
                    { "101", null, 1800 },
                    { "102", null, 1800 },
                    { "103", null, 1800 },
                    { "104", null, 1800 },
                    { "105", null, 1800 },
                    { "106", null, 1800 },
                    { "107", null, 1800 },
                    { "108", null, 1800 },
                    { "109", null, 1800 },
                    { "110", null, 1800 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_BookingId",
                table: "Room",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Room_RoomsRoomNumber",
                table: "Guests",
                column: "RoomsRoomNumber",
                principalTable: "Room",
                principalColumn: "RoomNumber");
        }
    }
}
