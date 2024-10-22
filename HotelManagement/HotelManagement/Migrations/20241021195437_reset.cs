using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GorvnIdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GorvnIdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActualCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingAmt = table.Column<int>(type: "int", nullable: false),
                    BalanceAmt = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovnId = table.Column<int>(type: "int", nullable: true),
                    GovnIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovIdFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingUniqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_Bookings_BookingUniqueId",
                        column: x => x.BookingUniqueId,
                        principalTable: "Bookings",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Guests_GorvnIdTypes_GovnId",
                        column: x => x.GovnId,
                        principalTable: "GorvnIdTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GorvnIdTypes",
                columns: new[] { "Id", "IdType" },
                values: new object[,]
                {
                    { 1, "Pan" },
                    { 2, "Aadhar" },
                    { 3, "Voter" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomNumber", "Rent" },
                values: new object[,]
                {
                    { "101", 1800 },
                    { "102", 1800 },
                    { "103", 1800 },
                    { "104", 1800 },
                    { "105", 1800 },
                    { "106", 1800 },
                    { "107", 1800 },
                    { "108", 1800 },
                    { "109", 1800 },
                    { "110", 1800 },
                    { "H1", 22000 },
                    { "H2", 22000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_BookingUniqueId",
                table: "Guests",
                column: "BookingUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GovnId",
                table: "Guests",
                column: "GovnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "GorvnIdTypes");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
