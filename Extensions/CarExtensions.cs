
using dotnet5api.Dtos;
using dotnet5api.Models;

namespace dotnet5api.Extensions
{
    public static class CarExtensions
    {
        public static CarDto ToDto(this Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Name = car.Name,
                Description = car.Description,
                LaunchYear = car.LaunchYear,
                Manufacturer = $"/manufacturers/{car.ManufacturerId}"
            };
        }
    }
}