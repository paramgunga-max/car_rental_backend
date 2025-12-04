using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental.Core.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50)]
        public string City { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
