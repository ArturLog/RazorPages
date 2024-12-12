using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GameOffer
    {
        public int Id { get; set; }
        [Range(1, 1000)]
        public double? Price { get; set; }
        [Range(1, 100)]
        public int? Amount { get; set; }
        public string? OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public ApplicationUser? Owner { get; set; }
        [Range(0.01, 1000000.00)]
        public int? GameId { get; set; }
        [ForeignKey("GameId")]
        public Game? Game { get; set; }
    }
}
