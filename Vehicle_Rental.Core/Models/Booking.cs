using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicle_Rental.Core.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookingID { get; set; }

        [Required, MaxLength(100)]
        public string CustomerName { get; set; }

        [Required, MaxLength(50)]
        public string CustomerCity { get; set; }

        [MaxLength(20)]
        public string MobilePhone { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int CarId { get; set; }   // Foreign Key to Vehicle

        [Required]
        public DateTime BookingDate { get; set; }

        public int? Discount { get; set; }

        [ForeignKey("CarId")]
        public Vehicle Vehicle { get; set; }
    }
}
