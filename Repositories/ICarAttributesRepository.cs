using System.Collections.Generic;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{
  public interface ICarAttributesRepository : IRepository<CarAttribute>
  {
    IEnumerable<CarAttribute> GetAttributesForCar(int carId);

  }

}
