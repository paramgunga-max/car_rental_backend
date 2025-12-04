using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental.Core.Models
{
    public class Vehicle
    {
        [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int DailyRate { get; set; }
        public string CarImage { get; set; }
        public string RegNo { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
