using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet5api.Models
{
  public class Car
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LaunchYear { get; set; }
    public int ManufacturerId { get; set; }

    [ForeignKey("ManufacturerId")]
    public virtual Manufacturer Manufacturer { get; set; }
    public ICollection<CarAttribute> Attributes { get; set; }
  }
}