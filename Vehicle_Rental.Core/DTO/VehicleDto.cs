using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental.Core.DTO
{
    public class VehicleDto
    {
        // Unique ID of the car
        public int CarId { get; set; }

        // Car brand (e.g., Toyota)
        [Required(ErrorMessage = "Brand is required")]                // Cannot be empty
        [MaxLength(50, ErrorMessage = "Brand cannot exceed 50 characters")] // Limits text length
        public string Brand { get; set; }

        // Car model (e.g., Corolla)
        [Required(ErrorMessage = "Model is required")]                 // Cannot be empty
        [MaxLength(50, ErrorMessage = "Model cannot exceed 50 characters")]
        public string Model { get; set; }

        // Manufacture year of the car
        [Required(ErrorMessage = "Year is required")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100")] // Valid year range
        public int Year { get; set; }

        // Color of the car
        [Required(ErrorMessage = "Color is required")]
        [MaxLength(20, ErrorMessage = "Color cannot exceed 20 characters")]
        public string Color { get; set; }

        // Daily rental price of the car
        [Required(ErrorMessage = "DailyRate is required")]
        [Range(0, int.MaxValue, ErrorMessage = "DailyRate must be positive")] // Must be >= 0
        public int DailyRate { get; set; }

        // Optional image URL of the car
        [MaxLength(250, ErrorMessage = "CarImage URL cannot exceed 250 characters")]
        public string CarImage { get; set; }

        // Registration number (unique identifier for the vehicle)
        [Required(ErrorMessage = "Registration number is required")]
        [MaxLength(20, ErrorMessage = "Registration number cannot exceed 20 characters")]
        public string RegNo { get; set; }
    }
}
