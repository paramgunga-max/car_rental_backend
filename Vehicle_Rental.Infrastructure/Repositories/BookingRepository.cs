using Microsoft.EntityFrameworkCore;
using Vehicle_Rental.Core.Models;
using Vehicle_Rental.Infrastructure.Data;

namespace Vehicle_Rental.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync() => await _context.Bookings.ToListAsync();
        public async Task<Booking> GetByIdAsync(int id) => await _context.Bookings.FindAsync(id);
       
         
        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null) 
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
    }
}
