
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet5api.Models
{
  public class CarAttribute
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public int CarId { get; set; }

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; }
  }
}