using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vehicle_Rental.Core.Factories;
using Vehicle_Rental.Core.Mapping;
using Vehicle_Rental.Infrastructure.Data;
using Vehicle_Rental.Infrastructure.Repositories;
using Vehicle_Rental_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddSingleton<IVehicleFactory, VehicleFactory>();


// DI for Repositories & Services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("AllowAngular");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
