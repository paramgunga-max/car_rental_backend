using Vehicle_Rental.Core.DTO;

namespace Vehicle_Rental_Api.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerDto customerDto);
        Task UpdateCustomerAsync(CustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
