using Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class BrandController : Controller
    {

        private readonly IBrandRepository BrandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            BrandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(BrandRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Brand GetBrand(string id)
        {
            Brand Brand = BrandRepository.Get(id);
            return Brand;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Brand Brand)
        {
            try
            {
                if (Brand == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                BrandRepository.Add(Brand);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(Brand);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Brand Brand)
        {
            try
            {
                if (Brand == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                BrandRepository.Update(Brand);
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
            BrandRepository.Remove(id);
        }
    }
}
