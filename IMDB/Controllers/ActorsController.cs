namespace IMDB.Controllers
{
    using IMDB.Data;
    using IMDB.DTOs;
    using IMDB.Entities;
    using IMDB.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;

        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }


        [HttpPost]
        public async Task<ActionResult> CreateActor([FromBody]ActorDTO actordto)
        {
            try
            {
                if (actordto == null)
                    return BadRequest();

                if(string.IsNullOrEmpty(actordto.Name))
                {
                    return BadRequest("Actor name cannot be null or empty");
                }

                var actor = await _actorRepository.GetActorByName(actordto.Name);
                if(actor != null)
                {
                    return BadRequest($"Actor {actordto.Name} already exists");
                }

                await _actorRepository.InsertActor(actordto);
                return Ok("Actor Created successfully");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new actor");
            }
             
        }
    }
}
