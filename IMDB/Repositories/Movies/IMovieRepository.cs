namespace IMDB.Repositories
{
    using IMDB.DTOs;
    using IMDB.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IMovieRepository
    {
        public IEnumerable<MovieDTO> GetAllMovies();

        public Task<Producers> GetProducer(string producerName);

        Task<Movies> GetMovieByName(string movieName);
        public Task InsertMovie(MovieDTO movieDTO);

        public Task UpdateMovie(int id, MovieDTO movieDTO);

        public Task<Movies> FindAsync(int id);

        public Task<Actors> GetActor(string actorName);


    }
}
