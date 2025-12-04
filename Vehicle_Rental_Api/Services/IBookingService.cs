using Vehicle_Rental.Core.DTO;

namespace Vehicle_Rental_Api.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task AddBookingAsync(BookingDto bookingDto);
        Task UpdateBookingAsync(BookingDto bookingDto);
        Task DeleteBookingAsync(int id);
    }
}
