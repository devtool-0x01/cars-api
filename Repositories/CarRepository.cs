using System.Collections.Generic;
using System.Linq;
using dotnet5api.Data;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{

  public class CarRepository : ICarRepository
  {
    private readonly HyperdriveDbContext dbContext;

    public CarRepository(HyperdriveDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public IEnumerable<Car> GetByManufacturerId(int manId)
    {
      return dbContext.Cars.Where(x => x.ManufacturerId == manId);
    }

    IEnumerable<Car> IRepository<Car>.GetAll()
    {
      return dbContext.Cars;
    }

    Car IRepository<Car>.GetById(int id)
    {
      return dbContext.Cars.SingleOrDefault(x => x.Id == id);
    }
  }
}