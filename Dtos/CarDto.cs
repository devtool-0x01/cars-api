namespace dotnet5api.Dtos
{
    public record CarDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int LaunchYear { get; set; }
        public string Manufacturer { get; init; }
    }
}