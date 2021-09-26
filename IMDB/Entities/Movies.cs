namespace IMDB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieID { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public Producers Producer { get; set; }

    }
}
