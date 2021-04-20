
using System.Collections.Generic;
using System.Linq;
using dotnet5api.Dtos;
using dotnet5api.Models;

namespace dotnet5api.Extensions
{
    public static class ManufacturerExtensions
    {
        public static ManufacturerDto ToDto(this Manufacturer man, IEnumerable<CarDto> cars)
        {
            if (cars is null)
                cars = new CarDto[0];

            return new ManufacturerDto
            {
                Id = man.Id,
                Name = man.Name,
                Description = man.Description,
                Country = man.Country,
                Cars = cars.Select(c => $"/cars/{c.Id}").ToList()
            };
        }
    }
}