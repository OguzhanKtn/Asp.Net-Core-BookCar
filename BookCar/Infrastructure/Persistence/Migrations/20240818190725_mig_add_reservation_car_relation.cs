using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_reservation_car_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_reservations_CarID",
                table: "reservations",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_cars_CarID",
                table: "reservations",
                column: "CarID",
                principalTable: "cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_cars_CarID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_CarID",
                table: "reservations");
        }
    }
}
