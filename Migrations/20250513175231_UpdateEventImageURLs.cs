using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEventImageURLs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1,
                column: "ImageURL",
                value: "https://storageeventease.blob.core.windows.net/eventeaseimages/Garden%20of%20love.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 2,
                column: "ImageURL",
                value: "https://storageeventease.blob.core.windows.net/eventeaseimages/IT%20Expo%202025.png");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 3,
                column: "ImageURL",
                value: "https://storageeventease.blob.core.windows.net/eventeaseimages/Sjava%20-%20One%20Man%20Show.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1,
                column: "ImageURL",
                value: "https://example.com/techconf.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 2,
                column: "ImageURL",
                value: "https://example.com/weddingexpo.jpg");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 3,
                column: "ImageURL",
                value: "https://example.com/musicfest.jpg");
        }
    }
}
