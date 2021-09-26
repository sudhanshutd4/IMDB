using IMDB.DTOs;
using IMDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Repositories
{
    public interface IActorRepository
    {
        Task InsertActor(ActorDTO actor);

        Task<Actors> GetActorByName(string actorName);
    }
}
