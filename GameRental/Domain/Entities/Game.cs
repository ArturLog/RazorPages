using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Game
    {
        [Key] 
        public int Id { get; set; }
        [MaxLength(100)] 
        public string? Title { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public ICollection<Genre>? Genres { get; set; } = [];
        public ICollection<GameOffer>? Offers { get; set; } = [];
        public ICollection<GameLeased>? Leases { get; set; } = [];
    }
}
