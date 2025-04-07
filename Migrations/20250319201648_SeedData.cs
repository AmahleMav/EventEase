using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventEase.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueID", "Capacity", "ImageURL", "Location", "VenueName" },
                values: new object[,]
                {
                    { 1, 500, "https://example.com/grandhall.jpg", "Downtown", "Grand Hall" },
                    { 2, 200, "https://example.com/skyline.jpg", "City Center", "Skyline Rooftop" },
                    { 3, 350, "https://example.com/gardens.jpg", "Suburbs", "Sunset Gardens" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Description", "EventDate", "EventName", "ImageURL", "VenueID" },
                values: new object[,]
                {
                    { 1, "Annual technology summit bringing together industry leaders.", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference 2025", "https://example.com/techconf.jpg", 1 },
                    { 2, "A grand showcase of wedding services and products.", new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wedding Expo", "https://example.com/weddingexpo.jpg", 2 },
                    { 3, "An electrifying music festival with top artists.", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music Festival", "https://example.com/musicfest.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "BookingDate", "EventID", "VenueID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueID",
                keyValue: 3);
        }
    }
}
