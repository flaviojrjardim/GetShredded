using System.ComponentModel.DataAnnotations;

namespace GetShredded.Models
{
    public class Exercise
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public int Set { get; set; }
        [Required]
        public int Rep { get; set; }
    }
}