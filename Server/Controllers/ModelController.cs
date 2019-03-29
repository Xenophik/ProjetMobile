using Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class ModelController : Controller
    {

        private readonly IModelRepository ModelRepository;

        public ModelController(IModelRepository modelRepository)
        {
            ModelRepository = modelRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(ModelRepository.GetAll());
        }

        [HttpGet("{id}")]
        public Model GetModel(string id)
        {
            Model Model = ModelRepository.Get(id);
            return Model;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Model Model)
        {
            try
            {
                if (Model == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }

                ModelRepository.Add(Model);

            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(Model);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Model Model)
        {
            try
            {
                if (Model == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                ModelRepository.Update(Model);
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
            ModelRepository.Remove(id);
        }
    }
}
