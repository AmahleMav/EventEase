using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEase.Migrations
{
    /// <inheritdoc />
    public partial class AddEventsAndBookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Events_EventID1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Venues_VenueID1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_EventID1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_VenueID1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EventID1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "VenueID1",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventID1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VenueID1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EventID1",
                table: "Bookings",
                column: "EventID1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VenueID1",
                table: "Bookings",
                column: "VenueID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Events_EventID1",
                table: "Bookings",
                column: "EventID1",
                principalTable: "Events",
                principalColumn: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Venues_VenueID1",
                table: "Bookings",
                column: "VenueID1",
                principalTable: "Venues",
                principalColumn: "VenueID");
        }
    }
}
