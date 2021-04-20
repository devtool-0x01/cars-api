using System.Collections.Generic;
using System.Linq;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{

  public class InMemoryCarRepository : ICarRepository
  {
    private static List<Car> Cars = new List<Car> {
          new() {Id = 1, Name = "Chiron", Description = "first 300+ mile an hour car", LaunchYear = 2019, ManufacturerId = 1},
          new() {Id = 2, Name = "Veyron", Description = "Original bugatti hypercar", LaunchYear = 2015, ManufacturerId = 1},
          new() {Id = 3, Name = "Agera", Description = "Beast of a hypercar", LaunchYear = 2016, ManufacturerId = 2},
          new() {Id = 4, Name = "Huyra", Description = "Hypercar simplicity", LaunchYear = 2016, ManufacturerId = 3},
          new() {Id = 5, Name = "Veneno", Description = "Hypercar exotica", LaunchYear = 2016, ManufacturerId = 4},
          new() {Id = 6, Name = "Sesto Elemento", Description = "Mad hypercar beauty", LaunchYear = 2016, ManufacturerId = 4},
          new() {Id = 7, Name = "C Two", Description = "All electric hypercar beauty", LaunchYear = 2016, ManufacturerId = 5},
          new() {Id = 8, Name = "Regera", Description = "A family hypercar!", LaunchYear = 2019, ManufacturerId = 2},
          new() {Id = 9, Name = "Jesko", Description = "Another beast of a hypercar", LaunchYear = 2020, ManufacturerId = 2},
          };

    public IEnumerable<Car> GetByManufacturerId(int manId)
    {
      return Cars.Where(x => x.ManufacturerId == manId);
    }

    IEnumerable<Car> IRepository<Car>.GetAll()
    {
      return Cars;
    }

    Car IRepository<Car>.GetById(int id)
    {
      return Cars.SingleOrDefault(x => x.Id == id);
    }
  }
}