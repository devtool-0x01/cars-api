
using System.Collections.Generic;

namespace dotnet5api.Repositories
{
  public interface IRepository<T>
  {
    IEnumerable<T> GetAll();
    T GetById(int id);

  }
}