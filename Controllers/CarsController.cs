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
  public class CarsController : ControllerBase
  {

    private readonly ILogger<CarsController> _logger;
    private readonly ICarRepository _carRepo;
    private readonly ICarAttributesRepository _carAttributesRepository;

    public CarsController(ILogger<CarsController> logger, ICarRepository carRepo, ICarAttributesRepository carAttributesRepository)
    {
      _logger = logger;
      _carRepo = carRepo;
      _carAttributesRepository = carAttributesRepository;
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

    [HttpGet("{carId}/attributes/")]
    public async Task<ActionResult<IEnumerable<CarAttribute>>> CarAttributes(int carId)
    {
      var attrs = _carAttributesRepository.GetAttributesForCar(carId);
      var res = await Task.FromResult(attrs);
      return Ok(res);
    }

  }
}
