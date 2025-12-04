using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental.Core.Models;
using Vehicle_Rental.Infrastructure.Repositories;

namespace Vehicle_Rental_Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _repository.GetByIdAsync(id);
            return booking == null ? null : _mapper.Map<BookingDto>(booking);
        }

        public async Task AddBookingAsync(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            await _repository.AddAsync(booking);
        }

        public async Task UpdateBookingAsync(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            booking.BookingID = bookingDto.BookingID; // Ensure ID is preserved for update
            await _repository.UpdateAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
