using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public int EventID { get; set; }

        [ForeignKey("EventID")]
        public virtual Event Event { get; set; }  

        [Required]
        public int VenueID { get; set; }

        [ForeignKey("VenueID")]
        public virtual Venue Venue { get; set; }  

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
    }
}
