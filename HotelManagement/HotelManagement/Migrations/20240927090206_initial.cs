using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                name: "Halls",
                columns: table => new
                {
                    HallNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.HallNumber);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovnId = table.Column<int>(type: "int", nullable: true),
                    GovnIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
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
                table: "Halls",
                column: "HallNumber",
                values: new object[]
                {
                    "H1",
                    "H2"
                });

            migrationBuilder.InsertData(
                table: "Room",
                column: "RoomNumber",
                values: new object[]
                {
                    "101",
                    "102",
                    "103",
                    "104",
                    "105",
                    "106",
                    "107",
                    "108",
                    "109",
                    "110"
                });

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
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "GorvnIdTypes");
        }
    }
}
