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
  public class ManufacturersController : ControllerBase
  {

    private readonly ILogger<ManufacturersController> _logger;
    private readonly IManufacturerRepository manRepo;
    private readonly ICarRepository carRepo;

    public ManufacturersController(ILogger<ManufacturersController> logger,
    IManufacturerRepository manRepo
    , ICarRepository carRepo)
    {
      _logger = logger;
      this.manRepo = manRepo;
      this.carRepo = carRepo;
    }

    [HttpGet]
    [ResponseCache(Duration = 60)]
    public async Task<IEnumerable<ManufacturerDto>> Get()
    {
      var list = this.manRepo.GetAll();
      // var cars = carRepo.GetAll();
      var manus = list
          .Select(m => m.ToDto(
            carRepo.GetByManufacturerId(m.Id)
            // cars.Where(c => c.ManufacturerId == x.Id)
            .Select(car => car.ToDto()))
      ).ToList();
      return await Task.FromResult(manus);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ManufacturerDto>> GetManufacturer(int id)
    {
      var man = this.manRepo.GetById(id);
      if (man is null)
      {
        return NotFound();
      }
      var cars = carRepo.GetByManufacturerId(man.Id).Select(x => x.ToDto());
      var result = await Task.FromResult(man.ToDto(cars));
      return Ok(result);
    }

  }
}
