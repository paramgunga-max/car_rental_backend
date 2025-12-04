using Vehicle_Rental.Core.DTO;
using Vehicle_Rental.Core.Models;

namespace Vehicle_Rental.Core.Factories
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(VehicleDto dto);
    }
}
