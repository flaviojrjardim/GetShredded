using System.ComponentModel.DataAnnotations;

namespace GetShredded.Dtos
{
    public class UpdateExerciseDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public int Set { get; set; }
        [Required]
        public int Rep { get; set; }
    }
}