using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class updatedBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemainingAmt",
                table: "Bookings",
                newName: "BookingAmt");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Bookings",
                newName: "ExpectedCheckOut");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Bookings",
                newName: "ExpectedCheckIn");

            migrationBuilder.RenameColumn(
                name: "AdvanceAmt",
                table: "Bookings",
                newName: "BalanceAmt");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckIn",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckOut",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCheckIn",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ActualCheckOut",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ExpectedCheckOut",
                table: "Bookings",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "ExpectedCheckIn",
                table: "Bookings",
                newName: "CheckIn");

            migrationBuilder.RenameColumn(
                name: "BookingAmt",
                table: "Bookings",
                newName: "RemainingAmt");

            migrationBuilder.RenameColumn(
                name: "BalanceAmt",
                table: "Bookings",
                newName: "AdvanceAmt");
        }
    }
}
