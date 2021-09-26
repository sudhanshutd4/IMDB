namespace IMDB.Repositories
{
    using IMDB.Data;
    using IMDB.DTOs;
    using IMDB.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDBContext _movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public IEnumerable<MovieDTO> GetAllMovies()
        {

            var movies = (from m in _movieDBContext.movies
                          join map in _movieDBContext.movieactorMapping
                          on m.MovieID equals map.Movies.MovieID
                          join a in _movieDBContext.actors
                          on map.Actors.ActorID equals a.ActorID
                          join p in _movieDBContext.producers
                          on m.Producer.ProducerID equals p.ProducerID
                          select new {
                              MovieId = m.MovieID,
                              MovieName = m.Name,
                              MovieDescription = m.Description,
                              ProducerName = p.Name ,
                              m.DateOfRelease,
                              ActorName = a.Name, }
                          ).AsEnumerable();

            List<MovieDTO> moviesList = new List<MovieDTO>();
            foreach (var item in movies.GroupBy(x=>x.MovieId))
            {
                var movie = new MovieDTO
                {
                    Name = item.First().MovieName,
                    ProducerName = item.First().ProducerName,
                    DateOfRelease = item.First().DateOfRelease,
                    Description = item.First().MovieDescription,
                    ActorsNames = item.Select(y=>y.ActorName).ToList()

                };
                moviesList.Add(movie);
            }

            return moviesList;

        }
        public async Task InsertMovie(MovieDTO movieDTO)
        {
            var producer = await _movieDBContext.producers
                           .FirstOrDefaultAsync(x => x.Name.ToLower() == movieDTO.ProducerName.ToLower());

            Movies movies = new Movies
            {
                Name = movieDTO.Name.ToLower(),
                DateOfRelease = movieDTO.DateOfRelease,
                Description = movieDTO.Description,
                Producer = producer
            };

            await _movieDBContext.movies.AddAsync(movies);
            await _movieDBContext.SaveChangesAsync();

            var movie = await _movieDBContext.movies.FirstOrDefaultAsync(x => x.Name.ToLower() == movieDTO.Name.ToLower());
            
            foreach (var item in movieDTO.ActorsNames)
            {
                MoviesActorMapping moviesActorMapping = new MoviesActorMapping
                {
                    Movies = movie,
                    Actors = await _movieDBContext.actors.FirstOrDefaultAsync(x => x.Name.ToLower() == item.ToLower())
                };

                _movieDBContext.movieactorMapping.Add(moviesActorMapping);
            }
            await _movieDBContext.SaveChangesAsync();
        }
        public async Task UpdateMovie(int id,MovieDTO movieDTO)
        {
            var movie = await _movieDBContext.movies.FindAsync(id);
            movie.Name = movieDTO.Name;
            movie.Description = movieDTO.Description;
            movie.DateOfRelease = movieDTO.DateOfRelease;
            movie.Producer = await _movieDBContext.producers
                                .FirstOrDefaultAsync(x => x.Name.ToLower() == movieDTO.ProducerName.ToLower());

            _movieDBContext.movies.Update(movie);

            var mapping = _movieDBContext.movieactorMapping
                        .Where(x => x.Movies.MovieID == movie.MovieID);

            //Removing old Mapping
            foreach (var item in mapping)
            {
                _movieDBContext.movieactorMapping.Remove(item);
            }

            var ActorsList = await _movieDBContext.actors.ToListAsync();

            //Adding New/Updated Mapping
            foreach (var item in movieDTO.ActorsNames)
            {
                MoviesActorMapping moviesActorMapping = new MoviesActorMapping
                {
                    Movies = movie,                    
                    Actors = ActorsList.FirstOrDefault(x => x.Name == item)
                };

                _movieDBContext.movieactorMapping.Add(moviesActorMapping);
            }

            await _movieDBContext.SaveChangesAsync();            
        }
        
        public async Task<Movies> FindAsync(int id)
        {
            return await _movieDBContext.movies.FindAsync(id);
        }

        public async Task<Producers> GetProducer(string producerName)
        {
            return await _movieDBContext.producers.FirstOrDefaultAsync(x => x.Name.ToLower() == producerName.ToLower());
        }

        public async Task<Actors> GetActor(string actorName)
        {
            return await _movieDBContext.actors.FirstOrDefaultAsync(x => x.Name.ToLower() == actorName.ToLower());
        }

        public async Task<Movies> GetMovieByName(string movieName)
        {
            return await _movieDBContext.movies.FirstOrDefaultAsync(x => x.Name.ToLower() == movieName.ToLower());
        }

    }
}
