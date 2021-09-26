namespace IMDB.Controllers
{
    using IMDB.DTOs;
    using IMDB.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IEnumerable<MovieDTO> GetMovies()
        {            
            return _movieRepository.GetAllMovies();           
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody]MovieDTO movieDTO)
        {
            try
            {
                if (movieDTO == null)
                {
                    return BadRequest();
                }                    

                if (string.IsNullOrEmpty(movieDTO.Name))
                {
                    return BadRequest("Movie name cannot be null or empty");
                }

                var movie = await _movieRepository.GetMovieByName(movieDTO.Name);
                if(movie != null)
                {
                    return BadRequest($"Movie {movieDTO.Name} already exists");
                }

                var producer = await _movieRepository.GetProducer(movieDTO.ProducerName);
                if (producer == null)
                {
                    return BadRequest($"Producer {movieDTO.ProducerName} does not exists,kindly add one");
                }
                                                   

                if(movieDTO.ActorsNames == null || movieDTO.ActorsNames.Count < 1)
                {
                    return BadRequest("Actors list cannot be null or empty");
                }

                foreach (var item in movieDTO.ActorsNames)
                {
                    var actor = await _movieRepository.GetActor(item);
                    if (actor == null)
                    {
                        return BadRequest($"Actor {item} does not exits,Kindly add one");
                    }

                }

                await _movieRepository.InsertMovie(movieDTO);                
                return Ok("Movie added successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while inserting Movie Data in DataBase");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> EditMovie(int id,[FromBody] MovieDTO movieDTO)
        {
            try
            {
                var movie = await _movieRepository.FindAsync(id);
                if(movie == null)
                {
                    return NotFound();
                }

                if(movieDTO == null)
                {
                    return BadRequest();
                }

                if (string.IsNullOrEmpty(movieDTO.Name))
                {
                    return BadRequest("Movie name cannot be null or empty");
                }

                var producer = await _movieRepository.GetProducer(movieDTO.ProducerName);
                if(producer == null)
                {
                    return NotFound($"Producer {movieDTO.ProducerName} does not exists,Kindly add one");
                }

                if (movieDTO.ActorsNames == null || movieDTO.ActorsNames.Count < 1)
                {
                    return BadRequest("Actors list cannot be null or empty");
                }

                foreach (var item in movieDTO.ActorsNames)
                {
                    var actor = await _movieRepository.GetActor(item);
                    if(actor == null)
                    {
                        return BadRequest($"Actor {item} does not exits,Kindly add one");
                    }
                        
                }

                await _movieRepository.UpdateMovie(id, movieDTO);
                return Ok("Movie edited successfully");
            }            
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Exception while editing a movie:{ex}");
            }
        }
    }

}
