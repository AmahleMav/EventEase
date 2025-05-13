using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventEase.Data;
using EventEase.Models;
using System.Threading.Tasks;

namespace EventEase.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.Include(e => e.Venue).ToListAsync();
            return View(events);
        }

        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventName,EventDate,Description,VenueID,ImageURL")] Event eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Venues = _context.Venues.ToList(); 
            return View(eventModel);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel == null) return NotFound();
            ViewBag.Venues = _context.Venues.ToList();
            return View(eventModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,EventDate,Description,VenueID,ImageURL")] Event eventModel)
        {
            if (id != eventModel.EventID) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Events.Any(e => e.EventID == id)) return NotFound();
                    throw;
                }
            }
            ViewBag.Venues = _context.Venues.ToList(); 
            return View(eventModel);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var eventModel = await _context.Events.Include(e => e.Venue).FirstOrDefaultAsync(e => e.EventID == id);
            if (eventModel == null) return NotFound();
            return View(eventModel);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Events.Include(e => e.Bookings).FirstOrDefaultAsync(e => e.EventID == id);
            if (eventModel != null)
            {
                if (eventModel.Bookings.Count > 0)
                {
                    TempData["ErrorMessage"] = "Cannot delete this event as it has existing bookings.";
                    return RedirectToAction(nameof(Index));
                }

                _context.Events.Remove(eventModel);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));
        }
    }
}

