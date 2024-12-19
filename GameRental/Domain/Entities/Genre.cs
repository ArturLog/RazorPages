
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Genre name is required.")]
        [MaxLength(100, ErrorMessage = "Genre name cannot exceed 100 characters.")]
        public string Name { get; set; }

        public ICollection<Game>? Games { get; set; }
    }
}
