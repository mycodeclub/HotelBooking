using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBookingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomIds",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "UniqueId");

            migrationBuilder.AddColumn<int>(
                name: "BookingUniqueId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingUniqueId",
                table: "Guests",
                column: "BookingUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_BookingUniqueId",
                table: "Guests",
                column: "BookingUniqueId",
                principalTable: "Bookings",
                principalColumn: "UniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingUniqueId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_BookingUniqueId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingUniqueId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UniqueId",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomIds",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "101",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "102",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "103",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "104",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "105",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "106",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "107",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "108",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "109",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "110",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "H1",
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomNumber",
                keyValue: "H2",
                column: "BookingId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
