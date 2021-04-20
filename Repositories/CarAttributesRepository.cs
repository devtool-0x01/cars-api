using System.Collections.Generic;
using System.Linq;
using dotnet5api.Data;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{

  public class CarAttributesRepository : ICarAttributesRepository
  {
    private readonly HyperdriveDbContext dbContext;

    public CarAttributesRepository(HyperdriveDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public IEnumerable<CarAttribute> GetAll()
    {
      return new CarAttribute[0];
    }

    public IEnumerable<CarAttribute> GetAttributesForCar(int carId)
    {
      return dbContext.CarAttributes.Where(x => x.CarId == carId);
    }

    public CarAttribute GetById(int id)
    {
      return dbContext.CarAttributes.FirstOrDefault(x => x.Id == id);
    }

  }
}