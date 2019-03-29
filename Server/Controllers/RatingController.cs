using Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : Controller
    {

        private readonly IRatingRepository RatingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            RatingRepository = ratingRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(RatingRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Rating GetRating(string id)
        {
            Rating Rating = RatingRepository.Get(id);
            return Rating;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Rating Rating)
        {
            try
            {
                if (Rating == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                RatingRepository.Add(Rating);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(Rating);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Rating Rating)
        {
            try
            {
                if (Rating == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                RatingRepository.Update(Rating);
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
            RatingRepository.Remove(id);
        }
    }
}
