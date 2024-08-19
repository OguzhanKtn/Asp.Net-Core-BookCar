using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class reservation_pricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricingID",
                table: "reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_PricingID",
                table: "reservations",
                column: "PricingID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_pricings_PricingID",
                table: "reservations",
                column: "PricingID",
                principalTable: "pricings",
                principalColumn: "PricingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_pricings_PricingID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_PricingID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "PricingID",
                table: "reservations");
        }
    }
}
