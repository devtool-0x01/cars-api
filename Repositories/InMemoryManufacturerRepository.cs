using System.Collections.Generic;
using System.Linq;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{

  public class InMemoryManufacturerRepository : IManufacturerRepository
  {
    public static List<Manufacturer> Manufacturers = new()
    {
      new() { Id = 1, Name = "Bugatti", Description = "Hypercar Royalty", Country = "France" },
      new() { Id = 2, Name = "Koenigsegg", Description = "Hypercar challenger", Country = "Sweden" },
      new() { Id = 3, Name = "Pagani", Description = "Hypercar contender", Country = "Unknown" },
      new() { Id = 4, Name = "Lamborghini", Description = "Hypercar contender", Country = "Italy" },
      new() { Id = 5, Name = "Rimac", Description = "Hypercar contender", Country = "Unknown" },
    };
    public IEnumerable<Manufacturer> GetAll()
    {
      return Manufacturers;
    }

    public Manufacturer GetById(int id)
    {
      return Manufacturers.SingleOrDefault(x => x.Id == id);
    }
  }
}