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
    public class ProducerRepository : IProducerRepository
    {
        private readonly MovieDBContext _movieDBContext;

        public ProducerRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
       
        public async Task InsertProducer(ProducerDTO producerdto)
        {
            Producers producer = new Producers();
            producer.Name = producerdto.Name.ToLower();
            producer.DateOfBirth = producerdto.DateOfBirth;
            producer.Description = producerdto.Description;
            producer.Company = producerdto.Company;
            producer.Gender = producerdto.Gender;

            var result = await _movieDBContext.AddAsync(producer);
            await _movieDBContext.SaveChangesAsync();
                        
        }

        public async Task<Producers> GetProducerByName(string producerName)
        {
            return await _movieDBContext.producers.FirstOrDefaultAsync(x => x.Name.ToLower() == producerName.ToLower());
        }
        
    }
}
