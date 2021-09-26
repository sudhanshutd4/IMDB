using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.DTOs
{
    public class ProducerDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }
    }
}
