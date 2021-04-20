
using System.Collections.Generic;

namespace dotnet5api.Models
{
  public class Manufacturer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
  }
}