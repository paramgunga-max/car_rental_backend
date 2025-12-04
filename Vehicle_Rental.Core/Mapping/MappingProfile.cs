using AutoMapper;
using Vehicle_Rental.Core.DTO;
using Vehicle_Rental.Core.Models;

namespace Vehicle_Rental.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Booking mappings
            CreateMap<Booking, BookingDto>().ReverseMap()
                .ForMember(dest => dest.BookingID, opt => opt.Ignore()); // Ignore ID when adding

            // Vehicle mappings
            CreateMap<Vehicle, VehicleDto>().ReverseMap()
                .ForMember(dest => dest.CarId, opt => opt.Ignore()); // Ignore ID when adding

            // Map CustomerDto -> Customer and vice versa
            CreateMap<CustomerDto, Customer>().ReverseMap();

        }
    }
}
