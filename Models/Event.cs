using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Venue")]
        public int VenueID { get; set; }
        public virtual Venue Venue { get; set; } 

        [Required]
        [Url]
        public string ImageURL { get; set; } = "https://via.placeholder.com/150";

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
