
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Game>? Games { get; set; }
    }
}
