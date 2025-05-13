using Microsoft.EntityFrameworkCore;
using EventEase.Models;
using System;

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueID)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventID)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueID)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Data for Venues
            modelBuilder.Entity<Venue>().HasData(
                new Venue { VenueID = 1, VenueName = "Botanical Gardens", Location = "Berea", Capacity = 150, ImageURL = "https://storageeventease.blob.core.windows.net/eventeaseimages/Durban%20Botanical%20Gardens.jpg" },
                new Venue { VenueID = 2, VenueName = "Durban ICC", Location = "Durban", Capacity = 2000, ImageURL = "https://storageeventease.blob.core.windows.net/eventeaseimages/Durban%20ICC.jpg" },
                new Venue { VenueID = 3, VenueName = "Playhouse Theater", Location = "Durban Central", Capacity = 1000, ImageURL = "https://storageeventease.blob.core.windows.net/eventeaseimages/Playhouse%20Theatre.jpeg" }
            );

            //Seed Data for Events
            modelBuilder.Entity<Event>().HasData(
                new Event { EventID = 1, EventName = "Garden of Love Wedding Ceremony", EventDate = new DateTime(2025, 6, 15), Description = "Surrounded by blooming flowers and a breathtaking scenery what better way to celebrate Love.", VenueID = 1, ImageURL = "https://storageeventease.blob.core.windows.net/eventeaseimages/Garden%20of%20love.jpg" },
                new Event { EventID = 2, EventName = "Durban IT Expo 2025", EventDate = new DateTime(2025, 7, 22), Description = "A look into the future of technology as we bring together tech enthusiasts under one roof.", VenueID = 2, ImageURL = "https://storageeventease.blob.core.windows.net/eventeaseimages/IT%20Expo%202025.png" },
                new Event { EventID = 3, EventName = "Sjava One Man Show - Live", EventDate = new DateTime(2025, 8, 10), Description = "Experience an unforgetable night with the King of South African Afropop/Soul Sjava, as he takes centre stage.", VenueID = 3, ImageURL = "https://storageeventease.blob.core.windows.net/eventeaseimages/Sjava%20-%20One%20Man%20Show.jpg" }
            );

            //Seed Data for Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking { BookingID = 1, EventID = 1, VenueID = 1, BookingDate = new DateTime(2025, 5, 1) },
                new Booking { BookingID = 2, EventID = 2, VenueID = 2, BookingDate = new DateTime(2025, 6, 15) },
                new Booking { BookingID = 3, EventID = 3, VenueID = 3, BookingDate = new DateTime(2025, 7, 5) }
            );
        }
    }
}
