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
    public class ActorRepository : IActorRepository
    {
        private readonly MovieDBContext _movieDBContext;

        public ActorRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public async Task InsertActor(ActorDTO actordto)
        {
            Actors actor = new Actors();
            actor.Name = actordto.Name.ToLower();
            actor.DateOfBirth = actordto.DateOfBirth;
            actor.Description = actordto.Description;
            actor.Gender = actordto.Gender;

            await _movieDBContext.AddAsync(actor);
            await _movieDBContext.SaveChangesAsync();
            
        }
        
        public async Task<Actors> GetActorByName(string actorName)
        {
            return await _movieDBContext.actors.FirstOrDefaultAsync(x => x.Name.ToLower() == actorName.ToLower());
        }
    }
}
