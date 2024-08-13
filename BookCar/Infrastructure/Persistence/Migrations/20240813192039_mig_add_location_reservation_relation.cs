using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_location_reservation_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationID = table.Column<int>(type: "int", nullable: true),
                    DropOffLocationID = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DriverLicenseYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservations_locations_DropOffLocationID",
                        column: x => x.DropOffLocationID,
                        principalTable: "locations",
                        principalColumn: "LocationID");
                    table.ForeignKey(
                        name: "FK_reservations_locations_PickUpLocationID",
                        column: x => x.PickUpLocationID,
                        principalTable: "locations",
                        principalColumn: "LocationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_DropOffLocationID",
                table: "reservations",
                column: "DropOffLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_PickUpLocationID",
                table: "reservations",
                column: "PickUpLocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
