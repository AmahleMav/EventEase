using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventEase.Data;
using EventEase.Models;
using System.Threading.Tasks;
using EventEase.ViewModels;

namespace EventEase.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchTerm)
        {
            var query = from b in _context.Bookings
                        join e in _context.Events on b.EventID equals e.EventID
                        join v in _context.Venues on b.VenueID equals v.VenueID
                        select new BookingViewModel
                        {
                            BookingID = b.BookingID,
                            EventName = e.EventName,
                            EventDate = e.EventDate,
                            VenueName = v.VenueName,
                            VenueLocation = v.Location,
                            BookingDate = b.BookingDate
                        };

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(b =>
                    b.BookingID.ToString().Contains(searchTerm) ||
                    b.EventName.Contains(searchTerm));
            }

            var bookings = await query.ToListAsync();
            return View(bookings);
        }

        public IActionResult Create()
        {
            ViewBag.Events = _context.Events.ToList();
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,EventID,VenueID,BookingDate")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                //Prevent double booking
                bool isDoubleBooked = await _context.Bookings.AnyAsync(b => b.EventID == booking.EventID && b.VenueID == booking.VenueID && b.BookingDate == booking.BookingDate);

                if (isDoubleBooked)
                {
                    ModelState.AddModelError("", "This venue is already booked for the selected event on this date.");
                    ViewBag.Events = _context.Events.ToList();
                    ViewBag.Venues = _context.Venues.ToList();
                    return View(booking);
                }

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Events = _context.Events.ToList();
            ViewBag.Venues = _context.Venues.ToList();
            return View(booking);
        }
    }
}
