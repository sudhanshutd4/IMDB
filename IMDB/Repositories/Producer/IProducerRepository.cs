namespace IMDB.Repositories
{
    using IMDB.DTOs;
    using IMDB.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IProducerRepository
    {
        Task InsertProducer(ProducerDTO producer);
        Task<Producers> GetProducerByName(string producerName);

    }
}
