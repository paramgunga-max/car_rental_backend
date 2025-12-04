using AutoMapper;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental.Core.Models;
using Vehicle_Rental.Infrastructure.Repositories;

namespace Vehicle_Rental_Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer == null ? null : _mapper.Map<CustomerDto>(customer);
        }

        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _repository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            customer.CustomerId = customerDto.CustomerId;
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
