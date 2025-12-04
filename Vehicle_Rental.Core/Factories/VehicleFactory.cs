using Vehicle_Rental.Core.DTO;
using Vehicle_Rental.Core.Models;

namespace Vehicle_Rental.Core.Factories
{
    // Factory class responsible for creating Vehicle objects from DTOs
    public class VehicleFactory : IVehicleFactory
    {
        // Creates and returns a Vehicle model object using values from VehicleDto
        public Vehicle CreateVehicle(VehicleDto dto)
        {
            // Map DTO properties to the Vehicle model
            return new Vehicle
            {
                CarId = dto.CarId,        // Unique ID
                Brand = dto.Brand,        // Car brand from DTO
                Model = dto.Model,        // Car model from DTO
                Year = dto.Year,          // Manufacturing year
                Color = dto.Color,        // Vehicle color
                DailyRate = dto.DailyRate,// Rental price per day
                CarImage = dto.CarImage,  // Optional image URL
                RegNo = dto.RegNo         // Registration number
            };
        }
    }
}
