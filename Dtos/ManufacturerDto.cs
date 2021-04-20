using System.Collections.Generic;

namespace dotnet5api.Dtos
{
    public record ManufacturerDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Country { get; init; }
        public ICollection<string> Cars { get; init; }
    }
}