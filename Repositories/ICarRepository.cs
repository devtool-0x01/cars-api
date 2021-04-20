using System.Collections.Generic;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{
  public interface ICarRepository : IRepository<Car>
  {
    IEnumerable<Car> GetByManufacturerId(int manId);

  }

}
