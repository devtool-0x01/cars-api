using System.Collections.Generic;
using System.Linq;
using dotnet5api.Data;
using dotnet5api.Models;

namespace dotnet5api.Repositories
{

  public class ManufacturerRepository : IManufacturerRepository
  {
    private readonly HyperdriveDbContext dbContext;

    public ManufacturerRepository(HyperdriveDbContext dbContext)
    {
      this.dbContext = dbContext;
    }
    public IEnumerable<Manufacturer> GetAll()
    {
      return dbContext.Manufacturers;
    }

    public Manufacturer GetById(int id)
    {
      return dbContext.Manufacturers.SingleOrDefault(x => x.Id == id);
    }
  }
}