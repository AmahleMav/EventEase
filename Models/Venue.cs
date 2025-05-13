using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }

        [Required]
        [StringLength(100)]
        public string VenueName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Range(1, 10000, ErrorMessage = "Capacity must be between 1 and 10,000.")]
        public int Capacity { get; set; }

        [Required]
        [Url]
        public string ImageURL { get; set; } = "https://via.placeholder.com/150";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

        
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
