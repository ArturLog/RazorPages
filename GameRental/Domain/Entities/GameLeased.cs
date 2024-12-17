using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class GameLeased
    {
        [Key] 
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateFrom { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateTo { get; set; }
        [Range(1, 1000)]
        public double? Price { get; set; }
        public bool? Active { get; set; }
        public int? GameId { get; set; }
        [ForeignKey("GameId")]
        public Game? Game { get; set; }
        public int? GameOfferId { get; set; }
        [ForeignKey("UserId")]
        public GameOffer? GameOffer { get; set; }
        public string? RenterId { get; set; }
        [ForeignKey("RenterId")]
        public ApplicationUser? Renter { get; set; }
    }
}
