using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.DTOs
{
    public class MovieDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string ProducerName { get; set; }
        public List<string> ActorsNames {get;set;}
    }
}
