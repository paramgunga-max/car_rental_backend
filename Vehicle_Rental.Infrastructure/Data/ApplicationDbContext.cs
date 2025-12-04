using Microsoft.EntityFrameworkCore;
using Vehicle_Rental.Core.Models;

namespace Vehicle_Rental.Infrastructure.Data
{
    // The main EF Core database context that represents the connection to the database
    public class ApplicationDbContext : DbContext
    {
        // Constructor receives database configuration from Dependency Injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets = Tables in the Database
        public DbSet<Booking> Bookings { get; set; }     // Table for bookings
        public DbSet<Vehicle> Vehicles { get; set; }     // Table for vehicles
        public DbSet<Customer> Customers { get; set; }   // Table for customers

        // Configure entity relationships and validation rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --------------------------------------------------------------------
            // BOOKING ENTITY CONFIGURATION
            // --------------------------------------------------------------------
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(b => b.BookingID);  // Primary Key

                // Customer Name
                entity.Property(b => b.CustomerName)
                      .IsRequired()
                      .HasMaxLength(100);

                // Customer City
                entity.Property(b => b.CustomerCity)
                      .IsRequired()
                      .HasMaxLength(50);

                // Mobile phone number
                entity.Property(b => b.MobilePhone)
                      .HasMaxLength(20);

                // Email
                entity.Property(b => b.Email)
                      .HasMaxLength(50);

                // Booking date (required)
                entity.Property(b => b.BookingDate)
                      .IsRequired();

                // Discount field with decimal precision
                entity.Property(b => b.Discount)
                      .HasPrecision(10, 2);

                // Relationship: One Vehicle → Many Bookings
                entity.HasOne(b => b.Vehicle)          // Booking HAS one Vehicle
                      .WithMany(v => v.Bookings)       // Vehicle HAS many Bookings
                      .HasForeignKey(b => b.CarId)     // Foreign key
                      .OnDelete(DeleteBehavior.Cascade); // Delete bookings if vehicle is deleted
            });

            // --------------------------------------------------------------------
            // VEHICLE ENTITY CONFIGURATION
            // --------------------------------------------------------------------
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.CarId);  // Primary Key

                entity.Property(v => v.Brand)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.Model)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(v => v.Year)
                      .IsRequired();

                entity.Property(v => v.Color)
                      .HasMaxLength(30);

                entity.Property(v => v.DailyRate)
                      .HasPrecision(10, 2);

                entity.Property(v => v.CarImage)
                      .HasMaxLength(250);

                entity.Property(v => v.RegNo)
                      .IsRequired()
                      .HasMaxLength(20);

                // Ensure registration number is unique
                entity.HasIndex(v => v.RegNo)
                      .IsUnique();
            });

            // --------------------------------------------------------------------
            // CUSTOMER ENTITY CONFIGURATION
            // --------------------------------------------------------------------
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);  // Primary Key

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.City)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(c => c.Email)
                      .HasMaxLength(50);

                entity.Property(c => c.Phone)
                      .HasMaxLength(20);
            });
        }
    }
}
