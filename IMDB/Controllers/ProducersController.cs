namespace IMDB.Controllers
{
    using IMDB.DTOs;
    using IMDB.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerRepository _producerRepository;

        public ProducersController(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }


        [HttpPost]
        public async Task<ActionResult> CreateProducer([FromBody] ProducerDTO producerdto)
        {
            try
            {
                if (producerdto == null)
                    return BadRequest();

                if(string.IsNullOrEmpty(producerdto.Name))
                {
                    return BadRequest("Producer name cannot be null or empty");
                }

                var producer = _producerRepository.GetProducerByName(producerdto.Name);
                if(producer!=null)
                {
                    return BadRequest($"Producer {producerdto.Name} already exists");
                }

                await _producerRepository.InsertProducer(producerdto);
                return Ok("Producer Created successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error occur while creating producer");
            }

        }

    }
}
