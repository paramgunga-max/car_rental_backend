using AutoMapper;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental.Core.Models;
using Vehicle_Rental.Core.Factories;
using Vehicle_Rental.Infrastructure.Repositories;

namespace Vehicle_Rental_Api.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;
        private readonly IMapper _mapper;
        private readonly IVehicleFactory _factory;

        public VehicleService(IVehicleRepository repository, IMapper mapper, IVehicleFactory factory)
        {
            _repository = repository;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VehicleDto>>(vehicles);
        }

        public async Task<VehicleDto> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _repository.GetByIdAsync(id);
            return vehicle == null ? null : _mapper.Map<VehicleDto>(vehicle);
        }

        public async Task AddVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = _factory.CreateVehicle(vehicleDto);
            await _repository.AddAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(VehicleDto vehicleDto)
        {
            var vehicle = _factory.CreateVehicle(vehicleDto);
            vehicle.CarId = vehicleDto.CarId; // keep ID

            await _repository.UpdateAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
