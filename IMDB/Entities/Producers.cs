namespace IMDB.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Producers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }

    }
}
