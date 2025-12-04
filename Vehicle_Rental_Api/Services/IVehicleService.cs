using Vehicle_Rental.Core.DTO;

namespace Vehicle_Rental_Api.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync();
        Task<VehicleDto> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(VehicleDto vehicleDto);
        Task UpdateVehicleAsync(VehicleDto vehicleDto);
        Task DeleteVehicleAsync(int id);
    }
}
