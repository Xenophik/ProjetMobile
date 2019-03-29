using Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {

        private readonly ICarRepository CarRepository;

        public CarController(ICarRepository carRepository)
        {
            CarRepository = carRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(CarRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Car GetCar(string id)
        {
            Car Car = CarRepository.Get(id);
            return Car;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Car Car)
        {
            try
            {
                if (Car == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                CarRepository.Add(Car);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(Car);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Car Car)
        {
            try
            {
                if (Car == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                CarRepository.Update(Car);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            CarRepository.Remove(id);
        }
    }
}
