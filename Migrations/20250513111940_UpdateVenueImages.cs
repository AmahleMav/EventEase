using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVenueImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 1,
                column: "ImageURL",
                value: "https://storageeventease.blob.core.windows.net/eventeaseimages/Durban%20Botanical%20Gardens.jpg");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 2,
                column: "ImageURL",
                value: "https://storageeventease.blob.core.windows.net/eventeaseimages/Durban%20ICC.jpg");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 3,
                column: "ImageURL",
                value: "https://storageeventease.blob.core.windows.net/eventeaseimages/Playhouse%20Theatre.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 1,
                column: "ImageURL",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 2,
                column: "ImageURL",
                value: "https://via.placeholder.com/150");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 3,
                column: "ImageURL",
                value: "https://via.placeholder.com/150");
        }
    }
}
