using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1,
                columns: new[] { "Description", "EventName" },
                values: new object[] { "Surrounded by blooming flowers and a breathtaking scenery what better way to celebrate Love.", "Garden of Love Wedding Ceremony" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 2,
                columns: new[] { "Description", "EventName" },
                values: new object[] { "A look into the future of technology as we bring together tech enthusiasts under one roof.", "Durban IT Expo 2025" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 3,
                columns: new[] { "Description", "EventName" },
                values: new object[] { "Experience an unforgetable night with the King of South African Afropop/Soul Sjava, as he takes centre stage.", "Sjava One Man Show - Live" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 1,
                columns: new[] { "Capacity", "ImageURL", "Location", "VenueName" },
                values: new object[] { 150, "https://via.placeholder.com/150", "Berea", "Botanical Gardens" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 2,
                columns: new[] { "Capacity", "ImageURL", "Location", "VenueName" },
                values: new object[] { 2000, "https://via.placeholder.com/150", "Durban", "Durban ICC" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 3,
                columns: new[] { "Capacity", "ImageURL", "Location", "VenueName" },
                values: new object[] { 1000, "https://via.placeholder.com/150", "Durban Central", "Playhouse Theater" });
        }
    }
}
