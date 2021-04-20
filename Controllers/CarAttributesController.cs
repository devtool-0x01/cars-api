using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet5api.Dtos;
using dotnet5api.Extensions;
using dotnet5api.Models;
using dotnet5api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet5api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CarAttributesController : ControllerBase
  {

    private readonly ILogger<CarsController> _logger;
    private readonly ICarRepository _carRepo;

    public CarAttributesController(ILogger<CarsController> logger, ICarRepository carRepo)
    {
      _logger = logger;
      this._carRepo = carRepo;
    }

    /// <summary>Get cars list </summary>
    [HttpGet]
    [ResponseCache(Duration = 60)]
    public async Task<IEnumerable<CarDto>> Get()
    {
      var list = _carRepo.GetAll()
        .Select(x => x.ToDto());
      return await Task.FromResult(list);
    }

    /// <summary>Get a single car by id</summary>
    [HttpGet("{id}")]
    // [ResponseCache(Duration = 60, VaryByQueryKeys = new string[] { "id" })]
    public async Task<ActionResult<CarDto>> GetCar(int id)
    {
      var car = _carRepo.GetById(id);
      if (car is null)
      {
        return NotFound();
      }
      CarDto result = await Task.FromResult(car.ToDto());

      return Ok(result);
    }

  }
}
