using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
         {
             cfg.CreateMap<User, UserDto>();
             cfg.CreateMap<Driver, DriverDto>();
             
                //przy mapowaniu, gdzie jakies pole nie nazywa sie tak samo!
                //cfg.CreateMap<Driver, DriverDto>().
                //ForMember(x=> x.MyVehicle, m=>m.MapFrom(p=>p.Vehicle));
         })
            .CreateMapper();

    }
}