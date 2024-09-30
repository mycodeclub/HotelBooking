using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class reDesignBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "GuestIds",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "GuestsNum",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RoomsRoomNumber",
                table: "Guests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomsRoomNumber",
                table: "Guests",
                column: "RoomsRoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Room_RoomsRoomNumber",
                table: "Guests",
                column: "RoomsRoomNumber",
                principalTable: "Room",
                principalColumn: "RoomNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Room_RoomsRoomNumber",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_RoomsRoomNumber",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RoomsRoomNumber",
                table: "Guests");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuestIds",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GuestsNum",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
