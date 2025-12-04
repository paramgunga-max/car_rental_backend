using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental.Core.DTO
{
    public class BookingDto
    {
        public int BookingID { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [MaxLength(50, ErrorMessage = "Customer name cannot exceed 50 characters")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer city is required")]
        [MaxLength(50, ErrorMessage = "Customer city cannot exceed 50 characters")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "Mobile phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CarId is required")]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Booking date is required")]
        public DateTime BookingDate { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public int? Discount { get; set; }
    }
}
