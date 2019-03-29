using Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {

        private readonly ITripRepository TripRepository;

        public TripController(ITripRepository tripRepository)
        {
            TripRepository = tripRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(TripRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Trip GetTrip(string id)
        {
            Trip Trip = TripRepository.Get(id);
            return Trip;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Trip Trip)
        {
            try
            {
                if (Trip == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                TripRepository.Add(Trip);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(Trip);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Trip Trip)
        {
            try
            {
                if (Trip == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                TripRepository.Update(Trip);
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
            TripRepository.Remove(id);
        }
    }
}
